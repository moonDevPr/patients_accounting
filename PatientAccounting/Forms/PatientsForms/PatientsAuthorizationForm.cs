using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Models;
using PatientsAccounting.Services;
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
using static PatientsAcounting.Services.CurrentUser;

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

                    string? roleName = null;
                    using (var context = new ApplicationDbContext())
                    {
                        if (authUser.id_users_role.HasValue)
                        {
                            roleName = context.UsersRoles
                                .Where(r => r.id == authUser.id_users_role.Value)
                                .Select(r => r.role_name)
                                .FirstOrDefault();
                        }
                    }
                    CurrentUser.RoleName = roleName;

                    var currentPatient = Patient.GetPatientByUsername(username);
                    if (currentPatient != null)
                    {
                        // Это пациент
                        var (patient, credentials, role) = currentPatient.Value;
                        CurrentUser.PatientId = patient.id;

                        MessageBox.Show($"Добро пожаловать, {patient.surname} {patient.name} {patient.patronymic}!");

                        PatientsMenu menu = new PatientsMenu();
                        menu.Show();
                        this.Hide();
                        return;
                    }

                    if (!string.IsNullOrEmpty(roleName))
                    {
                        switch (roleName)
                        {
                            case "Врач":
                                var currentDoctor = Doctor.GetDoctorByUsername(username);
                                if (currentDoctor != null)
                                {
                                    var (doctor, credentials, role) = currentDoctor.Value;
                                    MessageBox.Show($"Добро пожаловать, {doctor.surname} {doctor.name} {doctor.patronymic}!");
                                }
                                else
                                {
                                    MessageBox.Show($"Добро пожаловать, врач {username}!");
                                }

                                DoctorsMenuForm form = new DoctorsMenuForm();
                                form.Show();
                                this.Hide();
                                break;

                            case "Аналитик":
                                MessageBox.Show($"Добро пожаловать, аналитик {username}!");
                                AnalystMenuForm analystMenu = new AnalystMenuForm();
                                analystMenu.Show();
                                this.Hide();
                                break;

                            default:
                                MessageBox.Show($"Добро пожаловать, сотрудник {username}! Роль: {roleName}");
                                MessageBox.Show("Для вашей роли еще нет специальной формы");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: не удалось определить роль пользователя");
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

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }


    }

}