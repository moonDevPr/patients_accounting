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
    public partial class SpecialtiesAnalysisForm : Form
    {
        // Строка для отображения итоговых значений в таблице
        private DataGridViewRow? totalRow = null;
        // Список всех поликлиник для поиска
        private List<string> allHospitals = new List<string>();

        public SpecialtiesAnalysisForm()
        {
            InitializeComponent();
        }

        // Обработчик загрузки формы
        private void SpecialtiesAnalysisForm_Load(object sender, EventArgs e)
        {
            cmbTimePeriod.SelectedIndex = 4;
            LoadHospitalFilter();
            LoadDepartmentsFilter();
            LoadSpecialtiesAnalysis();
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

        // Загружает список отделений из базы данных
        private void LoadDepartmentsFilter()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var departments = context.Departments.ToList();
                    cmbDepartmentFilter.Items.Clear();
                    cmbDepartmentFilter.Items.Add("Все отделения");
                    foreach (var department in departments)
                    {
                        cmbDepartmentFilter.Items.Add(department.title);
                    }
                    cmbDepartmentFilter.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отделений: {ex.Message}", "Ошибка",
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

        // Загружает анализ специализаций врачей из базы данных
        private void LoadSpecialtiesAnalysis()
        {
            try
            {
                DateTime startDate, endDate;
                GetDateRange(out startDate, out endDate);

                using (var context = new ApplicationDbContext())
                {
                    // Получает завершенные визиты за указанный период
                    var visits = context.PatientVisits
                        .Where(v => v.appointment_date >= startDate &&
                                    v.appointment_date <= endDate &&
                                    v.completed == true)
                        .ToList();

                    // Загружает связанные данные
                    var doctorSchedules = context.DoctorWorkingHours.ToList();
                    var departmentPositions = context.DepartmentPositions.ToList();
                    var doctorPositions = context.DoctorPositions.ToList();
                    var doctors = context.Doctors.ToList();
                    var positions = context.Positions.ToList();
                    var hospitalDepartments = context.HospitalDepartments.ToList();
                    var hospitals = context.Hospitals.ToList();
                    var departments = context.Departments.ToList();

                    var analysisItems = new List<SpecialtiesAnalysisItem>();

                    // Обрабатывает каждый визит
                    foreach (var visit in visits)
                    {
                        var schedule = doctorSchedules.FirstOrDefault(s => s.id == visit.id_doctor_working_hours);
                        if (schedule == null) continue;

                        var depPosition = departmentPositions.FirstOrDefault(dp => dp.id == schedule.id_department_position);
                        if (depPosition == null) continue;

                        var docPosition = doctorPositions.FirstOrDefault(dp => dp.id == depPosition.id_position_doctor);
                        if (docPosition == null) continue;

                        var doctor = doctors.FirstOrDefault(d => d.id == docPosition.id_doctor);
                        if (doctor == null) continue;

                        var position = positions.FirstOrDefault(p => p.id == docPosition.id_position);
                        if (position == null) continue;

                        var hospitalDept = hospitalDepartments.FirstOrDefault(hd => hd.id == depPosition.id_hospital_department);
                        if (hospitalDept == null) continue;

                        var hospital = hospitals.FirstOrDefault(h => h.id == hospitalDept.id_hospital);
                        if (hospital == null) continue;

                        var department = departments.FirstOrDefault(d => d.id == hospitalDept.id_department);
                        if (department == null) continue;

                        // Применяет фильтры
                        string selectedHospital = cmbHospitalFilter.Text;
                        if (!string.IsNullOrEmpty(selectedHospital) && selectedHospital != "Все поликлиники" && hospital.name != selectedHospital)
                            continue;

                        if (cmbDepartmentFilter.SelectedIndex > 0 && department.title != cmbDepartmentFilter.SelectedItem?.ToString())
                            continue;

                        var doctorFullName = $"{doctor.surname} {doctor.name} {doctor.patronymic}";

                        // Ищет существующий элемент анализа или создает новый
                        var existingItem = analysisItems.FirstOrDefault(i =>
                            i.PositionTitle == position.title &&
                            i.HospitalName == hospital.name &&
                            i.DepartmentTitle == department.title);

                        if (existingItem != null)
                        {
                            existingItem.VisitCount++;
                            if (existingItem.DoctorVisits.ContainsKey(doctorFullName))
                                existingItem.DoctorVisits[doctorFullName] = existingItem.DoctorVisits[doctorFullName] + 1;
                            else
                                existingItem.DoctorVisits[doctorFullName] = 1;
                        }
                        else
                        {
                            var newItem = new SpecialtiesAnalysisItem
                            {
                                PositionTitle = position.title ?? "",
                                HospitalName = hospital.name ?? "",
                                DepartmentTitle = department.title ?? "",
                                VisitCount = 1
                            };
                            newItem.DoctorVisits[doctorFullName] = 1;
                            analysisItems.Add(newItem);
                        }
                    }

                    // Рассчитывает проценты и определяет самого посещаемого врача
                    var totalVisits = analysisItems.Sum(x => x.VisitCount);
                    foreach (var item in analysisItems)
                    {
                        item.Percentage = totalVisits > 0 ? Math.Round((double)item.VisitCount * 100.0 / totalVisits, 1) : 0;
                        item.TopDoctor = GetTopDoctor(item.DoctorVisits);
                    }

                    var sortedItems = analysisItems.OrderByDescending(x => x.VisitCount).ToList();
                    DisplayAnalysisInGrid(sortedItems, totalVisits);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки анализа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Определяет самого посещаемого врача на основе статистики визитов
        private string GetTopDoctor(Dictionary<string, int> doctorVisits)
        {
            if (doctorVisits == null || doctorVisits.Count == 0)
                return "Нет данных";

            var topDoctor = doctorVisits.OrderByDescending(kv => kv.Value).First();

            if (string.IsNullOrEmpty(topDoctor.Key))
                return "Нет данных";

            var parts = topDoctor.Key.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Форматирует ФИО в сокращенный вид
            if (parts.Length >= 3 && parts[1].Length > 0 && parts[2].Length > 0)
            {
                return $"{parts[0]} {parts[1][0]}.{parts[2][0]}.";
            }
            else if (parts.Length >= 2 && parts[1].Length > 0)
            {
                return $"{parts[0]} {parts[1][0]}.";
            }
            else if (parts.Length >= 1)
            {
                return parts[0];
            }
            else
            {
                return topDoctor.Key;
            }
        }

        // Отображает данные анализа в таблице
        private void DisplayAnalysisInGrid(List<SpecialtiesAnalysisItem> analysisData, int totalVisits)
        {
            dgvSpecialtiesAnalysis.Rows.Clear();
            dgvSpecialtiesAnalysis.Columns.Clear();

            CreateGridColumns();

            foreach (var item in analysisData)
            {
                dgvSpecialtiesAnalysis.Rows.Add(
                    item.PositionTitle,
                    item.HospitalName,
                    item.DepartmentTitle,
                    item.VisitCount,
                    item.Percentage,
                    item.TopDoctor
                );
            }

            CreateTotalRow(totalVisits);

            dgvSpecialtiesAnalysis.Sorted += DgvSpecialtiesAnalysis_Sorted;
        }

        // Создает колонки таблицы с настройками форматирования
        private void CreateGridColumns()
        {
            DataGridViewTextBoxColumn colPositionTitle = new DataGridViewTextBoxColumn();
            colPositionTitle.Name = "PositionTitle";
            colPositionTitle.HeaderText = "Направление (должность)";
            colPositionTitle.Width = 250;
            colPositionTitle.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colPositionTitle.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colPositionTitle.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvSpecialtiesAnalysis.Columns.Add(colPositionTitle);

            DataGridViewTextBoxColumn colHospitalName = new DataGridViewTextBoxColumn();
            colHospitalName.Name = "HospitalName";
            colHospitalName.HeaderText = "Поликлиника";
            colHospitalName.Width = 220;
            colHospitalName.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colHospitalName.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colHospitalName.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvSpecialtiesAnalysis.Columns.Add(colHospitalName);

            DataGridViewTextBoxColumn colDepartmentTitle = new DataGridViewTextBoxColumn();
            colDepartmentTitle.Name = "DepartmentTitle";
            colDepartmentTitle.HeaderText = "Отделение";
            colDepartmentTitle.Width = 200;
            colDepartmentTitle.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colDepartmentTitle.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colDepartmentTitle.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvSpecialtiesAnalysis.Columns.Add(colDepartmentTitle);

            DataGridViewTextBoxColumn colVisitCount = new DataGridViewTextBoxColumn();
            colVisitCount.Name = "VisitCount";
            colVisitCount.HeaderText = "Количество посещений";
            colVisitCount.Width = 200;
            colVisitCount.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colVisitCount.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colVisitCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colVisitCount.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvSpecialtiesAnalysis.Columns.Add(colVisitCount);

            DataGridViewTextBoxColumn colPercentage = new DataGridViewTextBoxColumn();
            colPercentage.Name = "Percentage";
            colPercentage.HeaderText = "Доля, %";
            colPercentage.Width = 130;
            colPercentage.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colPercentage.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colPercentage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPercentage.DefaultCellStyle.Format = "N1";
            colPercentage.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvSpecialtiesAnalysis.Columns.Add(colPercentage);

            DataGridViewTextBoxColumn colTopDoctor = new DataGridViewTextBoxColumn();
            colTopDoctor.Name = "TopDoctor";
            colTopDoctor.HeaderText = "Самый посещаемый врач";
            colTopDoctor.Width = 250;
            colTopDoctor.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colTopDoctor.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colTopDoctor.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvSpecialtiesAnalysis.Columns.Add(colTopDoctor);
        }

        // Создает итоговую строку в таблице
        private void CreateTotalRow(int totalVisits)
        {
            totalRow = new DataGridViewRow();
            totalRow.CreateCells(dgvSpecialtiesAnalysis);
            totalRow.Cells[0].Value = "ИТОГО";
            totalRow.Cells[1].Value = "";
            totalRow.Cells[2].Value = "";
            totalRow.Cells[3].Value = totalVisits;
            totalRow.Cells[4].Value = 100.0;
            totalRow.Cells[5].Value = "";
            totalRow.Cells[4].Style.Format = "N1";

            totalRow.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 60);
            totalRow.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            totalRow.DefaultCellStyle.ForeColor = Color.White;
            totalRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 60);
            totalRow.DefaultCellStyle.SelectionForeColor = Color.White;
            totalRow.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            totalRow.Height = 50;
            totalRow.ReadOnly = true;

            dgvSpecialtiesAnalysis.Rows.Add(totalRow);
            totalRow.Frozen = true;
        }

        // Обработчик события сортировки таблицы
        private void DgvSpecialtiesAnalysis_Sorted(object? sender, EventArgs e)
        {
            if (totalRow != null && dgvSpecialtiesAnalysis.Rows.Contains(totalRow))
            {
                dgvSpecialtiesAnalysis.Rows.Remove(totalRow);
                dgvSpecialtiesAnalysis.Rows.Add(totalRow);
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

        // Обработчик кнопки обновления анализа
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSpecialtiesAnalysis();
        }

        // Обработчик кнопки возврата
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Внутренний класс для хранения данных анализа специализаций
        private class SpecialtiesAnalysisItem
        {
            public string PositionTitle { get; set; } = "";
            public string HospitalName { get; set; } = "";
            public string DepartmentTitle { get; set; } = "";
            public int VisitCount { get; set; }
            public double Percentage { get; set; }
            public string TopDoctor { get; set; } = "";
            public Dictionary<string, int> DoctorVisits { get; set; } = new Dictionary<string, int>();
        }
    }
}