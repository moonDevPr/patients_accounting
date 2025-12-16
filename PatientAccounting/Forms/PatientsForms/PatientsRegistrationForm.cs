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
using static System.Net.Mime.MediaTypeNames;

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

            //
            if ((SnilsTextBox.Text.Length < 11) || (SnilsTextBox.Text.Length > 11))
            {
                MessageBox.Show("Неверный номер СНИЛСа. Номер должен содержать 11 символов");
                SnilsTextBox.Focus();
                SnilsTextBox.SelectAll();
                return;
            }



            if (checkUsernameExists(UsernameBox.Text))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                UsernameBox.Focus();
                UsernameBox.SelectAll();
                return;
            }

            if (checkSnilsExists(SnilsTextBox.Text) == true)
            {
                MessageBox.Show("Пользователь с таким номером СНИЛС уже существует");
                SnilsTextBox.Focus();
                SnilsTextBox.SelectAll();
                return;
            }

            if (!UsernameBox.Text.All(char.IsLetter))
            {
                MessageBox.Show("Фамилия пользователя не может содержать числовые значения");
                UsernameBox.Focus();
                UsernameBox.SelectAll();
                return;
            }

            if (!NameBox.Text.All(char.IsLetter))
            {
                MessageBox.Show("Имя не может содержать числовые значения");
                NameBox.Focus();
                NameBox.SelectAll();
                return;
            }

            if ((!string.IsNullOrWhiteSpace(PatronymicBox.Text)) && (!PatronymicBox.Text.All(char.IsLetter)))
            {
                MessageBox.Show("Отчество не может содержать числовые значения");
                NameBox.Focus();
                NameBox.SelectAll();
                return;
            }

            var patient = CreatePatientRecord();

            var userCredential = CreateUserCredentials(patient.id);

            //var patientCard = CreatePatientCard(patient.id);

            SaveToDatabase(patient, userCredential);

            MessageBox.Show("Учетная запись создана, для дальнейшего использования авторизуйтесь");

            this.Close();

            PatientsAuthorizationForm patientsAuthForm = new PatientsAuthorizationForm();
            patientsAuthForm.Show();


        }

        private bool checkFormValid()
        {
            if (string.IsNullOrEmpty(SurnameBox.Text) ||
                string.IsNullOrEmpty(NameBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Text) ||
                string.IsNullOrWhiteSpace(SnilsTextBox.Text))
            {
                MessageBox.Show("Проверьте заполнение обязательных полей");
                return false;
            }


            if (PasswordBox.Text.Length < 8)
            {
                MessageBox.Show("Длина пароля меньше допустимой длины");
                PasswordBox.Focus();
                PasswordBox.SelectAll();
                return false;
            }

            return true;
        }

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

        private Patients CreatePatientRecord()
        {
            return new Patients
            {
                surname = SurnameBox.Text,
                name = NameBox.Text,
                patronymic = PatronymicBox.Text,
                snils = SnilsTextBox.Text
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
                last_login = null,
                salt = salt

            };
        }

        private string GenerateSalt()
        {
            var saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

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

        private void SaveToDatabase(Patients patient, UsersCredentials userCredential)
        {
            using (var context = new ApplicationDbContext())
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.UsersCredentials.Add(userCredential);
                        context.SaveChanges();

                        patient.id_user_credential = userCredential.id;
                        context.Patients.Add(patient);
                        context.SaveChanges();


                        var patientCard = new PatientCards
                        {
                            id_patient = patient.id,
                            code = patient.id + 10,
                        };

                        context.PatientCards.Add(patientCard);
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

        private bool checkSnilsExists(string inputSnils)
        {
            Patients? snils = null;
            using (var context = new ApplicationDbContext())
            {
                snils = context.Patients
                    .FirstOrDefault(elem => elem.snils == inputSnils);
                if (snils != null)
                {
                    return true;
                }
                return false;
            }
        }

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
