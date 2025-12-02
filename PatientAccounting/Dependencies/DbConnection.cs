using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Models;
using PatientsAcounting.Models;
using System.IO;

namespace PatientsAccounting.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
                DotNetEnv.Env.Load(envPath);

                var dbHost = DotNetEnv.Env.GetString("DB_HOST", "dbHost");
                var dbPort = DotNetEnv.Env.GetString("DB_PORT", "port");
                var dbName = DotNetEnv.Env.GetString("DB_NAME", "dbname");
                var dbUsername = DotNetEnv.Env.GetString("DB_USERNAME", "username");
                var dbPassword = DotNetEnv.Env.GetString("DB_PASSWORD", "password");

                var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUsername};Password={dbPassword}";

                optionsBuilder.UseNpgsql(connectionString);

                
            }
        }

        // задача табли через коллекцию сущностей DbSet
        public DbSet<Analysis> Analysis { get; set; }
        public DbSet<Blocks> Blocks { get; set; }
        public DbSet<Chapters> Chapters { get; set; }
        public DbSet<Diseas> Diseas { get; set; }
        public DbSet<DiseasTypes> DiseasTypes { get; set; }
        public DbSet<UsersCredentials> UsersCredentials { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Hospitals> Hospitals { get; set; }
        public DbSet<PatientCards> PatientCards { get; set; }
        public DbSet<UsersRole> UsersRoles { get; set; }
        public DbSet<EntryType> EntryTypes { get; set; }
        public DbSet<VisitTypes> VisitTypes { get; set; }
        public DbSet<PatientVisits> PatientVisits { get; set; }
        public DbSet<VisitDiagnoses> VisitDiagnoses { get; set; }
        public DbSet<DoctorsHospitals> DoctorsHospitals { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentPosition> DepartmentPositions { get; set; }

        public DbSet<DoctorPosition> DoctorPositions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // настройка названий таблиц
            modelBuilder.Entity<Analysis>().ToTable("analysis");
            modelBuilder.Entity<Blocks>().ToTable("blocks");
            modelBuilder.Entity<Chapters>().ToTable("chapters");
            modelBuilder.Entity<Diseas>().ToTable("diseas");
            modelBuilder.Entity<DiseasTypes>().ToTable("diseas_types");
            modelBuilder.Entity<UsersCredentials>().ToTable("users_credentials");
            modelBuilder.Entity<Patients>().ToTable("patients");
            modelBuilder.Entity<Doctors>().ToTable("doctors");
            modelBuilder.Entity<Hospitals>().ToTable("hospitals");
            modelBuilder.Entity<PatientCards>().ToTable("patient_cards");
            modelBuilder.Entity<UsersRole>().ToTable("users_role");
            modelBuilder.Entity<EntryType>().ToTable("entry_types");
            modelBuilder.Entity<VisitTypes>().ToTable("visit_types");
            modelBuilder.Entity<PatientVisits>().ToTable("patient_visits");
            modelBuilder.Entity<VisitDiagnoses>().ToTable("visit_diagnoses");
            modelBuilder.Entity<DoctorsHospitals>().ToTable("doctors_hospitals");
            modelBuilder.Entity<Department>().ToTable("department");
            modelBuilder.Entity<DoctorPosition>().ToTable("doctor_position");
            modelBuilder.Entity<Positions>().ToTable("positions");
            modelBuilder.Entity<DepartmentPosition>().ToTable("department_position");

            // настройка индексов, атрибутов и связей

            // таблица анализов пациентов
            modelBuilder.Entity<Analysis>(entity =>
            {
                entity.HasIndex(p => p.type);
            });

            // таблица подразделов внутри глав в МКБ-10
            modelBuilder.Entity<Blocks>(entity =>
            {
                entity.HasIndex(block => block.id_chapter);
                entity.HasIndex(block => block.code);

                entity.HasOne<Chapters>()
                    .WithMany()
                    .HasForeignKey(b => b.id_chapter)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // таблица типов заболеваний
            modelBuilder.Entity<DiseasTypes>(entity =>
            {
                entity.HasOne<Blocks>()
                .WithMany()
                .HasForeignKey(dt => dt.id_block)
                .OnDelete(DeleteBehavior.Restrict);
            });


            // таблица поликлиник
            modelBuilder.Entity<Hospitals>(entity =>
            {
                entity.HasIndex(hospital => hospital.name);
                entity.HasIndex(hospital => hospital.town);
                entity.HasIndex(hospital => hospital.street);
                entity.HasIndex(hospital => hospital.house);
            });


            // таблица медицинских карточек пациентов
            modelBuilder.Entity<PatientCards>(entity =>
            {
                entity.HasIndex(card => card.code);

                entity.HasOne<Hospitals>()
                .WithMany()
                .HasForeignKey(dt => dt.id_hospital)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Patients>()
                .WithMany()
                .HasForeignKey(dt => dt.id_patient)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // таблица пациентов
            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasIndex(patient => patient.surname);
                entity.HasIndex(patient => patient.name);
                entity.HasIndex(patient => patient.patronymic);
                entity.HasIndex(patient => patient.snils);
            });


            // таблица-справочник ролей пользователей
            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasIndex(role => role.role_name);
                entity.HasIndex(role => role.description);
            });


            // таблица учетных данных пользователей
            modelBuilder.Entity<UsersCredentials>(entity =>
            {
                entity.HasIndex(credential => credential.username).IsUnique();
                entity.HasIndex(credential => credential.password_hash);
                entity.HasIndex(credential => credential.salt);
                entity.HasIndex(credential => credential.active);
                entity.HasIndex(credential => credential.created_date);
                entity.HasIndex(credential => credential.last_login);

                entity.HasOne<UsersRole>()
                .WithMany()
                .HasForeignKey(dt => dt.id_users_role)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Patients>()
                .WithMany()
                .HasForeignKey(dt => dt.id_patient)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Doctors>()
                .WithMany()
                .HasForeignKey(dt => dt.id_doctor)
                .OnDelete(DeleteBehavior.Restrict);
            });


            // таблица верхнего уровня классификации МКБ-10 - главы
            modelBuilder.Entity<Chapters>(entity =>
            {
                entity.HasIndex(chapter => chapter.number);
                entity.HasIndex(chapter => chapter.code_range);
                entity.HasIndex(chapter => chapter.title);
            });


            // таблица болезней
            modelBuilder.Entity<Diseas>(entity =>
            {
                entity.HasIndex(diseas => diseas.code);
                entity.HasIndex(diseas => diseas.title);
                entity.HasOne<DiseasTypes>()
                    .WithMany()
                    .HasForeignKey(d => d.id_diseas_type)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            // таблица докторов
            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasIndex(doctor => doctor.surname);
                entity.HasIndex(doctor => doctor.name);
                entity.HasIndex(doctor => doctor.patronymic);
            });

            modelBuilder.Entity<EntryType>(entity =>
            {
                entity.HasIndex(entryType => entryType.title);
            });

            // таблица типы посещений
            modelBuilder.Entity<VisitTypes>(entity =>
            {
                entity.HasIndex(visitType => visitType.title);
            });


            // таблица посещений пациентов
            modelBuilder.Entity<PatientVisits>(entity =>
            {
                entity.HasIndex(visit => visit.adding_date);
                entity.HasOne<DoctorsHospitals>()
                    .WithMany()
                    .HasForeignKey(pv => pv.id_doctor_hospitals)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<VisitTypes>()
                    .WithMany()
                    .HasForeignKey(pv => pv.id_visit_type)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Analysis>()
                    .WithMany()
                    .HasForeignKey(pv => pv.id_analysis)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<EntryType>()
                    .WithMany()
                    .HasForeignKey(pv => pv.id_entry_type)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<PatientCards>()
                    .WithMany()
                    .HasForeignKey(pv => pv.id_card)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // таблица доктор - диагнозы посещений
            modelBuilder.Entity<VisitDiagnoses>(entity =>
            {
                entity.HasOne<PatientVisits>()
                    .WithMany()
                    .HasForeignKey(vd => vd.id_visit)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Diseas>()
                    .WithMany()
                    .HasForeignKey(vd => vd.id_diseas)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // связующая таблица доктор - поликлиника
            modelBuilder.Entity<DoctorsHospitals>(entity =>
            {
                entity.HasIndex(dh => dh.active);
                entity.HasOne<Doctors>()
                    .WithMany()
                    .HasForeignKey(dh => dh.id_doctor)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Hospitals>()
                    .WithMany()
                    .HasForeignKey(dh => dh.id_hospital)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // таблица расписания врача - под вопросом (дублирование же)    

            // таблица отделений
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(department => department.title);
            }
            );


            // таблица должностей
            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasIndex(position => position.title);
            });


            // таблица доктор - должность
            modelBuilder.Entity<DoctorPosition>(entity =>
            {
                entity.HasOne<Doctors>()
                .WithMany()
                .HasForeignKey(d => d.id_doctor)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Positions>()
                .WithMany()
                .HasForeignKey(p => p.id_position)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // таблица отдел - должность и доктор
            modelBuilder.Entity<DepartmentPosition>(entity =>
            {
                entity.HasOne<Department>()
                    .WithMany()
                    .HasForeignKey(d => d.id_department)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<DoctorPosition>()
                    .WithMany()
                    .HasForeignKey(p => p.id_position_doctor)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}