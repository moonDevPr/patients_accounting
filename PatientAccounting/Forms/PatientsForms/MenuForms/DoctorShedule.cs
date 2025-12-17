#nullable disable

using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Models;
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

                var doctors = db.HospitalDepartments
                    .Where(hd => hd.id_hospital == hospitalId && hd.id_department == departmentId)
                    .Join(db.DepartmentPositions,
                          hd => hd.id,
                          dp => dp.id_hospital_department,
                          (hd, dp) => dp)
                    .Join(db.DoctorPositions,
                          dp => dp.id_position_doctor,
                          dpos => dpos.id,
                          (dp, dpos) => dpos)
                    .Join(db.Doctors,
                          dpos => dpos.id_doctor,
                          d => d.id,
                          (dpos, d) => d)
                    .Distinct()
                    .ToList();

                if (doctorComboBox != null)
                {
                    doctorComboBox.DisplayMember = "surname";
                    doctorComboBox.ValueMember = "id";
                    doctorComboBox.DataSource = doctors;

                    if (doctors.Count > 0)
                    {
                        doctorComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки врачей: {ex.Message}");
            }
        }

        private void DoctorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchedule();
        }

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

                var selectedDoctor = (Doctors)doctorComboBox.SelectedItem;
                var selectedHospital = (Hospitals)hospitalComboBox.SelectedItem;
                var selectedDate = calendar?.SelectionStart ?? DateTime.Today;
                var dayOfWeekRus = GetRussianDayOfWeek(selectedDate.DayOfWeek).ToLower();

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
                MessageBox.Show($"Ошибка загрузки расписания: {ex.Message}");
            }
        }

        private DoctorWorkingHours GetDoctorSchedule(ApplicationDbContext db,
    int doctorId, int hospitalId, string dayOfWeek)
        {
            try
            {
                // Находим связь врача с отделением
                var departmentPositionId = db.HospitalDepartments
                    .Where(hd => hd.id_hospital == hospitalId)
                    .Join(db.DepartmentPositions,
                          hd => hd.id,
                          dp => dp.id_hospital_department,
                          (hd, dp) => dp)
                    .Join(db.DoctorPositions,
                          dp => dp.id_position_doctor,
                          dpos => dpos.id,
                          (dp, dpos) => new { DepartmentPosition = dp, DoctorPosition = dpos })
                    .Where(x => x.DoctorPosition.id_doctor == doctorId)
                    .Select(x => x.DepartmentPosition.id)
                    .FirstOrDefault();

                if (departmentPositionId == 0)
                    return null;

                // Ищем расписание с AsNoTracking
                return db.DoctorWorkingHours
                    .AsNoTracking()
                    .FirstOrDefault(dwh => dwh.day_of_week.ToLower() == dayOfWeek &&
                                         dwh.id_department_position == departmentPositionId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка в GetDoctorSchedule: {ex.Message}");
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

                    var visit = new PatientVisits
                    {
                        document = $"Запись от {DateTime.Now:dd.MM.yyyy HH:mm}",
                        completed = false,
                        adding_date = DateTime.UtcNow,
                        appointment_date = normalizedAppointmentDateTime,
                        id_doctor_working_hours = workingHoursId,
                        id_visit_type = 1,
                        id_analysis = 1,
                        id_entry_type = 1,
                        id_card = cardId.Value
                    };

                    db.PatientVisits.Add(visit);
                    db.SaveChanges();

                    MessageBox.Show("Запись успешно создана!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadSchedule();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании записи: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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