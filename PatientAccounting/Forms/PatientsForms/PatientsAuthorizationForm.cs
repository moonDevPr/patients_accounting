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
                    // Получаем роль
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

                    // Обработка в зависимости от роли
                    if (!string.IsNullOrEmpty(roleName))
                    {
                        switch (roleName)
                        {
                            case "Пациент":
                                var currentPatient = Patient.GetPatientByUsername(username);
                                if (currentPatient != null)
                                {
                                    var (patient, credentials, role) = currentPatient.Value;

                                    CurrentUser.SetUserData(
                                        credentials.id,
                                        credentials.username,
                                        role.id,
                                        role.role_name
                                    );

                                    CurrentUser.SetPatientData(patient.id);

                                    MessageBox.Show($"Добро пожаловать, {patient.surname} {patient.name} {patient.patronymic}!");

                                    PatientsMenu menu = new PatientsMenu();
                                    menu.Show();
                                    this.Hide();
                                }
                                break;

                            case "Врач":
                                var currentDoctor = Doctor.GetDoctorByUsername(username);
                                if (currentDoctor != null)
                                {
                                    var (doctor, credentials, role) = currentDoctor.Value;

                                    CurrentUser.SetUserData(
                                        credentials.id,
                                        credentials.username,
                                        role.id,
                                        role.role_name
                                    );

                                    CurrentUser.SetDoctorData(
                                        doctor.id,
                                        $"{doctor.surname} {doctor.name} {doctor.patronymic}"
                                    );

                                    MessageBox.Show($"Добро пожаловать, {CurrentUser.DoctorFullName}!",
                                        "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    // Устанавливаем базовые данные
                                    CurrentUser.SetUserData(
                                        authUser.id,
                                        authUser.username,
                                        authUser.id_users_role ?? 0,
                                        roleName
                                    );

                                    // Пытаемся найти врача
                                    FindDoctorByUserId(authUser.id);
                                }

                                DoctorsMenuForm form = new DoctorsMenuForm();
                                form.Show();
                                this.Hide();
                                break;

                            case "Аналитик":
                                CurrentUser.SetUserData(
                                    authUser.id,
                                    authUser.username,
                                    authUser.id_users_role ?? 0,
                                    roleName
                                );

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

        private void FindDoctorByUserId(int userId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var doctor = context.Doctors
                        .FirstOrDefault(d => d.id_user_credential == userId);

                    if (doctor != null)
                    {
                        CurrentUser.SetDoctorData(
                            doctor.id,
                            $"{doctor.surname} {doctor.name} {doctor.patronymic}"
                        );

                        Console.WriteLine($"Найден врач: ID={doctor.id}, Name={doctor.surname} {doctor.name}");
                    }
                    else
                    {
                        Console.WriteLine($"Врач не найден для UserId={userId}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка поиска врача: {ex.Message}");
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