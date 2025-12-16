using Guna.UI2.WinForms;
using PatientsAccounting.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PatientsAccounting.Forms.AnalystsForms
{
    public partial class DiseasesReportForm : Form
    {
        // Строка для отображения итоговых значений в таблице
        private DataGridViewRow? totalRow = null;
        // Список всех поликлиник для поиска
        private List<string> allHospitals = new List<string>();

        public DiseasesReportForm()
        {
            InitializeComponent();
            InitializeDiseaseCategoryComboBox();
            ConfigureDataGridView();
        }

        // Инициализирует выпадающий список категорий заболеваний
        private void InitializeDiseaseCategoryComboBox()
        {
            cmbDiseaseCategory.Items.Clear();
            cmbDiseaseCategory.Items.Add("Все заболевания");
            cmbDiseaseCategory.Items.Add("По главам МКБ-10");
            cmbDiseaseCategory.Items.Add("По блокам МКБ-10");
            cmbDiseaseCategory.Items.Add("По типам заболеваний");
            cmbDiseaseCategory.SelectedIndex = 0;
        }

        // Настраивает внешний вид таблицы данных
        private void ConfigureDataGridView()
        {
            dgvDiseasesReport.BackgroundColor = Color.FromArgb(45, 45, 45);
            dgvDiseasesReport.BorderStyle = BorderStyle.None;
            dgvDiseasesReport.GridColor = Color.FromArgb(100, 100, 100);
            dgvDiseasesReport.RowHeadersVisible = false;
            dgvDiseasesReport.RowTemplate.Height = 45;

            dgvDiseasesReport.EnableHeadersVisualStyles = false;

            dgvDiseasesReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvDiseasesReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDiseasesReport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDiseasesReport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiseasesReport.ColumnHeadersHeight = 50;
            dgvDiseasesReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvDiseasesReport.ColumnHeadersDefaultCellStyle.Padding = new Padding(15, 12, 15, 12);

            dgvDiseasesReport.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgvDiseasesReport.DefaultCellStyle.ForeColor = Color.White;
            dgvDiseasesReport.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvDiseasesReport.DefaultCellStyle.Padding = new Padding(0, 12, 0, 12);
            dgvDiseasesReport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 80, 120);
            dgvDiseasesReport.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvDiseasesReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(55, 55, 55);
            dgvDiseasesReport.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvDiseasesReport.AlternatingRowsDefaultCellStyle.Padding = new Padding(0, 12, 0, 12);
        }

        // Загружает список поликлиник из базы данных
        private void LoadHospitalFilter()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var hospitals = context.Hospitals.ToList();

                    allHospitals.Clear();
                    allHospitals.Add("Все поликлиники");
                    allHospitals.AddRange(hospitals.Select(h => h.name));

                    cmbHospitalFilter.Items.Clear();
                    cmbHospitalFilter.Items.Add("Все поликлиники");
                    foreach (var hospital in hospitals)
                    {
                        cmbHospitalFilter.Items.Add(hospital.name);
                    }
                    cmbHospitalFilter.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки поликлиник: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Выполняет поиск поликлиники по введенному тексту
        private void SearchHospital()
        {
            string searchText = txtHospitalSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите название поликлиники для поиска", "Поиск",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHospitalSearch.Focus();
                return;
            }

            var matches = allHospitals
                .Where(h => h.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (matches.Count == 0)
            {
                MessageBox.Show($"Поликлиника с названием '{searchText}' не найдена", "Результат поиска",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHospitalSearch.SelectAll();
                txtHospitalSearch.Focus();
                return;
            }

            if (matches.Count == 1)
            {
                cmbHospitalFilter.SelectedItem = matches[0];
                txtHospitalSearch.Text = matches[0];
            }
            else
            {
                cmbHospitalFilter.Items.Clear();
                foreach (var match in matches)
                {
                    cmbHospitalFilter.Items.Add(match);
                }
                cmbHospitalFilter.DroppedDown = true;
            }

            txtHospitalSearch.SelectAll();
        }

        // Обработчик нажатия кнопки поиска поликлиники
        private void btnSearchHospital_Click(object sender, EventArgs e)
        {
            SearchHospital();
        }

        // Обработчик нажатия клавиши Enter в поле поиска поликлиники
        private void txtHospitalSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchHospital();
                e.Handled = true;
            }
        }

        // Обработчик изменения выбранной поликлиники
        private void cmbHospitalFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHospitalFilter.SelectedItem != null)
            {
                txtHospitalSearch.Text = cmbHospitalFilter.SelectedItem.ToString();

                if (cmbHospitalFilter.Items.Count != allHospitals.Count)
                {
                    LoadHospitalFilter();
                }
            }
        }

        // Загружает отчет по заболеваниям из базы данных
        private void LoadDiseasesReport()
        {
            try
            {
                DateTime startDate, endDate;
                GetDateRange(out startDate, out endDate);

                using (var context = new ApplicationDbContext())
                {
                    // Формирует запрос для получения данных о заболеваниях
                    var query = from visitDiagnosis in context.VisitDiagnoses
                                join patientVisit in context.PatientVisits
                                    on visitDiagnosis.id_visit equals patientVisit.id
                                join disease in context.Diseas
                                    on visitDiagnosis.id_diseas equals disease.id
                                join diseaseType in context.DiseasTypes
                                    on disease.id_diseas_type equals diseaseType.id
                                join block in context.Blocks
                                    on diseaseType.id_block equals block.id
                                join chapter in context.Chapters
                                    on block.id_chapter equals chapter.id
                                join patientCard in context.PatientCards
                                    on patientVisit.id_card equals patientCard.id
                                join hospital in context.Hospitals
                                    on patientCard.id_hospital equals hospital.id
                                where patientVisit.appointment_date >= startDate
                                      && patientVisit.appointment_date <= endDate
                                      && patientVisit.completed == true
                                select new
                                {
                                    DiseaseCode = disease.code,
                                    DiseaseTitle = disease.title,
                                    DiseaseTypeTitle = diseaseType.title,
                                    BlockCode = block.code,
                                    BlockTitle = block.title,
                                    ChapterNumber = chapter.number,
                                    ChapterTitle = chapter.title,
                                    HospitalName = hospital.name,
                                    VisitId = patientVisit.id
                                };

                    string selectedHospital = cmbHospitalFilter.Text;
                    if (!string.IsNullOrEmpty(selectedHospital) && selectedHospital != "Все поликлиники")
                    {
                        query = query.Where(x => x.HospitalName == selectedHospital);
                    }

                    var result = new List<DiseaseReportItem>();

                    // Обрабатывает данные в зависимости от выбранной категории
                    switch (cmbDiseaseCategory.SelectedIndex)
                    {
                        case 0:
                            result = query
                                .GroupBy(x => new { x.DiseaseCode, x.DiseaseTitle })
                                .Select(g => new DiseaseReportItem
                                {
                                    Category = g.Key.DiseaseTitle,
                                    Code = g.Key.DiseaseCode,
                                    VisitCount = g.Count(),
                                    Percentage = 0
                                })
                                .OrderByDescending(x => x.VisitCount)
                                .ToList();
                            break;

                        case 1:
                            result = query
                                .GroupBy(x => new { x.ChapterNumber, x.ChapterTitle })
                                .Select(g => new DiseaseReportItem
                                {
                                    Category = $"Глава {g.Key.ChapterNumber}: {g.Key.ChapterTitle}",
                                    Code = g.Key.ChapterNumber,
                                    VisitCount = g.Count(),
                                    Percentage = 0
                                })
                                .OrderBy(x => x.Code)
                                .ToList();
                            break;

                        case 2:
                            var blockData = query
                                .GroupBy(x => new
                                {
                                    x.BlockCode,
                                    x.BlockTitle,
                                    x.ChapterNumber
                                })
                                .Select(g => new
                                {
                                    BlockCode = g.Key.BlockCode,
                                    BlockTitle = g.Key.BlockTitle,
                                    ChapterNumber = g.Key.ChapterNumber,
                                    VisitCount = g.Count()
                                })
                                .OrderBy(x => x.ChapterNumber)
                                .ThenBy(x => x.BlockCode)
                                .ToList();

                            foreach (var item in blockData)
                            {
                                result.Add(new DiseaseReportItem
                                {
                                    Category = $"Блок {item.BlockCode}: {item.BlockTitle}",
                                    Code = $"{item.ChapterNumber}.{item.BlockCode}",
                                    VisitCount = item.VisitCount,
                                    Percentage = 0
                                });
                            }
                            break;

                        case 3:
                            result = query
                                .GroupBy(x => x.DiseaseTypeTitle)
                                .Select(g => new DiseaseReportItem
                                {
                                    Category = g.Key ?? "",
                                    Code = "",
                                    VisitCount = g.Count(),
                                    Percentage = 0
                                })
                                .OrderByDescending(x => x.VisitCount)
                                .ToList();
                            break;
                    }

                    // Рассчитывает проценты для каждого элемента
                    var totalVisits = result.Sum(x => x.VisitCount);
                    if (totalVisits > 0)
                    {
                        foreach (var item in result)
                        {
                            item.Percentage = Math.Round((double)item.VisitCount * 100.0 / totalVisits, 1);
                        }
                    }

                    DisplayReportInGrid(result, totalVisits);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Отображает данные отчета в таблице
        private void DisplayReportInGrid(List<DiseaseReportItem> reportData, int totalVisits)
        {
            dgvDiseasesReport.Rows.Clear();
            dgvDiseasesReport.Columns.Clear();

            CreateGridColumns();

            foreach (var item in reportData)
            {
                dgvDiseasesReport.Rows.Add(
                    item.Category ?? "",
                    item.Code ?? "",
                    item.VisitCount,
                    item.Percentage
                );
            }

            CreateTotalRow(totalVisits);

            dgvDiseasesReport.Sorted += DgvDiseasesReport_Sorted;
        }

        // Создает колонки таблицы с настройками форматирования
        private void CreateGridColumns()
        {
            DataGridViewTextBoxColumn colCategory = new DataGridViewTextBoxColumn();
            colCategory.Name = "Category";
            colCategory.HeaderText = "Категория";
            colCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCategory.MinimumWidth = 350;
            colCategory.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colCategory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colCategory.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvDiseasesReport.Columns.Add(colCategory);

            DataGridViewTextBoxColumn colCode = new DataGridViewTextBoxColumn();
            colCode.Name = "Code";
            colCode.HeaderText = "Код";
            colCode.Width = 150;
            colCode.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colCode.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCode.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvDiseasesReport.Columns.Add(colCode);

            DataGridViewTextBoxColumn colVisitCount = new DataGridViewTextBoxColumn();
            colVisitCount.Name = "VisitCount";
            colVisitCount.HeaderText = "Количество обращений";
            colVisitCount.Width = 220;
            colVisitCount.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colVisitCount.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colVisitCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colVisitCount.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvDiseasesReport.Columns.Add(colVisitCount);

            DataGridViewTextBoxColumn colPercentage = new DataGridViewTextBoxColumn();
            colPercentage.Name = "Percentage";
            colPercentage.HeaderText = "Процент от общего числа";
            colPercentage.Width = 200;
            colPercentage.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colPercentage.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colPercentage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPercentage.DefaultCellStyle.Format = "N1";
            colPercentage.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvDiseasesReport.Columns.Add(colPercentage);
        }

        // Создает итоговую строку в таблице
        private void CreateTotalRow(int totalVisits)
        {
            totalRow = new DataGridViewRow();
            totalRow.CreateCells(dgvDiseasesReport);
            totalRow.Cells[0].Value = "ИТОГО";
            totalRow.Cells[1].Value = "";
            totalRow.Cells[2].Value = totalVisits;
            totalRow.Cells[3].Value = 100.0;
            totalRow.Cells[3].Style.Format = "N1";

            totalRow.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 60);
            totalRow.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            totalRow.DefaultCellStyle.ForeColor = Color.White;
            totalRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 60);
            totalRow.DefaultCellStyle.SelectionForeColor = Color.White;
            totalRow.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            totalRow.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            totalRow.Height = 50;
            totalRow.ReadOnly = true;

            dgvDiseasesReport.Rows.Add(totalRow);
            totalRow.Frozen = true;
        }

        // Обработчик события сортировки таблицы
        private void DgvDiseasesReport_Sorted(object? sender, EventArgs e)
        {
            if (totalRow != null && dgvDiseasesReport.Rows.Contains(totalRow))
            {
                dgvDiseasesReport.Rows.Remove(totalRow);
                dgvDiseasesReport.Rows.Add(totalRow);
                totalRow.Frozen = true;
            }
        }

        // Определяет диапазон дат в зависимости от выбранного периода
        private void GetDateRange(out DateTime startDate, out DateTime endDate)
        {
            var nowUtc = DateTime.UtcNow;

            switch (cmbTimePeriod.SelectedIndex)
            {
                case 0:
                    startDate = nowUtc.AddMonths(-1).Date;
                    endDate = nowUtc.Date;
                    break;
                case 1:
                    startDate = nowUtc.AddMonths(-3).Date;
                    endDate = nowUtc.Date;
                    break;
                case 2:
                    startDate = nowUtc.AddMonths(-6).Date;
                    endDate = nowUtc.Date;
                    break;
                case 3:
                    startDate = nowUtc.AddYears(-1).Date;
                    endDate = nowUtc.Date;
                    break;
                case 4:
                    startDate = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    endDate = nowUtc.Date;
                    break;
                case 5:
                    startDate = dtpStartDate.Value.ToUniversalTime().Date;
                    endDate = dtpEndDate.Value.ToUniversalTime().Date;
                    break;
                default:
                    startDate = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    endDate = nowUtc.Date;
                    break;
            }

            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
        }

        // Обработчик загрузки формы
        private void DiseasesReportForm_Load(object sender, EventArgs e)
        {
            cmbTimePeriod.SelectedIndex = 4;
            LoadHospitalFilter();
            LoadDiseasesReport();
        }

        // Обработчик изменения выбранного временного периода
        private void cmbTimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool showDatePickers = cmbTimePeriod.SelectedIndex == 5;
            dtpStartDate.Visible = showDatePickers;
            dtpEndDate.Visible = showDatePickers;
            lblStartDate.Visible = showDatePickers;
            lblEndDate.Visible = showDatePickers;

            if (showDatePickers)
            {
                dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                dtpEndDate.Value = DateTime.Now;
            }
        }

        // Обработчик кнопки обновления отчета
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDiseasesReport();
        }

        // Обработчик кнопки возврата
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Заглушка для клика по заголовку
        private void TitleLabel_Click(object sender, EventArgs e)
        {
        }

        // Внутренний класс для хранения данных отчета
        private class DiseaseReportItem
        {
            public string Category { get; set; } = "";
            public string Code { get; set; } = "";
            public int VisitCount { get; set; }
            public double Percentage { get; set; }
        }
    }
}