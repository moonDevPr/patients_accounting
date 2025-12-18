using Guna.UI2.WinForms;
using PatientsAccounting.Models;
using PatientsAccounting.Forms;
using PatientsAcounting.Services;
using System;
using System.Drawing;
using System.Windows.Forms;
using PatientAccounting.Forms.PatientsForms.MenuForms;

namespace PatientsAccounting.Forms
{
    public partial class PatientsMenu : Form
    {
        private Form currentChildForm;


        public PatientsMenu()
        {
            InitializeComponent();
            AuthBtn.Visible = !CurrentUser.IsAuthenticated;
            logoutBtn.Visible = CurrentUser.IsAuthenticated;


        }

        private void OpenChildForm(Form childForm)
        {
            //if (currentChildForm != null)
            //{
            //    currentChildForm.Close();
            //}

            //currentChildForm = childForm;
            //childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;

            //childForm.BringToFront();
            //childForm.Show();

            
            if (currentChildForm != null)
            { 
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.AutoScroll = true; // ← ДОБАВЬ!

            // ВАЖНО: Добавляем форму в panelDesktop
            if (panelDesktop != null)
            {
                // Очищаем panelDesktop и добавляем дочернюю форму
                panelDesktop.Controls.Clear();
                panelDesktop.Controls.Add(childForm);

                // Убедимся, что panelDesktop видим и поверх других элементов
                panelDesktop.Visible = true;
                panelDesktop.BringToFront();
            }
            else
            {
                // Если panelDesktop не найден, откроем как отдельное окно
                MessageBox.Show("Панель panelDesktop не найдена!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                childForm.TopLevel = true;
                childForm.Show();
                return;
            }

            childForm.BringToFront();
            childForm.Show();
        
        }


        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Главная панель");
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                MessageBox.Show("Для просмотра профиля необходимо авторизоваться",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем PatientId
            if (!CurrentUser.PatientId.HasValue || CurrentUser.PatientId.Value <= 0)
            {
                MessageBox.Show("ID пациента не найден. Возможно, вы не являетесь пациентом.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Передаем PatientId в конструктор
                PatientProfileForm patientProfileForm = new PatientProfileForm(CurrentUser.PatientId.Value);

                if (panelDesktop != null)
                {
                    patientProfileForm.Size = panelDesktop.Size;
                }

                OpenChildForm(patientProfileForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии профиля: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AuthBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartAuthMenuForm authForm = new StartAuthMenuForm();
            authForm.ShowDialog();
        }

        private void CardBtn_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                MessageBox.Show("Для просмотра карты необходимо авторизоваться");
                return;
            }
            PatientCardForm patientCard = new PatientCardForm(CurrentUser.PatientId.Value);
            if (panelDesktop != null)
            {
                patientCard.Size = panelDesktop.Size;
            }
            OpenChildForm(patientCard);
        }

        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            DoctorScheduleForm scheduleForm = new DoctorScheduleForm();
            OpenChildForm(scheduleForm);
        
        }

        private void MakeVisitBtn_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("Записаться на прием");
        }

        private void HospitalsBtn_Click(Object sender, EventArgs e)
        {
           
            // Создаем форму больниц
            HospitalsForm hospitalsForm = new HospitalsForm();

            // Можно задать размер формы под панель
            if (panelDesktop != null)
            {
                hospitalsForm.Size = panelDesktop.Size;
            }

            // Открываем форму внутри panelDesktop
            OpenChildForm(hospitalsForm);
        
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CurrentUser.Clear();
                this.Hide();
                StartAuthMenuForm startForm = new StartAuthMenuForm();
                startForm.Show();
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}