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
        
        
        // обработчик кнопки регистрации - открытие формы
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            PatientsRegistrationForm registrationForm = new PatientsRegistrationForm();
            registrationForm.Show();
            this.Hide();
        }

        // обработчик кнопки авторизации - открытие формы
        private void LoginButton_Click(object sender, EventArgs e)
        {
            AuthorizationForm auuthForm = new AuthorizationForm();
            auuthForm.Show();
            this.Hide();
        }
        
    }
}
