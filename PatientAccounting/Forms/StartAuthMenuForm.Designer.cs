using Guna.UI2.WinForms.Suite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    partial class StartAuthMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Button RegisterButton;
        private Guna.UI2.WinForms.Guna2Button LoginButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel TitleLabel;
        private Guna.UI2.WinForms.Guna2Panel MainPanel;

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
            CustomizableEdges customizableEdges4 = new CustomizableEdges();
            CustomizableEdges customizableEdges5 = new CustomizableEdges();
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            CustomizableEdges customizableEdges3 = new CustomizableEdges();
            MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            subtitleLabel = new Label();
            LoginButton = new Guna.UI2.WinForms.Guna2Button();
            RegisterButton = new Guna.UI2.WinForms.Guna2Button();
            TitleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(45, 45, 45);
            MainPanel.Controls.Add(subtitleLabel);
            MainPanel.Controls.Add(LoginButton);
            MainPanel.Controls.Add(RegisterButton);
            MainPanel.Controls.Add(TitleLabel);
            MainPanel.CustomizableEdges = customizableEdges4;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(2);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges5;
            MainPanel.Size = new Size(769, 625);
            MainPanel.TabIndex = 1;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            subtitleLabel.ForeColor = SystemColors.ButtonHighlight;
            subtitleLabel.Location = new Point(40, 158);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(703, 45);
            subtitleLabel.TabIndex = 3;
            subtitleLabel.Text = "Система управления медицинскими записями";
            // 
            // LoginButton
            // 
            LoginButton.Animated = true;
            LoginButton.BackColor = Color.Transparent;
            LoginButton.BorderRadius = 15;
            LoginButton.CustomizableEdges = customizableEdges1;
            LoginButton.DisabledState.BorderColor = Color.DarkGray;
            LoginButton.DisabledState.CustomBorderColor = Color.DarkGray;
            LoginButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            LoginButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            LoginButton.FillColor = Color.FromArgb(0, 122, 204);
            LoginButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LoginButton.ForeColor = Color.White;
            LoginButton.HoverState.FillColor = Color.FromArgb(0, 98, 163);
            LoginButton.Location = new Point(248, 422);
            LoginButton.Margin = new Padding(2);
            LoginButton.Name = "LoginButton";
            LoginButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            LoginButton.Size = new Size(231, 62);
            LoginButton.TabIndex = 2;
            LoginButton.Text = "Авторизация";
            LoginButton.Click += LoginButton_Click;
            // 
            // RegisterButton
            // 
            RegisterButton.Animated = true;
            RegisterButton.BackColor = Color.Transparent;
            RegisterButton.BorderRadius = 15;
            RegisterButton.CustomizableEdges = customizableEdges1;
            RegisterButton.DisabledState.BorderColor = Color.DarkGray;
            RegisterButton.DisabledState.CustomBorderColor = Color.DarkGray;
            RegisterButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            RegisterButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            RegisterButton.FillColor = Color.FromArgb(76, 175, 80);
            RegisterButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            RegisterButton.ForeColor = Color.White;
            RegisterButton.HoverState.FillColor = Color.FromArgb(56, 142, 60);
            RegisterButton.Location = new Point(248, 299);
            RegisterButton.Margin = new Padding(2);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.ShadowDecoration.CustomizableEdges = customizableEdges3;
            RegisterButton.Size = new Size(231, 62);
            RegisterButton.TabIndex = 1;
            RegisterButton.Text = "Регистрация";
            RegisterButton.Click += RegistrationButton_Click;
            // 
            // TitleLabel
            // 
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new Font("Kristen ITC", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = Color.White;
            TitleLabel.Location = new Point(182, 74);
            TitleLabel.Margin = new Padding(2);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(404, 100);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "HealthHub";
            TitleLabel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // StartMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 625);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "StartMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Главное меню";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Обработчики событий для перемещения формы
        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Внутренний класс для работы с WinAPI
        internal static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            internal static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            internal static extern bool ReleaseCapture();
        }
        private Label subtitleLabel;
    }
}