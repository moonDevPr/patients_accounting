using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Xml.Linq;
using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;

namespace PatientsAccounting.Forms
{
    partial class AuthorizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel MainPanel;
        private Guna2HtmlLabel TitleLabel;
        private Guna2TextBox UsernameBox;
        private Guna2TextBox PasswordBox;
        private Guna2Button LoginButton;
        private Guna2Button ShowPasswordButton;
        private Guna2HtmlLabel UsernameLabel;
        private Guna2HtmlLabel PasswordLabel;
        private Label subtitleLabel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            CustomizableEdges customizableEdges11 = new CustomizableEdges();
            CustomizableEdges customizableEdges12 = new CustomizableEdges();
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
            label1 = new Label();
            MainPanel = new Guna2Panel();
            backButton = new Guna2Button();
            LoginButton = new Guna2Button();
            ShowPasswordButton = new Guna2Button();
            PasswordLabel = new Guna2HtmlLabel();
            PasswordBox = new Guna2TextBox();
            subtitleLabel = new Label();
            TitleLabel = new Guna2HtmlLabel();
            UsernameBox = new Guna2TextBox();
            UsernameLabel = new Guna2HtmlLabel();
            passwordTimer = new System.Windows.Forms.Timer(components);
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Kristen ITC", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(27, 573);
            label1.Name = "label1";
            label1.Size = new Size(141, 30);
            label1.TabIndex = 19;
            label1.Text = "HealthHub";
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(45, 45, 45);
            MainPanel.Controls.Add(backButton);
            MainPanel.Controls.Add(label1);
            MainPanel.Controls.Add(LoginButton);
            MainPanel.Controls.Add(ShowPasswordButton);
            MainPanel.Controls.Add(PasswordLabel);
            MainPanel.Controls.Add(PasswordBox);
            MainPanel.Controls.Add(subtitleLabel);
            MainPanel.Controls.Add(TitleLabel);
            MainPanel.Controls.Add(UsernameBox);
            MainPanel.Controls.Add(UsernameLabel);
            MainPanel.CustomizableEdges = customizableEdges11;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(2);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            MainPanel.Size = new Size(722, 625);
            MainPanel.TabIndex = 1;
            MainPanel.Paint += MainPanel_Paint;
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
            backButton.Font = new System.Drawing.Font("PT Sans", 10.999999F, FontStyle.Bold, GraphicsUnit.Point, 204);
            backButton.ForeColor = Color.White;
            backButton.HoverState.FillColor = Color.FromArgb(0, 98, 163);
            backButton.Location = new Point(27, 24);
            backButton.Margin = new Padding(2);
            backButton.Name = "backButton";
            backButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            backButton.Size = new Size(127, 53);
            backButton.TabIndex = 20;
            backButton.Text = "назад";
            backButton.Click += backButton_Click;
            // 
            // LoginButton
            // 
            LoginButton.Animated = true;
            LoginButton.BorderRadius = 10;
            LoginButton.CustomizableEdges = customizableEdges3;
            LoginButton.DisabledState.BorderColor = Color.DarkGray;
            LoginButton.DisabledState.CustomBorderColor = Color.DarkGray;
            LoginButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            LoginButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            LoginButton.FillColor = Color.FromArgb(0, 122, 204);
            LoginButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            LoginButton.ForeColor = Color.White;
            LoginButton.HoverState.FillColor = Color.FromArgb(0, 98, 163);
            LoginButton.Location = new Point(202, 487);
            LoginButton.Margin = new Padding(2);
            LoginButton.Name = "LoginButton";
            LoginButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            LoginButton.Size = new Size(300, 50);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Войти";
            LoginButton.Click += LoginButton_Click_1;
            // 
            // ShowPasswordButton
            // 
            ShowPasswordButton.Animated = true;
            ShowPasswordButton.BorderColor = Color.FromArgb(80, 80, 80);
            ShowPasswordButton.BorderRadius = 8;
            ShowPasswordButton.BorderThickness = 1;
            ShowPasswordButton.CustomizableEdges = customizableEdges5;
            ShowPasswordButton.DisabledState.BorderColor = Color.DarkGray;
            ShowPasswordButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ShowPasswordButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ShowPasswordButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ShowPasswordButton.FillColor = Color.FromArgb(70, 70, 70);
            ShowPasswordButton.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ShowPasswordButton.ForeColor = Color.White;
            ShowPasswordButton.HoverState.FillColor = Color.FromArgb(90, 90, 90);
            ShowPasswordButton.Location = new Point(404, 394);
            ShowPasswordButton.Margin = new Padding(2);
            ShowPasswordButton.Name = "ShowPasswordButton";
            ShowPasswordButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ShowPasswordButton.Size = new Size(125, 40);
            ShowPasswordButton.TabIndex = 5;
            ShowPasswordButton.Text = "Показать";
            ShowPasswordButton.Click += ShowPasswordButton_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PasswordLabel.ForeColor = Color.White;
            PasswordLabel.Location = new Point(184, 355);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(84, 32);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "Пароль";
            // 
            // PasswordBox
            // 
            PasswordBox.Animated = true;
            PasswordBox.BorderColor = Color.FromArgb(80, 80, 80);
            PasswordBox.BorderRadius = 8;
            PasswordBox.CustomizableEdges = customizableEdges7;
            PasswordBox.DefaultText = "";
            PasswordBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PasswordBox.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            PasswordBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PasswordBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PasswordBox.FillColor = Color.FromArgb(45, 45, 45);
            PasswordBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            PasswordBox.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            PasswordBox.ForeColor = Color.White;
            PasswordBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            PasswordBox.Location = new Point(184, 394);
            PasswordBox.Margin = new Padding(3, 4, 3, 4);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '•';
            PasswordBox.PlaceholderForeColor = Color.FromArgb(150, 150, 150);
            PasswordBox.PlaceholderText = "Введите пароль";
            PasswordBox.SelectedText = "";
            PasswordBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            PasswordBox.Size = new Size(200, 40);
            PasswordBox.TabIndex = 3;
            PasswordBox.UseSystemPasswordChar = true;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            subtitleLabel.ForeColor = Color.White;
            subtitleLabel.Location = new Point(144, 163);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(430, 38);
            subtitleLabel.TabIndex = 3;
            subtitleLabel.Text = "Войдите в свою учетную запись";
            subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new System.Drawing.Font("Segoe UI Black", 28F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TitleLabel.ForeColor = Color.FromArgb(0, 122, 204);
            TitleLabel.Location = new Point(170, 95);
            TitleLabel.Margin = new Padding(2);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(384, 76);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Авторизация";
            TitleLabel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // UsernameBox
            // 
            UsernameBox.Animated = true;
            UsernameBox.BorderColor = Color.FromArgb(80, 80, 80);
            UsernameBox.BorderRadius = 8;
            UsernameBox.CustomizableEdges = customizableEdges9;
            UsernameBox.DefaultText = "";
            UsernameBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            UsernameBox.DisabledState.FillColor = Color.FromArgb(80, 80, 80);
            UsernameBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            UsernameBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            UsernameBox.FillColor = Color.FromArgb(45, 45, 45);
            UsernameBox.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            UsernameBox.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UsernameBox.ForeColor = Color.White;
            UsernameBox.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            UsernameBox.Location = new Point(184, 281);
            UsernameBox.Margin = new Padding(3, 4, 3, 4);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.PlaceholderForeColor = Color.FromArgb(150, 150, 150);
            UsernameBox.PlaceholderText = "Введите имя пользователя";
            UsernameBox.SelectedText = "";
            UsernameBox.ShadowDecoration.CustomizableEdges = customizableEdges10;
            UsernameBox.Size = new Size(345, 45);
            UsernameBox.TabIndex = 2;
            // 
            // UsernameLabel
            // 
            UsernameLabel.BackColor = Color.Transparent;
            UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            UsernameLabel.ForeColor = Color.White;
            UsernameLabel.Location = new Point(184, 242);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(204, 32);
            UsernameLabel.TabIndex = 0;
            UsernameLabel.Text = "Имя пользователя";
            // 
            // passwordTimer
            // 
            passwordTimer.Interval = 5000;
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 625);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "AuthorizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Авторизация";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            
            if (PasswordBox.PasswordChar == '•' || PasswordBox.UseSystemPasswordChar)
            {
                PasswordBox.PasswordChar = '\0';
                PasswordBox.UseSystemPasswordChar = false;
                ShowPasswordButton.Text = "скрыть";
                passwordTimer.Start();
            }
            else
            {
                PasswordBox.PasswordChar = '•';
                PasswordBox.UseSystemPasswordChar = true;
                ShowPasswordButton.Text = "показать";
                passwordTimer.Stop();
            }
        
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            
            if (ValidateForm())
            {
                
                MessageBox.Show("Авторизация прошла успешно!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private Label label1;
        private Guna2Button backButton;
        private System.Windows.Forms.Timer passwordTimer;
    }
}