#nullable disable

using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Forms;
using PatientsAccounting.Models;
using PatientsAcounting.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PatientAccounting
{
    public partial class PatientVisitsForm : Form
    {
        public Patients currentPatient;
        private Guna2DataGridView dgvVisits;
        private Guna2Button btnBack;
        private Guna2Button btnAddVisit;
        private Guna2HtmlLabel lblPatientInfo;
        private Guna2HtmlLabel lblNoVisits;

        public PatientVisitsForm(Patients patient)
        {
            currentPatient = patient;
            InitializeComponent();
            SetupUI();
            LoadPatientInfo();
            LoadVisits();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(1202, 759); // Установлен нужный размер
            this.Name = "PatientVisitsForm";
            this.Text = "История визитов пациента";
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ResumeLayout(false);
        }

        private void SetupUI()
        {
            // Основная панель
            var mainPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(45, 45, 48)
            };

            // Заголовок и кнопка назад
            var headerPanel = new Guna2Panel
            {
                Location = new Point(0, 10),
                Size = new Size(1202, 60),
                FillColor = Color.Transparent
            };

            var lblTitle = new Guna2HtmlLabel
            {
                Text = "История визитов",
                Location = new Point(25, 5),
                Size = new Size(300, 40),
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            btnBack = new Guna2Button
            {
                Text = "Назад",
                Location = new Point(1060, 20), // Обновлено под новый размер
                Size = new Size(110, 32),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(70, 130, 180),
                BorderRadius = 6,
                Animated = true,
                Cursor = Cursors.Hand
            };
            btnBack.Click += btnBack_Click;

            headerPanel.Controls.AddRange(new Control[] { lblTitle, btnBack });

            // Информация о пациенте
            var infoPanel = new Guna2Panel
            {
                Location = new Point(0, 70),
                Size = new Size(1202, 40),
                FillColor = Color.Transparent
            };

            lblPatientInfo = new Guna2HtmlLabel
            {
                Location = new Point(25, 5),
                Size = new Size(1150, 30), // Обновлено под новый размер
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 220, 220),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            infoPanel.Controls.Add(lblPatientInfo);

            // Таблица визитов
            var tablePanel = new Guna2Panel
            {
                Location = new Point(0, 120),
                Size = new Size(1202, 570), // Обновлено под новый размер
                FillColor = Color.Transparent
            };

            dgvVisits = new Guna2DataGridView
            {
                Location = new Point(25, 0),
                Size = new Size(1152, 560), // Обновлено под новый размер
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.White,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ColumnHeadersHeight = 40,
                BackgroundColor = Color.FromArgb(50, 50, 53),
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(55, 55, 58),
                    ForeColor = Color.White
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(60, 60, 63),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(80, 140, 200),
                    SelectionForeColor = Color.White,
                    Padding = new Padding(8, 5, 8, 5),
                    WrapMode = DataGridViewTriState.True
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(70, 130, 180),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    WrapMode = DataGridViewTriState.True
                },
                RowTemplate = { Height = 38 },
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(70, 70, 73),
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };

            lblNoVisits = new Guna2HtmlLabel
            {
                Text = "<div style='text-align: center;'>Нет записей о визитах</div>",
                Location = new Point(476, 220), // Центрировано под новый размер
                Size = new Size(250, 40),
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.FromArgb(180, 180, 180),
                TextAlignment = ContentAlignment.MiddleCenter,
                Visible = false
            };

            tablePanel.Controls.AddRange(new Control[] { dgvVisits, lblNoVisits });

            // Панель кнопок
            var buttonsPanel = new Guna2Panel
            {
                Location = new Point(0, 700), // Обновлено положение
                Size = new Size(1202, 50),
                FillColor = Color.Transparent
            };

            btnAddVisit = new Guna2Button
            {
                Text = "Добавить визит",
                Location = new Point(1015, 10), // Обновлено под новый размер
                Size = new Size(170, 32),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(39, 174, 96),
                BorderRadius = 6,
                Animated = true,
                Cursor = Cursors.Hand
            };
            btnAddVisit.Click += btnAddVisit_Click;

            buttonsPanel.Controls.Add(btnAddVisit);

            // Добавляем все панели
            mainPanel.Controls.AddRange(new Control[] {
                headerPanel, infoPanel, tablePanel, buttonsPanel
            });

            this.Controls.Add(mainPanel);
        }

        private void LoadPatientInfo()
        {
            string fullName = $"{currentPatient.surname} {currentPatient.name}";
            if (!string.IsNullOrEmpty(currentPatient.patronymic))
                fullName += $" {currentPatient.patronymic}";

            string snils = string.IsNullOrEmpty(currentPatient.snils)
                ? "СНИЛС не указан"
                : FormatSnils(currentPatient.snils);

            lblPatientInfo.Text = $"Пациент: <span style='color:#4FC3F7;'>{fullName}</span> | СНИЛС: <span style='color:#81C784;'>{snils}</span>";
        }

        private string FormatSnils(string snils)
        {
            if (string.IsNullOrEmpty(snils) || snils.Length < 11)
                return snils;

            return $"{snils.Substring(0, 3)}-{snils.Substring(3, 3)}-{snils.Substring(6, 3)} {snils.Substring(9)}";
        }

         public void LoadVisits()
        {
            try
            {
                using var db = new ApplicationDbContext();

                // Находим медкарту пациента
                var patientCard = db.PatientCards
                    .FirstOrDefault(pc => pc.id_patient == currentPatient.id);

                if (patientCard == null)
                {
                    ShowNoData("Медкарта не найдена");
                    return;
                }

                // Получаем визиты с явным указанием полей
                var visitsQuery = from v in db.PatientVisits
                                  where v.id_card == patientCard.id
                                  select new
                                  {
                                      v.id,
                                      v.appointment_date,
                                      v.id_doctor_working_hours,
                                      v.completed,
                                      v.document,
                                      v.id_visit_type,
                                  };

                var visits = visitsQuery
                    .OrderByDescending(v => v.appointment_date)
                    .ToList();

                if (!visits.Any())
                {
                    ShowNoData("Нет записей о визитах");
                    return;
                }

                // Собираем данные для отображения
                var visitData = new List<object>();

                foreach (var visit in visits)
                {
                    string doctorName = "Не указан";
                    string hospitalName = "Не указана";
                    string visitType = "Не указан";
                    string diagnosis = "Не указан";
                    string visitTime = "Не указано";

                    // Получаем информацию о враче, поликлинике и времени через DoctorWorkingHours
                    if (visit.id_doctor_working_hours > 0)
                    {
                        try
                        {
                            var doctorWorkingInfo = (from dw in db.DoctorWorkingHours
                                                     where dw.id == visit.id_doctor_working_hours
                                                     join dp in db.DepartmentPositions on dw.id_department_position equals dp.id
                                                     join dpos in db.DoctorPositions on dp.id_position_doctor equals dpos.id
                                                     join doc in db.Doctors on dpos.id_doctor equals doc.id
                                                     join hd in db.HospitalDepartments on dp.id_hospital_department equals hd.id
                                                     join hosp in db.Hospitals on hd.id_hospital equals hosp.id
                                                     select new
                                                     {
                                                         DoctorSurname = doc.surname,
                                                         DoctorName = doc.name,
                                                         DoctorPatronymic = doc.patronymic,
                                                         HospitalName = hosp.name,
                                                         StartTime = dw.start_time  // Это DateTime
                                                     }).FirstOrDefault();

                            if (doctorWorkingInfo != null)
                            {
                                doctorName = $"{doctorWorkingInfo.DoctorSurname} {doctorWorkingInfo.DoctorName} {doctorWorkingInfo.DoctorPatronymic}".Trim();
                                hospitalName = doctorWorkingInfo.HospitalName ?? "Не указана";
                                // Берем только время из DateTime
                                visitTime = doctorWorkingInfo.StartTime.ToString("HH:mm");
                            }
                        }
                        catch (Exception)
                        {
                            // Если не удалось получить данные - оставляем значения по умолчанию
                        }
                    }

                    // Получаем тип визита
                    if (visit.id_visit_type > 0)
                    {
                        try
                        {
                            var type = db.VisitTypes
                                .Where(vt => vt.id == visit.id_visit_type)
                                .Select(vt => vt.title)
                                .FirstOrDefault();

                            visitType = type ?? "Не указан";
                        }
                        catch (Exception)
                        {
                            visitType = "Не указан";
                        }
                    }

                    // Получаем диагноз
                    try
                    {
                        var diagnosisInfo = (from vd in db.VisitDiagnoses
                                             where vd.id_visit == visit.id
                                             join d in db.Diseas on vd.id_diseas equals d.id
                                             select new
                                             {
                                                 DiseaseCode = d.code,
                                                 DiseaseTitle = d.title
                                             }).FirstOrDefault();

                        if (diagnosisInfo != null)
                        {
                            diagnosis = $"{diagnosisInfo.DiseaseCode} - {diagnosisInfo.DiseaseTitle}";
                        }
                    }
                    catch (Exception)
                    {
                        diagnosis = "Не указан";
                    }

                    visitData.Add(new
                    {
                        Дата = visit.appointment_date.ToString("dd.MM.yyyy"),
                        Время = visitTime,
                        Врач = doctorName,
                        Поликлиника = hospitalName,
                        Тип_визита = visitType,
                        Статус = visit.completed ? "Завершен" : "Запланирован",
                        Диагноз = diagnosis
                    });
                }

                // Отображаем данные в таблице
                dgvVisits.DataSource = visitData;

                // Настраиваем внешний вид таблицы под новый размер
                // Настраиваем внешний вид таблицы под новый размер
                if (dgvVisits.Columns.Count > 0)
                {
                    // Общая ширина таблицы: 1152 пикселя
                    // Распределяем пропорционально
                    dgvVisits.Columns[0].Width = 110;   // Дата - УВЕЛИЧЕН
                    dgvVisits.Columns[1].Width = 95;    // Время - УВЕЛИЧЕН
                    dgvVisits.Columns[2].Width = 170;    // Врач - УВЕЛИЧЕН
                    dgvVisits.Columns[3].Width = 160;    // Поликлиника - УВЕЛИЧЕН
                    dgvVisits.Columns[4].Width = 130;    // Тип визита - УВЕЛИЧЕН
                    dgvVisits.Columns[5].Width = 130;    // Статус - УВЕЛИЧЕН
                    dgvVisits.Columns[6].Width = 350;    // Диагноз - УВЕЛИЧЕН

                    // Раскрашиваем статусы
                    foreach (DataGridViewRow row in dgvVisits.Rows)
                    {
                        if (row.Cells[5]?.Value?.ToString() == "Завершен")
                        {
                            row.Cells[5].Style.ForeColor = Color.FromArgb(76, 175, 80);
                            row.Cells[5].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        }
                        else if (row.Cells[5]?.Value?.ToString() == "Запланирован")
                        {
                            row.Cells[5].Style.ForeColor = Color.FromArgb(255, 193, 7);
                            row.Cells[5].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        }
                    }
                }

                dgvVisits.Visible = true;
                lblNoVisits.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке визитов: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowNoData(string message)
        {
            dgvVisits.DataSource = null;
            dgvVisits.Visible = false;
            lblNoVisits.Text = $"<div style='text-align: center;'>{message}</div>";
            lblNoVisits.Visible = true;
        }

        private void ConfigureColumns()
        {
            if (dgvVisits.Columns.Count == 0) return;

            try
            {
                // Устанавливаем ширины колонок под новый размер
                SetColumnWidth("Дата", 90);
                SetColumnWidth("Время", 70);
                SetColumnWidth("Врач", 180);
                SetColumnWidth("Поликлиника", 170);
                SetColumnWidth("Тип визита", 130);
                SetColumnWidth("Статус", 100);
                SetColumnWidth("Диагноз", 300);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в ConfigureColumns: {ex.Message}");
            }
        }

        private void SetColumnWidth(string columnName, int width)
        {
            try
            {
                foreach (DataGridViewColumn col in dgvVisits.Columns)
                {
                    if (col.HeaderText == columnName)
                    {
                        col.Width = width;
                        return;
                    }
                }

                foreach (DataGridViewColumn col in dgvVisits.Columns)
                {
                    if (col.Name == columnName ||
                        col.DataPropertyName == columnName ||
                        col.Name.Contains(columnName.Replace(" ", "")))
                    {
                        col.Width = width;
                        col.HeaderText = columnName;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при установке ширины колонки '{columnName}': {ex.Message}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Ищем родительскую форму DoctorsMenuForm
            var doctorsMenuForm = FindParentDoctorsMenuForm();

            if (doctorsMenuForm != null)
            {
                // Открываем форму поиска пациентов в родительской форме
                var patientSearchForm = new PatientSearch();
                doctorsMenuForm.OpenChildForm(patientSearchForm);
            }
            else
            {
                // Если не нашли родительскую форму, просто закрываем текущую
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private DoctorsMenuForm? FindParentDoctorsMenuForm()
        {
            // Ищем DoctorsMenuForm в иерархии форм
            Control parent = this.Parent;

            // Если форма открыта как дочерняя в панели
            if (parent != null)
            {
                // Идем вверх по иерархии контролов
                while (parent != null)
                {
                    if (parent is DoctorsMenuForm doctorsForm)
                    {
                        return doctorsForm;
                    }
                    parent = parent.Parent;
                }
            }

            // Если форма открыта как модальное окно, ищем среди открытых форм
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is DoctorsMenuForm doctorsForm)
                {
                    return doctorsForm;
                }
            }

            return null;
        }

        private PatientVisitsForm? FindParentPatientVisitsForm()
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

        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            using var db = new ApplicationDbContext();
            var patientCard = db.PatientCards
                .FirstOrDefault(pc => pc.id_patient == currentPatient.id);

            if (patientCard != null)
            {
                // ПЕРЕДАЕМ ID ТЕКУЩЕГО ВРАЧА ИЗ CurrentUser
                int currentDoctorId = CurrentUser.DoctorId ?? 0;
                Console.WriteLine($"Создаем форму визита. ID врача: {currentDoctorId}");

                var addVisitForm = new AddPatientVisitForm(currentPatient, patientCard.id, currentDoctorId);

                // Открываем форму в панели или как диалог
                var parentForm = this.ParentForm as DoctorsMenuForm;
                if (parentForm != null)
                {
                    parentForm.OpenChildForm(addVisitForm);
                }
                else
                {
                    addVisitForm.FormClosed += (s, args) => LoadVisits();
                    addVisitForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Медкарта пациента не найдена", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

    }
}