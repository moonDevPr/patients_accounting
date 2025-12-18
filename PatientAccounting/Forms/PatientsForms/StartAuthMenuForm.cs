using PatientsAcounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    public partial class StartAuthMenuForm : Form
    {
        public StartAuthMenuForm()
        {
            InitializeComponent();
        }

        private void PatientsRegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            PatientsRegistrationForm registrationForm = new PatientsRegistrationForm();
            registrationForm.Show();
            this.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            PatientsAuthorizationForm auuthForm = new PatientsAuthorizationForm();
            auuthForm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (CurrentUser.IsAuthenticated)
            {
                switch (CurrentUser.RoleName)
                {
                    case "Врач":
                        DoctorsMenuForm doctorsMenu = new DoctorsMenuForm();
                        doctorsMenu.Show();
                        break;
                    case "Аналитик":
                        AnalystMenuForm analystMenuForm = new AnalystMenuForm();
                        analystMenuForm.Show();
                        break;
                    case "Пациент":
                        PatientsMenu patientsMenu = new PatientsMenu();
                        patientsMenu.Show();
                        break;
                    default:
                        PatientsMenu defaultMenu = new PatientsMenu();
                        defaultMenu.Show();
                        break;
                }
            }
            else
            {
                PatientsMenu patientsMenu = new PatientsMenu();
                patientsMenu.Show();
            }

            this.Hide();
        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}