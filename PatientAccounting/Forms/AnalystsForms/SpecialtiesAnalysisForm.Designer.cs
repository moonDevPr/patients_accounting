using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PatientsAccounting.Forms.AnalystsForms
{
    partial class SpecialtiesAnalysisForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel MainPanel;
        private Guna2HtmlLabel TitleLabel;
        private Guna2Button btnBack;
        private Label subtitleLabel;
        private Guna2Button btnRefresh;
        private Guna2DataGridView dgvSpecialtiesAnalysis;
        private Guna2ComboBox cmbTimePeriod;
        private Guna2ComboBox cmbHospitalFilter;
        private Guna2ComboBox cmbDepartmentFilter;
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            MainPanel = new Guna2Panel();
            btnSearchHospital = new Guna2Button();
            txtHospitalSearch = new Guna2TextBox();
            lblEndDate = new Label();
            lblStartDate = new Label();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            cmbDepartmentFilter = new Guna2ComboBox();
            cmbHospitalFilter = new Guna2ComboBox();
            cmbTimePeriod = new Guna2ComboBox();
            dgvSpecialtiesAnalysis = new Guna2DataGridView();
            btnRefresh = new Guna2Button();
            subtitleLabel = new Label();
            btnBack = new Guna2Button();
            TitleLabel = new Guna2HtmlLabel();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSpecialtiesAnalysis).BeginInit();
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
            MainPanel.Controls.Add(cmbDepartmentFilter);
            MainPanel.Controls.Add(cmbHospitalFilter);
            MainPanel.Controls.Add(cmbTimePeriod);
            MainPanel.Controls.Add(dgvSpecialtiesAnalysis);
            MainPanel.Controls.Add(btnRefresh);
            MainPanel.Controls.Add(subtitleLabel);
            MainPanel.Controls.Add(btnBack);
            MainPanel.Controls.Add(TitleLabel);
            MainPanel.CustomizableEdges = customizableEdges15;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(4, 4, 4, 4);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges16;
            MainPanel.Size = new Size(1787, 1170);
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
            btnSearchHospital.Location = new Point(632, 225);
            btnSearchHospital.Margin = new Padding(4, 4, 4, 4);
            btnSearchHospital.Name = "btnSearchHospital";
            btnSearchHospital.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSearchHospital.Size = new Size(104, 45);
            btnSearchHospital.TabIndex = 17;
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
            txtHospitalSearch.Location = new Point(354, 225);
            txtHospitalSearch.Margin = new Padding(4, 6, 4, 6);
            txtHospitalSearch.Name = "txtHospitalSearch";
            txtHospitalSearch.PlaceholderText = "Начните вводить название поликлиники...";
            txtHospitalSearch.SelectedText = "";
            txtHospitalSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtHospitalSearch.Size = new Size(250, 45);
            txtHospitalSearch.TabIndex = 16;
            txtHospitalSearch.KeyPress += txtHospitalSearch_KeyPress;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEndDate.ForeColor = Color.White;
            lblEndDate.Location = new Point(875, 300);
            lblEndDate.Margin = new Padding(4, 0, 4, 0);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(94, 28);
            lblEndDate.TabIndex = 15;
            lblEndDate.Text = "Дата по:";
            lblEndDate.Visible = false;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStartDate.ForeColor = Color.White;
            lblStartDate.Location = new Point(562, 300);
            lblStartDate.Margin = new Padding(4, 0, 4, 0);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(80, 28);
            lblStartDate.TabIndex = 14;
            lblStartDate.Text = "Дата с:";
            lblStartDate.Visible = false;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(1000, 300);
            dtpEndDate.Margin = new Padding(4, 4, 4, 4);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(186, 31);
            dtpEndDate.TabIndex = 13;
            dtpEndDate.Visible = false;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(662, 300);
            dtpStartDate.Margin = new Padding(4, 4, 4, 4);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(186, 31);
            dtpStartDate.TabIndex = 12;
            dtpStartDate.Visible = false;
            // 
            // cmbDepartmentFilter
            // 
            cmbDepartmentFilter.BackColor = Color.Transparent;
            cmbDepartmentFilter.BorderColor = Color.FromArgb(100, 100, 100);
            cmbDepartmentFilter.BorderRadius = 8;
            cmbDepartmentFilter.CustomizableEdges = customizableEdges5;
            cmbDepartmentFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cmbDepartmentFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartmentFilter.FillColor = Color.FromArgb(60, 60, 60);
            cmbDepartmentFilter.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbDepartmentFilter.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbDepartmentFilter.Font = new Font("Segoe UI", 10F);
            cmbDepartmentFilter.ForeColor = Color.White;
            cmbDepartmentFilter.ItemHeight = 30;
            cmbDepartmentFilter.Location = new Point(764, 225);
            cmbDepartmentFilter.Margin = new Padding(4, 4, 4, 4);
            cmbDepartmentFilter.Name = "cmbDepartmentFilter";
            cmbDepartmentFilter.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbDepartmentFilter.Size = new Size(312, 36);
            cmbDepartmentFilter.TabIndex = 11;
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
            cmbHospitalFilter.Location = new Point(1102, 225);
            cmbHospitalFilter.Margin = new Padding(4, 4, 4, 4);
            cmbHospitalFilter.Name = "cmbHospitalFilter";
            cmbHospitalFilter.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cmbHospitalFilter.Size = new Size(312, 36);
            cmbHospitalFilter.TabIndex = 10;
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
            cmbTimePeriod.Location = new Point(62, 225);
            cmbTimePeriod.Margin = new Padding(4, 4, 4, 4);
            cmbTimePeriod.Name = "cmbTimePeriod";
            cmbTimePeriod.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cmbTimePeriod.Size = new Size(271, 36);
            cmbTimePeriod.TabIndex = 9;
            cmbTimePeriod.SelectedIndexChanged += cmbTimePeriod_SelectedIndexChanged;
            // 
            // dgvSpecialtiesAnalysis
            // 
            dgvSpecialtiesAnalysis.AllowUserToAddRows = false;
            dgvSpecialtiesAnalysis.AllowUserToDeleteRows = false;
            dgvSpecialtiesAnalysis.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dgvSpecialtiesAnalysis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvSpecialtiesAnalysis.BackgroundColor = Color.FromArgb(45, 45, 45);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSpecialtiesAnalysis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSpecialtiesAnalysis.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(0, 12, 0, 12);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSpecialtiesAnalysis.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSpecialtiesAnalysis.GridColor = Color.FromArgb(100, 100, 100);
            dgvSpecialtiesAnalysis.Location = new Point(62, 375);
            dgvSpecialtiesAnalysis.Margin = new Padding(4, 4, 4, 4);
            dgvSpecialtiesAnalysis.Name = "dgvSpecialtiesAnalysis";
            dgvSpecialtiesAnalysis.ReadOnly = true;
            dgvSpecialtiesAnalysis.RowHeadersVisible = false;
            dgvSpecialtiesAnalysis.RowHeadersWidth = 51;
            dgvSpecialtiesAnalysis.RowTemplate.Height = 45;
            dgvSpecialtiesAnalysis.ScrollBars = ScrollBars.Vertical;
            dgvSpecialtiesAnalysis.Size = new Size(1375, 500);
            dgvSpecialtiesAnalysis.TabIndex = 8;
            dgvSpecialtiesAnalysis.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvSpecialtiesAnalysis.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 10F);
            dgvSpecialtiesAnalysis.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvSpecialtiesAnalysis.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvSpecialtiesAnalysis.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvSpecialtiesAnalysis.ThemeStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgvSpecialtiesAnalysis.ThemeStyle.GridColor = Color.FromArgb(100, 100, 100);
            dgvSpecialtiesAnalysis.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvSpecialtiesAnalysis.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSpecialtiesAnalysis.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSpecialtiesAnalysis.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvSpecialtiesAnalysis.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSpecialtiesAnalysis.ThemeStyle.HeaderStyle.Height = 50;
            dgvSpecialtiesAnalysis.ThemeStyle.ReadOnly = true;
            dgvSpecialtiesAnalysis.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgvSpecialtiesAnalysis.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSpecialtiesAnalysis.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            dgvSpecialtiesAnalysis.ThemeStyle.RowsStyle.ForeColor = Color.White;
            dgvSpecialtiesAnalysis.ThemeStyle.RowsStyle.Height = 45;
            dgvSpecialtiesAnalysis.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(100, 100, 100);
            dgvSpecialtiesAnalysis.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
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
            btnRefresh.Location = new Point(1453, 225);
            btnRefresh.Margin = new Padding(4, 4, 4, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnRefresh.Size = new Size(250, 45);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Обновить анализ";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 14F);
            subtitleLabel.ForeColor = Color.White;
            subtitleLabel.Location = new Point(438, 150);
            subtitleLabel.Margin = new Padding(4, 0, 4, 0);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(549, 38);
            subtitleLabel.TabIndex = 6;
            subtitleLabel.Text = "Анализ популярных направлений врачей";
            subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            btnBack.Animated = true;
            btnBack.BorderRadius = 10;
            btnBack.CustomizableEdges = customizableEdges13;
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
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnBack.Size = new Size(159, 66);
            btnBack.TabIndex = 5;
            btnBack.Text = "назад";
            btnBack.Click += btnBack_Click;
            // 
            // TitleLabel
            // 
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new Font("Segoe UI Black", 28F, FontStyle.Bold);
            TitleLabel.ForeColor = Color.FromArgb(0, 122, 204);
            TitleLabel.Location = new Point(375, 62);
            TitleLabel.Margin = new Padding(4, 4, 4, 4);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(829, 76);
            TitleLabel.TabIndex = 4;
            TitleLabel.Text = "Анализ направлений врачей";
            TitleLabel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // SpecialtiesAnalysisForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1787, 1170);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 4, 4, 4);
            Name = "SpecialtiesAnalysisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Анализ направлений врачей";
            Load += SpecialtiesAnalysisForm_Load;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSpecialtiesAnalysis).EndInit();
            ResumeLayout(false);
        }
    }
}