#nullable disable
#nullable enable

using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Forms;
using PatientsAccounting.Models;
using PatientsAcounting.Models;
using PatientsAcounting.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PatientAccounting
{
    public partial class AddPatientVisitForm : Form
    {
        private Patients currentPatient;
        private int patientCardId;
        private Guna2ComboBox cmbHospital;
        private Guna2ComboBox cmbDepartment;
        private Guna2ComboBox cmbDoctor;
        private Guna2ComboBox cmbVisitType;
        private Guna2ComboBox cmbEntryType;
        private Guna2ComboBox cmbDiagnosis;
        private Guna2ComboBox cmbAnalysis; // ДОБАВЛЕН КОМБОБОКС ДЛЯ АНАЛИЗОВ
        private Guna2DateTimePicker dtpVisitDate;
        private Guna2Button btnSave;
        private Guna2Button btnBack;
        private Guna2HtmlLabel lblTitle;
        private Guna2HtmlLabel lblPatientInfo;
        private int currentDoctorId;

        public AddPatientVisitForm(Patients patient, int patientCardId, int currentDoctorId = 0)
        {
            currentPatient = patient;
            this.patientCardId = patientCardId;
            this.currentDoctorId = currentDoctorId;
            InitializeComponent();
            SetupUI();
            LoadFormData();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // AddPatientVisitForm
            // 
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(1479, 674);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddPatientVisitForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Добавление визита";
            ResumeLayout(false);
        }

        private void SetupUI()
        {
            // Основная панель
            var mainPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(45, 45, 48)
            };

            // Панель заголовка
            var headerPanel = new Guna2Panel
            {
                Location = new Point(25, 25),
                Size = new Size(1152, 70),
                FillColor = Color.Transparent
            };

            lblTitle = new Guna2HtmlLabel
            {
                Text = "Добавление визита",
                Location = new Point(0, 15),
                Size = new Size(600, 40),
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            btnBack = new Guna2Button
            {
                Text = "Назад",
                Location = new Point(1010, 20),
                Size = new Size(130, 35),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(70, 130, 180),
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand
            };
            btnBack.Click += btnBack_Click;

            headerPanel.Controls.AddRange(new Control[] { lblTitle, btnBack });

            // Информация о пациенте
            var infoPanel = new Guna2Panel
            {
                Location = new Point(25, 115),
                Size = new Size(1152, 50),
                FillColor = Color.Transparent
            };

            lblPatientInfo = new Guna2HtmlLabel
            {
                Location = new Point(0, 10),
                Size = new Size(1152, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            infoPanel.Controls.Add(lblPatientInfo);

            // Форма ввода данных - УВЕЛИЧЕНА высота для дополнительного поля
            var formPanel = new Guna2Panel
            {
                Location = new Point(25, 185),
                Size = new Size(1152, 500),
                FillColor = Color.Transparent
            };

            int yPos = 20;
            int labelWidth = 250;
            int comboBoxWidth = 600;
            int leftPadding = 100;

            // Дата и время
            var lblVisitDate = new Guna2HtmlLabel
            {
                Text = "Дата и время визита:",
                Location = new Point(leftPadding, yPos),
                Size = new Size(labelWidth, 30),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 220, 220),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            dtpVisitDate = new Guna2DateTimePicker
            {
                Location = new Point(leftPadding + labelWidth + 20, yPos),
                Size = new Size(comboBoxWidth, 36),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd.MM.yyyy HH:mm",
                ShowUpDown = true,
                Value = DateTime.Now,
                MinDate = DateTime.Today, // ЗАПРЕЩАЕМ ВЫБОР ПРОШЛЫХ ДАТ
                MaxDate = DateTime.Today.AddYears(1) // ОПЦИОНАЛЬНО: ограничиваем выбор на год вперед
            };

            yPos += 55;

            // Врач
            var lblDoctor = new Guna2HtmlLabel
            {
                Text = "Врач:",
                Location = new Point(leftPadding, yPos),
                Size = new Size(labelWidth, 30),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 220, 220),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            cmbDoctor = new Guna2ComboBox
            {
                Location = new Point(leftPadding + labelWidth + 20, yPos),
                Size = new Size(comboBoxWidth, 36),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                BackColor = Color.FromArgb(60, 60, 63)
            };
            cmbDoctor.SelectedIndexChanged += CmbDoctor_SelectedIndexChanged;

            yPos += 55;

            // Больница
            var lblHospital = new Guna2HtmlLabel
            {
                Text = "Больница:",
                Location = new Point(leftPadding, yPos),
                Size = new Size(labelWidth, 30),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 220, 220),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            cmbHospital = new Guna2ComboBox
            {
                Location = new Point(leftPadding + labelWidth + 20, yPos),
                Size = new Size(comboBoxWidth, 36),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                BackColor = Color.FromArgb(60, 60, 63)
            };
            cmbHospital.SelectedIndexChanged += CmbHospital_SelectedIndexChanged;

            yPos += 55;

            // Отделение
            var lblDepartment = new Guna2HtmlLabel
            {
                Text = "Отделение:",
                Location = new Point(leftPadding, yPos),
                Size = new Size(labelWidth, 30),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 220, 220),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            cmbDepartment = new Guna2ComboBox
            {
                Location = new Point(leftPadding + labelWidth + 20, yPos),
                Size = new Size(comboBoxWidth, 36),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                BackColor = Color.FromArgb(60, 60, 63)
            };

            yPos += 55;

            // Тип визита
            var lblVisitType = new Guna2HtmlLabel
            {
                Text = "Тип визита:",
                Location = new Point(leftPadding, yPos),
                Size = new Size(labelWidth, 30),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 220, 220),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            cmbVisitType = new Guna2ComboBox
            {
                Location = new Point(leftPadding + labelWidth + 20, yPos),
                Size = new Size(comboBoxWidth, 36),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                BackColor = Color.FromArgb(60, 60, 63)
            };

            yPos += 55;

            // Тип записи
            var lblEntryType = new Guna2HtmlLabel
            {
                Text = "Тип записи:",
                Location = new Point(leftPadding, yPos),
                Size = new Size(labelWidth, 30),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 220, 220),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            cmbEntryType = new Guna2ComboBox
            {
                Location = new Point(leftPadding + labelWidth + 20, yPos),
                Size = new Size(comboBoxWidth, 36),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                BackColor = Color.FromArgb(60, 60, 63)
            };

            yPos += 55;

            // Анализ (ОБЯЗАТЕЛЬНОЕ ПОЛЕ)
            var lblAnalysis = new Guna2HtmlLabel
            {
                Text = "Анализ:",
                Location = new Point(leftPadding, yPos),
                Size = new Size(labelWidth, 30),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 220, 220),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            cmbAnalysis = new Guna2ComboBox
            {
                Location = new Point(leftPadding + labelWidth + 20, yPos),
                Size = new Size(comboBoxWidth, 36),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                BackColor = Color.FromArgb(60, 60, 63)
            };

            yPos += 55;

            // Диагноз (опционально)
            var lblDiagnosis = new Guna2HtmlLabel
            {
                Text = "Диагноз:",
                Location = new Point(leftPadding, yPos),
                Size = new Size(labelWidth, 30),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(220, 220, 220),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            cmbDiagnosis = new Guna2ComboBox
            {
                Location = new Point(leftPadding + labelWidth + 20, yPos),
                Size = new Size(comboBoxWidth, 36),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                BackColor = Color.FromArgb(60, 60, 63)
            };

            formPanel.Controls.AddRange(new Control[] {
                lblVisitDate, dtpVisitDate,
                lblDoctor, cmbDoctor,
                lblHospital, cmbHospital,
                lblDepartment, cmbDepartment,
                lblVisitType, cmbVisitType,
                lblEntryType, cmbEntryType,
                lblAnalysis, cmbAnalysis,
                lblDiagnosis, cmbDiagnosis
            });

            // Панель кнопок
            var buttonsPanel = new Guna2Panel
            {
                Location = new Point(25, 710),
                Size = new Size(1152, 70),
                FillColor = Color.Transparent
            };

            // Внутри formPanel, после добавления всех контролов:
            yPos += 55; // После последнего поля

            // Кнопка сохранить ВНУТРИ formPanel (выше)
            btnSave = new Guna2Button
            {
                Text = "Сохранить визит",
                Location = new Point((1152 - 260) / 2, yPos),
                Size = new Size(260, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(39, 174, 96),
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand
            };
            btnSave.Click += btnSave_Click;

            formPanel.Controls.Add(btnSave);

            // Добавляем все панели
            mainPanel.Controls.AddRange(new Control[] {
                headerPanel, infoPanel, formPanel, buttonsPanel
            });

            this.Controls.Add(mainPanel);
        }

        private void LoadPatientInfo()
        {
            string fullName = $"{currentPatient.surname} {currentPatient.name}";
            if (!string.IsNullOrEmpty(currentPatient.patronymic))
                fullName += $" {currentPatient.patronymic}";

            lblPatientInfo.Text = $"<span style='color:#4FC3F7; font-weight: bold;'>Пациент:</span> <span style='color:#FFFFFF; font-weight: bold;'>{fullName}</span>";
        }

        private void LoadFormData()
        {
            try
            {
                LoadPatientInfo();

                using var db = new ApplicationDbContext();

                // 1. Если есть текущий врач, загружаем только его
                if (currentDoctorId > 0)
                {
                    var currentDoctor = db.Doctors
                        .Where(d => d.id == currentDoctorId)
                        .Select(d => new
                        {
                            d.id,
                            FullName = $"{d.surname} {d.name} {d.patronymic}".Trim()
                        })
                        .FirstOrDefault();

                    if (currentDoctor != null)
                    {
                        var doctorList = new List<object> { currentDoctor };
                        cmbDoctor.DataSource = doctorList;
                        cmbDoctor.DisplayMember = "FullName";
                        cmbDoctor.ValueMember = "id";
                        cmbDoctor.SelectedIndex = 0;
                        cmbDoctor.Enabled = false; // Нельзя изменить

                        // Автоматически загружаем больницы для этого врача
                        LoadHospitalsForDoctor(currentDoctorId);
                    }
                }
                else
                {
                    // 2. Если врача нет, загружаем всех врачей
                    var allDoctors = db.Doctors
                        .OrderBy(d => d.surname)
                        .ThenBy(d => d.name)
                        .Select(d => new
                        {
                            d.id,
                            FullName = $"{d.surname} {d.name} {d.patronymic}".Trim()
                        })
                        .ToList();

                    cmbDoctor.DataSource = allDoctors;
                    cmbDoctor.DisplayMember = "FullName";
                    cmbDoctor.ValueMember = "id";
                    cmbDoctor.SelectedIndex = allDoctors.Count > 0 ? 0 : -1;
                }

                // 3. Загружаем типы визитов
                var visitTypes = db.VisitTypes.ToList();
                if (visitTypes.Count > 0)
                {
                    cmbVisitType.DataSource = visitTypes;
                    cmbVisitType.DisplayMember = "title";
                    cmbVisitType.ValueMember = "id";
                    cmbVisitType.SelectedIndex = 0;
                }
                else
                {
                    cmbVisitType.Items.Add("Нет доступных типов визитов");
                    cmbVisitType.SelectedIndex = 0;
                }

                // 4. Загружаем типы записи
                var entryTypes = db.EntryTypes.ToList();
                if (entryTypes.Count > 0)
                {
                    cmbEntryType.DataSource = entryTypes;
                    cmbEntryType.DisplayMember = "title";
                    cmbEntryType.ValueMember = "id";
                    cmbEntryType.SelectedIndex = 0;
                }
                else
                {
                    cmbEntryType.Items.Add("Нет доступных типов записи");
                    cmbEntryType.SelectedIndex = 0;
                }

                // 5. Загружаем анализы (ОБЯЗАТЕЛЬНОЕ ПОЛЕ) - ИСПРАВЛЕНО
                var analyses = db.Analysis
                    .Select(a => new
                    {
                        a.id,
                        DisplayName = a.type // Используем поле type вместо code и title
                    })
                    .OrderBy(a => a.DisplayName)
                    .ToList();

                if (analyses.Count > 0)
                {
                    cmbAnalysis.DataSource = analyses;
                    cmbAnalysis.DisplayMember = "DisplayName";
                    cmbAnalysis.ValueMember = "id";
                    cmbAnalysis.SelectedIndex = 0;
                }
                else
                {
                    // Если нет анализов, нужно создать хотя бы один
                    MessageBox.Show("Нет доступных анализов. Необходимо создать хотя бы один анализ в базе данных.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbAnalysis.Items.Add("Нет доступных анализов");
                    cmbAnalysis.SelectedIndex = 0;
                    cmbAnalysis.Enabled = false;
                    btnSave.Enabled = false;
                }

                // 6. Загружаем диагнозы (опционально) - ИСПРАВЛЕНО
                var diagnoses = db.Diseas
                    .Select(d => new
                    {
                        d.id,
                        DisplayName = d.title // Используем только title, так как code может отсутствовать
                    })
                    .OrderBy(d => d.DisplayName)
                    .ToList();

                if (diagnoses.Count > 0)
                {
                    cmbDiagnosis.DataSource = diagnoses;
                    cmbDiagnosis.DisplayMember = "DisplayName";
                    cmbDiagnosis.ValueMember = "id";
                    cmbDiagnosis.SelectedIndex = 0;
                }
                else
                {
                    cmbDiagnosis.Items.Add("Нет доступных диагнозов");
                    cmbDiagnosis.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbDoctor_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbDoctor.SelectedValue is int doctorId)
            {
                LoadHospitalsForDoctor(doctorId);
            }
        }

        private void LoadHospitalsForDoctor(int doctorId)
        {
            try
            {
                using var db = new ApplicationDbContext();

                var hospitals = (from hd in db.HospitalDepartments
                                 join dp in db.DepartmentPositions on hd.id equals dp.id_hospital_department
                                 join doctorPos in db.DoctorPositions on dp.id_position_doctor equals doctorPos.id
                                 where doctorPos.id_doctor == doctorId
                                 join h in db.Hospitals on hd.id_hospital equals h.id
                                 select new
                                 {
                                     h.id,
                                     h.name
                                 })
                                .Distinct()
                                .OrderBy(h => h.name)
                                .ToList();

                if (hospitals.Any())
                {
                    cmbHospital.DataSource = hospitals;
                    cmbHospital.DisplayMember = "name";
                    cmbHospital.ValueMember = "id";
                    cmbHospital.SelectedIndex = 0;

                    // Автоматически загружаем отделения для первой больницы
                    LoadDepartmentsForHospitalAndDoctor(hospitals[0].id, doctorId);
                }
                else
                {
                    cmbHospital.DataSource = null;
                    cmbDepartment.DataSource = null;
                    MessageBox.Show("У выбранного врача нет привязанных больниц", "Информация");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки больниц: {ex.Message}");
            }
        }

        private void CmbHospital_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbHospital.SelectedValue is int hospitalId &&
                cmbDoctor.SelectedValue is int doctorId)
            {
                LoadDepartmentsForHospitalAndDoctor(hospitalId, doctorId);
            }
        }

        private void LoadDepartmentsForHospitalAndDoctor(int hospitalId, int doctorId)
        {
            try
            {
                using var db = new ApplicationDbContext();

                var departments = (from hd in db.HospitalDepartments
                                   join dp in db.DepartmentPositions on hd.id equals dp.id_hospital_department
                                   join doctorPos in db.DoctorPositions on dp.id_position_doctor equals doctorPos.id
                                   where doctorPos.id_doctor == doctorId && hd.id_hospital == hospitalId
                                   join d in db.Departments on hd.id_department equals d.id
                                   select new
                                   {
                                       d.id,
                                       d.title
                                   })
                                 .Distinct()
                                 .OrderBy(d => d.title)
                                 .ToList();

                if (departments.Any())
                {
                    cmbDepartment.DataSource = departments;
                    cmbDepartment.DisplayMember = "title";
                    cmbDepartment.ValueMember = "id";
                    cmbDepartment.SelectedIndex = 0;
                }
                else
                {
                    cmbDepartment.DataSource = null;
                    MessageBox.Show("У выбранного врача в этой больнице нет отделений", "Информация");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отделений: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка обязательных полей
                if (cmbDoctor.SelectedValue == null ||
                    cmbHospital.SelectedValue == null ||
                    cmbDepartment.SelectedValue == null ||
                    cmbVisitType.SelectedValue == null ||
                    cmbEntryType.SelectedValue == null ||
                    cmbAnalysis.SelectedValue == null) // ДОБАВЛЕНА ПРОВЕРКА АНАЛИЗА
                {
                    MessageBox.Show("Заполните все обязательные поля", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // ПРОВЕРКА ДАТЫ - НЕ РАНЬШЕ СЕГОДНЯШНЕГО ДНЯ
                DateTime appointmentDate = dtpVisitDate.Value;
                if (appointmentDate.Date < DateTime.Today)
                {
                    MessageBox.Show("Нельзя выбрать прошедшую дату для визита!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpVisitDate.Value = DateTime.Now; // Сбрасываем на текущую дату
                    return;
                }

                // ПРОВЕРКА ВРЕМЕНИ - если выбрана сегодняшняя дата
                if (appointmentDate.Date == DateTime.Today && appointmentDate.TimeOfDay < DateTime.Now.TimeOfDay)
                {
                    MessageBox.Show("Нельзя выбрать прошедшее время на сегодня!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpVisitDate.Value = DateTime.Now; // Сбрасываем на текущее время
                    return;
                }


                using var db = new ApplicationDbContext();

                int doctorId = (int)cmbDoctor.SelectedValue;
                int hospitalId = (int)cmbHospital.SelectedValue;
                int departmentId = (int)cmbDepartment.SelectedValue;
                int visitTypeId = (int)cmbVisitType.SelectedValue;
                int entryTypeId = (int)cmbEntryType.SelectedValue;
                int analysisId = (int)cmbAnalysis.SelectedValue; // ОБЯЗАТЕЛЬНОЕ ПОЛЕ
                //DateTime appointmentDate = dtpVisitDate.Value;
                int? diagnosisId = cmbDiagnosis.SelectedValue as int?;

                // Проверка существования карты пациента
                var patientCard = db.PatientCards
                    .FirstOrDefault(pc => pc.id == patientCardId);

                if (patientCard == null)
                {
                    MessageBox.Show("Карта пациента не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка существования врача
                var doctor = db.Doctors
                    .FirstOrDefault(d => d.id == doctorId);

                if (doctor == null)
                {
                    MessageBox.Show("Врач не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка существования типа визита
                var visitType = db.VisitTypes
                    .FirstOrDefault(vt => vt.id == visitTypeId);

                if (visitType == null)
                {
                    MessageBox.Show("Тип визита не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка существования типа записи
                var entryType = db.EntryTypes
                    .FirstOrDefault(et => et.id == entryTypeId);

                if (entryType == null)
                {
                    MessageBox.Show("Тип записи не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка существования анализа (ОБЯЗАТЕЛЬНО)
                var analysis = db.Analysis
                    .FirstOrDefault(a => a.id == analysisId);

                if (analysis == null)
                {
                    MessageBox.Show("Анализ не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка диагноза если выбран
                if (diagnosisId.HasValue && diagnosisId > 0)
                {
                    var diagnosis = db.Diseas
                        .FirstOrDefault(d => d.id == diagnosisId.Value);

                    if (diagnosis == null)
                    {
                        MessageBox.Show("Диагноз не найден", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Находим расписание врача
                var departmentPosition = (from hd in db.HospitalDepartments
                                          where hd.id_hospital == hospitalId && hd.id_department == departmentId
                                          join dp in db.DepartmentPositions on hd.id equals dp.id_hospital_department
                                          join doctorPos in db.DoctorPositions on dp.id_position_doctor equals doctorPos.id
                                          where doctorPos.id_doctor == doctorId
                                          select dp).FirstOrDefault();

                if (departmentPosition == null)
                {
                    MessageBox.Show("Не удалось найти позицию врача в отделении", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Создаем или находим расписание
                var doctorWorkingHour = db.DoctorWorkingHours
                    .FirstOrDefault(dw => dw.id_department_position == departmentPosition.id &&
                                          dw.start_time == appointmentDate);

                if (doctorWorkingHour == null)
                {
                    doctorWorkingHour = new DoctorWorkingHours
                    {
                        id_department_position = departmentPosition.id,
                        start_time = appointmentDate,
                        end_time = appointmentDate.AddHours(1)
                    };

                    db.DoctorWorkingHours.Add(doctorWorkingHour);
                    db.SaveChanges();
                }

                // Проверяем, нет ли уже визита на это время
                var existingVisit = db.PatientVisits
                    .FirstOrDefault(v => v.id_doctor_working_hours == doctorWorkingHour.id &&
                                         v.id_card == patientCardId);

                if (existingVisit != null)
                {
                    MessageBox.Show("На это время уже записан визит для данного пациента", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Сохраняем визит СО ВСЕМИ ПОЛЯМИ
                var visit = new PatientVisits
                {
                    id_card = patientCardId,
                    id_doctor_working_hours = doctorWorkingHour.id,
                    id_visit_type = visitTypeId,
                    id_entry_type = entryTypeId,
                    id_analysis = analysisId, // ОБЯЗАТЕЛЬНОЕ ПОЛЕ
                    appointment_date = appointmentDate,
                    adding_date = DateTime.Now, // ПОЛЕ adding_date
                    completed = false,
                    document = "Визит создан"
                };

                db.PatientVisits.Add(visit);
                db.SaveChanges();

                // Сохраняем диагноз, если выбран
                if (diagnosisId.HasValue && diagnosisId > 0)
                {
                    var visitDiagnosis = new VisitDiagnoses
                    {
                        id_visit = visit.id,
                        id_diseas = diagnosisId.Value
                    };

                    db.VisitDiagnoses.Add(visitDiagnosis);
                    db.SaveChanges();
                }

                MessageBox.Show("Визит успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Закрываем форму
                if (this.Parent != null)
                {
                    this.Visible = false;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (DbUpdateException dbEx)
            {
                string errorMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                MessageBox.Show($"Ошибка базы данных: {errorMessage}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Ищем существующую форму PatientVisitsForm
            foreach (Form form in Application.OpenForms)
            {
                if (form is PatientVisitsForm patientVisitsForm &&
                    patientVisitsForm.currentPatient.id == currentPatient.id)
                {
                    // Обновляем данные если нужно
                    patientVisitsForm.LoadVisits();
                    patientVisitsForm.Visible = true;
                    patientVisitsForm.BringToFront();
                    this.Close();
                    return;
                }
            }

            // Если форма не найдена, создаем новую
            var newVisitsForm = new PatientVisitsForm(currentPatient);

            // Пытаемся найти родительскую форму DoctorsMenuForm
            var doctorsMenuForm = FindParentDoctorsMenuForm();
            if (doctorsMenuForm != null)
            {
                doctorsMenuForm.OpenChildForm(newVisitsForm);
            }
            else
            {
                newVisitsForm.Show();
            }

            this.Close();
        }

        // Метод для поиска родительской формы DoctorsMenuForm
        private DoctorsMenuForm? FindParentDoctorsMenuForm()
        {
            // Ищем в иерархии контролов
            Control parent = this.Parent;
            while (parent != null)
            {
                if (parent is DoctorsMenuForm doctorsForm)
                {
                    return doctorsForm;
                }
                parent = parent.Parent;
            }

            // Ищем среди открытых форм
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is DoctorsMenuForm doctorsForm)
                {
                    return doctorsForm;
                }
            }

            return null;
        }

        private PatientVisitsForm FindParentPatientVisitsForm()
        {
            Control parent = this.Parent;
            while (parent != null)
            {
                if (parent is PatientVisitsForm visitsForm)
                {
                    return visitsForm;
                }
                parent = parent.Parent;
            }
            return null;
        }
    }
}