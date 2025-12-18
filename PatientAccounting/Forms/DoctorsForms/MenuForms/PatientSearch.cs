#nullable disable

using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Forms;
using PatientsAccounting.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PatientAccounting
{
    public partial class PatientSearch : Form
    {
        private Guna2DataGridView dgvPatients;
        private Guna2TextBox txtSearch;
        private Guna2Button btnSearch;
        private Guna2Button btnSelect;
        private Guna2Button btnBack;
        private Guna2Button btnClear;
        private Guna2HtmlLabel lblTitle;
        private Guna2HtmlLabel lblNoResults;

        // Размеры для контейнера 1202x759
        private const int ContainerWidth = 1202;
        private const int ContainerHeight = 759;

        public PatientSearch()
        {
            InitializeComponent();
            SetupUI();
            LoadPatients();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // PatientSearch
            // 
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(1468, 920);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PatientSearch";
            StartPosition = FormStartPosition.Manual;
            Text = "Поиск пациента";
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
                Size = new Size(ContainerWidth - 50, 60),
                FillColor = Color.Transparent
            };

            // Заголовок "Поиск пациента"
            lblTitle = new Guna2HtmlLabel
            {
                Text = "Поиск пациента",
                Location = new Point(0, 10),
                Size = new Size(350, 40),
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            // Кнопка "Назад"
            btnBack = new Guna2Button
            {
                Text = "Назад",
                Location = new Point(headerPanel.Width - 140, 15),
                Size = new Size(130, 35),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(70, 130, 180),
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand
            };
            btnBack.Click += btnBack_Click;

            headerPanel.Controls.AddRange(new Control[] {
                lblTitle,
                btnBack
            });

            // Панель поиска
            var searchPanel = new Guna2Panel
            {
                Location = new Point(25, 105),
                Size = new Size(ContainerWidth - 50, 55),
                FillColor = Color.Transparent
            };

            // Поле поиска (увеличено)
            txtSearch = new Guna2TextBox
            {
                Location = new Point(0, 10),
                Size = new Size(500, 38),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(60, 60, 63),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                PlaceholderText = "ФИО или СНИЛС...",
                PlaceholderForeColor = Color.FromArgb(150, 150, 150),
                Animated = true
            };
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Кнопка поиска (увеличена)
            btnSearch = new Guna2Button
            {
                Text = "Найти",
                Location = new Point(515, 10),
                Size = new Size(110, 38),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(70, 130, 180),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand
            };
            btnSearch.Click += btnSearch_Click;

            // Кнопка сброса (увеличена)
            btnClear = new Guna2Button
            {
                Text = "Очистить",
                Location = new Point(640, 10),
                Size = new Size(130, 38),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(120, 120, 120),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand
            };
            btnClear.Click += btnClear_Click;

            searchPanel.Controls.AddRange(new Control[] {
                txtSearch,
                btnSearch,
                btnClear
            });

            // Панель с таблицей (увеличена для контейнера)
            var tablePanel = new Guna2Panel
            {
                Location = new Point(25, 180),
                Size = new Size(ContainerWidth - 50, ContainerHeight - 280),
                FillColor = Color.Transparent
            };

            // DataGridView пациентов - увеличен для контейнера
            dgvPatients = new Guna2DataGridView
            {
                Location = new Point(0, 0),
                Size = new Size(tablePanel.Width, tablePanel.Height - 50),
                Font = new Font("Segoe UI", 10),
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
                ColumnHeadersHeight = 45,
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
                    Padding = new Padding(10, 6, 10, 6)
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(70, 130, 180),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Padding = new Padding(12, 0, 0, 0)
                },
                RowTemplate = { Height = 40 },
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(70, 70, 73)
            };

            // Подписываемся на событие двойного клика
            dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;

            // Метка для отображения "нет результатов"
            lblNoResults = new Guna2HtmlLabel
            {
                Text = "<div style='text-align: center;'>Для отображения списка пациентов<br/>введите данные для поиска</div>",
                Location = new Point((tablePanel.Width - 400) / 2, (tablePanel.Height - 80) / 2),
                Size = new Size(400, 80),
                Font = new Font("Segoe UI", 14, FontStyle.Regular),
                ForeColor = Color.FromArgb(200, 200, 200),
                TextAlignment = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Visible = false
            };

            tablePanel.Controls.AddRange(new Control[] {
                dgvPatients,
                lblNoResults
            });

            // Панель кнопок
            var buttonsPanel = new Guna2Panel
            {
                Location = new Point(25, ContainerHeight - 80),
                Size = new Size(ContainerWidth - 50, 60),
                FillColor = Color.Transparent
            };

            // Кнопка "Выбрать" (увеличена)
            btnSelect = new Guna2Button
            {
                Text = "Выбрать",
                Location = new Point(buttonsPanel.Width - 200, 10),
                Size = new Size(200, 40),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(39, 174, 96),
                BorderColor = Color.Transparent,
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnSelect.Click += btnSelect_Click;

            buttonsPanel.Controls.Add(btnSelect);

            // Добавляем все панели на основную панель
            mainPanel.Controls.AddRange(new Control[] {
                headerPanel,
                searchPanel,
                tablePanel,
                buttonsPanel
            });

            this.Controls.Add(mainPanel);
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectPatientFromGrid();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var timer = new System.Windows.Forms.Timer { Interval = 350 };
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                LoadPatients(txtSearch.Text.Trim());
            };
            timer.Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPatients(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadPatients();
        }

        private void LoadPatients(string search = "")
        {
            try
            {
                using var db = new ApplicationDbContext();

                var query = from p in db.Patients
                            join pc in db.PatientCards on p.id equals pc.id_patient into patientCards
                            from card in patientCards.DefaultIfEmpty()
                            select new
                            {
                                ID = p.id,
                                Surname = p.surname,
                                Name = p.name,
                                Patronymic = p.patronymic,
                                Snils = p.snils,
                                CardCode = card != null ? card.code.ToString() : "Нет карты"
                            };

                if (!string.IsNullOrEmpty(search))
                {
                    search = search.ToLower();
                    query = query.Where(x =>
                        x.Surname.ToLower().Contains(search) ||
                        x.Name.ToLower().Contains(search) ||
                        x.Patronymic.ToLower().Contains(search) ||
                        x.Snils.ToLower().Contains(search));
                }

                var result = query
                    .OrderBy(x => x.Surname)
                    .ThenBy(x => x.Name)
                    .ThenBy(x => x.Patronymic)
                    .ToList();

                if (result.Any())
                {
                    // Очищаем существующие колонки
                    dgvPatients.Columns.Clear();

                    // Создаем колонки вручную
                    DataGridViewColumn idColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "ID",
                        DataPropertyName = "ID",
                        Visible = false
                    };

                    DataGridViewColumn fullNameColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "FullName",
                        HeaderText = "ФИО",
                        DataPropertyName = "FullName",
                        Width = (int)(dgvPatients.Width * 0.5)
                    };

                    DataGridViewColumn snilsColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "SnilsFormatted",
                        HeaderText = "СНИЛС",
                        DataPropertyName = "SnilsFormatted",
                        Width = (int)(dgvPatients.Width * 0.25)
                    };

                    DataGridViewColumn cardColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "Card",
                        HeaderText = "Карта",
                        DataPropertyName = "Card",
                        Width = (int)(dgvPatients.Width * 0.25)
                    };

                    dgvPatients.Columns.AddRange(idColumn, fullNameColumn, snilsColumn, cardColumn);

                    // Формируем данные для отображения
                    var displayList = result.Select(x => new
                    {
                        ID = x.ID,
                        FullName = x.Surname + " " + x.Name + (string.IsNullOrEmpty(x.Patronymic) ? "" : " " + x.Patronymic),
                        SnilsFormatted = string.IsNullOrEmpty(x.Snils) ? "Не указан" : FormatSnils(x.Snils),
                        Card = x.CardCode
                    }).ToList();

                    // Устанавливаем источник данных
                    dgvPatients.DataSource = displayList;

                    // Сохраняем ID в Tag строки
                    for (int i = 0; i < dgvPatients.Rows.Count && i < result.Count; i++)
                    {
                        dgvPatients.Rows[i].Tag = result[i].ID;
                    }

                    dgvPatients.Visible = true;
                    lblNoResults.Visible = false;
                    btnSelect.Enabled = true;
                }
                else
                {
                    dgvPatients.DataSource = null;
                    dgvPatients.Columns.Clear();
                    dgvPatients.Visible = false;
                    lblNoResults.Visible = true;

                    if (!string.IsNullOrEmpty(search))
                    {
                        lblNoResults.Text = "<div style='text-align: center;'>Пациенты не найдены<br/>Попробуйте изменить поисковый запрос</div>";
                    }
                    else
                    {
                        lblNoResults.Text = "<div style='text-align: center;'>Для отображения списка пациентов<br/>введите данные для поиска</div>";
                    }

                    btnSelect.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пациентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSelect.Enabled = false;
            }
        }

        private string FormatSnils(string snils)
        {
            if (string.IsNullOrEmpty(snils) || snils.Length < 11)
                return snils;

            return $"{snils.Substring(0, 3)}-{snils.Substring(3, 3)}-{snils.Substring(6, 3)} {snils.Substring(9)}";
        }

        private void SelectPatientFromGrid()
        {
            try
            {
                if (dgvPatients == null || dgvPatients.CurrentRow == null || !dgvPatients.Visible)
                {
                    MessageBox.Show("Выберите пациента из списка");
                    return;
                }

                // Получаем выбранную строку
                var row = dgvPatients.CurrentRow;
                int patientId = 0;
                bool idFound = false;

                // Способ 1: Получаем ID из Tag
                if (row.Tag != null && row.Tag is int)
                {
                    patientId = (int)row.Tag;
                    idFound = true;
                }
                // Способ 2: Получаем ID из DataBoundItem (более надежный)
                else if (row.DataBoundItem != null)
                {
                    try
                    {
                        var dataItem = row.DataBoundItem;
                        var idProperty = dataItem.GetType().GetProperty("ID");
                        if (idProperty != null)
                        {
                            patientId = Convert.ToInt32(idProperty.GetValue(dataItem));
                            idFound = true;
                        }
                    }
                    catch
                    {
                        // Продолжаем к следующему способу
                    }
                }
                // Способ 3: Получаем ID из скрытой колонки
                else if (dgvPatients.Columns.Contains("ID") && row.Cells["ID"] != null)
                {
                    try
                    {
                        patientId = Convert.ToInt32(row.Cells["ID"].Value);
                        idFound = true;
                    }
                    catch { }
                }

                if (!idFound)
                {
                    MessageBox.Show("Не удалось получить ID пациента");
                    return;
                }

                using var db = new ApplicationDbContext();
                var patient = db.Patients.FirstOrDefault(p => p.id == patientId);

                if (patient != null)
                {
                    // Открываем форму визитов
                    var visitsForm = new PatientVisitsForm(patient);

                    // Находим родительскую форму DoctorsMenuForm
                    var parentForm = this.ParentForm as DoctorsMenuForm;
                    if (parentForm != null)
                    {
                        // Вызываем публичный метод OpenChildForm
                        parentForm.OpenChildForm(visitsForm);
                    }
                    else
                    {
                        visitsForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Пациент не найден в базе данных");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectPatientFromGrid();
        }
    }
}