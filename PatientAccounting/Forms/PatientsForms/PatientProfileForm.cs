using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    public partial class PatientProfileForm : Form
    {
        private int patientId;
        private ApplicationDbContext context;
        private bool isEditMode = false;

        public PatientProfileForm(int patientId)
        {
            InitializeComponent();
            this.patientId = patientId;
            context = new ApplicationDbContext();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadPatientData();
            SetEditMode(false);
        }

        private void LoadPatientData()
        {
            try
            {
                var patient = context.Patients
                    .FirstOrDefault(p => p.id == patientId);

                if (patient == null)
                {
                    MessageBox.Show("Пациент не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtViewUserId.Text = patient.id_user_credential.ToString();
                txtViewSurname.Text = patient.surname ?? "";
                txtViewName.Text = patient.name ?? "";
                txtViewPatronymic.Text = patient.patronymic ?? "";
                txtViewSnils.Text = patient.snils ?? "";
                txtViewPhone.Text = patient.phone ?? "";
                txtViewTown.Text = patient.town ?? "";
                txtViewStreet.Text = patient.street ?? "";
                txtViewHouse.Text = patient.house ?? "";

                txtEditUserId.Text = patient.id_user_credential.ToString();
                txtEditSurname.Text = patient.surname ?? "";
                txtEditName.Text = patient.name ?? "";
                txtEditPatronymic.Text = patient.patronymic ?? "";
                txtEditSnils.Text = patient.snils ?? "";
                txtEditPhone.Text = patient.phone ?? "";
                txtEditTown.Text = patient.town ?? "";
                txtEditStreet.Text = patient.street ?? "";
                txtEditHouse.Text = patient.house ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetEditMode(bool editMode)
        {
            isEditMode = editMode;
            btnEdit.Visible = !editMode;
            btnSave.Visible = editMode;
            btnCancel.Visible = editMode;
            lblStatus.Text = editMode ? "Режим редактирования" : "Режим просмотра";
            txtEditSurname.ReadOnly = !editMode;
            txtEditName.ReadOnly = !editMode;
            txtEditPatronymic.ReadOnly = !editMode;
            txtEditSnils.ReadOnly = !editMode;
            txtEditPhone.ReadOnly = !editMode;
            txtEditTown.ReadOnly = !editMode;
            txtEditStreet.ReadOnly = !editMode;
            txtEditHouse.ReadOnly = !editMode;
            txtEditUserId.ReadOnly = true;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEditSurname.Text))
                {
                    MessageBox.Show("Введите фамилию", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEditSurname.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEditName.Text))
                {
                    MessageBox.Show("Введите имя", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEditName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEditPatronymic.Text))
                {
                    MessageBox.Show("Введите отчество", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEditPatronymic.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEditPhone.Text))
                {
                    MessageBox.Show("Введите телефон", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEditPhone.Focus();
                    return;
                }

                var patient = context.Patients.Find(patientId);
                if (patient == null)
                {
                    MessageBox.Show("Пациент не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                patient.surname = txtEditSurname.Text.Trim();
                patient.name = txtEditName.Text.Trim();
                patient.patronymic = txtEditPatronymic.Text.Trim();
                patient.snils = txtEditSnils.Text.Trim();
                patient.phone = txtEditPhone.Text.Trim();
                patient.town = txtEditTown.Text.Trim();
                patient.street = txtEditStreet.Text.Trim();
                patient.house = txtEditHouse.Text.Trim();

                context.SaveChanges();
                LoadPatientData();
                SetEditMode(false);
                tabControl.SelectedTab = tabPageView;

                MessageBox.Show("Данные успешно сохранены", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoadPatientData();
            SetEditMode(false);
        }

        private bool isPasswordVisible = false;

        private void BtnShowPassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtCurrentPassword.UseSystemPasswordChar = false;
                txtNewPassword.UseSystemPasswordChar = false;
                txtConfirmNewPassword.UseSystemPasswordChar = false;
                btnShowPassword.Text = "скрыть";
            }
            else
            {
                txtCurrentPassword.UseSystemPasswordChar = true;
                txtNewPassword.UseSystemPasswordChar = true;
                txtConfirmNewPassword.UseSystemPasswordChar = true;
                btnShowPassword.Text = "показать";
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
                {
                    MessageBox.Show("Введите текущий пароль", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCurrentPassword.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    MessageBox.Show("Введите новый пароль", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPassword.Focus();
                    return;
                }

                if (txtNewPassword.Text != txtConfirmNewPassword.Text)
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmNewPassword.Focus();
                    return;
                }

                if (txtNewPassword.Text.Length < 6)
                {
                    MessageBox.Show("Пароль должен быть не менее 6 символов", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPassword.Focus();
                    return;
                }

                var patient = context.Patients.Find(patientId);
                if (patient == null)
                {
                    MessageBox.Show("Пациент не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var userCredential = context.UsersCredentials
                    .FirstOrDefault(u => u.id == patient.id_user_credential);

                if (userCredential == null)
                {
                    MessageBox.Show("Учетные данные не найдены", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string currentPassword = HashPassword(txtCurrentPassword.Text, userCredential.salt);
                if (userCredential.password_hash != currentPassword)
                {
                    MessageBox.Show("Текущий пароль неверен", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                userCredential.password_hash = HashPassword(txtNewPassword.Text, userCredential.salt);
                context.SaveChanges();

                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmNewPassword.Clear();

                MessageBox.Show("Пароль успешно изменен", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                tabControl.SelectedTab = tabPageView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            context?.Dispose();
            base.OnFormClosing(e);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void tabPageView_Click(object sender, EventArgs e)
        {

        }
    }
}