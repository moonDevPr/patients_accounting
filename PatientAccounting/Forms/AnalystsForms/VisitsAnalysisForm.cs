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
    public partial class VisitsAnalysisForm : Form
    {
        // Строка для отображения итоговых значений в таблице
        private DataGridViewRow? totalRow = null;
        // Список всех поликлиник для поиска
        private List<string> allHospitals = new List<string>();

        public VisitsAnalysisForm()
        {
            InitializeComponent();
        }

        // Обработчик загрузки формы
        private void VisitsAnalysisForm_Load(object sender, EventArgs e)
        {
            cmbTimePeriod.SelectedIndex = 4;
            LoadHospitalFilter();
            LoadDepartmentFilter();
            LoadDoctorsFilter();
            LoadVisitsAnalysis();
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
        private void LoadDepartmentFilter()
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

        // Загружает список врачей из базы данных
        private void LoadDoctorsFilter()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var doctors = context.Doctors.ToList();
                    cmbDoctorFilter.Items.Clear();
                    cmbDoctorFilter.Items.Add("Все врачи");
                    foreach (var doctor in doctors)
                    {
                        cmbDoctorFilter.Items.Add($"{doctor.surname} {doctor.name} {doctor.patronymic}");
                    }
                    cmbDoctorFilter.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки врачей: {ex.Message}", "Ошибка",
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

        // Загружает анализ посещаемости врачей из базы данных
        private void LoadVisitsAnalysis()
        {
            try
            {
                DateTime startDate, endDate;
                GetDateRange(out startDate, out endDate);

                using (var context = new ApplicationDbContext())
                {
                    // Формирует сложный запрос для получения данных о визитах к врачам
                    var doctorData = (from doctor in context.Doctors
                                      join doctorPosition in context.DoctorPositions on doctor.id equals doctorPosition.id_doctor
                                      join position in context.Positions on doctorPosition.id_position equals position.id
                                      join departmentPosition in context.DepartmentPositions on doctorPosition.id equals departmentPosition.id_position_doctor
                                      join hospitalDepartment in context.HospitalDepartments on departmentPosition.id_hospital_department equals hospitalDepartment.id
                                      join hospital in context.Hospitals on hospitalDepartment.id_hospital equals hospital.id
                                      join department in context.Departments on hospitalDepartment.id_department equals department.id
                                      join doctorSchedule in context.DoctorWorkingHours on departmentPosition.id equals doctorSchedule.id_department_position
                                      join patientVisit in context.PatientVisits on doctorSchedule.id equals patientVisit.id_doctor_working_hours
                                      where patientVisit.appointment_date >= startDate
                                            && patientVisit.appointment_date <= endDate
                                            && patientVisit.completed == true
                                      select new
                                      {
                                          DoctorId = doctor.id,
                                          DoctorName = $"{doctor.surname} {doctor.name} {doctor.patronymic}",
                                          PositionTitle = position.title,
                                          HospitalName = hospital.name,
                                          DepartmentTitle = department.title,
                                          VisitDate = patientVisit.appointment_date,
                                          VisitId = patientVisit.id
                                      }).ToList();

                    var filteredData = doctorData.AsEnumerable();

                    // Применяет фильтр по поликлинике
                    string selectedHospital = cmbHospitalFilter.Text;
                    if (!string.IsNullOrEmpty(selectedHospital) && selectedHospital != "Все поликлиники")
                    {
                        filteredData = filteredData.Where(x => x.HospitalName == selectedHospital);
                    }

                    // Применяет фильтр по отделению
                    if (cmbDepartmentFilter.SelectedIndex > 0)
                    {
                        string? selectedDepartment = cmbDepartmentFilter.SelectedItem?.ToString();
                        if (!string.IsNullOrEmpty(selectedDepartment))
                        {
                            filteredData = filteredData.Where(x => x.DepartmentTitle == selectedDepartment);
                        }
                    }

                    // Применяет фильтр по врачу
                    if (cmbDoctorFilter.SelectedIndex > 0)
                    {
                        string? selectedDoctor = cmbDoctorFilter.SelectedItem?.ToString();
                        if (!string.IsNullOrEmpty(selectedDoctor))
                        {
                            filteredData = filteredData.Where(x => x.DoctorName == selectedDoctor);
                        }
                    }

                    // Группирует данные по врачам и агрегирует статистику
                    var analysisResults = filteredData
                        .GroupBy(x => new
                        {
                            x.DoctorId,
                            x.DoctorName,
                            x.PositionTitle,
                            x.HospitalName,
                            x.DepartmentTitle
                        })
                        .Select(g => new DoctorAnalysisItem
                        {
                            DoctorId = g.Key.DoctorId,
                            DoctorName = g.Key.DoctorName,
                            PositionTitle = g.Key.PositionTitle ?? "",
                            HospitalName = g.Key.HospitalName ?? "",
                            DepartmentTitle = g.Key.DepartmentTitle ?? "",
                            TotalVisits = g.Count(),
                            LastVisitDate = g.Max(x => x.VisitDate),
                            FirstVisitDate = g.Min(x => x.VisitDate)
                        })
                        .OrderByDescending(x => x.TotalVisits)
                        .ToList();

                    // Рассчитывает среднее количество визитов в день
                    int totalDays = (endDate - startDate).Days + 1;
                    foreach (var doctor in analysisResults)
                    {
                        doctor.AvgVisitsPerDay = totalDays > 0 ?
                            Math.Round((double)doctor.TotalVisits / totalDays, 2) : 0;
                    }

                    DisplayAnalysisInGrid(analysisResults);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки анализа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Отображает данные анализа в таблице
        private void DisplayAnalysisInGrid(List<DoctorAnalysisItem> analysisData)
        {
            dgvVisitsAnalysis.Rows.Clear();
            dgvVisitsAnalysis.Columns.Clear();

            CreateGridColumns();

            // Заполняет таблицу данными
            foreach (var doctor in analysisData)
            {
                var firstVisitLocal = doctor.FirstVisitDate.Kind == DateTimeKind.Utc
                    ? doctor.FirstVisitDate.ToLocalTime().Date
                    : doctor.FirstVisitDate.Date;

                var lastVisitLocal = doctor.LastVisitDate.Kind == DateTimeKind.Utc
                    ? doctor.LastVisitDate.ToLocalTime().Date
                    : doctor.LastVisitDate.Date;

                dgvVisitsAnalysis.Rows.Add(
                    doctor.DoctorName,
                    doctor.PositionTitle,
                    doctor.HospitalName,
                    doctor.DepartmentTitle,
                    doctor.TotalVisits,
                    doctor.AvgVisitsPerDay,
                    firstVisitLocal,
                    lastVisitLocal
                );
            }

            if (analysisData.Count > 0)
            {
                CreateTotalRow(analysisData);
            }

            dgvVisitsAnalysis.Sorted += DgvVisitsAnalysis_Sorted;

            // Выделяет цветом топ-5 врачей по количеству визитов
            for (int i = 0; i < Math.Min(5, analysisData.Count); i++)
            {
                if (i < dgvVisitsAnalysis.Rows.Count - 1)
                {
                    var color = i switch
                    {
                        0 => Color.FromArgb(50, 80, 50),   // 1 место
                        1 => Color.FromArgb(60, 70, 80),   // 2 место
                        2 => Color.FromArgb(80, 60, 60),   // 3 место
                        3 => Color.FromArgb(70, 60, 80),   // 4 место
                        4 => Color.FromArgb(80, 70, 60),   // 5 место
                        _ => Color.FromArgb(45, 45, 45)
                    };
                    dgvVisitsAnalysis.Rows[i].DefaultCellStyle.BackColor = color;
                }
            }
        }

        // Создает колонки таблицы с настройками форматирования
        private void CreateGridColumns()
        {
            DataGridViewTextBoxColumn colDoctorName = new DataGridViewTextBoxColumn();
            colDoctorName.Name = "DoctorName";
            colDoctorName.HeaderText = "Врач";
            colDoctorName.Width = 200;
            colDoctorName.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colDoctorName.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colDoctorName.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvVisitsAnalysis.Columns.Add(colDoctorName);

            DataGridViewTextBoxColumn colPositionTitle = new DataGridViewTextBoxColumn();
            colPositionTitle.Name = "PositionTitle";
            colPositionTitle.HeaderText = "Должность";
            colPositionTitle.Width = 170;
            colPositionTitle.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colPositionTitle.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colPositionTitle.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvVisitsAnalysis.Columns.Add(colPositionTitle);

            DataGridViewTextBoxColumn colHospitalName = new DataGridViewTextBoxColumn();
            colHospitalName.Name = "HospitalName";
            colHospitalName.HeaderText = "Поликлиника";
            colHospitalName.Width = 180;
            colHospitalName.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colHospitalName.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colHospitalName.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvVisitsAnalysis.Columns.Add(colHospitalName);

            DataGridViewTextBoxColumn colDepartmentTitle = new DataGridViewTextBoxColumn();
            colDepartmentTitle.Name = "DepartmentTitle";
            colDepartmentTitle.HeaderText = "Отделение";
            colDepartmentTitle.Width = 160;
            colDepartmentTitle.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colDepartmentTitle.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colDepartmentTitle.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvVisitsAnalysis.Columns.Add(colDepartmentTitle);

            DataGridViewTextBoxColumn colTotalVisits = new DataGridViewTextBoxColumn();
            colTotalVisits.Name = "TotalVisits";
            colTotalVisits.HeaderText = "Всего посещений";
            colTotalVisits.Width = 160;
            colTotalVisits.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colTotalVisits.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colTotalVisits.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTotalVisits.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvVisitsAnalysis.Columns.Add(colTotalVisits);

            DataGridViewTextBoxColumn colAvgVisitsPerDay = new DataGridViewTextBoxColumn();
            colAvgVisitsPerDay.Name = "AvgVisitsPerDay";
            colAvgVisitsPerDay.HeaderText = "Среднее посещений в день";
            colAvgVisitsPerDay.Width = 200;
            colAvgVisitsPerDay.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colAvgVisitsPerDay.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colAvgVisitsPerDay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAvgVisitsPerDay.DefaultCellStyle.Format = "N2";
            colAvgVisitsPerDay.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvVisitsAnalysis.Columns.Add(colAvgVisitsPerDay);

            DataGridViewTextBoxColumn colFirstVisitDate = new DataGridViewTextBoxColumn();
            colFirstVisitDate.Name = "FirstVisitDate";
            colFirstVisitDate.HeaderText = "Первый прием";
            colFirstVisitDate.Width = 140;
            colFirstVisitDate.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colFirstVisitDate.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colFirstVisitDate.DefaultCellStyle.Format = "dd.MM.yyyy";
            colFirstVisitDate.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvVisitsAnalysis.Columns.Add(colFirstVisitDate);

            DataGridViewTextBoxColumn colLastVisitDate = new DataGridViewTextBoxColumn();
            colLastVisitDate.Name = "LastVisitDate";
            colLastVisitDate.HeaderText = "Последний прием";
            colLastVisitDate.Width = 140;
            colLastVisitDate.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            colLastVisitDate.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            colLastVisitDate.DefaultCellStyle.Format = "dd.MM.yyyy";
            colLastVisitDate.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvVisitsAnalysis.Columns.Add(colLastVisitDate);
        }

        // Создает итоговую строку в таблице
        private void CreateTotalRow(List<DoctorAnalysisItem> analysisData)
        {
            int totalVisits = analysisData.Sum(x => x.TotalVisits);

            totalRow = new DataGridViewRow();
            totalRow.CreateCells(dgvVisitsAnalysis);
            totalRow.Cells[0].Value = "ИТОГО";
            totalRow.Cells[1].Value = "";
            totalRow.Cells[2].Value = "";
            totalRow.Cells[3].Value = "";
            totalRow.Cells[4].Value = totalVisits;
            totalRow.Cells[5].Value = "";
            totalRow.Cells[6].Value = "";
            totalRow.Cells[7].Value = "";

            totalRow.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 60);
            totalRow.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            totalRow.DefaultCellStyle.ForeColor = Color.White;
            totalRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 60);
            totalRow.DefaultCellStyle.SelectionForeColor = Color.White;
            totalRow.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            totalRow.DefaultCellStyle.Padding = new Padding(15, 0, 15, 0);
            totalRow.Height = 50;
            totalRow.ReadOnly = true;

            dgvVisitsAnalysis.Rows.Add(totalRow);
            totalRow.Frozen = true;
        }

        // Обработчик события сортировки таблицы
        private void DgvVisitsAnalysis_Sorted(object? sender, EventArgs e)
        {
            if (totalRow != null && dgvVisitsAnalysis.Rows.Contains(totalRow))
            {
                dgvVisitsAnalysis.Rows.Remove(totalRow);
                dgvVisitsAnalysis.Rows.Add(totalRow);
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
            LoadVisitsAnalysis();
        }

        // Обработчик кнопки возврата
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Внутренний класс для хранения данных анализа врачей
        private class DoctorAnalysisItem
        {
            public int DoctorId { get; set; }
            public string DoctorName { get; set; } = "";
            public string PositionTitle { get; set; } = "";
            public string HospitalName { get; set; } = "";
            public string DepartmentTitle { get; set; } = "";
            public int TotalVisits { get; set; }
            public double AvgVisitsPerDay { get; set; }
            public DateTime FirstVisitDate { get; set; }
            public DateTime LastVisitDate { get; set; }
        }

        // Заглушка для обработчика изменения выбора врача
        private void cmbDoctorFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработчик может быть использован для дополнительной логики
        }
    }
}