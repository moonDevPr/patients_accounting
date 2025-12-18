using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    partial class AnalystMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel leftMenuPanel;
        private Guna2Panel contentPanel;
        private Guna2Button dashboardBtn;
        private Guna2Button profileBtn;
        private Guna2Button visitsAnalysisBtn;
        private Guna2Button specialtiesAnalysisBtn;
        private Guna2Button diseasesReportBtn;
        private Guna2Button logoutBtn;
        private Guna2Button AuthBtn;
        private Guna2HtmlLabel guna2HtmlLabel1;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            leftMenuPanel = new Guna2Panel();
            diseasesReportBtn = new Guna2Button();
            specialtiesAnalysisBtn = new Guna2Button();
            logoutBtn = new Guna2Button();
            visitsAnalysisBtn = new Guna2Button();
            profileBtn = new Guna2Button();
            dashboardBtn = new Guna2Button();
            contentPanel = new Guna2Panel();
            AuthBtn = new Guna2Button();
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            leftMenuPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftMenuPanel
            // 
            leftMenuPanel.BackColor = Color.FromArgb(30, 30, 30);
            leftMenuPanel.Controls.Add(diseasesReportBtn);
            leftMenuPanel.Controls.Add(specialtiesAnalysisBtn);
            leftMenuPanel.Controls.Add(logoutBtn);
            leftMenuPanel.Controls.Add(visitsAnalysisBtn);
            leftMenuPanel.Controls.Add(profileBtn);
            leftMenuPanel.Controls.Add(dashboardBtn);
            leftMenuPanel.CustomizableEdges = customizableEdges13;
            leftMenuPanel.Dock = DockStyle.Left;
            leftMenuPanel.Location = new Point(0, 0);
            leftMenuPanel.Name = "leftMenuPanel";
            leftMenuPanel.ShadowDecoration.CustomizableEdges = customizableEdges14;
            leftMenuPanel.Size = new Size(273, 913);
            leftMenuPanel.TabIndex = 0;
            // 
            // diseasesReportBtn
            // 
            diseasesReportBtn.Animated = true;
            diseasesReportBtn.BackColor = Color.Transparent;
            diseasesReportBtn.BorderRadius = 10;
            diseasesReportBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            diseasesReportBtn.CustomizableEdges = customizableEdges1;
            diseasesReportBtn.DisabledState.BorderColor = Color.DarkGray;
            diseasesReportBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            diseasesReportBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            diseasesReportBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            diseasesReportBtn.Dock = DockStyle.Top;
            diseasesReportBtn.FillColor = Color.Transparent;
            diseasesReportBtn.Font = new Font("Segoe UI", 11F);
            diseasesReportBtn.ForeColor = Color.White;
            diseasesReportBtn.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            diseasesReportBtn.ImageAlign = HorizontalAlignment.Left;
            diseasesReportBtn.ImageOffset = new Point(10, 0);
            diseasesReportBtn.Location = new Point(0, 362);
            diseasesReportBtn.Name = "diseasesReportBtn";
            diseasesReportBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            diseasesReportBtn.Size = new Size(273, 85);
            diseasesReportBtn.TabIndex = 6;
            diseasesReportBtn.Text = "Отчет по заболеваниям";
            diseasesReportBtn.TextAlign = HorizontalAlignment.Left;
            diseasesReportBtn.TextOffset = new Point(20, 0);
            diseasesReportBtn.Click += DiseasesReportBtn_Click;
            // 
            // specialtiesAnalysisBtn
            // 
            specialtiesAnalysisBtn.Animated = true;
            specialtiesAnalysisBtn.BackColor = Color.Transparent;
            specialtiesAnalysisBtn.BorderRadius = 10;
            specialtiesAnalysisBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            specialtiesAnalysisBtn.CustomizableEdges = customizableEdges3;
            specialtiesAnalysisBtn.DisabledState.BorderColor = Color.DarkGray;
            specialtiesAnalysisBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            specialtiesAnalysisBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            specialtiesAnalysisBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            specialtiesAnalysisBtn.Dock = DockStyle.Top;
            specialtiesAnalysisBtn.FillColor = Color.Transparent;
            specialtiesAnalysisBtn.Font = new Font("Segoe UI", 11F);
            specialtiesAnalysisBtn.ForeColor = Color.White;
            specialtiesAnalysisBtn.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            specialtiesAnalysisBtn.ImageAlign = HorizontalAlignment.Left;
            specialtiesAnalysisBtn.ImageOffset = new Point(10, 0);
            specialtiesAnalysisBtn.Location = new Point(0, 277);
            specialtiesAnalysisBtn.Name = "specialtiesAnalysisBtn";
            specialtiesAnalysisBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            specialtiesAnalysisBtn.Size = new Size(273, 85);
            specialtiesAnalysisBtn.TabIndex = 5;
            specialtiesAnalysisBtn.Text = "Анализ направлений";
            specialtiesAnalysisBtn.TextAlign = HorizontalAlignment.Left;
            specialtiesAnalysisBtn.TextOffset = new Point(20, 0);
            specialtiesAnalysisBtn.Click += SpecialtiesAnalysisBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Animated = true;
            logoutBtn.BackColor = Color.Transparent;
            logoutBtn.BorderRadius = 10;
            logoutBtn.CustomizableEdges = customizableEdges5;
            logoutBtn.DisabledState.BorderColor = Color.DarkGray;
            logoutBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            logoutBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            logoutBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            logoutBtn.Dock = DockStyle.Bottom;
            logoutBtn.FillColor = Color.Transparent;
            logoutBtn.Font = new Font("Segoe UI", 11F);
            logoutBtn.ForeColor = Color.White;
            logoutBtn.HoverState.FillColor = Color.FromArgb(232, 17, 35);
            logoutBtn.ImageAlign = HorizontalAlignment.Left;
            logoutBtn.ImageOffset = new Point(10, 0);
            logoutBtn.Location = new Point(0, 863);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            logoutBtn.Size = new Size(273, 50);
            logoutBtn.TabIndex = 4;
            logoutBtn.Text = "Выйти";
            logoutBtn.TextAlign = HorizontalAlignment.Left;
            logoutBtn.TextOffset = new Point(20, 0);
            logoutBtn.Click += LogoutBtn_Click;
            // 
            // visitsAnalysisBtn
            // 
            visitsAnalysisBtn.Animated = true;
            visitsAnalysisBtn.BackColor = Color.Transparent;
            visitsAnalysisBtn.BorderRadius = 10;
            visitsAnalysisBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            visitsAnalysisBtn.CustomizableEdges = customizableEdges7;
            visitsAnalysisBtn.DisabledState.BorderColor = Color.DarkGray;
            visitsAnalysisBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            visitsAnalysisBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            visitsAnalysisBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            visitsAnalysisBtn.Dock = DockStyle.Top;
            visitsAnalysisBtn.FillColor = Color.Transparent;
            visitsAnalysisBtn.Font = new Font("Segoe UI", 11F);
            visitsAnalysisBtn.ForeColor = Color.White;
            visitsAnalysisBtn.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            visitsAnalysisBtn.ImageAlign = HorizontalAlignment.Left;
            visitsAnalysisBtn.ImageOffset = new Point(10, 0);
            visitsAnalysisBtn.Location = new Point(0, 184);
            visitsAnalysisBtn.Name = "visitsAnalysisBtn";
            visitsAnalysisBtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            visitsAnalysisBtn.Size = new Size(273, 93);
            visitsAnalysisBtn.TabIndex = 3;
            visitsAnalysisBtn.Text = "Анализ посещаемости";
            visitsAnalysisBtn.TextAlign = HorizontalAlignment.Left;
            visitsAnalysisBtn.TextOffset = new Point(20, 0);
            visitsAnalysisBtn.Click += VisitsAnalysisBtn_Click;
            // 
            // profileBtn
            // 
            profileBtn.Animated = true;
            profileBtn.BackColor = Color.Transparent;
            profileBtn.BorderRadius = 10;
            profileBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            profileBtn.CustomizableEdges = customizableEdges9;
            profileBtn.DisabledState.BorderColor = Color.DarkGray;
            profileBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            profileBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            profileBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            profileBtn.Dock = DockStyle.Top;
            profileBtn.FillColor = Color.Transparent;
            profileBtn.Font = new Font("Segoe UI", 11F);
            profileBtn.ForeColor = Color.White;
            profileBtn.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            profileBtn.ImageAlign = HorizontalAlignment.Left;
            profileBtn.ImageOffset = new Point(10, 0);
            profileBtn.Location = new Point(0, 90);
            profileBtn.Name = "profileBtn";
            profileBtn.ShadowDecoration.CustomizableEdges = customizableEdges10;
            profileBtn.Size = new Size(273, 94);
            profileBtn.TabIndex = 1;
            profileBtn.Text = "Профиль";
            profileBtn.TextAlign = HorizontalAlignment.Left;
            profileBtn.TextOffset = new Point(20, 0);
            profileBtn.Click += ProfileBtn_Click;
            // 
            // dashboardBtn
            // 
            dashboardBtn.Animated = true;
            dashboardBtn.BackColor = Color.Transparent;
            dashboardBtn.BorderRadius = 10;
            dashboardBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            dashboardBtn.Checked = true;
            dashboardBtn.CustomizableEdges = customizableEdges11;
            dashboardBtn.DisabledState.BorderColor = Color.DarkGray;
            dashboardBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            dashboardBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            dashboardBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            dashboardBtn.Dock = DockStyle.Top;
            dashboardBtn.FillColor = Color.Transparent;
            dashboardBtn.Font = new Font("Segoe UI", 11F);
            dashboardBtn.ForeColor = Color.White;
            dashboardBtn.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            dashboardBtn.ImageAlign = HorizontalAlignment.Left;
            dashboardBtn.ImageOffset = new Point(10, 0);
            dashboardBtn.Location = new Point(0, 0);
            dashboardBtn.Name = "dashboardBtn";
            dashboardBtn.ShadowDecoration.CustomizableEdges = customizableEdges12;
            dashboardBtn.Size = new Size(273, 90);
            dashboardBtn.TabIndex = 0;
            dashboardBtn.Text = "Главная";
            dashboardBtn.TextAlign = HorizontalAlignment.Left;
            dashboardBtn.TextOffset = new Point(20, 0);
            dashboardBtn.Click += DashboardBtn_Click;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(45, 45, 45);
            contentPanel.Controls.Add(AuthBtn);
            contentPanel.Controls.Add(guna2HtmlLabel1);
            contentPanel.CustomizableEdges = customizableEdges17;
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(273, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.ShadowDecoration.CustomizableEdges = customizableEdges18;
            contentPanel.Size = new Size(1364, 913);
            contentPanel.TabIndex = 2;
            // 
            // AuthBtn
            // 
            AuthBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AuthBtn.CustomizableEdges = customizableEdges15;
            AuthBtn.DisabledState.BorderColor = Color.DarkGray;
            AuthBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            AuthBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AuthBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AuthBtn.FillColor = Color.FromArgb(64, 64, 64);
            AuthBtn.Font = new Font("Segoe UI", 11F);
            AuthBtn.ForeColor = Color.White;
            AuthBtn.Location = new Point(1128, 21);
            AuthBtn.Name = "AuthBtn";
            AuthBtn.ShadowDecoration.CustomizableEdges = customizableEdges16;
            AuthBtn.Size = new Size(214, 57);
            AuthBtn.TabIndex = 31;
            AuthBtn.Text = "Войти";
            AuthBtn.Click += AuthBtn_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(28, 21);
            guna2HtmlLabel1.Margin = new Padding(2);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(125, 31);
            guna2HtmlLabel1.TabIndex = 30;
            guna2HtmlLabel1.Text = "HealthHub";
            guna2HtmlLabel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // AnalystMenuForm
            // 
            ClientSize = new Size(1637, 913);
            Controls.Add(contentPanel);
            Controls.Add(leftMenuPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AnalystMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Панель аналитика";
            leftMenuPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}