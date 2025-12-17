#nullable disable

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using PatientsAccounting.Models;
using Guna.UI2.WinForms;

namespace PatientAccounting.Forms.PatientsForms.MenuForms
{
    public partial class HospitalsForm : Form
    {
        private Guna2ComboBox comboBoxHospitals = null!;
        private PictureBox pictureBoxHospital = null!;
        private Guna2HtmlLabel labelLocation = null!;
        private Guna2Button backButton = null!;
        private Label nameLabel = null!;

        public HospitalsForm()
        {
            
            SetupUI();
            LoadHospitals();
        }

       

        private void SetupUI()
        {
            // Используем TableLayoutPanel для автоматического масштабирования
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.BackColor = Color.FromArgb(45, 45, 48);
            mainLayout.Padding = new Padding(20);

            // 5 строк
            mainLayout.RowCount = 5;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // Кнопка назад
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80)); // Заголовок
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // ComboBox
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10)); // Разделитель
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Контент

            // 2 колонки для контента
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            // Кнопка "Назад" в правом верхнем углу (span 2 колонки)
            backButton = new Guna2Button
            {
                Text = "Назад",
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(70, 130, 180),
                BorderRadius = 8,
                Animated = true,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Right
            };
            backButton.Click += (s, e) => Close();
            mainLayout.Controls.Add(backButton, 1, 0);

            // Заголовок по центру (span 2 колонки)
            var titleLabel = new Guna2HtmlLabel
            {
                Text = "Поликлиники",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204),
                TextAlignment = ContentAlignment.MiddleCenter
            };
            mainLayout.Controls.Add(titleLabel, 0, 1);
            mainLayout.SetColumnSpan(titleLabel, 2);

            // ComboBox (span 2 колонки)
            comboBoxHospitals = new Guna2ComboBox
            {
                Dock = DockStyle.Fill,
                Height = 40,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(80, 80, 80),
                BorderColor = Color.FromArgb(100, 100, 100),
                BorderRadius = 8,
                DrawMode = DrawMode.OwnerDrawFixed,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxHospitals.SelectedIndexChanged += ComboBoxHospitals_SelectedIndexChanged;
            mainLayout.Controls.Add(comboBoxHospitals, 0, 2);
            mainLayout.SetColumnSpan(comboBoxHospitals, 2);

            // Разделитель (span 2 колонки)
            var separator = new Panel
            {
                BackColor = Color.FromArgb(100, 100, 100),
                Dock = DockStyle.Fill,
                Height = 2
            };
            mainLayout.Controls.Add(separator, 0, 3);
            mainLayout.SetColumnSpan(separator, 2);

            // Левая панель (расположение)
            var leftPanel = CreateLeftPanel();
            mainLayout.Controls.Add(leftPanel, 0, 4);

            // Правая панель (фото и название)
            var rightPanel = CreateRightPanel();
            mainLayout.Controls.Add(rightPanel, 1, 4);

            Controls.Add(mainLayout);
        }

        private Guna2Panel CreateLeftPanel()
        {
            var panel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(60, 60, 65),
                BorderRadius = 10,
                Padding = new Padding(20)
            };

            var locationTitle = new Guna2HtmlLabel
            {
                Text = "Расположение",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleCenter
            };

            labelLocation = new Guna2HtmlLabel
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14, FontStyle.Regular),
                ForeColor = Color.White,
                TextAlignment = ContentAlignment.MiddleLeft
            };

            panel.Controls.Add(labelLocation);
            panel.Controls.Add(locationTitle);

            return panel;
        }

        private Guna2Panel CreateRightPanel()
        {
            var panel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(60, 60, 65),
                BorderRadius = 10,
                Padding = new Padding(20)
            };

            pictureBoxHospital = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 200,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(80, 80, 80)
            };

            var noPhotoLabel = new Label
            {
                Text = "Фото отсутствует",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14, FontStyle.Italic),
                ForeColor = Color.FromArgb(180, 180, 180),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pictureBoxHospital.Controls.Add(noPhotoLabel);

            nameLabel = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(nameLabel);
            panel.Controls.Add(pictureBoxHospital);

            return panel;
        }

        private void LoadHospitals()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var hospitals = context.Hospitals
                        .OrderBy(h => h.name)
                        .ToList();

                    comboBoxHospitals.DisplayMember = "name";
                    comboBoxHospitals.ValueMember = "id";
                    comboBoxHospitals.DataSource = hospitals;

                    // Настраиваем отображение - широкая выпадающая панель
                    comboBoxHospitals.DropDownWidth = 600;

                    comboBoxHospitals.DrawItem += (sender, e) =>
                    {
                        e.DrawBackground();

                        if (e.Index >= 0)
                        {
                            Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                                ? Color.White
                                : Color.White;

                            Color backColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                                ? Color.FromArgb(70, 130, 180)
                                : Color.FromArgb(80, 80, 80);

                            using (var brush = new SolidBrush(backColor))
                            {
                                e.Graphics.FillRectangle(brush, e.Bounds);
                            }

                            var hospital = (Hospitals)comboBoxHospitals.Items[e.Index];

                            using (var brush = new SolidBrush(textColor))
                            {
                                e.Graphics.DrawString(hospital.name,
                                    new Font("Segoe UI", 11),
                                    brush, e.Bounds);
                            }
                        }
                    };

                    if (hospitals.Any())
                    {
                        comboBoxHospitals.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке поликлиник: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxHospitals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHospitals.SelectedItem is Hospitals selectedHospital)
            {
                ShowHospitalInfo(selectedHospital);
            }
        }

        private void ShowHospitalInfo(Hospitals hospital)
        {
            try
            {
                // Название поликлиники
                nameLabel.Text = hospital.name;

                // Рассчитываем оптимальную высоту для текста
                using (Graphics g = nameLabel.CreateGraphics())
                {
                    // Измеряем текст с учетом переноса
                    SizeF textSize = g.MeasureString(hospital.name, nameLabel.Font, nameLabel.Width - 10);

                    // Устанавливаем высоту label в зависимости от размера текста
                    nameLabel.Height = (int)Math.Ceiling(textSize.Height) + 20;

                    // Если текст слишком большой, уменьшаем шрифт
                    if (nameLabel.Height > 120)
                    {
                        nameLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                        textSize = g.MeasureString(hospital.name, nameLabel.Font, nameLabel.Width - 10);
                        nameLabel.Height = (int)Math.Ceiling(textSize.Height) + 20;
                    }
                }

                // Расположение поликлиники
                if (!string.IsNullOrEmpty(hospital.town) &&
                    !string.IsNullOrEmpty(hospital.street) &&
                    !string.IsNullOrEmpty(hospital.house))
                {
                    labelLocation.Text = $"<b>Город:</b> {hospital.town}<br><br>" +
                                       $"<b>Улица:</b> {hospital.street}<br><br>" +
                                       $"<b>Дом:</b> {hospital.house}";
                }
                else
                {
                    labelLocation.Text = "<b>Информация о расположении не указана</b>";
                }

                // Всегда показываем надпись "Фото отсутствует"
                pictureBoxHospital.Image = null;
                if (pictureBoxHospital.Controls.Count > 0)
                {
                    pictureBoxHospital.Controls[0].Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отображении информации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HospitalsForm_Load(object sender, EventArgs e)
        {

        }
    }
}