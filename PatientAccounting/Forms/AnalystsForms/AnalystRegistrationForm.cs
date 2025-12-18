using PatientsAccounting.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    public partial class AnalystRegistrationForm : Form
    {
        private bool passCaptcha = false;

        public AnalystRegistrationForm()
        {
            InitializeComponent();
        }

        private void DoctorsRegistrationForm_Load(object sender, EventArgs e)
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

            if (checkUsernameExists(UsernameBox.Text))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                UsernameBox.Focus();
                UsernameBox.SelectAll();
                return;
            }

            if (!SurnameBox.Text.All(char.IsLetter))
            {
                MessageBox.Show("Фамилия не может содержать числовые значения");
                SurnameBox.Focus();
                SurnameBox.SelectAll();
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
                PatronymicBox.Focus();
                PatronymicBox.SelectAll();
                return;
            }

            var analyst = CreateAnalystRecord();

            var userCredential = CreateUserCredentials(analyst.id);

            SaveToDatabase(analyst, userCredential);

            MessageBox.Show("Учетная запись аналитика создана, для дальнейшего использования авторизуйтесь");
        }

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

        private Doctors CreateAnalystRecord()
        {
            return new Doctors
            {
                surname = SurnameBox.Text,
                name = NameBox.Text,
                patronymic = PatronymicBox.Text
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

        private UsersCredentials CreateUserCredentials(int analystId)
        {
            var salt = GenerateSalt();
            var passwordHash = HashPassword(PasswordBox.Text, salt);

            return new UsersCredentials
            {
                username = UsernameBox.Text.Trim(),
                password_hash = passwordHash,
                active = true,
                created_date = DateTime.UtcNow,
                id_users_role = getAnalystRoleId().id,
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

        private void SaveToDatabase(Doctors analyst, UsersCredentials userCredential)
        {
            using (var context = new ApplicationDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.UsersCredentials.Add(userCredential);
                        context.SaveChanges();

                        analyst.id_user_credential = userCredential.id;
                        context.Doctors.Add(analyst);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        private static UsersRole? getAnalystRoleId()
        {
            UsersRole? role = null;
            using (var context = new ApplicationDbContext())
            {
                role = context.UsersRoles
                    .FirstOrDefault(elem => elem.role_name == "Аналитик");
                if (role != null)
                {
                    return role;
                }
                else
                {
                    var new_role = new UsersRole
                    {
                        role_name = "Аналитик",
                        description = "роль аналитика"
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
            }
            else
            {
                PasswordBox.PasswordChar = '•';
                PasswordBox.UseSystemPasswordChar = true;
                ShowPswButton.Text = "показать";
            }
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}