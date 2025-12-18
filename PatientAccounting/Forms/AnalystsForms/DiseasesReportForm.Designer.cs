using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PatientsAccounting.Forms.AnalystsForms
{
    partial class DiseasesReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel MainPanel;
        private Guna2HtmlLabel TitleLabel;
        private Guna2Button btnBack;
        private Label subtitleLabel;
        private Guna2Button btnRefresh;
        private DataGridView dgvDiseasesReport;
        private Guna2ComboBox cmbTimePeriod;
        private Guna2ComboBox cmbHospitalFilter;
        private Guna2ComboBox cmbDiseaseCategory;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lblStartDate;
        private Label lblEndDate;
        private Guna2Button btnSearchHospital;
        private Guna2TextBox txtHospitalSearch;

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
            MainPanel = new Guna2Panel();
            btnSearchHospital = new Guna2Button();
            txtHospitalSearch = new Guna2TextBox();
            lblEndDate = new Label();
            lblStartDate = new Label();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            cmbDiseaseCategory = new Guna2ComboBox();
            cmbHospitalFilter = new Guna2ComboBox();
            cmbTimePeriod = new Guna2ComboBox();
            dgvDiseasesReport = new DataGridView();
            btnRefresh = new Guna2Button();
            subtitleLabel = new Label();
            btnBack = new Guna2Button();
            TitleLabel = new Guna2HtmlLabel();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiseasesReport).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(45, 45, 45);
            MainPanel.Controls.Add(btnSearchHospital);
            MainPanel.Controls.Add(txtHospitalSearch);
            MainPanel.Controls.Add(lblEndDate);
            MainPanel.Controls.Add(lblStartDate);
            MainPanel.Controls.Add(dtpEndDate);
            MainPanel.Controls.Add(dtpStartDate);
            MainPanel.Controls.Add(cmbDiseaseCategory);
            MainPanel.Controls.Add(cmbHospitalFilter);
            MainPanel.Controls.Add(cmbTimePeriod);
            MainPanel.Controls.Add(dgvDiseasesReport);
            MainPanel.Controls.Add(btnRefresh);
            MainPanel.Controls.Add(subtitleLabel);
            MainPanel.Controls.Add(btnBack);
            MainPanel.Controls.Add(TitleLabel);
            MainPanel.CustomizableEdges = customizableEdges13;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(4, 4, 4, 4);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges14;
            MainPanel.Size = new Size(1566, 1170);
            MainPanel.TabIndex = 0;
            // 
            // btnSearchHospital
            // 
            btnSearchHospital.Animated = true;
            btnSearchHospital.BorderRadius = 15;
            btnSearchHospital.CustomizableEdges = customizableEdges1;
            btnSearchHospital.DisabledState.BorderColor = Color.DarkGray;
            btnSearchHospital.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSearchHospital.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSearchHospital.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSearchHospital.FillColor = Color.FromArgb(0, 122, 204);
            btnSearchHospital.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearchHospital.ForeColor = Color.White;
            btnSearchHospital.Location = new Point(579, 225);
            btnSearchHospital.Margin = new Padding(4, 4, 4, 4);
            btnSearchHospital.Name = "btnSearchHospital";
            btnSearchHospital.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSearchHospital.Size = new Size(116, 45);
            btnSearchHospital.TabIndex = 16;
            btnSearchHospital.Text = "Найти";
            btnSearchHospital.Click += btnSearchHospital_Click;
            // 
            // txtHospitalSearch
            // 
            txtHospitalSearch.BorderColor = Color.FromArgb(100, 100, 100);
            txtHospitalSearch.BorderRadius = 8;
            txtHospitalSearch.CustomizableEdges = customizableEdges3;
            txtHospitalSearch.DefaultText = "";
            txtHospitalSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtHospitalSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtHospitalSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtHospitalSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtHospitalSearch.FillColor = Color.FromArgb(60, 60, 60);
            txtHospitalSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtHospitalSearch.Font = new Font("Segoe UI", 10F);
            txtHospitalSearch.ForeColor = Color.White;
            txtHospitalSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtHospitalSearch.Location = new Point(312, 225);
            txtHospitalSearch.Margin = new Padding(4, 6, 4, 6);
            txtHospitalSearch.Name = "txtHospitalSearch";
            txtHospitalSearch.PlaceholderText = "Начните вводить название поликлиники...";
            txtHospitalSearch.SelectedText = "";
            txtHospitalSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtHospitalSearch.Size = new Size(250, 45);
            txtHospitalSearch.TabIndex = 15;
            txtHospitalSearch.KeyPress += txtHospitalSearch_KeyPress;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEndDate.ForeColor = Color.White;
            lblEndDate.Location = new Point(688, 300);
            lblEndDate.Margin = new Padding(4, 0, 4, 0);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(94, 28);
            lblEndDate.TabIndex = 14;
            lblEndDate.Text = "Дата по:";
            lblEndDate.Visible = false;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStartDate.ForeColor = Color.White;
            lblStartDate.Location = new Point(312, 300);
            lblStartDate.Margin = new Padding(4, 0, 4, 0);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(80, 28);
            lblStartDate.TabIndex = 13;
            lblStartDate.Text = "Дата с:";
            lblStartDate.Visible = false;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(812, 300);
            dtpEndDate.Margin = new Padding(4, 4, 4, 4);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(186, 31);
            dtpEndDate.TabIndex = 12;
            dtpEndDate.Visible = false;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(412, 300);
            dtpStartDate.Margin = new Padding(4, 4, 4, 4);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(186, 31);
            dtpStartDate.TabIndex = 11;
            dtpStartDate.Visible = false;
            // 
            // cmbDiseaseCategory
            // 
            cmbDiseaseCategory.BackColor = Color.Transparent;
            cmbDiseaseCategory.BorderColor = Color.FromArgb(100, 100, 100);
            cmbDiseaseCategory.BorderRadius = 8;
            cmbDiseaseCategory.CustomizableEdges = customizableEdges5;
            cmbDiseaseCategory.DrawMode = DrawMode.OwnerDrawFixed;
            cmbDiseaseCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDiseaseCategory.FillColor = Color.FromArgb(60, 60, 60);
            cmbDiseaseCategory.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbDiseaseCategory.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbDiseaseCategory.Font = new Font("Segoe UI", 10F);
            cmbDiseaseCategory.ForeColor = Color.White;
            cmbDiseaseCategory.ItemHeight = 30;
            cmbDiseaseCategory.Location = new Point(712, 234);
            cmbDiseaseCategory.Margin = new Padding(4, 4, 4, 4);
            cmbDiseaseCategory.Name = "cmbDiseaseCategory";
            cmbDiseaseCategory.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbDiseaseCategory.Size = new Size(312, 36);
            cmbDiseaseCategory.TabIndex = 10;
            // 
            // cmbHospitalFilter
            // 
            cmbHospitalFilter.BackColor = Color.Transparent;
            cmbHospitalFilter.BorderColor = Color.FromArgb(100, 100, 100);
            cmbHospitalFilter.BorderRadius = 8;
            cmbHospitalFilter.CustomizableEdges = customizableEdges7;
            cmbHospitalFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cmbHospitalFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHospitalFilter.FillColor = Color.FromArgb(60, 60, 60);
            cmbHospitalFilter.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbHospitalFilter.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbHospitalFilter.Font = new Font("Segoe UI", 10F);
            cmbHospitalFilter.ForeColor = Color.White;
            cmbHospitalFilter.ItemHeight = 30;
            cmbHospitalFilter.Location = new Point(1045, 234);
            cmbHospitalFilter.Margin = new Padding(4, 4, 4, 4);
            cmbHospitalFilter.Name = "cmbHospitalFilter";
            cmbHospitalFilter.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cmbHospitalFilter.Size = new Size(231, 36);
            cmbHospitalFilter.TabIndex = 9;
            cmbHospitalFilter.SelectedIndexChanged += cmbHospitalFilter_SelectedIndexChanged;
            // 
            // cmbTimePeriod
            // 
            cmbTimePeriod.BackColor = Color.Transparent;
            cmbTimePeriod.BorderColor = Color.FromArgb(100, 100, 100);
            cmbTimePeriod.BorderRadius = 8;
            cmbTimePeriod.CustomizableEdges = customizableEdges9;
            cmbTimePeriod.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTimePeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimePeriod.FillColor = Color.FromArgb(60, 60, 60);
            cmbTimePeriod.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbTimePeriod.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbTimePeriod.Font = new Font("Segoe UI", 10F);
            cmbTimePeriod.ForeColor = Color.White;
            cmbTimePeriod.ItemHeight = 30;
            cmbTimePeriod.Items.AddRange(new object[] { "За последний месяц", "За последние 3 месяца", "За последние 6 месяцев", "За последний год", "За все время", "Произвольный период" });
            cmbTimePeriod.Location = new Point(38, 225);
            cmbTimePeriod.Margin = new Padding(4, 4, 4, 4);
            cmbTimePeriod.Name = "cmbTimePeriod";
            cmbTimePeriod.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cmbTimePeriod.Size = new Size(250, 36);
            cmbTimePeriod.TabIndex = 8;
            cmbTimePeriod.SelectedIndexChanged += cmbTimePeriod_SelectedIndexChanged;
            // 
            // dgvDiseasesReport
            // 
            dgvDiseasesReport.AllowUserToAddRows = false;
            dgvDiseasesReport.AllowUserToDeleteRows = false;
            dgvDiseasesReport.AllowUserToResizeRows = false;
            dgvDiseasesReport.BackgroundColor = Color.FromArgb(45, 45, 45);
            dgvDiseasesReport.BorderStyle = BorderStyle.None;
            dgvDiseasesReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDiseasesReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDiseasesReport.ColumnHeadersHeight = 50;
            dgvDiseasesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDiseasesReport.GridColor = Color.FromArgb(100, 100, 100);
            dgvDiseasesReport.Location = new Point(62, 375);
            dgvDiseasesReport.Margin = new Padding(4, 4, 4, 4);
            dgvDiseasesReport.Name = "dgvDiseasesReport";
            dgvDiseasesReport.ReadOnly = true;
            dgvDiseasesReport.RowHeadersVisible = false;
            dgvDiseasesReport.RowHeadersWidth = 51;
            dgvDiseasesReport.RowTemplate.Height = 45;
            dgvDiseasesReport.ScrollBars = ScrollBars.Vertical;
            dgvDiseasesReport.Size = new Size(1375, 500);
            dgvDiseasesReport.TabIndex = 7;
            // 
            // btnRefresh
            // 
            btnRefresh.Animated = true;
            btnRefresh.BorderRadius = 10;
            btnRefresh.CustomizableEdges = customizableEdges11;
            btnRefresh.DisabledState.BorderColor = Color.DarkGray;
            btnRefresh.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRefresh.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRefresh.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRefresh.FillColor = Color.FromArgb(0, 122, 204);
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1293, 225);
            btnRefresh.Margin = new Padding(4, 4, 4, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnRefresh.Size = new Size(250, 45);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Обновить отчет";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 14F);
            subtitleLabel.ForeColor = Color.White;
            subtitleLabel.Location = new Point(510, 142);
            subtitleLabel.Margin = new Padding(4, 0, 4, 0);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(451, 38);
            subtitleLabel.TabIndex = 4;
            subtitleLabel.Text = "Числовой отчет по заболеваниям";
            subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            btnBack.Animated = true;
            btnBack.BorderRadius = 10;
            btnBack.CustomizableEdges = customizableEdges1;
            btnBack.DisabledState.BorderColor = Color.DarkGray;
            btnBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBack.FillColor = Color.DimGray;
            btnBack.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(38, 38);
            btnBack.Margin = new Padding(4, 4, 4, 4);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnBack.Size = new Size(159, 66);
            btnBack.TabIndex = 3;
            btnBack.Text = "назад";
            btnBack.Click += btnBack_Click;
            // 
            // TitleLabel
            // 
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new Font("Segoe UI Black", 28F, FontStyle.Bold);
            TitleLabel.ForeColor = Color.FromArgb(0, 122, 204);
            TitleLabel.Location = new Point(412, 38);
            TitleLabel.Margin = new Padding(4, 4, 4, 4);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(684, 76);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Отчет по заболеваниям";
            TitleLabel.TextAlignment = ContentAlignment.MiddleCenter;
            TitleLabel.Click += TitleLabel_Click;
            // 
            // DiseasesReportForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1566, 1170);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 4, 4, 4);
            Name = "DiseasesReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Отчет по заболеваниям";
            Load += DiseasesReportForm_Load;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiseasesReport).EndInit();
            ResumeLayout(false);
        }
    }
}