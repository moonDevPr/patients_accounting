using Guna.UI2.WinForms;
using PatientsAccounting.Models;
using PatientsAcounting.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            childForm.BringToFront();
            childForm.Show();
        }


        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Главная панель");
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Профиль пациента");
        }

        private void AuthBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartAuthMenuForm authForm = new StartAuthMenuForm();
            authForm.ShowDialog();
        }

        private void CardBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Медицинская карточка");
        }

        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Расписание врачей");
        }

        private void MakeVisitBtn_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("Записаться на прием");
        }

        private void HospitalsBtn_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("Просмотреть информацию о поликлиниках");
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