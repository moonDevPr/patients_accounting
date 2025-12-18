#nullable disable

using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Models;
using PatientsAccounting.Services;
using PatientsAcounting.Models;
using PatientsAcounting.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PatientAccounting.Forms.PatientsForms.MenuForms
{
    public partial class DoctorScheduleForm : Form
    {
        private Guna2ComboBox hospitalComboBox = null!;
        private Guna2ComboBox departmentComboBox = null!;
        private Guna2ComboBox doctorComboBox = null!;
        private FlowLayoutPanel timeSlotsPanel = null!;
        private Guna2Button backButton = null!;
        private MonthCalendar calendar = null!;

        public DoctorScheduleForm()
        {
            InitializeForm();
            LoadHospitals();

            // Устанавливаем минимальную дату на сегодня
            if (calendar != null)
            {
                calendar.MinDate = DateTime.Today;
                calendar.SetDate(DateTime.Today);
            }
        }

        private void InitializeForm()
        {
            // Устанавливаем размер формы под панель
            Size = new Size(900, 600); // Уменьшили размер формы
            StartPosition = FormStartPosition.CenterScreen; // Центрируем форму на экране
            BackColor = Color.FromArgb(45, 45, 48);
            Text = "Расписание врачей";
            Padding = new Padding(10); // Уменьшили padding

            SetupUI();
        }

        private void SetupUI()
        {
            // Основная панель с фиксированным размером
            var mainPanel = new Guna2Panel
            {
                Size = new Size(900, 600),
                Location = new Point(0, 0), // Добавили отступ от краев формы
                FillColor = Color.FromArgb(45, 45, 48),
                Anchor = AnchorStyles.None // Якоря для центрирования
            };

            // Кнопка "Назад" - перемещаем в верхний правый угол
            backButton = new Guna2Button
            {
                Text = "Назад",
                Size = new Size(100, 30), // Уменьшили размер
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(70, 130, 180),
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand
            };
            backButton.Location = new Point(mainPanel.Width - backButton.Width - 40, 20);
            backButton.Click += (s, e) => Close();

            // Заголовок
            var titleLabel = new Guna2HtmlLabel
            {
                Text = "Расписание врачей",
                Size = new Size(250, 40),
                Font = new Font("Segoe UI", 18, FontStyle.Bold), // Уменьшили шрифт
                ForeColor = Color.FromArgb(0, 122, 204),
                TextAlignment = ContentAlignment.MiddleLeft
            };
            titleLabel.Location = new Point(20, 20);

            // Панель фильтров (слева) - уменьшаем высоту
            var filtersPanel = new Guna2Panel
            {
                Size = new Size(400, 450), // Уменьшили размер
                FillColor = Color.FromArgb(60, 60, 65),
                BorderRadius = 15,
                Padding = new Padding(15) // Уменьшили padding
            };
            filtersPanel.Location = new Point(20, 80);

            // Больница
            var hospitalLabel = new Guna2HtmlLabel
            {
                Text = "Больница",
                Size = new Size(340, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold), // Уменьшили шрифт
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleLeft
            };
            hospitalLabel.Location = new Point(10, 10);

            hospitalComboBox = new Guna2ComboBox
            {
                Size = new Size(340, 32), // Уменьшили высоту
                Font = new Font("Segoe UI", 10), // Уменьшили шрифт
                ForeColor = Color.White,
                FillColor = Color.FromArgb(80, 80, 80),
                BorderColor = Color.FromArgb(100, 100, 100),
                BorderRadius = 8,
                DrawMode = DrawMode.OwnerDrawFixed,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            hospitalComboBox.Location = new Point(10, 40);
            hospitalComboBox.SelectedIndexChanged += HospitalComboBox_SelectedIndexChanged;

            // Отделение
            var departmentLabel = new Guna2HtmlLabel
            {
                Text = "Отделение",
                Size = new Size(340, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleLeft
            };
            departmentLabel.Location = new Point(10, 85);

            departmentComboBox = new Guna2ComboBox
            {
                Size = new Size(340, 32),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(80, 80, 80),
                BorderColor = Color.FromArgb(100, 100, 100),
                BorderRadius = 8,
                DrawMode = DrawMode.OwnerDrawFixed,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            departmentComboBox.Location = new Point(10, 115);
            departmentComboBox.SelectedIndexChanged += DepartmentComboBox_SelectedIndexChanged;

            // Врач
            var doctorLabel = new Guna2HtmlLabel
            {
                Text = "Врач",
                Size = new Size(340, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleLeft
            };
            doctorLabel.Location = new Point(10, 160);

            doctorComboBox = new Guna2ComboBox
            {
                Size = new Size(340, 32),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(80, 80, 80),
                BorderColor = Color.FromArgb(100, 100, 100),
                BorderRadius = 8,
                DrawMode = DrawMode.OwnerDrawFixed,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            doctorComboBox.Location = new Point(10, 190);
            doctorComboBox.SelectedIndexChanged += DoctorComboBox_SelectedIndexChanged;

            // Календарь - уменьшаем размер
            calendar = new MonthCalendar
            {
                Size = new Size(340, 150), // Уменьшили высоту
                Font = new Font("Segoe UI", 9), // Уменьшили шрифт
                TitleForeColor = Color.White,
                TitleBackColor = Color.FromArgb(70, 130, 180),
                TrailingForeColor = Color.Gray,
                MaxSelectionCount = 1
            };
            calendar.Location = new Point(10, 235);
            calendar.DateChanged += Calendar_DateChanged;

            // Добавляем элементы в панель фильтров
            filtersPanel.Controls.AddRange(new Control[] {
                hospitalLabel, hospitalComboBox,
                departmentLabel, departmentComboBox,
                doctorLabel, doctorComboBox,
                calendar
            });

            // Панель расписания (справа) - уменьшаем размер
            var schedulePanel = new Guna2Panel
            {
                Size = new Size(425, 450),
                FillColor = Color.FromArgb(60, 60, 65),
                BorderRadius = 15,
                Padding = new Padding(15),
                AutoScroll = true
            };
            schedulePanel.Location = new Point(440, 80); // Изменили позицию

            // Заголовок "Время приёма"
            var scheduleTitle = new Guna2HtmlLabel
            {
                Text = "Время приёма",
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold), // Уменьшили шрифт
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleLeft
            };
            scheduleTitle.Location = new Point(23, 15);

            // Панель для временных слотов
            timeSlotsPanel = new FlowLayoutPanel
            {
                Size = new Size(395, 400),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.Transparent
            };
            timeSlotsPanel.Location = new Point(15, 50);

            // Добавляем элементы в панель расписания
            schedulePanel.Controls.Add(scheduleTitle);
            schedulePanel.Controls.Add(timeSlotsPanel);

            // Добавляем все элементы на основную панель
            mainPanel.Controls.AddRange(new Control[] {
                backButton,
                titleLabel,
                filtersPanel,
                schedulePanel
            });

            // Центрируем основную панель
            CenterPanel(mainPanel);

            // Добавляем основную панель на форму
            Controls.Add(mainPanel);
        }

        private void CenterPanel(Control panel)
        {
            // Центрируем панель относительно формы
            panel.Location = new Point(
                (ClientSize.Width - panel.Width) / 2,
                (ClientSize.Height - panel.Height) / 2
            );
        }



        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadSchedule();
        }

        private void LoadHospitals()
        {
            try
            {
                using var db = new ApplicationDbContext();
                var hospitals = db.Hospitals.ToList();

                if (hospitalComboBox != null)
                {
                    hospitalComboBox.DisplayMember = "name";
                    hospitalComboBox.DataSource = hospitals;

                    if (hospitals.Count > 0)
                    {
                        hospitalComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки больниц: {ex.Message}");
            }
        }

        private void HospitalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hospitalComboBox?.SelectedItem != null)
            {
                var selectedHospital = (Hospitals)hospitalComboBox.SelectedItem;
                LoadDepartments(selectedHospital.id);
            }
        }

        private void LoadDepartments(int hospitalId)
        {
            try
            {
                using var db = new ApplicationDbContext();
                var departments = db.HospitalDepartments
                    .Where(hd => hd.id_hospital == hospitalId)
                    .Join(db.Departments,
                          hd => hd.id_department,
                          d => d.id,
                          (hd, d) => d)
                    .Distinct()
                    .ToList();

                if (departmentComboBox != null)
                {
                    departmentComboBox.DisplayMember = "title";
                    departmentComboBox.DataSource = departments;

                    if (departments.Count > 0)
                    {
                        departmentComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отделений: {ex.Message}");
            }
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (departmentComboBox?.SelectedItem != null && hospitalComboBox?.SelectedItem != null)
            {
                var selectedHospital = (Hospitals)hospitalComboBox.SelectedItem;
                var selectedDepartment = (Department)departmentComboBox.SelectedItem;
                LoadDoctors(selectedHospital.id, selectedDepartment.id);
            }
        }

        private void LoadDoctors(int hospitalId, int departmentId)
        {
            try
            {
                using var db = new ApplicationDbContext();

                // Используем LINQ Join без навигационных свойств
                var doctors = (from hd in db.HospitalDepartments
                               where hd.id_hospital == hospitalId && hd.id_department == departmentId
                               join dp in db.DepartmentPositions on hd.id equals dp.id_hospital_department
                               join dpos in db.DoctorPositions on dp.id_position_doctor equals dpos.id
                               join doc in db.Doctors on dpos.id_doctor equals doc.id
                               select doc)
                             .Distinct()
                             .ToList();

                Console.WriteLine($"Найдено врачей через JOIN: {doctors.Count}");

                // Если не найдено через связи, загружаем всех врачей
                if (doctors.Count == 0)
                {
                    Console.WriteLine("Загружаем всех врачей...");
                    doctors = db.Doctors.ToList();

                    if (doctors.Count == 0)
                    {
                        MessageBox.Show("В базе данных нет врачей!",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Заполняем ComboBox
                doctorComboBox.Items.Clear();
                doctorComboBox.Enabled = true;

                foreach (var doctor in doctors)
                {
                    string displayText = $"{doctor.surname} {doctor.name}";
                    if (!string.IsNullOrWhiteSpace(doctor.patronymic))
                    {
                        displayText += $" {doctor.patronymic}";
                    }

                    var item = new
                    {
                        Id = doctor.id,
                        DisplayText = displayText,
                        Doctor = doctor
                    };

                    doctorComboBox.Items.Add(item);
                }

                doctorComboBox.DisplayMember = "DisplayText";
                doctorComboBox.ValueMember = "Id";

                if (doctors.Count > 0)
                {
                    doctorComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки врачей: {ex.Message}");
            }
        }

        // Вспомогательный класс для элементов ComboBox
        public class ComboBoxDoctorItem
        {
            public Doctors Doctor { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        // Метод для полной диагностики всех связей в базе
        private void DebugAllDatabaseConnections(ApplicationDbContext db)
        {
            try
            {
                Console.WriteLine("\n=== ПОЛНАЯ ДИАГНОСТИКА БАЗЫ ДАННЫХ ===");

                // 1. Все врачи
                var allDoctors = db.Doctors.ToList();
                Console.WriteLine($"Всего врачей в системе: {allDoctors.Count}");
                foreach (var doc in allDoctors)
                {
                    Console.WriteLine($"  Врач ID={doc.id}: {doc.surname} {doc.name}");
                }

                // 2. Все DoctorPositions
                var allDoctorPositions = db.DoctorPositions.ToList();
                Console.WriteLine($"\nВсего DoctorPositions: {allDoctorPositions.Count}");
                foreach (var dp in allDoctorPositions)
                {
                    Console.WriteLine($"  DoctorPosition ID={dp.id}: Doctor ID={dp.id_doctor}, Position ID={dp.id_position}");
                }

                // 3. Все DepartmentPositions
                var allDepartmentPositions = db.DepartmentPositions.ToList();
                Console.WriteLine($"\nВсего DepartmentPositions: {allDepartmentPositions.Count}");
                foreach (var dpp in allDepartmentPositions)
                {
                    Console.WriteLine($"  DepartmentPosition ID={dpp.id}: HospitalDepartment ID={dpp.id_hospital_department}, DoctorPosition ID={dpp.id_position_doctor}");
                }

                // 4. Все HospitalDepartments
                var allHospitalDepts = db.HospitalDepartments.ToList();
                Console.WriteLine($"\nВсего HospitalDepartments: {allHospitalDepts.Count}");
                foreach (var hd in allHospitalDepts)
                {
                    Console.WriteLine($"  HospitalDepartment ID={hd.id}: Hospital ID={hd.id_hospital}, Department ID={hd.id_department}");
                }

                // 5. Проверяем цепочку для всех HospitalDepartments
                Console.WriteLine("\n=== ПРОВЕРКА ВСЕХ СВЯЗЕЙ ===");
                foreach (var hd in allHospitalDepts)
                {
                    var depPositions = db.DepartmentPositions
                        .Where(dp => dp.id_hospital_department == hd.id)
                        .ToList();

                    Console.WriteLine($"\nДля HospitalDepartment ID={hd.id} (Hospital={hd.id_hospital}, Dept={hd.id_department}):");
                    Console.WriteLine($"  Найдено DepartmentPositions: {depPositions.Count}");

                    foreach (var dp in depPositions)
                    {
                        var docPos = db.DoctorPositions.FirstOrDefault(d => d.id == dp.id_position_doctor);
                        if (docPos != null)
                        {
                            var doctor = db.Doctors.FirstOrDefault(d => d.id == docPos.id_doctor);
                            Console.WriteLine($"    DepartmentPosition ID={dp.id} -> DoctorPosition ID={docPos.id} -> Врач: {(doctor != null ? $"{doctor.surname} {doctor.name}" : "НЕ НАЙДЕН")}");
                        }
                        else
                        {
                            Console.WriteLine($"    DepartmentPosition ID={dp.id} -> DoctorPosition НЕ НАЙДЕН");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при диагностике: {ex.Message}");
            }
        }

        // Метод для отладки цепочки связей (добавьте его в класс)
        private void CheckDoctorChain(ApplicationDbContext db, int hospitalId, int departmentId)
        {
            try
            {
                Console.WriteLine("=== ОТЛАДКА ЦЕПОЧКИ СВЯЗЕЙ ===");

                // 1. Проверяем HospitalDepartments
                var hospitalDepts = db.HospitalDepartments
                    .Where(hd => hd.id_hospital == hospitalId && hd.id_department == departmentId)
                    .ToList();

                Console.WriteLine($"1. HospitalDepartments найдено: {hospitalDepts.Count}");
                foreach (var hd in hospitalDepts)
                {
                    Console.WriteLine($"   ID: {hd.id}, HospitalId: {hd.id_hospital}, DepartmentId: {hd.id_department}");
                }

                if (hospitalDepts.Count == 0)
                {
                    MessageBox.Show("Выбранное отделение не существует в этой больнице!",
                        "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Проверяем DepartmentPositions
                foreach (var hd in hospitalDepts)
                {
                    var depPositions = db.DepartmentPositions
                        .Where(dp => dp.id_hospital_department == hd.id)
                        .ToList();

                    Console.WriteLine($"2. Для HospitalDepartment ID={hd.id} найдено DepartmentPositions: {depPositions.Count}");

                    if (depPositions.Count == 0)
                    {
                        Console.WriteLine("   ВНИМАНИЕ: Нет должностей в этом отделении!");
                        MessageBox.Show("В выбранном отделении нет назначенных должностей!",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 3. Проверяем DoctorPositions
                    foreach (var dp in depPositions)
                    {
                        Console.WriteLine($"   DepartmentPosition ID={dp.id}, ссылается на DoctorPosition ID={dp.id_position_doctor}");

                        var docPosition = db.DoctorPositions
                            .FirstOrDefault(dpos => dpos.id == dp.id_position_doctor);

                        if (docPosition != null)
                        {
                            Console.WriteLine($"   3. DoctorPosition ID={docPosition.id} найден, ссылается на Doctor ID={docPosition.id_doctor}");

                            // 4. Проверяем Doctors
                            var doctor = db.Doctors
                                .FirstOrDefault(d => d.id == docPosition.id_doctor);

                            if (doctor != null)
                            {
                                Console.WriteLine($"   4. Врач найден: {doctor.surname} {doctor.name} (ID: {doctor.id})");
                            }
                            else
                            {
                                Console.WriteLine($"   4. ВНИМАНИЕ: Врач с ID {docPosition.id_doctor} не найден!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"   3. ВНИМАНИЕ: DoctorPosition с ID {dp.id_position_doctor} не найден!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отладке: {ex.Message}");
            }
        }


        private void ShowNoDoctorsMessage()
        {
            var label = new Label
            {
                Text = "В выбранном отделении нет врачей",
                ForeColor = Color.Orange,
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            // Можно добавить сообщение на форму или в лог
            Console.WriteLine("В выбранном отделении нет врачей");
        }

        private void DoctorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Убедитесь, что в методе LoadDoctors вы правильно сохраняете объект врача
            // Например, в методе LoadDoctors используйте такой подход:
            // doctorComboBox.Items.Add(new { Doctor = doctor, DisplayText = displayText });

            LoadSchedule();
        }

        // Обновите LoadSchedule:
        private void LoadSchedule()
        {
            timeSlotsPanel.Controls.Clear();

            if (doctorComboBox?.SelectedItem == null || hospitalComboBox?.SelectedItem == null)
            {
                ShowNoDataMessage("Выберите врача для просмотра расписания");
                return;
            }

            try
            {
                using var db = new ApplicationDbContext();

                // Получаем врача из выбранного элемента
                dynamic selectedItem = doctorComboBox.SelectedItem;
                var selectedDoctor = (Doctors)selectedItem.Doctor; // Теперь объект врача доступен через свойство Doctor

                var selectedHospital = (Hospitals)hospitalComboBox.SelectedItem;
                var selectedDate = calendar?.SelectionStart ?? DateTime.Today;
                var dayOfWeekRus = GetRussianDayOfWeek(selectedDate.DayOfWeek).ToLower();

                Console.WriteLine($"Загрузка расписания для врача: {selectedDoctor.surname} {selectedDoctor.name}, " +
                                 $"Больница: {selectedHospital.name}, Дата: {selectedDate:dd.MM.yyyy}, День: {dayOfWeekRus}");

                // 1. Находим расписание врача на этот день
                var doctorSchedule = GetDoctorSchedule(db, selectedDoctor.id, selectedHospital.id, dayOfWeekRus);

                if (doctorSchedule == null)
                {
                    ShowNoDataMessage("Выходной - нет приёмов в этот день", Color.Orange);
                    return;
                }

                // 2. Получаем занятые слоты
                var busySlots = GetBusyTimeSlots(db, doctorSchedule.id, selectedDate);

                // 3. Генерируем свободные слоты
                GenerateTimeSlots(doctorSchedule, selectedDoctor, selectedHospital, selectedDate, busySlots);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки расписания: {ex.Message}\n\nПодробности в консоли",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Ошибка в LoadSchedule: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private DoctorWorkingHours GetDoctorSchedule(ApplicationDbContext db,
    int doctorId, int hospitalId, string dayOfWeek)
        {
            try
            {
                Console.WriteLine($"\n=== ПОИСК РАСПИСАНИЯ ===");
                Console.WriteLine($"Doctor ID: {doctorId}, Hospital ID: {hospitalId}, Day: {dayOfWeek}");

                // Получаем имя дня недели на русском
                var russianDayName = GetRussianDayOfWeek(calendar.SelectionStart.DayOfWeek).ToLower();
                Console.WriteLine($"Русское название дня: {russianDayName}");

                // 1. Находим HospitalDepartment для выбранной больницы и отделения
                if (departmentComboBox.SelectedItem == null)
                {
                    Console.WriteLine("Отделение не выбрано!");
                    return null;
                }

                var selectedDepartment = (Department)departmentComboBox.SelectedItem;

                var hospitalDept = db.HospitalDepartments
                    .FirstOrDefault(hd => hd.id_hospital == hospitalId &&
                                         hd.id_department == selectedDepartment.id);

                if (hospitalDept == null)
                {
                    Console.WriteLine($"HospitalDepartment не найден: Hospital={hospitalId}, Department={selectedDepartment.id}");
                    return null;
                }

                Console.WriteLine($"Найден HospitalDepartment ID: {hospitalDept.id}");

                // 2. Находим DepartmentPosition для этого врача в этом отделении
                // Сначала находим все DoctorPositions этого врача
                var doctorPositions = db.DoctorPositions
                    .Where(dp => dp.id_doctor == doctorId)
                    .Select(dp => dp.id)
                    .ToList();

                if (doctorPositions.Count == 0)
                {
                    Console.WriteLine($"У врача ID={doctorId} нет DoctorPositions");
                    return null;
                }

                // Находим DepartmentPosition, который ссылается на DoctorPosition этого врача
                // И принадлежит указанному HospitalDepartment
                var departmentPosition = db.DepartmentPositions
                    .FirstOrDefault(dp => dp.id_hospital_department == hospitalDept.id &&
                                         doctorPositions.Contains(dp.id_position_doctor));

                if (departmentPosition == null)
                {
                    Console.WriteLine($"DepartmentPosition не найден для врача ID={doctorId} в HospitalDepartment ID={hospitalDept.id}");
                    return null;
                }

                Console.WriteLine($"Найден DepartmentPosition ID: {departmentPosition.id}");

                // 3. Ищем расписание для этого DepartmentPosition
                var schedule = db.DoctorWorkingHours
                    .FirstOrDefault(dwh => dwh.day_of_week.ToLower() == russianDayName &&
                                          dwh.id_department_position == departmentPosition.id);

                if (schedule != null)
                {
                    Console.WriteLine($"✓ Расписание найдено: ID={schedule.id}, " +
                                    $"{schedule.start_time:HH:mm}-{schedule.end_time:HH:mm}, " +
                                    $"Длительность: {schedule.duration_appointment} мин");
                }
                else
                {
                    Console.WriteLine($"✗ Расписание не найдено для дня недели: {russianDayName}");

                    // Для отладки: выведем все расписания для этого DepartmentPosition
                    var allSchedules = db.DoctorWorkingHours
                        .Where(dwh => dwh.id_department_position == departmentPosition.id)
                        .ToList();

                    Console.WriteLine($"Всего расписаний для DepartmentPosition {departmentPosition.id}: {allSchedules.Count}");
                    foreach (var s in allSchedules)
                    {
                        Console.WriteLine($"  День: {s.day_of_week}, Время: {s.start_time:HH:mm}-{s.end_time:HH:mm}");
                    }
                }

                return schedule;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в GetDoctorSchedule: {ex.Message}\n{ex.StackTrace}");
                return null;
            }
        }

        private List<DateTime> GetBusyTimeSlots(ApplicationDbContext db,
    int scheduleId, DateTime selectedDate)
        {
            var busySlots = db.PatientVisits
                .Where(v => v.id_doctor_working_hours == scheduleId &&
                           v.appointment_date.Date == selectedDate.Date)
                .Select(v => new { v.appointment_date })
                .ToList();

            return busySlots.Select(s => s.appointment_date).ToList();
        }

        private void GenerateTimeSlots(DoctorWorkingHours schedule,
    Doctors doctor, Hospitals hospital,
    DateTime selectedDate, List<DateTime> busySlots)
        {
            var startTime = schedule.start_time.TimeOfDay;
            var endTime = schedule.end_time.TimeOfDay;
            var slotDuration = TimeSpan.FromMinutes(schedule.duration_appointment);
            var hasFreeSlots = false;

            var currentTime = startTime;
            while (currentTime + slotDuration <= endTime)
            {
                var slotEndTime = currentTime + slotDuration;

                // Создаем полный DateTime для слота
                var slotDateTime = selectedDate.Date.Add(currentTime);
                var slotEndDateTime = selectedDate.Date.Add(slotEndTime);

                // Упрощаем проверку: ищем любой занятый слот, который пересекается с текущим
                var isBusy = busySlots.Any(busyDateTime =>
                {
                    var busyTime = busyDateTime.TimeOfDay;
                    return busyTime >= currentTime && busyTime < slotEndTime;
                });

                if (!isBusy)
                {
                    hasFreeSlots = true;
                    AddTimeSlot(
                        $"{currentTime:hh\\:mm} - {slotEndTime:hh\\:mm}",
                        doctor,
                        hospital,
                        slotDateTime,
                        schedule.id
                    );
                }

                currentTime = slotEndTime;
            }

            if (!hasFreeSlots)
            {
                ShowNoDataMessage("Нет свободных окон", Color.Gray);
            }
        }

        private void ShowNoDataMessage(string message, Color? color = null)
        {
            var label = new Guna2HtmlLabel
            {
                Text = message,
                Font = new Font("Segoe UI", 12),
                ForeColor = color ?? Color.Gray,
                AutoSize = true,
                Margin = new Padding(10, 20, 10, 10)
            };
            timeSlotsPanel.Controls.Add(label);
        }

        private string GetRussianDayOfWeek(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Monday => "понедельник",
                DayOfWeek.Tuesday => "вторник",
                DayOfWeek.Wednesday => "среда",
                DayOfWeek.Thursday => "четверг",
                DayOfWeek.Friday => "пятница",
                DayOfWeek.Saturday => "суббота",
                DayOfWeek.Sunday => "воскресенье",
                _ => ""
            };
        }

        private void AddTimeSlot(string timeRange, Doctors doctor, Hospitals hospital,
    DateTime slotDateTime, int scheduleId)
        {
            var timeSlotPanel = new Guna2Panel
            {
                Size = new Size(360, 45), // Уменьшили размер
                Margin = new Padding(10, 5, 10, 5),
                FillColor = Color.FromArgb(80, 80, 80),
                BorderRadius = 10
            };

            int centerY = 22; // Изменили из-за уменьшения высоты

            var timeLabel = new Guna2HtmlLabel
            {
                Text = timeRange,
                Location = new Point(10, centerY - 10),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Regular), // Уменьшили шрифт
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleLeft
            };

            var freeLabel = new Guna2HtmlLabel
            {
                Text = "Свободно",
                Location = new Point(130, centerY - 10),
                Size = new Size(70, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Regular), // Уменьшили шрифт
                ForeColor = Color.LightGreen,
                TextAlignment = ContentAlignment.MiddleCenter
            };

            var bookButton = new Guna2Button
            {
                Text = "Записаться",
                Location = new Point(230, centerY - 12), // Подкорректировали позицию
                Size = new Size(115, 28), // Уменьшили размер
                Font = new Font("Segoe UI", 9, FontStyle.Bold), // Уменьшили шрифт
                ForeColor = Color.White,
                FillColor = Color.FromArgb(70, 130, 180),
                BorderRadius = 8,
                Cursor = Cursors.Hand,
                Tag = new
                {
                    Doctor = doctor,
                    Hospital = hospital,
                    AppointmentDateTime = slotDateTime,
                    ScheduleId = scheduleId
                }
            };
            bookButton.Click += BookButton_Click;

            timeSlotPanel.Controls.AddRange(new Control[] {
        timeLabel,
        freeLabel,
        bookButton
    });

            timeSlotsPanel.Controls.Add(timeSlotPanel);
        }

        private void BookButton_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button button && button.Tag is object tag)
            {
                dynamic data = tag;

                BookAppointment(
                    (Doctors)data.Doctor,
                    (Hospitals)data.Hospital,
                    (DateTime)data.AppointmentDateTime,
                    (int)data.ScheduleId
                );
            }
        }

        private void BookAppointment(Doctors doctor, Hospitals hospital,
    DateTime appointmentDateTime, int workingHoursId)
        {
            try
            {
                if (!CurrentUser.IsAuthenticated)
                {
                    MessageBox.Show("Для записи на приём необходимо войти в систему",
                        "Требуется авторизация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? cardId = GetCurrentPatientCardId();
                if (!cardId.HasValue) return;

                if (CurrentUser.RoleName != "Пациент")
                {
                    MessageBox.Show("Только пациенты могут записываться на приём",
                        "Недостаточно прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    $"Подтвердить запись на приём?\n\n" +
                    $"Врач: {doctor.surname} {doctor.name}\n" +
                    $"Больница: {hospital.name}\n" +
                    $"Дата: {appointmentDateTime:dd.MM.yyyy}\n" +
                    $"Время: {appointmentDateTime:HH:mm}",
                    "Подтверждение записи",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                using (var db = new ApplicationDbContext())
                {
                    // 1. Проверяем, что все необходимые данные существуют
                    Console.WriteLine("\n=== ПРОВЕРКА ДАННЫХ ДЛЯ ЗАПИСИ ===");
                    Console.WriteLine($"WorkingHours ID: {workingHoursId}");
                    Console.WriteLine($"Card ID: {cardId.Value}");
                    Console.WriteLine($"Appointment DateTime: {appointmentDateTime}");
                    Console.WriteLine($"Current User PatientId: {CurrentUser.PatientId}");

                    // Проверяем существование записи в doctor_schedule
                    var schedule = db.DoctorWorkingHours
                        .FirstOrDefault(dwh => dwh.id == workingHoursId);

                    if (schedule == null)
                    {
                        MessageBox.Show("Расписание врача не найдено!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Console.WriteLine($"✓ Расписание найдено: ID={schedule.id}");

                    // Проверяем карту пациента
                    var patientCard = db.PatientCards
                        .FirstOrDefault(pc => pc.id == cardId.Value);

                    if (patientCard == null)
                    {
                        MessageBox.Show("Медицинская карта не найдена!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Console.WriteLine($"✓ Карта пациента найдена: ID={patientCard.id}");

                    // 2. Проверяем, не занято ли это время
                    var normalizedAppointmentDateTime = DateTime.SpecifyKind(
                        appointmentDateTime,
                        DateTimeKind.Utc
                    );

                    var existingVisit = db.PatientVisits
                        .FirstOrDefault(v => v.id_doctor_working_hours == workingHoursId &&
                                           v.appointment_date.Date == normalizedAppointmentDateTime.Date &&
                                           v.appointment_date.TimeOfDay == normalizedAppointmentDateTime.TimeOfDay);

                    if (existingVisit != null)
                    {
                        MessageBox.Show("Это время уже занято! Пожалуйста, выберите другое время.",
                            "Время занято", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. Получаем ID для обязательных полей
                    // Ищем первый доступный тип визита
                    var visitType = db.VisitTypes.FirstOrDefault();
                    if (visitType == null)
                    {
                        // Создаем тестовый тип визита если его нет
                        visitType = new VisitTypes { title = "Первичный прием" };
                        db.VisitTypes.Add(visitType);
                        db.SaveChanges();
                    }

                    // Ищем первый доступный тип записи
                    var entryType = db.EntryTypes.FirstOrDefault();
                    if (entryType == null)
                    {
                        entryType = new EntryType { title = "Запись через систему" };
                        db.EntryTypes.Add(entryType);
                        db.SaveChanges();
                    }

                    // Ищем первый доступный анализ
                    var analysis = db.Analysis.FirstOrDefault();
                    if (analysis == null)
                    {
                        analysis = new Analysis { type = "Общий анализ" };
                        db.Analysis.Add(analysis);
                        db.SaveChanges();
                    }

                    Console.WriteLine($"✓ Тип визита: {visitType.id}, Тип записи: {entryType.id}, Анализ: {analysis.id}");

                    // 4. Создаем запись
                    var visit = new PatientVisits
                    {
                        document = $"Запись от {DateTime.Now:dd.MM.yyyy HH:mm}",
                        completed = false,
                        adding_date = DateTime.UtcNow,
                        appointment_date = normalizedAppointmentDateTime,
                        id_doctor_working_hours = workingHoursId,
                        id_visit_type = visitType.id,
                        id_analysis = analysis.id,
                        id_entry_type = entryType.id,
                        id_card = cardId.Value
                    };

                    // Выводим отладочную информацию
                    Console.WriteLine("Создана запись PatientVisits:");
                    Console.WriteLine($"  Document: {visit.document}");
                    Console.WriteLine($"  Completed: {visit.completed}");
                    Console.WriteLine($"  Adding Date: {visit.adding_date}");
                    Console.WriteLine($"  Appointment Date: {visit.appointment_date}");
                    Console.WriteLine($"  DoctorWorkingHours ID: {visit.id_doctor_working_hours}");
                    Console.WriteLine($"  VisitType ID: {visit.id_visit_type}");
                    Console.WriteLine($"  Analysis ID: {visit.id_analysis}");
                    Console.WriteLine($"  EntryType ID: {visit.id_entry_type}");
                    Console.WriteLine($"  Card ID: {visit.id_card}");

                    db.PatientVisits.Add(visit);

                    // Сохраняем с детальной обработкой ошибок
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Запись успешно создана!",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshScheduleAfterBooking();
                    }
                    catch (DbUpdateException dbEx)
                    {
                        // Логируем все детали ошибки
                        Console.WriteLine($"\n=== ОШИБКА СОХРАНЕНИЯ ===");
                        Console.WriteLine($"Сообщение: {dbEx.Message}");

                        if (dbEx.InnerException != null)
                        {
                            Console.WriteLine($"Внутреннее исключение: {dbEx.InnerException.Message}");
                            Console.WriteLine($"Stack Trace: {dbEx.InnerException.StackTrace}");

                            if (dbEx.InnerException.InnerException != null)
                            {
                                Console.WriteLine($"Вложенное исключение: {dbEx.InnerException.InnerException.Message}");
                            }
                        }

                        // Проверяем конкретные ошибки PostgreSQL
                        if (dbEx.InnerException is Npgsql.PostgresException pgEx)
                        {
                            Console.WriteLine($"\nPostgreSQL ошибка:");
                            Console.WriteLine($"  Code: {pgEx.SqlState}");
                            Console.WriteLine($"  Message: {pgEx.MessageText}");
                            Console.WriteLine($"  Detail: {pgEx.Detail}");
                            Console.WriteLine($"  Table: {pgEx.TableName}");
                            Console.WriteLine($"  Column: {pgEx.ColumnName}");
                            Console.WriteLine($"  Constraint: {pgEx.ConstraintName}");
                        }

                        MessageBox.Show($"Ошибка при создании записи:\n\n" +
                                      $"Детали: {(dbEx.InnerException?.Message ?? dbEx.Message)}\n\n" +
                                      $"Проверьте настройки базы данных.",
                            "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании записи: {ex.Message}\n\n{ex.StackTrace}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshScheduleAfterBooking()
        {
            try
            {
                // 1. Сохраняем текущие выбранные значения
                var selectedHospital = hospitalComboBox.SelectedItem as Hospitals;
                var selectedDepartment = departmentComboBox.SelectedItem as Department;
                var selectedDoctor = doctorComboBox.SelectedItem;
                var selectedDate = calendar.SelectionStart;

                // 2. Очищаем панель слотов
                timeSlotsPanel.Controls.Clear();

                // 3. Немедленно загружаем обновленное расписание
                LoadSchedule();

                // 4. Визуальное подтверждение
                var messageLabel = new Guna2HtmlLabel
                {
                    Text = "✓ Вы успешно записаны! Расписание обновлено.",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.LightGreen,
                    AutoSize = true,
                    Margin = new Padding(10, 20, 10, 10)
                };

                // Добавляем сообщение поверх слотов
                timeSlotsPanel.Controls.Add(messageLabel);
                messageLabel.BringToFront();

                // 5. Через 3 секунды убираем сообщение
                var timer = new System.Windows.Forms.Timer
                {
                    Interval = 3000,
                    Enabled = true
                };
                timer.Tick += (s, e) =>
                {
                    timeSlotsPanel.Controls.Remove(messageLabel);
                    timer.Stop();
                    timer.Dispose();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обновления расписания: {ex.Message}");
            }
        }

        private void InitializeComponent()
        {

        }

        private int? GetCurrentPatientCardId()
        {
            try
            {
                if (!CurrentUser.IsAuthenticated || !CurrentUser.PatientId.HasValue)
                {
                    MessageBox.Show("Для записи на приём необходимо войти в систему как пациент",
                        "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                using var db = new ApplicationDbContext();
                var patientCard = db.PatientCards
                    .FirstOrDefault(pc => pc.id_patient == CurrentUser.PatientId.Value);

                if (patientCard == null)
                {
                    MessageBox.Show("Медицинская карта не найдена. Обратитесь в регистратуру.",
                        "Карта не найдена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                return patientCard.id;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения медицинской карты: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}