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
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }

        // обработчик кнопки возврата к прошлой форме
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            StartAuthMenuForm startMenuForm = new StartAuthMenuForm();
            startMenuForm.Show();
        }

        
        // обработчик кнопки подтверждения авторизации
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
                // проверка введенных данных
                var authUser = CheckUserCredentials(username, password);
                if (authUser != null) // данные найдены - успешный вход
                {
                    CurrentUser.UserId = authUser.id;
                    CurrentUser.Username = authUser.username;
                    if (authUser.id_users_role.HasValue)
                    {
                        CurrentUser.RoleId = authUser.id_users_role.Value;
                    }
                    CurrentUser.PatientId = authUser.id_patient;

                    var currentPatient = getPatient((int)CurrentUser.PatientId);

                    if (currentPatient != null)
                    {
                        MessageBox.Show($"Добро пожаловать, {currentPatient.surname} {currentPatient.name} {currentPatient.patronymic}!");
                        PatientsMenu menu = new PatientsMenu();
                        menu.Show();
                        this.Close();
                    }
                    /*
                     * в случае, если у пользователя нет закрепленной роли, то показ интерфейса для него закрыт
                     */
                    else
                    {
                        MessageBox.Show($"Добро пожаловать. У вас не выбран тип аккаунта, поэтому наш сервис не может предоставить вам функционал");

                    }

                   
                }
                // обработка неверных данных
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль");
                }
            }
            // для дева - вывод ошибок 
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка авторизации: {ex.Message}");
            }
        }

        // функция поиска пользователя по username и password
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

        // хэширование пароля. TODO: добавить pepper к паролю
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

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        // получение пациента по id. TODO: сделать через join в получении UC
        private static Patients getPatient(int patientId)
        {
            using (var context = new ApplicationDbContext())
            {
                var patient = context.Patients
                    .FirstOrDefault(elem => elem.id == patientId);

                return patient;
            }
        }

    }
}
