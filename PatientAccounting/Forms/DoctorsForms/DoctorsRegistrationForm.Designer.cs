using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System.Drawing;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    partial class DoctorsRegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel MainPanel;
        private Guna2HtmlLabel TitleLabel;
        private Label subtitleLabel;
        private Guna2TextBox SurnameBox;
        private Guna2TextBox NameBox;
        private Guna2TextBox PatronymicBox;
        private Guna2TextBox UsernameBox;
        private Guna2TextBox PasswordBox;
        private Guna2HtmlLabel SurnameLabel;
        private Guna2HtmlLabel NameLabel;
        private Guna2HtmlLabel PatronymicLabel;
        private Guna2HtmlLabel UsernameLabel;
        private Guna2HtmlLabel PasswordLabel;
        private Guna2Button CreateAccountButton;
        private Guna2Button ShowPswButton;
        private Guna2HtmlLabel guna2HtmlLabel1;
        private Guna2Button backButton;
        private CheckBox CapctchaCheckBox;
        private System.Windows.Forms.Timer passwordTimer;
        private Guna2ShadowForm guna2ShadowForm1;

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
            components = new System.ComponentModel.Container();
            CustomizableEdges customizableEdges17 = new CustomizableEdges();
            CustomizableEdges customizableEdges18 = new CustomizableEdges();
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            CustomizableEdges customizableEdges3 = new CustomizableEdges();
            CustomizableEdges customizableEdges4 = new CustomizableEdges();
            CustomizableEdges customizableEdges5 = new CustomizableEdges();
            CustomizableEdges customizableEdges6 = new CustomizableEdges();
            CustomizableEdges customizableEdges7 = new CustomizableEdges();
            CustomizableEdges customizableEdges8 = new CustomizableEdges();
            CustomizableEdges customizableEdges9 = new CustomizableEdges();
            CustomizableEdges customizableEdges10 = new CustomizableEdges();
            CustomizableEdges customizableEdges11 = new CustomizableEdges();
            CustomizableEdges customizableEdges12 = new CustomizableEdges();
            CustomizableEdges customizableEdges13 = new CustomizableEdges();
            CustomizableEdges customizableEdges14 = new CustomizableEdges();
            CustomizableEdges customizableEdges15 = new CustomizableEdges();
            CustomizableEdges customizableEdges16 = new CustomizableEdges();
            MainPanel = new Guna2Panel();
            CapctchaCheckBox = new CheckBox();
            backButton = new Guna2Button();
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            ShowPswButton = new Guna2Button();
            CreateAccountButton = new Guna2Button();
            PasswordLabel = new Guna2HtmlLabel();
            UsernameLabel = new Guna2HtmlLabel();
            PatronymicLabel = new Guna2HtmlLabel();
            NameLabel = new Guna2HtmlLabel();
            SurnameLabel = new Guna2HtmlLabel();
            PasswordBox = new Guna2TextBox();
            UsernameBox = new Guna2TextBox();
            PatronymicBox = new Guna2TextBox();
            NameBox = new Guna2TextBox();
            SurnameBox = new Guna2TextBox();
            subtitleLabel = new Label();
            TitleLabel = new Guna2HtmlLabel();
            passwordTimer = new System.Windows.Forms.Timer(components);
            guna2ShadowForm1 = new Guna2ShadowForm(components);
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(45, 45, 45);
            MainPanel.Controls.Add(CapctchaCheckBox);
            MainPanel.Controls.Add(backButton);
            MainPanel.Controls.Add(guna2HtmlLabel1);
            MainPanel.Controls.Add(ShowPswButton);
            MainPanel.Controls.Add(CreateAccountButton);
            MainPanel.Controls.Add(PasswordLabel);
            MainPanel.Controls.Add(UsernameLabel);
            MainPanel.Controls.Add(PatronymicLabel);
            MainPanel.Controls.Add(NameLabel);
            MainPanel.Controls.Add(SurnameLabel);
            MainPanel.Controls.Add(PasswordBox);
            MainPanel.Controls.Add(UsernameBox);
            MainPanel.Controls.Add(PatronymicBox);
            MainPanel.Controls.Add(NameBox);
            MainPanel.Controls.Add(SurnameBox);
            MainPanel.Controls.Add(subtitleLabel);
            MainPanel.Controls.Add(TitleLabel);
            MainPanel.CustomizableEdges = customizableEdges17;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(2);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges18;
            MainPanel.Size = new Size(800, 869);
            MainPanel.TabIndex = 1;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // CapctchaCheckBox
            // 
            CapctchaCheckBox.AutoSize = true;
            CapctchaCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            CapctchaCheckBox.ForeColor = SystemColors.ButtonHighlight;
            CapctchaCheckBox.Location = new Point(166, 717);
            CapctchaCheckBox.Name = "CapctchaCheckBox";
            CapctchaCheckBox.Size = new Size(143, 32);
            CapctchaCheckBox.TabIndex = 31;
            CapctchaCheckBox.Text = "Я не робот";
            CapctchaCheckBox.UseVisualStyleBackColor = true;
            CapctchaCheckBox.Click += CapctchaCheckBox_Click;
            // 
            // backButton
            // 
            backButton.Animated = true;
            backButton.BorderRadius = 10;
            backButton.CustomizableEdges = customizableEdges1;
            backButton.DisabledState.BorderColor = Color.DarkGray;
            backButton.DisabledState.CustomBorderColor = Color.DarkGray;
            backButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            backButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            backButton.FillColor = Color.DimGray;
            backButton.Font = new Font("PT Sans", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 204);
            backButton.ForeColor = Color.White;
            backButton.HoverState.FillColor = Color.FromArgb(0, 98, 163);
            backButton.Location = new Point(24, 30);
            backButton.Margin = new Padding(2);
            backButton.Name = "backButton";
            backButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            backButton.Size = new Size(127, 53);
            backButton.TabIndex = 30;
            backButton.Text = "назад";
            backButton.Click += backButton_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Kristen ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(647, 823);
            guna2HtmlLabel1.Margin = new Padding(2);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(142, 35);
            guna2HtmlLabel1.TabIndex = 29;
            guna2HtmlLabel1.Text = "HealthHub";
            guna2HtmlLabel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // ShowPswButton
            // 
            ShowPswButton.Animated = true;
            ShowPswButton.BackColor = Color.Transparent;
            ShowPswButton.BorderColor = Color.FromArgb(100, 100, 100);
            ShowPswButton.BorderRadius = 8;
            ShowPswButton.BorderThickness = 1;
            ShowPswButton.CustomizableEdges = customizableEdges3;
            ShowPswButton.DisabledState.BorderColor = Color.DarkGray;
            ShowPswButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ShowPswButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ShowPswButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ShowPswButton.FillColor = Color.FromArgb(60, 60, 60);
            ShowPswButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShowPswButton.ForeColor = Color.White;
            ShowPswButton.HoverState.FillColor = Color.FromArgb(80, 80, 80);
            ShowPswButton.Location = new Point(524, 608);
            ShowPswButton.Name = "ShowPswButton";
            ShowPswButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ShowPswButton.Size = new Size(112, 45);
            ShowPswButton.TabIndex = 27;
            ShowPswButton.Text = "показать";
            ShowPswButton.Click += ShowPswButton_Click;
            // 
            // CreateAccountButton
            // 
            CreateAccountButton.Animated = true;
            CreateAccountButton.BackColor = Color.Transparent;
            CreateAccountButton.BorderRadius = 15;
            CreateAccountButton.CustomizableEdges = customizableEdges5;
            CreateAccountButton.DisabledState.BorderColor = Color.DarkGray;
            CreateAccountButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CreateAccountButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CreateAccountButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CreateAccountButton.FillColor = Color.FromArgb(76, 175, 80);
            CreateAccountButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            CreateAccountButton.ForeColor = Color.White;
            CreateAccountButton.HoverState.FillColor = Color.FromArgb(56, 142, 60);
            CreateAccountButton.Location = new Point(267, 773);
            CreateAccountButton.Name = "CreateAccountButton";
            CreateAccountButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            CreateAccountButton.Size = new Size(249, 50);
            CreateAccountButton.TabIndex = 26;
            CreateAccountButton.Text = "Создать аккаунт";
            CreateAccountButton.Click += CreateAccountButton_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PasswordLabel.ForeColor = Color.White;
            PasswordLabel.Location = new Point(166, 568);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(100, 32);
            PasswordLabel.TabIndex = 24;
            PasswordLabel.Text = "Пароль *";
            // 
            // UsernameLabel
            // 
            UsernameLabel.BackColor = Color.Transparent;
            UsernameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            UsernameLabel.ForeColor = Color.White;
            UsernameLabel.Location = new Point(166, 455);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(220, 32);
            UsernameLabel.TabIndex = 23;
            UsernameLabel.Text = "Имя пользователя *";
            // 
            // PatronymicLabel
            // 
            PatronymicLabel.BackColor = Color.Transparent;
            PatronymicLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PatronymicLabel.ForeColor = Color.White;
            PatronymicLabel.Location = new Point(166, 324);
            PatronymicLabel.Name = "PatronymicLabel";
            PatronymicLabel.Size = new Size(102, 32);
            PatronymicLabel.TabIndex = 22;
            PatronymicLabel.Text = "Отчество";
            // 
            // NameLabel
            // 
            NameLabel.BackColor = Color.Transparent;
            NameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            NameLabel.ForeColor = Color.White;
            NameLabel.Location = new Point(166, 231);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(66, 32);
            NameLabel.TabIndex = 21;
            NameLabel.Text = "Имя *";
            // 
            // SurnameLabel
            // 
            SurnameLabel.BackColor = Color.Transparent;
            SurnameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            SurnameLabel.ForeColor = Color.White;
            SurnameLabel.Location = new Point(166, 129);
            SurnameLabel.Name = "SurnameLabel";
            SurnameLabel.Size = new Size(120, 32);
            SurnameLabel.TabIndex = 20;
            SurnameLabel.Text = "Фамилия *";
            // 
            // PasswordBox
            // 
            PasswordBox.Animated = true;
            PasswordBox.BorderColor = Color.FromArgb(100, 100, 100);
            PasswordBox.BorderRadius = 8;
            PasswordBox.CustomizableEdges = customizableEdges7;
            PasswordBox.DefaultText = "";
            PasswordBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PasswordBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            PasswordBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PasswordBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PasswordBox.FillColor = Color.FromArgb(60, 60, 60);
            PasswordBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            PasswordBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            PasswordBox.ForeColor = Color.White;
            PasswordBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            PasswordBox.Location = new Point(199, 608);
            PasswordBox.Margin = new Padding(4, 5, 4, 5);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '•';
            PasswordBox.PlaceholderForeColor = Color.Gray;
            PasswordBox.PlaceholderText = "Введите пароль";
            PasswordBox.SelectedText = "";
            PasswordBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            PasswordBox.Size = new Size(318, 45);
            PasswordBox.TabIndex = 19;
            PasswordBox.UseSystemPasswordChar = true;
            // 
            // UsernameBox
            // 
            UsernameBox.Animated = true;
            UsernameBox.BorderColor = Color.FromArgb(100, 100, 100);
            UsernameBox.BorderRadius = 8;
            UsernameBox.CustomizableEdges = customizableEdges9;
            UsernameBox.DefaultText = "";
            UsernameBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            UsernameBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            UsernameBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            UsernameBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            UsernameBox.FillColor = Color.FromArgb(60, 60, 60);
            UsernameBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            UsernameBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UsernameBox.ForeColor = Color.White;
            UsernameBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            UsernameBox.Location = new Point(197, 495);
            UsernameBox.Margin = new Padding(4, 5, 4, 5);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.PlaceholderForeColor = Color.Gray;
            UsernameBox.PlaceholderText = "Введите имя пользователя";
            UsernameBox.SelectedText = "";
            UsernameBox.ShadowDecoration.CustomizableEdges = customizableEdges10;
            UsernameBox.Size = new Size(438, 45);
            UsernameBox.TabIndex = 18;
            // 
            // PatronymicBox
            // 
            PatronymicBox.Animated = true;
            PatronymicBox.BorderColor = Color.FromArgb(100, 100, 100);
            PatronymicBox.BorderRadius = 8;
            PatronymicBox.CustomizableEdges = customizableEdges11;
            PatronymicBox.DefaultText = "";
            PatronymicBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PatronymicBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            PatronymicBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PatronymicBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PatronymicBox.FillColor = Color.FromArgb(60, 60, 60);
            PatronymicBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            PatronymicBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            PatronymicBox.ForeColor = Color.White;
            PatronymicBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            PatronymicBox.Location = new Point(198, 364);
            PatronymicBox.Margin = new Padding(4, 5, 4, 5);
            PatronymicBox.Name = "PatronymicBox";
            PatronymicBox.PlaceholderForeColor = Color.Gray;
            PatronymicBox.PlaceholderText = "Введите отчество";
            PatronymicBox.SelectedText = "";
            PatronymicBox.ShadowDecoration.CustomizableEdges = customizableEdges12;
            PatronymicBox.Size = new Size(438, 45);
            PatronymicBox.TabIndex = 17;
            // 
            // NameBox
            // 
            NameBox.Animated = true;
            NameBox.BorderColor = Color.FromArgb(100, 100, 100);
            NameBox.BorderRadius = 8;
            NameBox.CustomizableEdges = customizableEdges13;
            NameBox.DefaultText = "";
            NameBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            NameBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            NameBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            NameBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            NameBox.FillColor = Color.FromArgb(60, 60, 60);
            NameBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            NameBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NameBox.ForeColor = Color.White;
            NameBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            NameBox.Location = new Point(199, 271);
            NameBox.Margin = new Padding(4, 5, 4, 5);
            NameBox.Name = "NameBox";
            NameBox.PlaceholderForeColor = Color.Gray;
            NameBox.PlaceholderText = "Введите имя";
            NameBox.SelectedText = "";
            NameBox.ShadowDecoration.CustomizableEdges = customizableEdges14;
            NameBox.Size = new Size(438, 45);
            NameBox.TabIndex = 16;
            // 
            // SurnameBox
            // 
            SurnameBox.Animated = true;
            SurnameBox.BorderColor = Color.FromArgb(100, 100, 100);
            SurnameBox.BorderRadius = 8;
            SurnameBox.CustomizableEdges = customizableEdges15;
            SurnameBox.DefaultText = "";
            SurnameBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            SurnameBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            SurnameBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            SurnameBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            SurnameBox.FillColor = Color.FromArgb(60, 60, 60);
            SurnameBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            SurnameBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            SurnameBox.ForeColor = Color.White;
            SurnameBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            SurnameBox.Location = new Point(199, 169);
            SurnameBox.Margin = new Padding(4, 5, 4, 5);
            SurnameBox.Name = "SurnameBox";
            SurnameBox.PlaceholderForeColor = Color.Gray;
            SurnameBox.PlaceholderText = "Введите фамилию";
            SurnameBox.SelectedText = "";
            SurnameBox.ShadowDecoration.CustomizableEdges = customizableEdges16;
            SurnameBox.Size = new Size(438, 45);
            SurnameBox.TabIndex = 15;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            subtitleLabel.ForeColor = SystemColors.ButtonHighlight;
            subtitleLabel.Location = new Point(304, 85);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(223, 32);
            subtitleLabel.TabIndex = 28;
            subtitleLabel.Text = "регистрация врача";
            // 
            // TitleLabel
            // 
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TitleLabel.ForeColor = Color.FromArgb(0, 122, 204);
            TitleLabel.Location = new Point(279, 16);
            TitleLabel.Margin = new Padding(2);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(311, 67);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Регистрация";
            TitleLabel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // passwordTimer
            // 
            passwordTimer.Interval = 5000;
            // 
            // guna2ShadowForm1
            // 
            guna2ShadowForm1.TargetForm = this;
            // 
            // DoctorsRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 869);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "DoctorsRegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Регистрация врача";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}