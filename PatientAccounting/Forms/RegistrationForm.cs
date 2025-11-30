using PatientsAccounting.Models;
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
    public partial class PatientsRegistrationForm : Form
    {
        private bool passCaptcha = false;
        public PatientsRegistrationForm()
        {
            InitializeComponent();
        }

        private void PatientsRegistrationForm_Load(object sender, EventArgs e)
        {

        }
        
        // обработчик кнопки создания аккаунта
        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (!checkFormValid())
            {
                return;
            }

            if (!CapctchaCheckBox.Checked)
            {
                MessageBox.Show("Пройдите капчу для создания аккаунта");
                return;
            }
            
            // проверка username на уникальность
            if (checkUsernameExists(UsernameBox.Text))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                UsernameBox.Focus();
                UsernameBox.SelectAll();
                return;
            }
            
            // создание данных пациента
            var patient = CreatePatientRecord();
            
            // создание записи в таблицу UserCredentials
            var userCredential = CreateUserCredentials(patient.id);

            // сохранение в БД
            SaveToDatabase(patient, userCredential);

            MessageBox.Show("Учетная запись создана, для дальнейшего использования авторизуйтесь");

            this.Close();
            
            // открытие общей формы авторизации / регистрации
            StartAuthMenuForm startForm = new StartAuthMenuForm();
            startForm.Show();


        }
        
        // проверка валидности введенных данных
        private bool checkFormValid()
        {
            if (string.IsNullOrEmpty(SurnameBox.Text) ||
                string.IsNullOrEmpty(NameBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                MessageBox.Show("Проверьте заполнение обязательных полей");
                return false;
            }


            if (PasswordBox.Text.Length < 8)
            {
                MessageBox.Show("Длина пароля меньше допустимой длины");
                
                // выделение поля пароля для указания на ошибку
                PasswordBox.Focus();
                PasswordBox.SelectAll();
                return false;
            }

            return true;
        }
        
        // обработчик открытия формы проверки "я не робот"
        private void CapctchaCheckBox_Click(object sender, EventArgs e)
        {
            if (passCaptcha == true)
            {
                return;
            }

            CapctchaCheckBox.Checked = !CapctchaCheckBox.Checked;
            RegistrationPreviewForm form = new RegistrationPreviewForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                CapctchaCheckBox.Checked = true;
                passCaptcha = true;
            }
            else
            {
                CapctchaCheckBox.Checked = false;
            }


        }
        
        // создание пациента. TODO: добавить дополнительные поля ввода (и снилс)
        private Patients CreatePatientRecord()
        {
            return new Patients
            {
                surname = SurnameBox.Text,
                name = NameBox.Text,
                patronymic = PatronymicBox.Text,
                snils = ""
            };
        }

        public static bool checkUsernameExists(string username)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.UsersCredentials
                    .Any(uc => uc.username == username.Trim());
            }
        }

        // создание записи в таблице UserCredentials
        private UsersCredentials CreateUserCredentials(int PatientId)
        {
            var salt = GenerateSalt();

            var passwordHash = HashPassword(PasswordBox.Text, salt);

            
            return new UsersCredentials
            {
                username = UsernameBox.Text.Trim(),
                password_hash = passwordHash,
                active = true,
                created_date = DateTime.UtcNow,
                id_users_role = getRoleId().id,
                id_patient = PatientId,
                last_login = null,
                id_doctor = null,
                salt = salt

            };
        }
        
        // создание соли
        private string GenerateSalt()
        {
            var saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // создание хэша пароля
        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                var bytes = Encoding.UTF8.GetBytes(saltedPassword);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        
        // сохранение записей в БД
        private void SaveToDatabase(Patients patient, UsersCredentials userCredential)
        {
            using (var context = new ApplicationDbContext())
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Patients.Add(patient);
                        context.SaveChanges();

                        userCredential.id_patient = patient.id;

                        context.UsersCredentials.Add(userCredential);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        
        // получение id роли пациента через запрос
        private static UsersRole? getRoleId()
        {
            UsersRole? role = null;
            using (var context = new ApplicationDbContext())
            {
                role = context.UsersRoles
                    .FirstOrDefault(elem => elem.role_name == "Пациент");
                if (role != null)
                {
                    return role;
                }
                else
                {
                    var new_role = new UsersRole
                    {
                        role_name = "Пациент",
                        description = "просто описание"
                    };

                    context.UsersRoles.Add(new_role);
                    context.SaveChanges();

                    role = new_role;
                }
            }

            return role;
        }



        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            StartAuthMenuForm startForm = new StartAuthMenuForm();
            startForm.ShowDialog();
        }
        
        // обработчик кнопки скрытия и показа пароля
        private void ShowPswButton_Click(object sender, EventArgs e)
        {
            if (PasswordBox.PasswordChar == '•' || PasswordBox.UseSystemPasswordChar)
            {
                PasswordBox.PasswordChar = '\0';
                PasswordBox.UseSystemPasswordChar = false;
                ShowPswButton.Text = "скрыть";
                passwordTimer.Start();
            }
            else
            {
                PasswordBox.PasswordChar = '•';
                PasswordBox.UseSystemPasswordChar = true;
                ShowPswButton.Text = "показать";
                passwordTimer.Stop();
            }
        }

    }

}
