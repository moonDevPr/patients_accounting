using Guna.UI2.WinForms;

namespace PatientsAccounting.Forms
{
    partial class PatientCardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel MainPanel;
        private Guna2Panel panelView;
        private Guna2HtmlLabel lblTitle;
        private Guna2HtmlLabel lblCardId;
        private Guna2HtmlLabel lblCardCode;
        private Guna2HtmlLabel lblHospital;
        private Guna2HtmlLabel lblPatientId;
        private Guna2HtmlLabel lblFullName;
        private Guna2TextBox txtCardId;
        private Guna2TextBox txtCardCode;
        private Guna2TextBox txtHospital;
        private Guna2TextBox txtPatientId;
        private Guna2TextBox txtFullName;
        private Guna2Button btnBack;
        private Guna2Button btnRefresh;
        private Guna2Button btnPrint;
        private DataGridView dataGridViewVisits;
        private Guna2HtmlLabel lblVisitsHistory;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            MainPanel = new Guna2Panel();
            dataGridViewVisits = new DataGridView();
            lblVisitsHistory = new Guna2HtmlLabel();
            btnPrint = new Guna2Button();
            btnRefresh = new Guna2Button();
            btnBack = new Guna2Button();
            panelView = new Guna2Panel();
            txtFullName = new Guna2TextBox();
            txtPatientId = new Guna2TextBox();
            txtHospital = new Guna2TextBox();
            txtCardCode = new Guna2TextBox();
            txtCardId = new Guna2TextBox();
            lblFullName = new Guna2HtmlLabel();
            lblPatientId = new Guna2HtmlLabel();
            lblHospital = new Guna2HtmlLabel();
            lblCardCode = new Guna2HtmlLabel();
            lblCardId = new Guna2HtmlLabel();
            lblTitle = new Guna2HtmlLabel();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVisits).BeginInit();
            panelView.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(45, 45, 45);
            MainPanel.Controls.Add(dataGridViewVisits);
            MainPanel.Controls.Add(lblVisitsHistory);
            MainPanel.Controls.Add(btnPrint);
            MainPanel.Controls.Add(btnRefresh);
            MainPanel.Controls.Add(btnBack);
            MainPanel.Controls.Add(panelView);
            MainPanel.Controls.Add(lblTitle);
            MainPanel.CustomizableEdges = customizableEdges19;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges20;
            MainPanel.Size = new Size(1200, 800);
            MainPanel.TabIndex = 0;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // dataGridViewVisits
            // 
            dataGridViewVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVisits.BackgroundColor = Color.FromArgb(60, 60, 60);
            dataGridViewVisits.BorderStyle = BorderStyle.None;
            dataGridViewVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewVisits.GridColor = Color.FromArgb(80, 80, 80);
            dataGridViewVisits.Location = new Point(50, 475);
            dataGridViewVisits.Name = "dataGridViewVisits";
            dataGridViewVisits.ReadOnly = true;
            dataGridViewVisits.RowHeadersWidth = 51;
            dataGridViewVisits.RowTemplate.Height = 29;
            dataGridViewVisits.Size = new Size(894, 250);
            dataGridViewVisits.TabIndex = 6;
            // 
            // lblVisitsHistory
            // 
            lblVisitsHistory.BackColor = Color.Transparent;
            lblVisitsHistory.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblVisitsHistory.ForeColor = Color.FromArgb(0, 122, 204);
            lblVisitsHistory.Location = new Point(50, 429);
            lblVisitsHistory.Name = "lblVisitsHistory";
            lblVisitsHistory.Size = new Size(282, 40);
            lblVisitsHistory.TabIndex = 5;
            lblVisitsHistory.Text = "История посещений";
            // 
            // btnPrint
            // 
            btnPrint.Animated = true;
            btnPrint.BorderRadius = 10;
            btnPrint.CustomizableEdges = customizableEdges1;
            btnPrint.DisabledState.BorderColor = Color.DarkGray;
            btnPrint.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrint.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrint.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrint.FillColor = Color.FromArgb(40, 167, 69);
            btnPrint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.HoverState.FillColor = Color.FromArgb(33, 136, 56);
            btnPrint.Location = new Point(685, 68);
            btnPrint.Name = "btnPrint";
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPrint.Size = new Size(180, 45);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "Печать карты";
            btnPrint.Click += BtnPrint_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Animated = true;
            btnRefresh.BorderRadius = 10;
            btnRefresh.CustomizableEdges = customizableEdges3;
            btnRefresh.DisabledState.BorderColor = Color.DarkGray;
            btnRefresh.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRefresh.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRefresh.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRefresh.FillColor = Color.FromArgb(0, 122, 204);
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.HoverState.FillColor = Color.FromArgb(0, 98, 163);
            btnRefresh.Location = new Point(685, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnRefresh.Size = new Size(180, 45);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить";
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnBack
            // 
            btnBack.Animated = true;
            btnBack.BorderRadius = 10;
            btnBack.CustomizableEdges = customizableEdges5;
            btnBack.DisabledState.BorderColor = Color.DarkGray;
            btnBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBack.FillColor = Color.FromArgb(100, 100, 100);
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.HoverState.FillColor = Color.FromArgb(120, 120, 120);
            btnBack.Location = new Point(50, 30);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnBack.Size = new Size(180, 45);
            btnBack.TabIndex = 2;
            btnBack.Text = "Назад";
            btnBack.Click += BtnBack_Click;
            // 
            // panelView
            // 
            panelView.BackColor = Color.FromArgb(60, 60, 60);
            panelView.BorderRadius = 15;
            panelView.Controls.Add(txtFullName);
            panelView.Controls.Add(txtPatientId);
            panelView.Controls.Add(txtHospital);
            panelView.Controls.Add(txtCardCode);
            panelView.Controls.Add(txtCardId);
            panelView.Controls.Add(lblFullName);
            panelView.Controls.Add(lblPatientId);
            panelView.Controls.Add(lblHospital);
            panelView.Controls.Add(lblCardCode);
            panelView.Controls.Add(lblCardId);
            panelView.CustomizableEdges = customizableEdges17;
            panelView.Location = new Point(50, 119);
            panelView.Name = "panelView";
            panelView.ShadowDecoration.CustomizableEdges = customizableEdges18;
            panelView.Size = new Size(894, 304);
            panelView.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Animated = true;
            txtFullName.BorderColor = Color.FromArgb(100, 100, 100);
            txtFullName.BorderRadius = 8;
            txtFullName.Cursor = Cursors.IBeam;
            txtFullName.CustomizableEdges = customizableEdges7;
            txtFullName.DefaultText = "";
            txtFullName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFullName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFullName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFullName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFullName.FillColor = Color.FromArgb(70, 70, 70);
            txtFullName.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtFullName.Font = new Font("Segoe UI", 11F);
            txtFullName.ForeColor = Color.White;
            txtFullName.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtFullName.Location = new Point(200, 244);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "";
            txtFullName.ReadOnly = true;
            txtFullName.SelectedText = "";
            txtFullName.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtFullName.Size = new Size(672, 45);
            txtFullName.TabIndex = 9;
            // 
            // txtPatientId
            // 
            txtPatientId.Animated = true;
            txtPatientId.BorderColor = Color.FromArgb(100, 100, 100);
            txtPatientId.BorderRadius = 8;
            txtPatientId.Cursor = Cursors.IBeam;
            txtPatientId.CustomizableEdges = customizableEdges9;
            txtPatientId.DefaultText = "";
            txtPatientId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPatientId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPatientId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPatientId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPatientId.FillColor = Color.FromArgb(70, 70, 70);
            txtPatientId.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtPatientId.Font = new Font("Segoe UI", 11F);
            txtPatientId.ForeColor = Color.White;
            txtPatientId.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtPatientId.Location = new Point(200, 183);
            txtPatientId.Margin = new Padding(4, 5, 4, 5);
            txtPatientId.Name = "txtPatientId";
            txtPatientId.PlaceholderText = "";
            txtPatientId.ReadOnly = true;
            txtPatientId.SelectedText = "";
            txtPatientId.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtPatientId.Size = new Size(672, 45);
            txtPatientId.TabIndex = 8;
            // 
            // txtHospital
            // 
            txtHospital.Animated = true;
            txtHospital.BorderColor = Color.FromArgb(100, 100, 100);
            txtHospital.BorderRadius = 8;
            txtHospital.Cursor = Cursors.IBeam;
            txtHospital.CustomizableEdges = customizableEdges11;
            txtHospital.DefaultText = "";
            txtHospital.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtHospital.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtHospital.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtHospital.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtHospital.FillColor = Color.FromArgb(70, 70, 70);
            txtHospital.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtHospital.Font = new Font("Segoe UI", 11F);
            txtHospital.ForeColor = Color.White;
            txtHospital.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtHospital.Location = new Point(200, 128);
            txtHospital.Margin = new Padding(4, 5, 4, 5);
            txtHospital.Name = "txtHospital";
            txtHospital.PlaceholderText = "";
            txtHospital.ReadOnly = true;
            txtHospital.SelectedText = "";
            txtHospital.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtHospital.Size = new Size(672, 45);
            txtHospital.TabIndex = 7;
            // 
            // txtCardCode
            // 
            txtCardCode.Animated = true;
            txtCardCode.BorderColor = Color.FromArgb(100, 100, 100);
            txtCardCode.BorderRadius = 8;
            txtCardCode.Cursor = Cursors.IBeam;
            txtCardCode.CustomizableEdges = customizableEdges13;
            txtCardCode.DefaultText = "";
            txtCardCode.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCardCode.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCardCode.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCardCode.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCardCode.FillColor = Color.FromArgb(70, 70, 70);
            txtCardCode.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtCardCode.Font = new Font("Segoe UI", 11F);
            txtCardCode.ForeColor = Color.White;
            txtCardCode.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtCardCode.Location = new Point(200, 73);
            txtCardCode.Margin = new Padding(4, 5, 4, 5);
            txtCardCode.Name = "txtCardCode";
            txtCardCode.PlaceholderText = "";
            txtCardCode.ReadOnly = true;
            txtCardCode.SelectedText = "";
            txtCardCode.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtCardCode.Size = new Size(672, 45);
            txtCardCode.TabIndex = 6;
            // 
            // txtCardId
            // 
            txtCardId.Animated = true;
            txtCardId.BorderColor = Color.FromArgb(100, 100, 100);
            txtCardId.BorderRadius = 8;
            txtCardId.Cursor = Cursors.IBeam;
            txtCardId.CustomizableEdges = customizableEdges15;
            txtCardId.DefaultText = "";
            txtCardId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCardId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCardId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCardId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCardId.FillColor = Color.FromArgb(70, 70, 70);
            txtCardId.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtCardId.Font = new Font("Segoe UI", 11F);
            txtCardId.ForeColor = Color.White;
            txtCardId.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtCardId.Location = new Point(200, 18);
            txtCardId.Margin = new Padding(4, 5, 4, 5);
            txtCardId.Name = "txtCardId";
            txtCardId.PlaceholderText = "";
            txtCardId.ReadOnly = true;
            txtCardId.SelectedText = "";
            txtCardId.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtCardId.Size = new Size(672, 45);
            txtCardId.TabIndex = 5;
            // 
            // lblFullName
            // 
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFullName.ForeColor = Color.White;
            lblFullName.Location = new Point(19, 244);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(167, 32);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "ФИО пациента:";
            // 
            // lblPatientId
            // 
            lblPatientId.BackColor = Color.Transparent;
            lblPatientId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPatientId.ForeColor = Color.White;
            lblPatientId.Location = new Point(21, 196);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(138, 32);
            lblPatientId.TabIndex = 3;
            lblPatientId.Text = "ID пациента:";
            // 
            // lblHospital
            // 
            lblHospital.BackColor = Color.Transparent;
            lblHospital.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHospital.ForeColor = Color.White;
            lblHospital.Location = new Point(19, 128);
            lblHospital.Name = "lblHospital";
            lblHospital.Size = new Size(161, 32);
            lblHospital.TabIndex = 2;
            lblHospital.Text = "Прикреплен к:";
            // 
            // lblCardCode
            // 
            lblCardCode.BackColor = Color.Transparent;
            lblCardCode.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardCode.ForeColor = Color.White;
            lblCardCode.Location = new Point(21, 73);
            lblCardCode.Name = "lblCardCode";
            lblCardCode.Size = new Size(122, 32);
            lblCardCode.TabIndex = 1;
            lblCardCode.Text = "Код карты:";
            // 
            // lblCardId
            // 
            lblCardId.BackColor = Color.Transparent;
            lblCardId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardId.ForeColor = Color.White;
            lblCardId.Location = new Point(21, 22);
            lblCardId.Name = "lblCardId";
            lblCardId.Size = new Size(104, 32);
            lblCardId.TabIndex = 0;
            lblCardId.Text = "ID карты:";
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitle.Location = new Point(236, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(410, 56);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Медицинская карта";
            // 
            // PatientCardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "PatientCardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Медицинская карта";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVisits).EndInit();
            panelView.ResumeLayout(false);
            panelView.PerformLayout();
            ResumeLayout(false);
        }
    }
}