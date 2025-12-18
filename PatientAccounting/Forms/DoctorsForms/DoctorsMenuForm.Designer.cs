using Guna.UI2.WinForms;

namespace PatientsAccounting.Forms
{
    partial class DoctorsMenuForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel leftMenuPanel;
        private Guna2Panel contentPanel;
        private Guna2Button dashboardBtn;
        private Guna2Button profileBtn;
        private Guna2Button CardBtn;
        private Guna2Button DoctorsScheduleBtn;
        private Guna2Button logoutBtn;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            leftMenuPanel = new Guna2Panel();
            HospitalsBtn = new Guna2Button();
            MakeVisitBtn = new Guna2Button();
            logoutBtn = new Guna2Button();
            DoctorsScheduleBtn = new Guna2Button();
            CardBtn = new Guna2Button();
            profileBtn = new Guna2Button();
            dashboardBtn = new Guna2Button();
            contentPanel = new Guna2Panel();
            panelDesktop = new Panel();
            AuthBtn = new Guna2Button();
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            leftMenuPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftMenuPanel
            // 
            leftMenuPanel.BackColor = Color.FromArgb(30, 30, 30);
            leftMenuPanel.Controls.Add(HospitalsBtn);
            leftMenuPanel.Controls.Add(MakeVisitBtn);
            leftMenuPanel.Controls.Add(logoutBtn);
            leftMenuPanel.Controls.Add(DoctorsScheduleBtn);
            leftMenuPanel.Controls.Add(CardBtn);
            leftMenuPanel.Controls.Add(profileBtn);
            leftMenuPanel.Controls.Add(dashboardBtn);
            leftMenuPanel.CustomizableEdges = customizableEdges15;
            leftMenuPanel.Dock = DockStyle.Left;
            leftMenuPanel.Location = new Point(0, 0);
            leftMenuPanel.Name = "leftMenuPanel";
            leftMenuPanel.ShadowDecoration.CustomizableEdges = customizableEdges16;
            leftMenuPanel.Size = new Size(250, 885);
            leftMenuPanel.TabIndex = 0;
            // 
            // HospitalsBtn
            // 
            HospitalsBtn.Animated = true;
            HospitalsBtn.BackColor = Color.Transparent;
            HospitalsBtn.BorderRadius = 10;
            HospitalsBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            HospitalsBtn.CustomizableEdges = customizableEdges1;
            HospitalsBtn.DisabledState.BorderColor = Color.DarkGray;
            HospitalsBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            HospitalsBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            HospitalsBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            HospitalsBtn.Dock = DockStyle.Top;
            HospitalsBtn.FillColor = Color.Transparent;
            HospitalsBtn.Font = new Font("Segoe UI", 11F);
            HospitalsBtn.ForeColor = Color.White;
            HospitalsBtn.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            HospitalsBtn.ImageAlign = HorizontalAlignment.Left;
            HospitalsBtn.ImageOffset = new Point(10, 0);
            HospitalsBtn.Location = new Point(0, 447);
            HospitalsBtn.Name = "HospitalsBtn";
            HospitalsBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            HospitalsBtn.Size = new Size(250, 85);
            HospitalsBtn.TabIndex = 6;
            HospitalsBtn.Text = "Поликлиники";
            HospitalsBtn.TextAlign = HorizontalAlignment.Left;
            HospitalsBtn.TextOffset = new Point(20, 0);
            HospitalsBtn.Click += HospitalsBtn_Click;
            // 
            // MakeVisitBtn
            // 
            MakeVisitBtn.Animated = true;
            MakeVisitBtn.BackColor = Color.Transparent;
            MakeVisitBtn.BorderRadius = 10;
            MakeVisitBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            MakeVisitBtn.CustomizableEdges = customizableEdges3;
            MakeVisitBtn.DisabledState.BorderColor = Color.DarkGray;
            MakeVisitBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            MakeVisitBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            MakeVisitBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            MakeVisitBtn.Dock = DockStyle.Top;
            MakeVisitBtn.FillColor = Color.Transparent;
            MakeVisitBtn.Font = new Font("Segoe UI", 11F);
            MakeVisitBtn.ForeColor = Color.White;
            MakeVisitBtn.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            MakeVisitBtn.ImageAlign = HorizontalAlignment.Left;
            MakeVisitBtn.ImageOffset = new Point(10, 0);
            MakeVisitBtn.Location = new Point(0, 362);
            MakeVisitBtn.Name = "MakeVisitBtn";
            MakeVisitBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            MakeVisitBtn.Size = new Size(250, 85);
            MakeVisitBtn.TabIndex = 5;
            MakeVisitBtn.Text = "Мои приемы";
            MakeVisitBtn.TextAlign = HorizontalAlignment.Left;
            MakeVisitBtn.TextOffset = new Point(20, 0);
            MakeVisitBtn.Click += MakeVisitBtn_Click;
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
            logoutBtn.Location = new Point(0, 835);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            logoutBtn.Size = new Size(250, 50);
            logoutBtn.TabIndex = 4;
            logoutBtn.Text = "Выйти";
            logoutBtn.TextAlign = HorizontalAlignment.Left;
            logoutBtn.TextOffset = new Point(20, 0);
            logoutBtn.Click += LogoutBtn_Click;
            // 
            // DoctorsScheduleBtn
            // 
            DoctorsScheduleBtn.Animated = true;
            DoctorsScheduleBtn.BackColor = Color.Transparent;
            DoctorsScheduleBtn.BorderRadius = 10;
            DoctorsScheduleBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            DoctorsScheduleBtn.CustomizableEdges = customizableEdges7;
            DoctorsScheduleBtn.DisabledState.BorderColor = Color.DarkGray;
            DoctorsScheduleBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            DoctorsScheduleBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            DoctorsScheduleBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            DoctorsScheduleBtn.Dock = DockStyle.Top;
            DoctorsScheduleBtn.FillColor = Color.Transparent;
            DoctorsScheduleBtn.Font = new Font("Segoe UI", 11F);
            DoctorsScheduleBtn.ForeColor = Color.White;
            DoctorsScheduleBtn.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            DoctorsScheduleBtn.ImageAlign = HorizontalAlignment.Left;
            DoctorsScheduleBtn.ImageOffset = new Point(10, 0);
            DoctorsScheduleBtn.Location = new Point(0, 277);
            DoctorsScheduleBtn.Name = "DoctorsScheduleBtn";
            DoctorsScheduleBtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            DoctorsScheduleBtn.Size = new Size(250, 85);
            DoctorsScheduleBtn.TabIndex = 3;
            DoctorsScheduleBtn.Text = "Найти пациента";
            DoctorsScheduleBtn.TextAlign = HorizontalAlignment.Left;
            DoctorsScheduleBtn.TextOffset = new Point(20, 0);
            DoctorsScheduleBtn.Click += HistoryBtn_Click;
            // 
            // CardBtn
            // 
            CardBtn.Animated = true;
            CardBtn.BackColor = Color.Transparent;
            CardBtn.BorderRadius = 10;
            CardBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            CardBtn.CustomizableEdges = customizableEdges9;
            CardBtn.DisabledState.BorderColor = Color.DarkGray;
            CardBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            CardBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CardBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CardBtn.Dock = DockStyle.Top;
            CardBtn.FillColor = Color.Transparent;
            CardBtn.Font = new Font("Segoe UI", 11F);
            CardBtn.ForeColor = Color.White;
            CardBtn.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            CardBtn.ImageAlign = HorizontalAlignment.Left;
            CardBtn.ImageOffset = new Point(10, 0);
            CardBtn.Location = new Point(0, 184);
            CardBtn.Name = "CardBtn";
            CardBtn.ShadowDecoration.CustomizableEdges = customizableEdges10;
            CardBtn.Size = new Size(250, 93);
            CardBtn.TabIndex = 2;
            CardBtn.Text = "Регистрация врача";
            CardBtn.TextAlign = HorizontalAlignment.Left;
            CardBtn.TextOffset = new Point(20, 0);
            CardBtn.Click += CardBtn_Click;
            // 
            // profileBtn
            // 
            profileBtn.Animated = true;
            profileBtn.BackColor = Color.Transparent;
            profileBtn.BorderRadius = 10;
            profileBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            profileBtn.CustomizableEdges = customizableEdges11;
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
            profileBtn.ShadowDecoration.CustomizableEdges = customizableEdges12;
            profileBtn.Size = new Size(250, 94);
            profileBtn.TabIndex = 1;
            profileBtn.Text = "Профиль врача";
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
            dashboardBtn.CustomizableEdges = customizableEdges13;
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
            dashboardBtn.ShadowDecoration.CustomizableEdges = customizableEdges14;
            dashboardBtn.Size = new Size(250, 90);
            dashboardBtn.TabIndex = 0;
            dashboardBtn.Text = "Главная";
            dashboardBtn.TextAlign = HorizontalAlignment.Left;
            dashboardBtn.TextOffset = new Point(20, 0);
            dashboardBtn.Click += DashboardBtn_Click;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(45, 45, 45);
            contentPanel.Controls.Add(panelDesktop);
            contentPanel.Controls.Add(AuthBtn);
            contentPanel.Controls.Add(guna2HtmlLabel1);
            contentPanel.CustomizableEdges = customizableEdges19;
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(250, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.ShadowDecoration.CustomizableEdges = customizableEdges20;
            contentPanel.Size = new Size(1230, 885);
            contentPanel.TabIndex = 2;
            contentPanel.Paint += contentPanel_Paint;
            // 
            // panelDesktop
            // 
            panelDesktop.Location = new Point(28, 99);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1202, 759);
            panelDesktop.TabIndex = 0;
            // 
            // AuthBtn
            // 
            AuthBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AuthBtn.CustomizableEdges = customizableEdges17;
            AuthBtn.DisabledState.BorderColor = Color.DarkGray;
            AuthBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            AuthBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AuthBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AuthBtn.FillColor = Color.FromArgb(64, 64, 64);
            AuthBtn.Font = new Font("Segoe UI", 11F);
            AuthBtn.ForeColor = Color.White;
            AuthBtn.Location = new Point(994, 21);
            AuthBtn.Name = "AuthBtn";
            AuthBtn.ShadowDecoration.CustomizableEdges = customizableEdges18;
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
            guna2HtmlLabel1.Size = new Size(104, 27);
            guna2HtmlLabel1.TabIndex = 30;
            guna2HtmlLabel1.Text = "HealthHub";
            guna2HtmlLabel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // DoctorsMenuForm
            // 
            ClientSize = new Size(1480, 885);
            Controls.Add(contentPanel);
            Controls.Add(leftMenuPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DoctorsMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Панель пациента";
            leftMenuPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            ResumeLayout(false);
        }
        private Guna2HtmlLabel guna2HtmlLabel1;
        private Guna2Button MakeVisitBtn;
        private Guna2Button AuthBtn;
        private Guna2Button HospitalsBtn;
        private Panel panelDesktop;
    }
}