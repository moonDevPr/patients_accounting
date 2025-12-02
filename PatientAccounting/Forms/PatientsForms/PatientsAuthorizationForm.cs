using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Models;
using PatientsAcounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PatientsAccounting.Forms
{
    public partial class PatientsAuthorizationForm : Form
    {
        public PatientsAuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            StartAuthMenuForm startMenuForm = new StartAuthMenuForm();
            startMenuForm.Show();
        }

        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            try
            {
                var authUser = CheckUserCredentials(username, password);
                if (authUser != null)
                {
                    CurrentUser.UserId = authUser.id;
                    CurrentUser.Username = authUser.username;
                    if (authUser.id_users_role.HasValue)
                    {
                        CurrentUser.RoleId = authUser.id_users_role.Value;
                    }
                    CurrentUser.PatientId = authUser.id_patient;

                    var currentPatient = Patient.GetAllInformation((int)CurrentUser.PatientId);


                    if (currentPatient != null)
                    {
                        var (patient, credentials, role) = currentPatient.Value;
                        MessageBox.Show($"Добро пожаловать, {patient.surname} {patient.name} {patient.patronymic}!");

                        CurrentUser.RoleName = role.role_name;

                        if (role.role_name == "Пациент")
                        {
                            PatientsMenu menu = new PatientsMenu();
                            menu.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Добро пожаловать. У вас не выбран тип аккаунта, поэтому наш сервис не может предоставить вам функционал");

                    }

                   
                }

                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка авторизации: {ex.Message}");
            }
        }

        private static UsersCredentials? CheckUserCredentials(string username, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.UsersCredentials
                    .FirstOrDefault(elem => elem.username == username &&
                    elem.active == true);

                if (user != null)
                {
                    string inputHashPassword = HashPassword(password, user.salt);

                    if (inputHashPassword == user.password_hash)
                    {
                        return user;
                    }

                }

                return null;

            }
        }

        private static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                var bytes = Encoding.UTF8.GetBytes(saltedPassword);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }


       

    }
}
