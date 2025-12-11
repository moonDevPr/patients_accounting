using Guna.UI2.WinForms;
using PatientsAccounting.Forms.AnalystsForms;
using PatientsAcounting.Services;
using System;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    public partial class AnalystMenuForm : Form
    {
        // Текущая открытая дочерняя форма
        private Form? currentChildForm = null;

        public AnalystMenuForm()
        {
            InitializeComponent();

            // Устанавливает видимость кнопок в зависимости от статуса авторизации
            AuthBtn.Visible = !CurrentUser.IsAuthenticated;
            logoutBtn.Visible = CurrentUser.IsAuthenticated;
        }

        // Открывает дочернюю форму внутри главной панели
        private void OpenChildForm(Form childForm)
        {
            // Закрывает предыдущую дочернюю форму, если она открыта
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;

            // Настраивает свойства дочерней формы для встраивания в панель
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Добавляет форму на панель содержимого и отображает ее
            contentPanel.Controls.Add(childForm);
            contentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Обработчик кнопки "Дашборд" - открывает главную панель аналитика
        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            // Главная панель аналитика (функционал в разработке)
            MessageBox.Show("Главная панель аналитика (в разработке)", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Обработчик кнопки "Профиль" - открывает форму профиля аналитика
        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            // Профиль аналитика (функционал в разработке)
            MessageBox.Show("Профиль аналитика (в разработке)", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Обработчик кнопки "Авторизация" - открывает форму входа в систему
        private void AuthBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartAuthMenuForm authForm = new StartAuthMenuForm();
            authForm.ShowDialog();
        }

        // Обработчик кнопки "Анализ посещаемости по врачам"
        private void VisitsAnalysisBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VisitsAnalysisForm());
        }

        // Обработчик кнопки "Анализ популярных направлений врачей"
        private void SpecialtiesAnalysisBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SpecialtiesAnalysisForm());
        }

        // Обработчик кнопки "Числовой отчет по заболеваниям"
        private void DiseasesReportBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DiseasesReportForm());
        }

        // Обработчик кнопки "Выход" - завершает сеанс пользователя
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

        // Обработчик кнопки "Закрыть" - завершает работу приложения
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Обработчик кнопки "Свернуть" - минимизирует окно приложения
        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}