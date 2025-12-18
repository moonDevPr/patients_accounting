using Guna.UI2.WinForms;

namespace PatientsAccounting.Forms
{
    partial class AnalystRegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel MainPanel;
        private Guna2HtmlLabel lblHealthHub;
        private Guna2HtmlLabel lblRegistration;
        private Guna2Panel panelRegistration;
        private Guna2TextBox SurnameBox;
        private Guna2TextBox NameBox;
        private Guna2TextBox PatronymicBox;
        private Guna2TextBox UsernameBox;
        private Guna2TextBox PasswordBox;
        private Guna2CheckBox CapctchaCheckBox;
        private Guna2Button CreateAccountButton;
        private Guna2Button ShowPswButton;
        private Guna2HtmlLabel lblSurname;
        private Guna2HtmlLabel lblName;
        private Guna2HtmlLabel lblPatronymic;
        private Guna2HtmlLabel lblUsername;
        private Guna2HtmlLabel lblPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            MainPanel = new Guna2Panel();
            lblHealthHub = new Guna2HtmlLabel();
            lblRegistration = new Guna2HtmlLabel();
            panelRegistration = new Guna2Panel();
            ShowPswButton = new Guna2Button();
            PasswordBox = new Guna2TextBox();
            UsernameBox = new Guna2TextBox();
            PatronymicBox = new Guna2TextBox();
            NameBox = new Guna2TextBox();
            SurnameBox = new Guna2TextBox();
            lblPassword = new Guna2HtmlLabel();
            lblUsername = new Guna2HtmlLabel();
            lblPatronymic = new Guna2HtmlLabel();
            lblName = new Guna2HtmlLabel();
            lblSurname = new Guna2HtmlLabel();
            CreateAccountButton = new Guna2Button();
            CapctchaCheckBox = new Guna2CheckBox();
            MainPanel.SuspendLayout();
            panelRegistration.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(45, 45, 45);
            MainPanel.Controls.Add(lblHealthHub);
            MainPanel.Controls.Add(lblRegistration);
            MainPanel.Controls.Add(panelRegistration);
            MainPanel.Controls.Add(CreateAccountButton);
            MainPanel.Controls.Add(CapctchaCheckBox);
            MainPanel.CustomizableEdges = customizableEdges17;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges18;
            MainPanel.Size = new Size(1000, 700);
            MainPanel.TabIndex = 0;
            // 
            // lblHealthHub
            // 
            lblHealthHub.BackColor = Color.Transparent;
            lblHealthHub.Font = new Font("Kristen ITC", 12F, FontStyle.Bold);
            lblHealthHub.ForeColor = Color.White;
            lblHealthHub.Location = new Point(30, 30);
            lblHealthHub.Name = "lblHealthHub";
            lblHealthHub.Size = new Size(142, 35);
            lblHealthHub.TabIndex = 5;
            lblHealthHub.Text = "HealthHub";
            // 
            // lblRegistration
            // 
            lblRegistration.BackColor = Color.Transparent;
            lblRegistration.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            lblRegistration.ForeColor = Color.FromArgb(0, 122, 204);
            lblRegistration.Location = new Point(50, 100);
            lblRegistration.Name = "lblRegistration";
            lblRegistration.Size = new Size(482, 56);
            lblRegistration.TabIndex = 4;
            lblRegistration.Text = "Регистрация аналитика";
            // 
            // panelRegistration
            // 
            panelRegistration.BackColor = Color.FromArgb(60, 60, 60);
            panelRegistration.BorderRadius = 15;
            panelRegistration.Controls.Add(ShowPswButton);
            panelRegistration.Controls.Add(PasswordBox);
            panelRegistration.Controls.Add(UsernameBox);
            panelRegistration.Controls.Add(PatronymicBox);
            panelRegistration.Controls.Add(NameBox);
            panelRegistration.Controls.Add(SurnameBox);
            panelRegistration.Controls.Add(lblPassword);
            panelRegistration.Controls.Add(lblUsername);
            panelRegistration.Controls.Add(lblPatronymic);
            panelRegistration.Controls.Add(lblName);
            panelRegistration.Controls.Add(lblSurname);
            panelRegistration.CustomizableEdges = customizableEdges13;
            panelRegistration.Location = new Point(50, 180);
            panelRegistration.Name = "panelRegistration";
            panelRegistration.ShadowDecoration.CustomizableEdges = customizableEdges14;
            panelRegistration.Size = new Size(900, 350);
            panelRegistration.TabIndex = 3;
            // 
            // ShowPswButton
            // 
            ShowPswButton.Animated = true;
            ShowPswButton.BorderRadius = 8;
            ShowPswButton.CustomizableEdges = customizableEdges1;
            ShowPswButton.DisabledState.BorderColor = Color.DarkGray;
            ShowPswButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ShowPswButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ShowPswButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ShowPswButton.FillColor = Color.FromArgb(80, 80, 80);
            ShowPswButton.Font = new Font("Segoe UI", 9F);
            ShowPswButton.ForeColor = Color.White;
            ShowPswButton.HoverState.FillColor = Color.FromArgb(100, 100, 100);
            ShowPswButton.Location = new Point(720, 280);
            ShowPswButton.Name = "ShowPswButton";
            ShowPswButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ShowPswButton.Size = new Size(130, 45);
            ShowPswButton.TabIndex = 10;
            ShowPswButton.Text = "показать";
            ShowPswButton.Click += ShowPswButton_Click;
            // 
            // PasswordBox
            // 
            PasswordBox.Animated = true;
            PasswordBox.BorderColor = Color.FromArgb(100, 100, 100);
            PasswordBox.BorderRadius = 8;
            PasswordBox.Cursor = Cursors.IBeam;
            PasswordBox.CustomizableEdges = customizableEdges3;
            PasswordBox.DefaultText = "";
            PasswordBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PasswordBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            PasswordBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PasswordBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PasswordBox.FillColor = Color.FromArgb(70, 70, 70);
            PasswordBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            PasswordBox.Font = new Font("Segoe UI", 11F);
            PasswordBox.ForeColor = Color.White;
            PasswordBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            PasswordBox.Location = new Point(200, 280);
            PasswordBox.Margin = new Padding(4, 5, 4, 5);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '•';
            PasswordBox.PlaceholderText = "Введите пароль (минимум 8 символов)";
            PasswordBox.SelectedText = "";
            PasswordBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            PasswordBox.Size = new Size(513, 45);
            PasswordBox.TabIndex = 9;
            PasswordBox.UseSystemPasswordChar = true;
            // 
            // UsernameBox
            // 
            UsernameBox.Animated = true;
            UsernameBox.BorderColor = Color.FromArgb(100, 100, 100);
            UsernameBox.BorderRadius = 8;
            UsernameBox.Cursor = Cursors.IBeam;
            UsernameBox.CustomizableEdges = customizableEdges5;
            UsernameBox.DefaultText = "";
            UsernameBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            UsernameBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            UsernameBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            UsernameBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            UsernameBox.FillColor = Color.FromArgb(70, 70, 70);
            UsernameBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            UsernameBox.Font = new Font("Segoe UI", 11F);
            UsernameBox.ForeColor = Color.White;
            UsernameBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            UsernameBox.Location = new Point(200, 220);
            UsernameBox.Margin = new Padding(4, 5, 4, 5);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.PlaceholderText = "Введите логин";
            UsernameBox.SelectedText = "";
            UsernameBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            UsernameBox.Size = new Size(650, 45);
            UsernameBox.TabIndex = 8;
            // 
            // PatronymicBox
            // 
            PatronymicBox.Animated = true;
            PatronymicBox.BorderColor = Color.FromArgb(100, 100, 100);
            PatronymicBox.BorderRadius = 8;
            PatronymicBox.Cursor = Cursors.IBeam;
            PatronymicBox.CustomizableEdges = customizableEdges7;
            PatronymicBox.DefaultText = "";
            PatronymicBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PatronymicBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            PatronymicBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PatronymicBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PatronymicBox.FillColor = Color.FromArgb(70, 70, 70);
            PatronymicBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            PatronymicBox.Font = new Font("Segoe UI", 11F);
            PatronymicBox.ForeColor = Color.White;
            PatronymicBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            PatronymicBox.Location = new Point(200, 160);
            PatronymicBox.Margin = new Padding(4, 5, 4, 5);
            PatronymicBox.Name = "PatronymicBox";
            PatronymicBox.PlaceholderText = "Введите отчество (необязательно)";
            PatronymicBox.SelectedText = "";
            PatronymicBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            PatronymicBox.Size = new Size(650, 45);
            PatronymicBox.TabIndex = 7;
            // 
            // NameBox
            // 
            NameBox.Animated = true;
            NameBox.BorderColor = Color.FromArgb(100, 100, 100);
            NameBox.BorderRadius = 8;
            NameBox.Cursor = Cursors.IBeam;
            NameBox.CustomizableEdges = customizableEdges9;
            NameBox.DefaultText = "";
            NameBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            NameBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            NameBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            NameBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            NameBox.FillColor = Color.FromArgb(70, 70, 70);
            NameBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            NameBox.Font = new Font("Segoe UI", 11F);
            NameBox.ForeColor = Color.White;
            NameBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            NameBox.Location = new Point(200, 100);
            NameBox.Margin = new Padding(4, 5, 4, 5);
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Введите имя";
            NameBox.SelectedText = "";
            NameBox.ShadowDecoration.CustomizableEdges = customizableEdges10;
            NameBox.Size = new Size(650, 45);
            NameBox.TabIndex = 6;
            // 
            // SurnameBox
            // 
            SurnameBox.Animated = true;
            SurnameBox.BorderColor = Color.FromArgb(100, 100, 100);
            SurnameBox.BorderRadius = 8;
            SurnameBox.Cursor = Cursors.IBeam;
            SurnameBox.CustomizableEdges = customizableEdges11;
            SurnameBox.DefaultText = "";
            SurnameBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            SurnameBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            SurnameBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            SurnameBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            SurnameBox.FillColor = Color.FromArgb(70, 70, 70);
            SurnameBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            SurnameBox.Font = new Font("Segoe UI", 11F);
            SurnameBox.ForeColor = Color.White;
            SurnameBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            SurnameBox.Location = new Point(200, 40);
            SurnameBox.Margin = new Padding(4, 5, 4, 5);
            SurnameBox.Name = "SurnameBox";
            SurnameBox.PlaceholderText = "Введите фамилию";
            SurnameBox.SelectedText = "";
            SurnameBox.ShadowDecoration.CustomizableEdges = customizableEdges12;
            SurnameBox.Size = new Size(650, 45);
            SurnameBox.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(50, 285);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(90, 32);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Пароль:";
            // 
            // lblUsername
            // 
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(50, 225);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(74, 32);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Логин:";
            // 
            // lblPatronymic
            // 
            lblPatronymic.BackColor = Color.Transparent;
            lblPatronymic.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPatronymic.ForeColor = Color.White;
            lblPatronymic.Location = new Point(50, 165);
            lblPatronymic.Name = "lblPatronymic";
            lblPatronymic.Size = new Size(108, 32);
            lblPatronymic.TabIndex = 2;
            lblPatronymic.Text = "Отчество:";
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(50, 105);
            lblName.Name = "lblName";
            lblName.Size = new Size(56, 32);
            lblName.TabIndex = 1;
            lblName.Text = "Имя:";
            // 
            // lblSurname
            // 
            lblSurname.BackColor = Color.Transparent;
            lblSurname.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSurname.ForeColor = Color.White;
            lblSurname.Location = new Point(50, 45);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new Size(110, 32);
            lblSurname.TabIndex = 0;
            lblSurname.Text = "Фамилия:";
            // 
            // CreateAccountButton
            // 
            CreateAccountButton.Animated = true;
            CreateAccountButton.BorderRadius = 10;
            CreateAccountButton.CustomizableEdges = customizableEdges15;
            CreateAccountButton.DisabledState.BorderColor = Color.DarkGray;
            CreateAccountButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CreateAccountButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CreateAccountButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CreateAccountButton.FillColor = Color.FromArgb(40, 167, 69);
            CreateAccountButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            CreateAccountButton.ForeColor = Color.White;
            CreateAccountButton.HoverState.FillColor = Color.FromArgb(33, 136, 56);
            CreateAccountButton.Location = new Point(570, 550);
            CreateAccountButton.Name = "CreateAccountButton";
            CreateAccountButton.ShadowDecoration.CustomizableEdges = customizableEdges16;
            CreateAccountButton.Size = new Size(380, 45);
            CreateAccountButton.TabIndex = 2;
            CreateAccountButton.Text = "Создать аккаунт";
            CreateAccountButton.Click += CreateAccountButton_Click;
            // 
            // CapctchaCheckBox
            // 
            CapctchaCheckBox.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            CapctchaCheckBox.CheckedState.BorderRadius = 5;
            CapctchaCheckBox.CheckedState.BorderThickness = 0;
            CapctchaCheckBox.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            CapctchaCheckBox.Font = new Font("Segoe UI", 11F);
            CapctchaCheckBox.ForeColor = Color.White;
            CapctchaCheckBox.Location = new Point(50, 555);
            CapctchaCheckBox.Name = "CapctchaCheckBox";
            CapctchaCheckBox.Size = new Size(500, 35);
            CapctchaCheckBox.TabIndex = 1;
            CapctchaCheckBox.Text = "Я не робот";
            CapctchaCheckBox.UncheckedState.BorderRadius = 0;
            CapctchaCheckBox.UncheckedState.BorderThickness = 0;
            CapctchaCheckBox.Click += CapctchaCheckBox_Click;
            // 
            // AnalystRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AnalystRegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Регистрация аналитика";
            Load += DoctorsRegistrationForm_Load;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            panelRegistration.ResumeLayout(false);
            panelRegistration.PerformLayout();
            ResumeLayout(false);
        }
    }
}