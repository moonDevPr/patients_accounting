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
            this.Close();

            if ((CurrentUser.IsAuthenticated && CurrentUser.RoleName == "Пациент") || (!CurrentUser.IsAuthenticated))
            {
                PatientsMenu patientsMenu = new PatientsMenu();
                patientsMenu.Show();
            }

            
        }
    }
}
