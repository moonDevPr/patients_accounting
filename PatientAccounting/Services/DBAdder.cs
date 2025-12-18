using PatientsAccounting.Models;
using PatientsAcounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientsAccounting.Services
{
    public class DatabaseSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly Random _random = new Random();

        public DatabaseSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedAllTables()
        {
            try
            {
                Console.WriteLine("Начало заполнения базы данных...");

                ClearAllTables();

                SeedUsersRoles();
                SeedEntryTypes();
                SeedAnalysis();
                SeedVisitTypes();
                SeedPositions();
                SeedDepartments();
                SeedHospitals();
                SeedHospitalDepartments();
                SeedChapters();
                SeedBlocks();
                SeedDiseaseTypes();
                SeedDiseases();
                SeedUsersCredentials();
                SeedPatients();
                SeedDoctors();
                SeedDoctorPositions();
                SeedDepartmentPositions();
                SeedDoctorWorkingHours();
                SeedPatientCards();
                SeedPatientVisits();
                SeedVisitDiagnoses();

                _context.SaveChanges();
                Console.WriteLine("База данных успешно заполнена!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при заполнении базы данных: {ex.Message}");
                throw;
            }
        }

        private void ClearAllTables()
        {
            Console.WriteLine("Очистка таблиц...");

            _context.VisitDiagnoses.RemoveRange(_context.VisitDiagnoses);
            _context.PatientVisits.RemoveRange(_context.PatientVisits);
            _context.DoctorWorkingHours.RemoveRange(_context.DoctorWorkingHours);
            _context.DepartmentPositions.RemoveRange(_context.DepartmentPositions);
            _context.DoctorPositions.RemoveRange(_context.DoctorPositions);
            _context.PatientCards.RemoveRange(_context.PatientCards);
            _context.Patients.RemoveRange(_context.Patients);
            _context.Doctors.RemoveRange(_context.Doctors);
            _context.UsersCredentials.RemoveRange(_context.UsersCredentials);
            _context.Diseas.RemoveRange(_context.Diseas);
            _context.DiseasTypes.RemoveRange(_context.DiseasTypes);
            _context.Blocks.RemoveRange(_context.Blocks);
            _context.Chapters.RemoveRange(_context.Chapters);
            _context.HospitalDepartments.RemoveRange(_context.HospitalDepartments);
            _context.Hospitals.RemoveRange(_context.Hospitals);
            _context.Departments.RemoveRange(_context.Departments);
            _context.Positions.RemoveRange(_context.Positions);
            _context.VisitTypes.RemoveRange(_context.VisitTypes);
            _context.Analysis.RemoveRange(_context.Analysis);
            _context.EntryTypes.RemoveRange(_context.EntryTypes);
            _context.UsersRoles.RemoveRange(_context.UsersRoles);

            _context.SaveChanges();
        }

        private void SeedUsersRoles()
        {
            Console.WriteLine("Заполнение таблицы UsersRoles...");

            var roles = new List<UsersRole>
            {
                new UsersRole { role_name = "Пациент", description = "Роль для пациентов системы" },
                new UsersRole { role_name = "Врач", description = "Роль для врачей медицинского учреждения" },
                new UsersRole { role_name = "Аналитик", description = "Роль для аналитиков медицинских данных" }
            };

            _context.UsersRoles.AddRange(roles);
            _context.SaveChanges();
        }

        private void SeedEntryTypes()
        {
            Console.WriteLine("Заполнение таблицы EntryType...");

            var entryTypes = new List<EntryType>
            {
                new EntryType { title = "Первичный прием" },
                new EntryType { title = "Повторный прием" },
                new EntryType { title = "Профилактический осмотр" },
                new EntryType { title = "Диагностика" },
                new EntryType { title = "Консультация" }
            };

            _context.EntryTypes.AddRange(entryTypes);
            _context.SaveChanges();
        }

        private void SeedAnalysis()
        {
            Console.WriteLine("Заполнение таблицы Analysis...");

            var analyses = new List<Analysis>
            {
                new Analysis { type = "Общий анализ крови" },
                new Analysis { type = "Биохимический анализ крови" },
                new Analysis { type = "Общий анализ мочи" },
                new Analysis { type = "Анализ на гормоны" },
                new Analysis { type = "УЗИ" },
                new Analysis { type = "Рентген" },
                new Analysis { type = "МРТ" },
                new Analysis { type = "КТ" },
                new Analysis { type = "ЭКГ" },
                new Analysis { type = "ЭхоКГ" }
            };

            _context.Analysis.AddRange(analyses);
            _context.SaveChanges();
        }

        private void SeedVisitTypes()
        {
            Console.WriteLine("Заполнение таблицы VisitTypes...");

            var visitTypes = new List<VisitTypes>
            {
                new VisitTypes { title = "Плановый прием" },
                new VisitTypes { title = "Экстренный прием" },
                new VisitTypes { title = "Профилактический осмотр" },
                new VisitTypes { title = "Вакцинация" },
                new VisitTypes { title = "Диагностика" },
                new VisitTypes { title = "Лечебная процедура" },
                new VisitTypes { title = "Консультация" },
                new VisitTypes { title = "Диспансеризация" },
                new VisitTypes { title = "Послеоперационный осмотр" },
                new VisitTypes { title = "Реабилитация" }
            };

            _context.VisitTypes.AddRange(visitTypes);
            _context.SaveChanges();
        }

        private void SeedPositions()
        {
            Console.WriteLine("Заполнение таблицы Positions...");

            var positions = new List<Positions>
            {
                new Positions { title = "Терапевт" },
                new Positions { title = "Хирург" },
                new Positions { title = "Кардиолог" },
                new Positions { title = "Невролог" },
                new Positions { title = "Офтальмолог" },
                new Positions { title = "Отоларинголог" },
                new Positions { title = "Стоматолог" },
                new Positions { title = "Педиатр" },
                new Positions { title = "Гинеколог" },
                new Positions { title = "Уролог" },
                new Positions { title = "Дерматолог" },
                new Positions { title = "Эндокринолог" },
                new Positions { title = "Онколог" },
                new Positions { title = "Рентгенолог" },
                new Positions { title = "Анестезиолог" }
            };

            _context.Positions.AddRange(positions);
            _context.SaveChanges();
        }

        private void SeedDepartments()
        {
            Console.WriteLine("Заполнение таблицы Department...");

            var departments = new List<Department>
            {
                new Department { title = "Терапевтическое отделение" },
                new Department { title = "Хирургическое отделение" },
                new Department { title = "Кардиологическое отделение" },
                new Department { title = "Неврологическое отделение" },
                new Department { title = "Офтальмологическое отделение" },
                new Department { title = "ЛОР-отделение" },
                new Department { title = "Стоматологическое отделение" },
                new Department { title = "Педиатрическое отделение" },
                new Department { title = "Гинекологическое отделение" },
                new Department { title = "Урологическое отделение" },
                new Department { title = "Дерматовенерологическое отделение" },
                new Department { title = "Эндокринологическое отделение" },
                new Department { title = "Онкологическое отделение" },
                new Department { title = "Рентгенологическое отделение" },
                new Department { title = "Реанимационное отделение" }
            };

            _context.Departments.AddRange(departments);
            _context.SaveChanges();
        }

        private void SeedHospitals()
        {
            Console.WriteLine("Заполнение таблицы Hospitals...");

            var hospitals = new List<Hospitals>
            {
                new Hospitals
                {
                    name = "Городская поликлиника №1",
                    town = "Москва",
                    street = "Ленинский проспект",
                    house = "12"
                },
                new Hospitals
                {
                    name = "Центральная больница",
                    town = "Москва",
                    street = "Тверская",
                    house = "25"
                },
                new Hospitals
                {
                    name = "Детская клиническая больница",
                    town = "Санкт-Петербург",
                    street = "Невский проспект",
                    house = "48"
                },
                new Hospitals
                {
                    name = "Поликлиника Северного округа",
                    town = "Москва",
                    street = "Профсоюзная",
                    house = "96"
                },
                new Hospitals
                {
                    name = "Клинический госпиталь",
                    town = "Казань",
                    street = "Кремлевская",
                    house = "18"
                }
            };

            _context.Hospitals.AddRange(hospitals);
            _context.SaveChanges();
        }

        private void SeedHospitalDepartments()
        {
            Console.WriteLine("Заполнение таблицы HospitalDepartments...");

            var hospitalDepartments = new List<HospitalDepartments>();
            var hospitals = _context.Hospitals.ToList();
            var departments = _context.Departments.ToList();

            foreach (var hospital in hospitals)
            {
                var deptCount = _random.Next(5, 10);
                var selectedDepartments = departments.OrderBy(x => _random.Next()).Take(deptCount).ToList();

                foreach (var department in selectedDepartments)
                {
                    hospitalDepartments.Add(new HospitalDepartments
                    {
                        id_hospital = hospital.id,
                        id_department = department.id
                    });
                }
            }

            _context.HospitalDepartments.AddRange(hospitalDepartments);
            _context.SaveChanges();
        }

        private void SeedChapters()
        {
            Console.WriteLine("Заполнение таблицы Chapters...");

            var chapters = new List<Chapters>
            {
                new Chapters { number = "I", code_range = "A00-B99", title = "Некоторые инфекционные и паразитарные болезни" },
                new Chapters { number = "II", code_range = "C00-D48", title = "Новообразования" },
                new Chapters { number = "III", code_range = "D50-D89", title = "Болезни крови, кроветворных органов и отдельные нарушения, вовлекающие иммунный механизм" },
                new Chapters { number = "IV", code_range = "E00-E90", title = "Болезни эндокринной системы, расстройства питания и нарушения обмена веществ" },
                new Chapters { number = "V", code_range = "F00-F99", title = "Психические расстройства и расстройства поведения" },
                new Chapters { number = "VI", code_range = "G00-G99", title = "Болезни нервной системы" },
                new Chapters { number = "VII", code_range = "H00-H59", title = "Болезни глаза и его придаточного аппарата" },
                new Chapters { number = "VIII", code_range = "H60-H95", title = "Болезни уха и сосцевидного отростка" },
                new Chapters { number = "IX", code_range = "I00-I99", title = "Болезни системы кровообращения" },
                new Chapters { number = "X", code_range = "J00-J99", title = "Болезни органов дыхания" }
            };

            _context.Chapters.AddRange(chapters);
            _context.SaveChanges();
        }

        private void SeedBlocks()
        {
            Console.WriteLine("Заполнение таблицы Blocks...");

            var blocks = new List<Blocks>();
            var chapters = _context.Chapters.ToList();

            foreach (var chapter in chapters)
            {
                var blockCount = _random.Next(3, 6);
                for (int i = 1; i <= blockCount; i++)
                {
                    blocks.Add(new Blocks
                    {
                        code = $"B{i:D3}",
                        title = $"Блок {i} для главы {chapter.number}",
                        id_chapter = chapter.id
                    });
                }
            }

            _context.Blocks.AddRange(blocks);
            _context.SaveChanges();
        }

        private void SeedDiseaseTypes()
        {
            Console.WriteLine("Заполнение таблицы DiseasTypes...");

            var diseaseTypes = new List<DiseasTypes>();
            var blocks = _context.Blocks.ToList();

            var typeTitles = new[]
            {
                "Острые заболевания",
                "Хронические заболевания",
                "Инфекционные заболевания",
                "Неврологические заболевания",
                "Сердечно-сосудистые заболевания",
                "Заболевания дыхательной системы",
                "Заболевания пищеварительной системы",
                "Заболевания опорно-двигательного аппарата",
                "Эндокринные заболевания",
                "Кожные заболевания"
            };

            foreach (var block in blocks)
            {
                var typeCount = _random.Next(2, 5);
                for (int i = 1; i <= typeCount; i++)
                {
                    diseaseTypes.Add(new DiseasTypes
                    {
                        code = $"T{i:D2}",
                        title = typeTitles[_random.Next(typeTitles.Length)],
                        inclusion_text = "Текст включения для данного типа заболеваний",
                        exclusion_text = "Текст исключения для данного типа заболеваний",
                        id_block = block.id
                    });
                }
            }

            _context.DiseasTypes.AddRange(diseaseTypes);
            _context.SaveChanges();
        }

        private void SeedDiseases()
        {
            Console.WriteLine("Заполнение таблицы Diseas...");

            var diseases = new List<Diseas>();
            var diseaseTypes = _context.DiseasTypes.ToList();

            var diseaseNames = new[]
            {
                "Грипп",
                "Гипертоническая болезнь",
                "Сахарный диабет",
                "Бронхит",
                "Гастрит",
                "Артрит",
                "Астма",
                "Пневмония",
                "Мигрень",
                "Ангина",
                "Остеохондроз",
                "Гепатит",
                "Панкреатит",
                "Холецистит",
                "Дерматит"
            };

            foreach (var type in diseaseTypes)
            {
                var diseaseCount = _random.Next(3, 9);
                for (int i = 1; i <= diseaseCount; i++)
                {
                    diseases.Add(new Diseas
                    {
                        code = $"D{i:D3}",
                        title = diseaseNames[_random.Next(diseaseNames.Length)],
                        description = $"Описание заболевания {type.title}",
                        active = true,
                        priority = _random.Next(1, 4),
                        primary = _random.Next(0, 2) == 1,
                        id_diseas_type = type.id
                    });
                }
            }

            _context.Diseas.AddRange(diseases);
            _context.SaveChanges();
        }

        private string GenerateSalt()
        {
            var saltBytes = new byte[32];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var saltedPassword = password + salt;
                var bytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void SeedUsersCredentials()
        {
            Console.WriteLine("Заполнение таблицы UsersCredentials...");

            var userCredentials = new List<UsersCredentials>();
            var roles = _context.UsersRoles.ToList();

            var testUsers = new[]
            {
                new { Username = "patient1", Password = "patient123", Role = "Пациент" },
                new { Username = "patient2", Password = "patient456", Role = "Пациент" },
                new { Username = "patient3", Password = "patient789", Role = "Пациент" },
                new { Username = "doctor1", Password = "doctor123", Role = "Врач" },
                new { Username = "doctor2", Password = "doctor456", Role = "Врач" },
                new { Username = "doctor3", Password = "doctor789", Role = "Врач" },
                new { Username = "analyst1", Password = "analyst123", Role = "Аналитик" }
            };

            foreach (var testUser in testUsers)
            {
                var salt = GenerateSalt();
                var role = roles.FirstOrDefault(r => r.role_name == testUser.Role);

                userCredentials.Add(new UsersCredentials
                {
                    username = testUser.Username,
                    password_hash = HashPassword(testUser.Password, salt),
                    salt = salt,
                    active = true,
                    created_date = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
                    last_login = DateTime.UtcNow.AddDays(-_random.Next(0, 30)),
                    id_users_role = role?.id
                });
            }

            _context.UsersCredentials.AddRange(userCredentials);
            _context.SaveChanges();
        }

        private void SeedPatients()
        {
            Console.WriteLine("Заполнение таблицы Patients...");

            var patients = new List<Patients>();
            var patientCredentials = _context.UsersCredentials
                .Where(uc => uc.id_users_role == _context.UsersRoles.First(r => r.role_name == "Пациент").id)
                .ToList();

            var patientData = new[]
            {
                new { Surname = "Иванов", Name = "Иван", Patronymic = "Иванович", Snils = "12345678901", Phone = "+79161234567" },
                new { Surname = "Петров", Name = "Петр", Patronymic = "Петрович", Snils = "23456789012", Phone = "+79162345678" },
                new { Surname = "Сидорова", Name = "Анна", Patronymic = "Сергеевна", Snils = "34567890123", Phone = "+79163456789" }
            };

            for (int i = 0; i < patientCredentials.Count && i < patientData.Length; i++)
            {
                patients.Add(new Patients
                {
                    surname = patientData[i].Surname,
                    name = patientData[i].Name,
                    patronymic = patientData[i].Patronymic,
                    snils = patientData[i].Snils,
                    phone = patientData[i].Phone,
                    town = "Москва",
                    street = "Ленина",
                    house = (i + 1).ToString(),
                    id_user_credential = patientCredentials[i].id
                });
            }

            _context.Patients.AddRange(patients);
            _context.SaveChanges();
        }

        private void SeedDoctors()
        {
            Console.WriteLine("Заполнение таблицы Doctors...");

            var doctors = new List<Doctors>();
            var doctorCredentials = _context.UsersCredentials
                .Where(uc => uc.id_users_role == _context.UsersRoles.First(r => r.role_name == "Врач").id)
                .ToList();

            var doctorData = new[]
            {
                new { Surname = "Смирнов", Name = "Александр", Patronymic = "Владимирович" },
                new { Surname = "Кузнецова", Name = "Елена", Patronymic = "Игоревна" },
                new { Surname = "Попов", Name = "Дмитрий", Patronymic = "Александрович" }
            };

            for (int i = 0; i < doctorCredentials.Count && i < doctorData.Length; i++)
            {
                doctors.Add(new Doctors
                {
                    surname = doctorData[i].Surname,
                    name = doctorData[i].Name,
                    patronymic = doctorData[i].Patronymic,
                    id_user_credential = doctorCredentials[i].id
                });
            }

            _context.Doctors.AddRange(doctors);
            _context.SaveChanges();
        }

        private void SeedDoctorPositions()
        {
            Console.WriteLine("Заполнение таблицы DoctorPosition...");

            var doctorPositions = new List<DoctorPosition>();
            var doctors = _context.Doctors.ToList();
            var positions = _context.Positions.ToList();

            foreach (var doctor in doctors)
            {
                var posCount = _random.Next(1, 3);
                var selectedPositions = positions.OrderBy(x => _random.Next()).Take(posCount).ToList();

                foreach (var position in selectedPositions)
                {
                    doctorPositions.Add(new DoctorPosition
                    {
                        id_doctor = doctor.id,
                        id_position = position.id
                    });
                }
            }

            _context.DoctorPositions.AddRange(doctorPositions);
            _context.SaveChanges();
        }

        private void SeedDepartmentPositions()
        {
            Console.WriteLine("Заполнение таблицы DepartmentPosition...");

            var departmentPositions = new List<DepartmentPosition>();
            var doctorPositions = _context.DoctorPositions.ToList();
            var hospitalDepartments = _context.HospitalDepartments.ToList();

            foreach (var doctorPosition in doctorPositions)
            {
                var hospitalDept = hospitalDepartments.OrderBy(x => _random.Next()).FirstOrDefault();
                if (hospitalDept != null)
                {
                    departmentPositions.Add(new DepartmentPosition
                    {
                        id_position_doctor = doctorPosition.id,
                        id_hospital_department = hospitalDept.id
                    });
                }
            }

            _context.DepartmentPositions.AddRange(departmentPositions);
            _context.SaveChanges();
        }

        private void SeedDoctorWorkingHours()
        {
            Console.WriteLine("Заполнение таблицы DoctorWorkingHours...");

            var workingHours = new List<DoctorWorkingHours>();
            var departmentPositions = _context.DepartmentPositions.ToList();
            var daysOfWeek = new[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" };

            foreach (var deptPosition in departmentPositions)
            {
                var daysCount = _random.Next(3, 6);
                for (int i = 0; i < daysCount; i++)
                {
                    var startHour = 8 + _random.Next(0, 3);
                    var endHour = startHour + 8;

                    workingHours.Add(new DoctorWorkingHours
                    {
                        day_of_week = daysOfWeek[i % daysOfWeek.Length],
                        duration_appointment = 30,
                        start_time = DateTime.Today.AddHours(startHour),
                        end_time = DateTime.Today.AddHours(endHour),
                        id_department_position = deptPosition.id
                    });
                }
            }

            _context.DoctorWorkingHours.AddRange(workingHours);
            _context.SaveChanges();
        }

        private void SeedPatientCards()
        {
            Console.WriteLine("Заполнение таблицы PatientCards...");

            var patientCards = new List<PatientCards>();
            var patients = _context.Patients.ToList();
            var hospitals = _context.Hospitals.ToList();

            foreach (var patient in patients)
            {
                var hospital = hospitals.OrderBy(x => _random.Next()).FirstOrDefault();

                patientCards.Add(new PatientCards
                {
                    code = 1000 + patient.id,
                    id_hospital = hospital?.id,
                    id_patient = patient.id
                });
            }

            _context.PatientCards.AddRange(patientCards);
            _context.SaveChanges();
        }

        private void SeedPatientVisits()
        {
            Console.WriteLine("Заполнение таблицы PatientVisits...");

            var patientVisits = new List<PatientVisits>();
            var patientCards = _context.PatientCards.ToList();
            var workingHours = _context.DoctorWorkingHours.ToList();
            var visitTypes = _context.VisitTypes.ToList();
            var analyses = _context.Analysis.ToList();
            var entryTypes = _context.EntryTypes.ToList();

            foreach (var card in patientCards)
            {
                var visitCount = _random.Next(2, 6);
                for (int i = 0; i < visitCount; i++)
                {
                    var workingHour = workingHours.OrderBy(x => _random.Next()).FirstOrDefault();
                    var visitDate = DateTime.UtcNow.AddDays(-_random.Next(1, 180));

                    patientVisits.Add(new PatientVisits
                    {
                        document = $"Медкарта №{card.code}/V{i+1}",
                        completed = _random.Next(0, 2) == 1,
                        adding_date = visitDate.AddDays(-7),
                        appointment_date = visitDate,
                        id_doctor_working_hours = workingHour?.id ?? 1,
                        id_visit_type = visitTypes.OrderBy(x => _random.Next()).First().id,
                        id_analysis = analyses.OrderBy(x => _random.Next()).First().id,
                        id_entry_type = entryTypes.OrderBy(x => _random.Next()).First().id,
                        id_card = card.id
                    });
                }
            }

            _context.PatientVisits.AddRange(patientVisits);
            _context.SaveChanges();
        }

        private void SeedVisitDiagnoses()
        {
            Console.WriteLine("Заполнение таблицы VisitDiagnoses...");

            var visitDiagnoses = new List<VisitDiagnoses>();
            var visits = _context.PatientVisits.ToList();
            var diseases = _context.Diseas.ToList();
            
            var severityLevels = new[] { "Легкая", "Средняя", "Тяжелая" };
            var changeReasons = new[] { "Первичная диагностика", "Уточнение диагноза", "Изменение состояния", "Контрольный осмотр" };

            foreach (var visit in visits)
            {
                var diagnosisCount = _random.Next(1, 4);
                for (int i = 0; i < diagnosisCount; i++)
                {
                    var disease = diseases.OrderBy(x => _random.Next()).FirstOrDefault();
                    if (disease != null)
                    {
                        visitDiagnoses.Add(new VisitDiagnoses
                        {
                            severity = severityLevels[_random.Next(severityLevels.Length)],
                            comment = $"Комментарий к диагнозу для посещения {visit.id}",
                            primary = i == 0,
                            change_reason = changeReasons[_random.Next(changeReasons.Length)],
                            id_visit = visit.id,
                            id_diseas = disease.id
                        });
                    }
                }
            }

            _context.VisitDiagnoses.AddRange(visitDiagnoses);
            _context.SaveChanges();
        }
    }
}