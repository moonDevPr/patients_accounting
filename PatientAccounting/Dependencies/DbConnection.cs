using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        public DbSet<HospitalDepartments> HospitalDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        internal DbSet<DoctorWorkingHours> DoctorWorkingHours { get; set; }
        internal DbSet<DepartmentPosition> DepartmentPositions { get; set; }
        internal DbSet<DoctorPosition> DoctorPositions { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<Analysis> Analysis { get; set; }
        public DbSet<Blocks> Blocks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Все ToTable прописываем:
            modelBuilder.Entity<Analysis>().ToTable("analysis");
            modelBuilder.Entity<Blocks>().ToTable("blocks");
            modelBuilder.Entity<Chapters>().ToTable("chapters");
            modelBuilder.Entity<Department>().ToTable("department");
            modelBuilder.Entity<DepartmentPosition>().ToTable("department_position");
            modelBuilder.Entity<Diseas>().ToTable("diseas");
            modelBuilder.Entity<DiseasTypes>().ToTable("diseas_types");
            modelBuilder.Entity<DoctorPosition>().ToTable("doctor_position");
            modelBuilder.Entity<Doctors>().ToTable("doctors");
            modelBuilder.Entity<DoctorWorkingHours>().ToTable("doctor_schedule");
            modelBuilder.Entity<EntryType>().ToTable("entry_types");
            modelBuilder.Entity<HospitalDepartments>().ToTable("hospital_departments");
            modelBuilder.Entity<Hospitals>().ToTable("hospitals");
            modelBuilder.Entity<PatientCards>().ToTable("patient_cards");
            modelBuilder.Entity<Patients>().ToTable("patients");
            modelBuilder.Entity<PatientVisits>().ToTable("patient_visits");
            modelBuilder.Entity<Positions>().ToTable("positions"); 
            modelBuilder.Entity<UsersCredentials>().ToTable("users_credentials");
            modelBuilder.Entity<UsersRole>().ToTable("users_role");
            modelBuilder.Entity<VisitTypes>().ToTable("visit_types");
            modelBuilder.Entity<VisitDiagnoses>().ToTable("visit_diagnoses");

            
            base.OnModelCreating(modelBuilder);

            // Для PostgreSQL - конвертируем все DateTime в UTC при сохранении
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(
                            new ValueConverter<DateTime, DateTime>(
                                v => v.Kind == DateTimeKind.Unspecified
                                    ? DateTime.SpecifyKind(v, DateTimeKind.Utc)
                                    : v.ToUniversalTime(),
                                v => DateTime.SpecifyKind(v, DateTimeKind.Local)
                            )
                        );
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(
                            new ValueConverter<DateTime?, DateTime?>(
                                v => v.HasValue
                                    ? (v.Value.Kind == DateTimeKind.Unspecified
                                        ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                                        : v.Value.ToUniversalTime())
                                    : v,
                                v => v.HasValue
                                    ? DateTime.SpecifyKind(v.Value, DateTimeKind.Local)
                                    : v
                            )
                        );
                    }
                }
            }
        


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

            // таблица верхнего уровня классификации МКБ-10 - главы
            modelBuilder.Entity<Chapters>(entity =>
            {
                entity.HasIndex(chapter => chapter.number);
                entity.HasIndex(chapter => chapter.code_range);
                entity.HasIndex(chapter => chapter.title);
            });

            // таблица отделений
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(department => department.title);
            }
            );

            // таблица отдел и больница - должность и доктор
            modelBuilder.Entity<DepartmentPosition>(entity =>
            {
                entity.HasOne<HospitalDepartments>()
                    .WithMany()
                    .HasForeignKey(d => d.id_hospital_department)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<DoctorPosition>()
                    .WithMany()
                    .HasForeignKey(p => p.id_position_doctor)
                    .OnDelete(DeleteBehavior.Restrict);
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

            // таблица типов заболеваний
            modelBuilder.Entity<DiseasTypes>(entity =>
            {
                entity.HasOne<Blocks>()
                .WithMany()
                .HasForeignKey(dt => dt.id_block)
                .OnDelete(DeleteBehavior.Restrict);
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

            // таблица докторов
            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasIndex(doctor => doctor.surname);
                entity.HasIndex(doctor => doctor.name);
                entity.HasIndex(doctor => doctor.patronymic);

                entity.HasOne<UsersCredentials>()
               .WithMany()
               .HasForeignKey(dt => dt.id_user_credential)
               .OnDelete(DeleteBehavior.Restrict);
            });

            // расписание врача
            // Найдите конфигурацию DoctorWorkingHours
            modelBuilder.Entity<DoctorWorkingHours>(entity =>
            {
                entity.ToTable("doctor_schedule");

                entity.HasIndex(schedule => schedule.day_of_week);
                entity.HasIndex(schedule => schedule.start_time);
                entity.HasIndex(schedule => schedule.end_time);
                entity.HasIndex(schedule => schedule.duration_appointment);

                // ПРОСТАЯ конфигурация - EF Core сам поймет тип
                entity.Property(e => e.start_time);
                entity.Property(e => e.end_time);

                entity.HasOne<DepartmentPosition>()
                    .WithMany()
                    .HasForeignKey(dt => dt.id_department_position)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<EntryType>(entity =>
            {
                entity.HasIndex(entryType => entryType.title);
            });

            // связующая таблица доктор - поликлиника
            modelBuilder.Entity<HospitalDepartments>(entity =>
            {
                entity.HasOne<Hospitals>()
                    .WithMany()
                    .HasForeignKey(dh => dh.id_hospital)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Department>()
                    .WithMany()
                    .HasForeignKey(dh => dh.id_department)
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

                entity.HasOne<UsersCredentials>()
               .WithMany()
               .HasForeignKey(dt => dt.id_user_credential)
               .OnDelete(DeleteBehavior.Restrict);
            });

            // таблица посещений пациентов
            modelBuilder.Entity<PatientVisits>(entity =>
            {
                entity.HasIndex(visit => visit.adding_date);

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

                entity.HasOne<DoctorWorkingHours>()
                    .WithMany()
                    .HasForeignKey(pv => pv.id_doctor_working_hours)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // таблица должностей
            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasIndex(position => position.title);
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

            });

            // таблица-справочник ролей пользователей
            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasIndex(role => role.role_name);
                entity.HasIndex(role => role.description);
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

            // таблица типы посещений
            modelBuilder.Entity<VisitTypes>(entity =>
            {
                entity.HasIndex(visitType => visitType.title);
            });

        }
    }
}