#nullable disable

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PatientsAccounting.Models;

namespace PatientAccounting
{
    public partial class Appointment : Form
    {
        private ApplicationDbContext _context;
        private int _currentDoctorId;

        // Элементы управления Guna2
        private Guna2DataGridView dataGridViewSchedule;
        private Guna2Button btnFilter;
        private Guna2Button btnClearFilter;
        private Guna2Button btnBack;
        private Guna2DateTimePicker dtpFromDate;
        private Guna2DateTimePicker dtpToDate;
        private Guna2HtmlLabel lblFrom;
        private Guna2HtmlLabel lblTo;
        private Guna2HtmlLabel lblRecordCount;
        private Guna2Panel headerPanel;
        private Guna2HtmlLabel headerLabel;
        private Guna2Panel filterPanel;
        private Guna2Panel contentPanel;

        public Appointment(int doctorId)
        {
            _currentDoctorId = doctorId;
            _context = new ApplicationDbContext();
            InitializeComponent();
            SetupUI();
            LoadSchedule();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Appointment
            // 
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(1468, 920);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Appointment";
            StartPosition = FormStartPosition.Manual;
            Text = "Расписание приемов";
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
            headerPanel = new Guna2Panel
            {
                Location = new Point(25, 25),
                Size = new Size(1152, 70),
                FillColor = Color.Transparent
            };

            // Заголовок "Расписание приемов"
            headerLabel = new Guna2HtmlLabel
            {
                Text = "Расписание приемов",
                Location = new Point(0, 15),
                Size = new Size(500, 40),
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            // Кнопка "Назад" - в правом верхнем углу
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
            btnBack.Click += (s, e) => this.Close();

            headerPanel.Controls.AddRange(new Control[] {
        headerLabel,
        btnBack
    });

            // Панель фильтров - РАСПОЛАГАЕМ ПОД ЗАГОЛОВКОМ И СДВИГАЕМ ВЛЕВО
            filterPanel = new Guna2Panel
            {
                Location = new Point(25, 110), // Придвинули ближе к заголовку
                Size = new Size(1152, 50),
                FillColor = Color.Transparent
            };

            // Фильтры смещаем ВЛЕВО, чтобы были под словом "Расписание"
            int filterY = 10;
            int startX = 0; // НАЧИНАЕМ С НУЛЯ - КРАЙНЕЕ ЛЕВОЕ ПОЛОЖЕНИЕ

            // Элементы фильтрации - УВЕЛИЧЕНЫ ШИРИНЫ
            lblFrom = new Guna2HtmlLabel
            {
                Text = "От:",
                Location = new Point(startX, filterY),
                Size = new Size(40, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleLeft
            };

            dtpFromDate = new Guna2DateTimePicker
            {
                Location = new Point(startX + 45, filterY),
                Size = new Size(180, 36), // УВЕЛИЧЕНА ШИРИНА С 130 ДО 180
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                Checked = false,
                Format = DateTimePickerFormat.Short,
                Animated = true
            };

            lblTo = new Guna2HtmlLabel
            {
                Text = "До:",
                Location = new Point(startX + 240, filterY), // Смещено из-за увеличения ширины
                Size = new Size(40, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleLeft
            };

            dtpToDate = new Guna2DateTimePicker
            {
                Location = new Point(startX + 285, filterY),
                Size = new Size(180, 36), // УВЕЛИЧЕНА ШИРИНА С 130 ДО 180
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                Checked = false,
                Format = DateTimePickerFormat.Short,
                Animated = true
            };

            btnFilter = new Guna2Button
            {
                Text = "Фильтр",
                Location = new Point(startX + 480, filterY),
                Size = new Size(120, 36),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(70, 130, 180),
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand
            };
            btnFilter.Click += btnFilter_Click;

            btnClearFilter = new Guna2Button
            {
                Text = "Сбросить",
                Location = new Point(startX + 615, filterY),
                Size = new Size(130, 36),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(100, 100, 100),
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand
            };
            btnClearFilter.Click += btnClearFilter_Click;

            lblRecordCount = new Guna2HtmlLabel
            {
                Text = "Найдено записей: 0",
                Location = new Point(startX + 760, filterY+3),
                Size = new Size(250, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleLeft
            };

            filterPanel.Controls.AddRange(new Control[] {
        lblFrom,
        dtpFromDate,
        lblTo,
        dtpToDate,
        btnFilter,
        btnClearFilter,
        lblRecordCount
    });

            // Панель контента с DataGridView
            contentPanel = new Guna2Panel
            {
                Location = new Point(25, 180), // Подвинули выше
                Size = new Size(1152, 545),
                FillColor = Color.Transparent
            };

            // DataGridView Guna2
            dataGridViewSchedule = new Guna2DataGridView
            {
                Location = new Point(0, 0),
                Size = new Size(1152, 525),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 50,
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
                    SelectionBackColor = Color.FromArgb(90, 130, 180),
                    SelectionForeColor = Color.White,
                    Padding = new Padding(12, 10, 12, 10),
                    WrapMode = DataGridViewTriState.True
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(70, 130, 180),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Padding = new Padding(12, 0, 0, 0)
                },
                RowTemplate = { Height = 45 },
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(70, 70, 73),
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };

            contentPanel.Controls.Add(dataGridViewSchedule);

            // Добавляем все панели на основную панель
            mainPanel.Controls.AddRange(new Control[] {
        headerPanel,
        filterPanel,
        contentPanel
    });

            this.Controls.Add(mainPanel);
        }

        private void LoadSchedule()
        {
            try
            {
                var today = DateTime.Today;

                // Используем _currentDoctorId (который уже установлен из CurrentUser)
                var schedule = (from pv in _context.PatientVisits
                                join ds in _context.DoctorWorkingHours on pv.id_doctor_working_hours equals ds.id
                                join dp in _context.DepartmentPositions on ds.id_department_position equals dp.id
                                join dop in _context.DoctorPositions on dp.id_position_doctor equals dop.id
                                join d in _context.Doctors on dop.id_doctor equals d.id
                                join hd in _context.HospitalDepartments on dp.id_hospital_department equals hd.id
                                join h in _context.Hospitals on hd.id_hospital equals h.id
                                join pc in _context.PatientCards on pv.id_card equals pc.id
                                join pat in _context.Patients on pc.id_patient equals pat.id
                                where d.id == _currentDoctorId && // Используем ID врача из CurrentUser
                                      pv.appointment_date >= today
                                orderby pv.appointment_date, ds.start_time
                                select new
                                {
                                    Дата_приема = pv.appointment_date,
                                    Время_приема = ds.start_time,
                                    Поликлиника = h.name,
                                    Фамилия = pat.surname,
                                    Имя = pat.name,
                                    Отчество = pat.patronymic,
                                    Код_карты = pc.code,
                                    ФИО = pat.surname + " " + pat.name + (pat.patronymic != null ? " " + pat.patronymic : "")
                                }).ToList();

                // Форматируем дату и время отдельно
                var result = schedule.Select(v => new
                {
                    Дата = v.Дата_приема.ToString("dd.MM.yyyy"),
                    Время = v.Время_приема.ToString("HH:mm"),
                    v.Поликлиника,
                    ФИО = v.ФИО,
                    v.Код_карты
                }).ToList();

                dataGridViewSchedule.DataSource = result;
                lblRecordCount.Text = $"Найдено записей: {result.Count}";

                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViewColumns()
        {
            try
            {
                if (dataGridViewSchedule == null || dataGridViewSchedule.Columns.Count == 0)
                {
                    return;
                }

                // Вариант 1: По индексам (уже показано выше)

                // Вариант 2: По именам свойств (более безопасно)
                foreach (DataGridViewColumn column in dataGridViewSchedule.Columns)
                {
                    if (column != null)
                    {
                        // Устанавливаем заголовки
                        if (column.Name == "Date" || column.DataPropertyName == "Date")
                        {
                            column.HeaderText = "Дата";
                            column.FillWeight = 12;
                            column.MinimumWidth = 100;
                        }
                        else if (column.Name == "Time" || column.DataPropertyName == "Time")
                        {
                            column.HeaderText = "Время";
                            column.FillWeight = 10;
                            column.MinimumWidth = 80;
                        }
                        else if (column.Name == "Hospital" || column.DataPropertyName == "Hospital")
                        {
                            column.HeaderText = "Поликлиника";
                            column.FillWeight = 25;
                            column.MinimumWidth = 150;
                        }
                        else if (column.Name == "FullName" || column.DataPropertyName == "FullName")
                        {
                            column.HeaderText = "ФИО пациента";
                            column.FillWeight = 38;
                            column.MinimumWidth = 200;
                        }
                        else if (column.Name == "Card" || column.DataPropertyName == "Card")
                        {
                            column.HeaderText = "Карта";
                            column.FillWeight = 15;
                            column.MinimumWidth = 100;
                        }
                        else
                        {
                            // Для других колонок
                            column.FillWeight = 100 / dataGridViewSchedule.Columns.Count;
                            column.MinimumWidth = 80;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка в ConfigureDataGridViewColumns: {ex.Message}");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                var today = DateTime.Today;

                // ИСПРАВЛЕННЫЙ ЗАПРОС - используем время из DoctorWorkingHours
                var query = from pv in _context.PatientVisits
                            join ds in _context.DoctorWorkingHours on pv.id_doctor_working_hours equals ds.id
                            join dp in _context.DepartmentPositions on ds.id_department_position equals dp.id
                            join dop in _context.DoctorPositions on dp.id_position_doctor equals dop.id
                            join d in _context.Doctors on dop.id_doctor equals d.id
                            join hd in _context.HospitalDepartments on dp.id_hospital_department equals hd.id
                            join h in _context.Hospitals on hd.id_hospital equals h.id
                            join pc in _context.PatientCards on pv.id_card equals pc.id
                            join pat in _context.Patients on pc.id_patient equals pat.id
                            where d.id == _currentDoctorId &&
                                  pv.appointment_date >= today
                            select new
                            {
                                Дата_приема = pv.appointment_date,
                                Время_приема = ds.start_time,  // Время из расписания врача
                                Поликлиника = h.name,
                                Фамилия = pat.surname,
                                Имя = pat.name,
                                Отчество = pat.patronymic,
                                Код_карты = pc.code
                            };

                if (dtpFromDate.Checked)
                {
                    var fromDate = dtpFromDate.Value.Date;
                    query = query.Where(v => v.Дата_приема >= fromDate);
                }

                if (dtpToDate.Checked)
                {
                    var toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);
                    query = query.Where(v => v.Дата_приема <= toDate);
                }

                var result = query.OrderBy(v => v.Дата_приема)
                    .ThenBy(v => v.Время_приема)
                    .Select(v => new
                    {
                        Дата = v.Дата_приема.ToString("dd.MM.yyyy"),
                        Время = v.Время_приема.ToString("HH:mm"),  // Форматируем как часы:минуты (24-часовой формат)
                        v.Поликлиника,
                        ФИО = v.Фамилия + " " + v.Имя + (v.Отчество != null ? " " + v.Отчество : ""),
                        v.Код_карты
                    })
                    .ToList();

                dataGridViewSchedule.DataSource = result;
                lblRecordCount.Text = $"Найдено записей: {result.Count}";

                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;
            LoadSchedule();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context?.Dispose();
        }
    }
}