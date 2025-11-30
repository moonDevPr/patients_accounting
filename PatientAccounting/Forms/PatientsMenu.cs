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
        /*
         * форма вывода общего меню для пациентов
         */

        public PatientsMenu()
        {
            InitializeComponent();
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
        
        // обработчик выхода из аккаунта
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
    }
}