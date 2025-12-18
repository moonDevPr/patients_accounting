using Guna.UI2.WinForms;
using PatientAccounting.Forms.PatientsForms.MenuForms;
using PatientsAccounting.Forms;
using PatientsAccounting.Models;
using PatientsAcounting.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    public partial class DoctorsMenuForm : Form
    {
        private Form? currentChildForm;

        public DoctorsMenuForm()
        {
            InitializeComponent();

            if (AuthBtn != null && logoutBtn != null)
            {
                AuthBtn.Visible = !CurrentUser.IsAuthenticated;
                logoutBtn.Visible = CurrentUser.IsAuthenticated;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.AutoScroll = true;

            if (panelDesktop != null)
            {
                panelDesktop.Controls.Clear();
                panelDesktop.Controls.Add(childForm);

                panelDesktop.Visible = true;
                panelDesktop.BringToFront();
            }
            else
            {
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
            MessageBox.Show("Профиль врача");
        }

        private void AuthBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartAuthMenuForm authForm = new StartAuthMenuForm();
            authForm.ShowDialog();
        }

        private void CardBtn_Click(object sender, EventArgs e)
        {
            DoctorsRegistrationForm doctorsRegistration = new DoctorsRegistrationForm();
            doctorsRegistration.Show();


        }

        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            DoctorScheduleForm scheduleForm = new DoctorScheduleForm();
            OpenChildForm(scheduleForm);
        }

        private void MakeVisitBtn_Click(object sender, EventArgs e)
        {
            AnalystRegistrationForm analystRegistrationForm = new AnalystRegistrationForm();
            OpenChildForm(analystRegistrationForm);
        }

        private void HospitalsBtn_Click(object sender, EventArgs e)
        {
            HospitalsForm hospitalsForm = new HospitalsForm();

            if (panelDesktop != null)
            {
                hospitalsForm.Size = panelDesktop.Size;
            }

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

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}