using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    public partial class PatientCardForm : Form
    {
        private int patientId;
        private ApplicationDbContext context;

        public PatientCardForm(int patientId)
        {
            InitializeComponent();
            this.patientId = patientId;
            context = new ApplicationDbContext();
            LoadPatientCardData();
        }

        private void LoadPatientCardData()
        {
            try
            {
                var patient = context.Patients
                    .FirstOrDefault(p => p.id == patientId);

                if (patient == null)
                {
                    MessageBox.Show("Пациент не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                var patientCard = context.PatientCards
                    .FirstOrDefault(pc => pc.id_patient == patientId);

                txtCardId.Text = patientCard?.id.ToString() ?? "Не назначен";
                txtCardCode.Text = patientCard?.code.ToString() ?? "Не назначен";

                if (patientCard?.id_hospital.HasValue == true)
                {
                    var hospital = context.Hospitals
                        .FirstOrDefault(h => h.id == patientCard.id_hospital.Value);
                    txtHospital.Text = hospital?.name ?? "Неизвестно";
                }
                else
                {
                    txtHospital.Text = "Не назначена";
                }

                txtPatientId.Text = patient.id.ToString();
                txtFullName.Text = $"{patient.surname} {patient.name} {patient.patronymic}";

                LoadVisitsHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVisitsHistory()
        {
            try
            {
                var patientCard = context.PatientCards
                    .FirstOrDefault(pc => pc.id_patient == patientId);

                if (patientCard == null)
                {
                    dataGridViewVisits.DataSource = null;
                    return;
                }

                var visits = context.PatientVisits
                    .Where(v => v.id_card == patientCard.id)
                    .OrderByDescending(v => v.appointment_date)
                    .Select(v => new
                    {
                        v.id,
                        Документ = v.document,
                        Статус = v.completed ? "Завершен" : "Запланирован",
                        Дата_добавления = v.adding_date.ToString("dd.MM.yyyy"),
                        Дата_приема = v.appointment_date.ToString("dd.MM.yyyy HH:mm"),
                        Тип_посещения = context.VisitTypes.FirstOrDefault(vt => vt.id == v.id_visit_type),
                        Тип_записи = context.EntryTypes.FirstOrDefault(et => et.id == v.id_entry_type)
                    })
                    .ToList();

                dataGridViewVisits.DataSource = visits;

                if (visits.Count == 0)
                {
                    MessageBox.Show("История посещений пуста", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории посещений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatientCardData();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var patient = context.Patients
                    .FirstOrDefault(p => p.id == patientId);

                if (patient == null) return;

                string message = $"Медицинская карта пациента\n\n" +
                               $"ФИО: {patient.surname} {patient.name} {patient.patronymic}\n" +
                               $"СНИЛС: {patient.snils}\n" +
                               $"Телефон: {patient.phone}\n" +
                               $"Адрес: {patient.town}, {patient.street}, {patient.house}\n\n" +
                               $"Данные успешно подготовлены для печати.";

                MessageBox.Show(message, "Печать медицинской карты",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подготовке к печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            context?.Dispose();
            base.OnFormClosing(e);
        }

        private void dataGridViewVisits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Обработка клика по ячейке таблицы
        }

        private void panelView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}