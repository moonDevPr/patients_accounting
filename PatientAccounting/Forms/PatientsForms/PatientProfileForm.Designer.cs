using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System.Drawing;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    partial class PatientProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel MainPanel;
        private Guna2TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageView;
        private System.Windows.Forms.TabPage tabPageEdit;
        private System.Windows.Forms.TabPage tabPagePassword;
        private Guna2Button backButton;

        // Вкладка просмотра
        private Guna2HtmlLabel TitleLabelView;
        private Guna2Panel panelView;
        private Guna2HtmlLabel lblViewUserId;
        private Guna2HtmlLabel lblViewSurname;
        private Guna2HtmlLabel lblViewName;
        private Guna2HtmlLabel lblViewPatronymic;
        private Guna2HtmlLabel lblViewSnils;
        private Guna2HtmlLabel lblViewPhone;
        private Guna2HtmlLabel lblViewTown;
        private Guna2HtmlLabel lblViewStreet;
        private Guna2HtmlLabel lblViewHouse;
        private Guna2TextBox txtViewUserId;
        private Guna2TextBox txtViewSurname;
        private Guna2TextBox txtViewName;
        private Guna2TextBox txtViewPatronymic;
        private Guna2TextBox txtViewSnils;
        private Guna2TextBox txtViewPhone;
        private Guna2TextBox txtViewTown;
        private Guna2TextBox txtViewStreet;
        private Guna2TextBox txtViewHouse;

        // Вкладка редактирования
        private Guna2HtmlLabel TitleLabelEdit;
        private Guna2Panel panelEdit;
        private Guna2HtmlLabel lblEditUserId;
        private Guna2HtmlLabel lblEditSurname;
        private Guna2HtmlLabel lblEditName;
        private Guna2HtmlLabel lblEditPatronymic;
        private Guna2HtmlLabel lblEditSnils;
        private Guna2HtmlLabel lblEditPhone;
        private Guna2HtmlLabel lblEditTown;
        private Guna2HtmlLabel lblEditStreet;
        private Guna2HtmlLabel lblEditHouse;
        private Guna2TextBox txtEditUserId;
        private Guna2TextBox txtEditSurname;
        private Guna2TextBox txtEditName;
        private Guna2TextBox txtEditPatronymic;
        private Guna2TextBox txtEditSnils;
        private Guna2TextBox txtEditPhone;
        private Guna2TextBox txtEditTown;
        private Guna2TextBox txtEditStreet;
        private Guna2TextBox txtEditHouse;
        private Guna2Button btnEdit;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Guna2HtmlLabel lblStatus;

        // Вкладка смены пароля
        private Guna2HtmlLabel TitleLabelPassword;
        private Guna2Panel panelPassword;
        private Guna2HtmlLabel lblCurrentPassword;
        private Guna2HtmlLabel lblNewPassword;
        private Guna2HtmlLabel lblConfirmPassword;
        private Guna2TextBox txtCurrentPassword;
        private Guna2TextBox txtNewPassword;
        private Guna2TextBox txtConfirmNewPassword;
        private Guna2Button btnChangePassword;
        private Guna2Button btnShowPassword;

        private Guna2ShadowForm guna2ShadowForm;

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
            CustomizableEdges customizableEdges61 = new CustomizableEdges();
            CustomizableEdges customizableEdges62 = new CustomizableEdges();
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            CustomizableEdges customizableEdges21 = new CustomizableEdges();
            CustomizableEdges customizableEdges22 = new CustomizableEdges();
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
            CustomizableEdges customizableEdges17 = new CustomizableEdges();
            CustomizableEdges customizableEdges18 = new CustomizableEdges();
            CustomizableEdges customizableEdges19 = new CustomizableEdges();
            CustomizableEdges customizableEdges20 = new CustomizableEdges();
            CustomizableEdges customizableEdges23 = new CustomizableEdges();
            CustomizableEdges customizableEdges24 = new CustomizableEdges();
            CustomizableEdges customizableEdges25 = new CustomizableEdges();
            CustomizableEdges customizableEdges26 = new CustomizableEdges();
            CustomizableEdges customizableEdges27 = new CustomizableEdges();
            CustomizableEdges customizableEdges28 = new CustomizableEdges();
            CustomizableEdges customizableEdges47 = new CustomizableEdges();
            CustomizableEdges customizableEdges48 = new CustomizableEdges();
            CustomizableEdges customizableEdges29 = new CustomizableEdges();
            CustomizableEdges customizableEdges30 = new CustomizableEdges();
            CustomizableEdges customizableEdges31 = new CustomizableEdges();
            CustomizableEdges customizableEdges32 = new CustomizableEdges();
            CustomizableEdges customizableEdges33 = new CustomizableEdges();
            CustomizableEdges customizableEdges34 = new CustomizableEdges();
            CustomizableEdges customizableEdges35 = new CustomizableEdges();
            CustomizableEdges customizableEdges36 = new CustomizableEdges();
            CustomizableEdges customizableEdges37 = new CustomizableEdges();
            CustomizableEdges customizableEdges38 = new CustomizableEdges();
            CustomizableEdges customizableEdges39 = new CustomizableEdges();
            CustomizableEdges customizableEdges40 = new CustomizableEdges();
            CustomizableEdges customizableEdges41 = new CustomizableEdges();
            CustomizableEdges customizableEdges42 = new CustomizableEdges();
            CustomizableEdges customizableEdges43 = new CustomizableEdges();
            CustomizableEdges customizableEdges44 = new CustomizableEdges();
            CustomizableEdges customizableEdges45 = new CustomizableEdges();
            CustomizableEdges customizableEdges46 = new CustomizableEdges();
            CustomizableEdges customizableEdges59 = new CustomizableEdges();
            CustomizableEdges customizableEdges60 = new CustomizableEdges();
            CustomizableEdges customizableEdges49 = new CustomizableEdges();
            CustomizableEdges customizableEdges50 = new CustomizableEdges();
            CustomizableEdges customizableEdges51 = new CustomizableEdges();
            CustomizableEdges customizableEdges52 = new CustomizableEdges();
            CustomizableEdges customizableEdges53 = new CustomizableEdges();
            CustomizableEdges customizableEdges54 = new CustomizableEdges();
            CustomizableEdges customizableEdges55 = new CustomizableEdges();
            CustomizableEdges customizableEdges56 = new CustomizableEdges();
            CustomizableEdges customizableEdges57 = new CustomizableEdges();
            CustomizableEdges customizableEdges58 = new CustomizableEdges();
            MainPanel = new Guna2Panel();
            tabControl = new Guna2TabControl();
            tabPageView = new TabPage();
            backButton = new Guna2Button();
            panelView = new Guna2Panel();
            txtViewHouse = new Guna2TextBox();
            txtViewStreet = new Guna2TextBox();
            txtViewTown = new Guna2TextBox();
            txtViewPhone = new Guna2TextBox();
            txtViewSnils = new Guna2TextBox();
            txtViewPatronymic = new Guna2TextBox();
            txtViewName = new Guna2TextBox();
            txtViewSurname = new Guna2TextBox();
            txtViewUserId = new Guna2TextBox();
            lblViewHouse = new Guna2HtmlLabel();
            lblViewStreet = new Guna2HtmlLabel();
            lblViewTown = new Guna2HtmlLabel();
            lblViewPhone = new Guna2HtmlLabel();
            lblViewSnils = new Guna2HtmlLabel();
            lblViewPatronymic = new Guna2HtmlLabel();
            lblViewName = new Guna2HtmlLabel();
            lblViewSurname = new Guna2HtmlLabel();
            lblViewUserId = new Guna2HtmlLabel();
            TitleLabelView = new Guna2HtmlLabel();
            tabPageEdit = new TabPage();
            lblStatus = new Guna2HtmlLabel();
            btnCancel = new Guna2Button();
            btnSave = new Guna2Button();
            btnEdit = new Guna2Button();
            panelEdit = new Guna2Panel();
            txtEditHouse = new Guna2TextBox();
            txtEditStreet = new Guna2TextBox();
            txtEditTown = new Guna2TextBox();
            txtEditPhone = new Guna2TextBox();
            txtEditSnils = new Guna2TextBox();
            txtEditPatronymic = new Guna2TextBox();
            txtEditName = new Guna2TextBox();
            txtEditSurname = new Guna2TextBox();
            txtEditUserId = new Guna2TextBox();
            lblEditHouse = new Guna2HtmlLabel();
            lblEditStreet = new Guna2HtmlLabel();
            lblEditTown = new Guna2HtmlLabel();
            lblEditPhone = new Guna2HtmlLabel();
            lblEditSnils = new Guna2HtmlLabel();
            lblEditPatronymic = new Guna2HtmlLabel();
            lblEditName = new Guna2HtmlLabel();
            lblEditSurname = new Guna2HtmlLabel();
            lblEditUserId = new Guna2HtmlLabel();
            TitleLabelEdit = new Guna2HtmlLabel();
            tabPagePassword = new TabPage();
            panelPassword = new Guna2Panel();
            btnShowPassword = new Guna2Button();
            btnChangePassword = new Guna2Button();
            txtConfirmNewPassword = new Guna2TextBox();
            txtNewPassword = new Guna2TextBox();
            txtCurrentPassword = new Guna2TextBox();
            lblConfirmPassword = new Guna2HtmlLabel();
            lblNewPassword = new Guna2HtmlLabel();
            lblCurrentPassword = new Guna2HtmlLabel();
            TitleLabelPassword = new Guna2HtmlLabel();
            guna2ShadowForm = new Guna2ShadowForm(components);
            MainPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageView.SuspendLayout();
            panelView.SuspendLayout();
            tabPageEdit.SuspendLayout();
            panelEdit.SuspendLayout();
            tabPagePassword.SuspendLayout();
            panelPassword.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(45, 45, 45);
            MainPanel.Controls.Add(tabControl);
            MainPanel.CustomizableEdges = customizableEdges61;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges62;
            MainPanel.Size = new Size(1200, 931);
            MainPanel.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Alignment = TabAlignment.Left;
            tabControl.Controls.Add(tabPageView);
            tabControl.Controls.Add(tabPageEdit);
            tabControl.Controls.Add(tabPagePassword);
            tabControl.ItemSize = new Size(180, 40);
            tabControl.Location = new Point(30, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1140, 871);
            tabControl.TabButtonHoverState.BorderColor = Color.Empty;
            tabControl.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            tabControl.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            tabControl.TabButtonHoverState.ForeColor = Color.White;
            tabControl.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            tabControl.TabButtonIdleState.BorderColor = Color.Empty;
            tabControl.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            tabControl.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            tabControl.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            tabControl.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            tabControl.TabButtonSelectedState.BorderColor = Color.Empty;
            tabControl.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            tabControl.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            tabControl.TabButtonSelectedState.ForeColor = Color.White;
            tabControl.TabButtonSelectedState.InnerColor = Color.FromArgb(0, 122, 204);
            tabControl.TabButtonSize = new Size(180, 40);
            tabControl.TabIndex = 2;
            tabControl.TabMenuBackColor = Color.FromArgb(33, 42, 57);
            // 
            // tabPageView
            // 
            tabPageView.BackColor = Color.FromArgb(45, 45, 45);
            tabPageView.Controls.Add(backButton);
            tabPageView.Controls.Add(panelView);
            tabPageView.Controls.Add(TitleLabelView);
            tabPageView.Location = new Point(184, 4);
            tabPageView.Name = "tabPageView";
            tabPageView.Padding = new Padding(3);
            tabPageView.Size = new Size(952, 863);
            tabPageView.TabIndex = 0;
            tabPageView.Text = "Просмотр";
            tabPageView.Click += tabPageView_Click;
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
            backButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            backButton.ForeColor = Color.White;
            backButton.HoverState.FillColor = Color.FromArgb(0, 98, 163);
            backButton.Location = new Point(364, 23);
            backButton.Name = "backButton";
            backButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            backButton.Size = new Size(140, 45);
            backButton.TabIndex = 1;
            backButton.Text = "Назад";
            backButton.Click += BackButton_Click;
            // 
            // panelView
            // 
            panelView.BackColor = Color.FromArgb(60, 60, 60);
            panelView.BorderRadius = 15;
            panelView.Controls.Add(txtViewHouse);
            panelView.Controls.Add(txtViewStreet);
            panelView.Controls.Add(txtViewTown);
            panelView.Controls.Add(txtViewPhone);
            panelView.Controls.Add(txtViewSnils);
            panelView.Controls.Add(txtViewPatronymic);
            panelView.Controls.Add(txtViewName);
            panelView.Controls.Add(txtViewSurname);
            panelView.Controls.Add(txtViewUserId);
            panelView.Controls.Add(lblViewHouse);
            panelView.Controls.Add(lblViewStreet);
            panelView.Controls.Add(lblViewTown);
            panelView.Controls.Add(lblViewPhone);
            panelView.Controls.Add(lblViewSnils);
            panelView.Controls.Add(lblViewPatronymic);
            panelView.Controls.Add(lblViewName);
            panelView.Controls.Add(lblViewSurname);
            panelView.Controls.Add(lblViewUserId);
            panelView.CustomizableEdges = customizableEdges21;
            panelView.Location = new Point(71, 102);
            panelView.Name = "panelView";
            panelView.ShadowDecoration.CustomizableEdges = customizableEdges22;
            panelView.Size = new Size(738, 532);
            panelView.TabIndex = 1;
            // 
            // txtViewHouse
            // 
            txtViewHouse.Animated = true;
            txtViewHouse.BorderColor = Color.FromArgb(100, 100, 100);
            txtViewHouse.BorderRadius = 8;
            txtViewHouse.Cursor = Cursors.IBeam;
            txtViewHouse.CustomizableEdges = customizableEdges3;
            txtViewHouse.DefaultText = "";
            txtViewHouse.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtViewHouse.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtViewHouse.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtViewHouse.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtViewHouse.FillColor = Color.FromArgb(70, 70, 70);
            txtViewHouse.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewHouse.Font = new Font("Segoe UI", 11F);
            txtViewHouse.ForeColor = Color.White;
            txtViewHouse.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewHouse.Location = new Point(200, 407);
            txtViewHouse.Margin = new Padding(4, 5, 4, 5);
            txtViewHouse.Name = "txtViewHouse";
            txtViewHouse.PlaceholderText = "";
            txtViewHouse.ReadOnly = true;
            txtViewHouse.SelectedText = "";
            txtViewHouse.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtViewHouse.Size = new Size(505, 45);
            txtViewHouse.TabIndex = 17;
            // 
            // txtViewStreet
            // 
            txtViewStreet.Animated = true;
            txtViewStreet.BorderColor = Color.FromArgb(100, 100, 100);
            txtViewStreet.BorderRadius = 8;
            txtViewStreet.Cursor = Cursors.IBeam;
            txtViewStreet.CustomizableEdges = customizableEdges5;
            txtViewStreet.DefaultText = "";
            txtViewStreet.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtViewStreet.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtViewStreet.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtViewStreet.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtViewStreet.FillColor = Color.FromArgb(70, 70, 70);
            txtViewStreet.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewStreet.Font = new Font("Segoe UI", 11F);
            txtViewStreet.ForeColor = Color.White;
            txtViewStreet.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewStreet.Location = new Point(200, 352);
            txtViewStreet.Margin = new Padding(4, 5, 4, 5);
            txtViewStreet.Name = "txtViewStreet";
            txtViewStreet.PlaceholderText = "";
            txtViewStreet.ReadOnly = true;
            txtViewStreet.SelectedText = "";
            txtViewStreet.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtViewStreet.Size = new Size(505, 45);
            txtViewStreet.TabIndex = 16;
            // 
            // txtViewTown
            // 
            txtViewTown.Animated = true;
            txtViewTown.BorderColor = Color.FromArgb(100, 100, 100);
            txtViewTown.BorderRadius = 8;
            txtViewTown.Cursor = Cursors.IBeam;
            txtViewTown.CustomizableEdges = customizableEdges7;
            txtViewTown.DefaultText = "";
            txtViewTown.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtViewTown.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtViewTown.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtViewTown.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtViewTown.FillColor = Color.FromArgb(70, 70, 70);
            txtViewTown.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewTown.Font = new Font("Segoe UI", 11F);
            txtViewTown.ForeColor = Color.White;
            txtViewTown.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewTown.Location = new Point(200, 297);
            txtViewTown.Margin = new Padding(4, 5, 4, 5);
            txtViewTown.Name = "txtViewTown";
            txtViewTown.PlaceholderText = "";
            txtViewTown.ReadOnly = true;
            txtViewTown.SelectedText = "";
            txtViewTown.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtViewTown.Size = new Size(505, 45);
            txtViewTown.TabIndex = 15;
            // 
            // txtViewPhone
            // 
            txtViewPhone.Animated = true;
            txtViewPhone.BorderColor = Color.FromArgb(100, 100, 100);
            txtViewPhone.BorderRadius = 8;
            txtViewPhone.Cursor = Cursors.IBeam;
            txtViewPhone.CustomizableEdges = customizableEdges9;
            txtViewPhone.DefaultText = "";
            txtViewPhone.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtViewPhone.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtViewPhone.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtViewPhone.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtViewPhone.FillColor = Color.FromArgb(70, 70, 70);
            txtViewPhone.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewPhone.Font = new Font("Segoe UI", 11F);
            txtViewPhone.ForeColor = Color.White;
            txtViewPhone.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewPhone.Location = new Point(200, 230);
            txtViewPhone.Margin = new Padding(4, 5, 4, 5);
            txtViewPhone.Name = "txtViewPhone";
            txtViewPhone.PlaceholderText = "";
            txtViewPhone.ReadOnly = true;
            txtViewPhone.SelectedText = "";
            txtViewPhone.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtViewPhone.Size = new Size(505, 48);
            txtViewPhone.TabIndex = 14;
            // 
            // txtViewSnils
            // 
            txtViewSnils.Animated = true;
            txtViewSnils.BorderColor = Color.FromArgb(100, 100, 100);
            txtViewSnils.BorderRadius = 8;
            txtViewSnils.Cursor = Cursors.IBeam;
            txtViewSnils.CustomizableEdges = customizableEdges11;
            txtViewSnils.DefaultText = "";
            txtViewSnils.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtViewSnils.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtViewSnils.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtViewSnils.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtViewSnils.FillColor = Color.FromArgb(70, 70, 70);
            txtViewSnils.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewSnils.Font = new Font("Segoe UI", 11F);
            txtViewSnils.ForeColor = Color.White;
            txtViewSnils.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewSnils.Location = new Point(200, 175);
            txtViewSnils.Margin = new Padding(4, 5, 4, 5);
            txtViewSnils.Name = "txtViewSnils";
            txtViewSnils.PlaceholderText = "";
            txtViewSnils.ReadOnly = true;
            txtViewSnils.SelectedText = "";
            txtViewSnils.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtViewSnils.Size = new Size(505, 45);
            txtViewSnils.TabIndex = 13;
            // 
            // txtViewPatronymic
            // 
            txtViewPatronymic.Animated = true;
            txtViewPatronymic.BorderColor = Color.FromArgb(100, 100, 100);
            txtViewPatronymic.BorderRadius = 8;
            txtViewPatronymic.Cursor = Cursors.IBeam;
            txtViewPatronymic.CustomizableEdges = customizableEdges13;
            txtViewPatronymic.DefaultText = "";
            txtViewPatronymic.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtViewPatronymic.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtViewPatronymic.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtViewPatronymic.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtViewPatronymic.FillColor = Color.FromArgb(70, 70, 70);
            txtViewPatronymic.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewPatronymic.Font = new Font("Segoe UI", 11F);
            txtViewPatronymic.ForeColor = Color.White;
            txtViewPatronymic.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewPatronymic.Location = new Point(200, 120);
            txtViewPatronymic.Margin = new Padding(4, 5, 4, 5);
            txtViewPatronymic.Name = "txtViewPatronymic";
            txtViewPatronymic.PlaceholderText = "";
            txtViewPatronymic.ReadOnly = true;
            txtViewPatronymic.SelectedText = "";
            txtViewPatronymic.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtViewPatronymic.Size = new Size(505, 45);
            txtViewPatronymic.TabIndex = 12;
            // 
            // txtViewName
            // 
            txtViewName.Animated = true;
            txtViewName.BorderColor = Color.FromArgb(100, 100, 100);
            txtViewName.BorderRadius = 8;
            txtViewName.Cursor = Cursors.IBeam;
            txtViewName.CustomizableEdges = customizableEdges15;
            txtViewName.DefaultText = "";
            txtViewName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtViewName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtViewName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtViewName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtViewName.FillColor = Color.FromArgb(70, 70, 70);
            txtViewName.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewName.Font = new Font("Segoe UI", 11F);
            txtViewName.ForeColor = Color.White;
            txtViewName.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewName.Location = new Point(200, 65);
            txtViewName.Margin = new Padding(4, 5, 4, 5);
            txtViewName.Name = "txtViewName";
            txtViewName.PlaceholderText = "";
            txtViewName.ReadOnly = true;
            txtViewName.SelectedText = "";
            txtViewName.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtViewName.Size = new Size(505, 45);
            txtViewName.TabIndex = 11;
            // 
            // txtViewSurname
            // 
            txtViewSurname.Animated = true;
            txtViewSurname.BorderColor = Color.FromArgb(100, 100, 100);
            txtViewSurname.BorderRadius = 8;
            txtViewSurname.Cursor = Cursors.IBeam;
            txtViewSurname.CustomizableEdges = customizableEdges17;
            txtViewSurname.DefaultText = "";
            txtViewSurname.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtViewSurname.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtViewSurname.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtViewSurname.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtViewSurname.FillColor = Color.FromArgb(70, 70, 70);
            txtViewSurname.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewSurname.Font = new Font("Segoe UI", 11F);
            txtViewSurname.ForeColor = Color.White;
            txtViewSurname.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewSurname.Location = new Point(200, 10);
            txtViewSurname.Margin = new Padding(4, 5, 4, 5);
            txtViewSurname.Name = "txtViewSurname";
            txtViewSurname.PlaceholderText = "";
            txtViewSurname.ReadOnly = true;
            txtViewSurname.SelectedText = "";
            txtViewSurname.ShadowDecoration.CustomizableEdges = customizableEdges18;
            txtViewSurname.Size = new Size(505, 45);
            txtViewSurname.TabIndex = 10;
            // 
            // txtViewUserId
            // 
            txtViewUserId.Animated = true;
            txtViewUserId.BorderColor = Color.FromArgb(100, 100, 100);
            txtViewUserId.BorderRadius = 8;
            txtViewUserId.Cursor = Cursors.IBeam;
            txtViewUserId.CustomizableEdges = customizableEdges19;
            txtViewUserId.DefaultText = "";
            txtViewUserId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtViewUserId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtViewUserId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtViewUserId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtViewUserId.FillColor = Color.FromArgb(70, 70, 70);
            txtViewUserId.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewUserId.Font = new Font("Segoe UI", 11F);
            txtViewUserId.ForeColor = Color.White;
            txtViewUserId.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtViewUserId.Location = new Point(200, 473);
            txtViewUserId.Margin = new Padding(4, 5, 4, 5);
            txtViewUserId.Name = "txtViewUserId";
            txtViewUserId.PlaceholderText = "";
            txtViewUserId.ReadOnly = true;
            txtViewUserId.SelectedText = "";
            txtViewUserId.ShadowDecoration.CustomizableEdges = customizableEdges20;
            txtViewUserId.Size = new Size(505, 43);
            txtViewUserId.TabIndex = 9;
            // 
            // lblViewHouse
            // 
            lblViewHouse.BackColor = Color.Transparent;
            lblViewHouse.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewHouse.ForeColor = Color.White;
            lblViewHouse.Location = new Point(50, 407);
            lblViewHouse.Name = "lblViewHouse";
            lblViewHouse.Size = new Size(56, 32);
            lblViewHouse.TabIndex = 8;
            lblViewHouse.Text = "Дом:";
            // 
            // lblViewStreet
            // 
            lblViewStreet.BackColor = Color.Transparent;
            lblViewStreet.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewStreet.ForeColor = Color.White;
            lblViewStreet.Location = new Point(50, 352);
            lblViewStreet.Name = "lblViewStreet";
            lblViewStreet.Size = new Size(76, 32);
            lblViewStreet.TabIndex = 7;
            lblViewStreet.Text = "Улица:";
            // 
            // lblViewTown
            // 
            lblViewTown.BackColor = Color.Transparent;
            lblViewTown.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewTown.ForeColor = Color.White;
            lblViewTown.Location = new Point(50, 297);
            lblViewTown.Name = "lblViewTown";
            lblViewTown.Size = new Size(74, 32);
            lblViewTown.TabIndex = 6;
            lblViewTown.Text = "Город:";
            // 
            // lblViewPhone
            // 
            lblViewPhone.BackColor = Color.Transparent;
            lblViewPhone.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewPhone.ForeColor = Color.White;
            lblViewPhone.Location = new Point(50, 230);
            lblViewPhone.Name = "lblViewPhone";
            lblViewPhone.Size = new Size(102, 32);
            lblViewPhone.TabIndex = 5;
            lblViewPhone.Text = "Телефон:";
            // 
            // lblViewSnils
            // 
            lblViewSnils.BackColor = Color.Transparent;
            lblViewSnils.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewSnils.ForeColor = Color.White;
            lblViewSnils.Location = new Point(50, 175);
            lblViewSnils.Name = "lblViewSnils";
            lblViewSnils.Size = new Size(87, 32);
            lblViewSnils.TabIndex = 4;
            lblViewSnils.Text = "СНИЛС:";
            // 
            // lblViewPatronymic
            // 
            lblViewPatronymic.BackColor = Color.Transparent;
            lblViewPatronymic.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewPatronymic.ForeColor = Color.White;
            lblViewPatronymic.Location = new Point(52, 120);
            lblViewPatronymic.Name = "lblViewPatronymic";
            lblViewPatronymic.Size = new Size(108, 32);
            lblViewPatronymic.TabIndex = 3;
            lblViewPatronymic.Text = "Отчество:";
            // 
            // lblViewName
            // 
            lblViewName.BackColor = Color.Transparent;
            lblViewName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewName.ForeColor = Color.White;
            lblViewName.Location = new Point(50, 68);
            lblViewName.Name = "lblViewName";
            lblViewName.Size = new Size(56, 32);
            lblViewName.TabIndex = 2;
            lblViewName.Text = "Имя:";
            // 
            // lblViewSurname
            // 
            lblViewSurname.BackColor = Color.Transparent;
            lblViewSurname.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewSurname.ForeColor = Color.White;
            lblViewSurname.Location = new Point(42, 23);
            lblViewSurname.Name = "lblViewSurname";
            lblViewSurname.Size = new Size(110, 32);
            lblViewSurname.TabIndex = 1;
            lblViewSurname.Text = "Фамилия:";
            // 
            // lblViewUserId
            // 
            lblViewUserId.BackColor = Color.Transparent;
            lblViewUserId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewUserId.ForeColor = Color.White;
            lblViewUserId.Location = new Point(50, 462);
            lblViewUserId.Name = "lblViewUserId";
            lblViewUserId.Size = new Size(111, 32);
            lblViewUserId.TabIndex = 0;
            lblViewUserId.Text = "ID учетки:";
            // 
            // TitleLabelView
            // 
            TitleLabelView.BackColor = Color.Transparent;
            TitleLabelView.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            TitleLabelView.ForeColor = Color.FromArgb(0, 122, 204);
            TitleLabelView.Location = new Point(50, 12);
            TitleLabelView.Name = "TitleLabelView";
            TitleLabelView.Size = new Size(209, 56);
            TitleLabelView.TabIndex = 0;
            TitleLabelView.Text = "Просмотр";
            // 
            // tabPageEdit
            // 
            tabPageEdit.BackColor = Color.FromArgb(45, 45, 45);
            tabPageEdit.Controls.Add(lblStatus);
            tabPageEdit.Controls.Add(btnCancel);
            tabPageEdit.Controls.Add(btnSave);
            tabPageEdit.Controls.Add(btnEdit);
            tabPageEdit.Controls.Add(panelEdit);
            tabPageEdit.Controls.Add(TitleLabelEdit);
            tabPageEdit.Location = new Point(184, 4);
            tabPageEdit.Name = "tabPageEdit";
            tabPageEdit.Padding = new Padding(3);
            tabPageEdit.Size = new Size(952, 863);
            tabPageEdit.TabIndex = 1;
            tabPageEdit.Text = "Редактирование";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(50, 100);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(184, 30);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Режим просмотра";
            lblStatus.Click += lblStatus_Click;
            // 
            // btnCancel
            // 
            btnCancel.Animated = true;
            btnCancel.BorderRadius = 10;
            btnCancel.CustomizableEdges = customizableEdges23;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.FromArgb(100, 100, 100);
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.HoverState.FillColor = Color.FromArgb(120, 120, 120);
            btnCancel.Location = new Point(250, 570);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnCancel.Size = new Size(180, 45);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.Visible = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Animated = true;
            btnSave.BorderRadius = 10;
            btnSave.CustomizableEdges = customizableEdges25;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.FromArgb(0, 122, 204);
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.HoverState.FillColor = Color.FromArgb(0, 98, 163);
            btnSave.Location = new Point(50, 570);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnSave.Size = new Size(180, 45);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.Visible = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.Animated = true;
            btnEdit.BorderRadius = 10;
            btnEdit.CustomizableEdges = customizableEdges27;
            btnEdit.DisabledState.BorderColor = Color.DarkGray;
            btnEdit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEdit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEdit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEdit.FillColor = Color.FromArgb(40, 167, 69);
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.HoverState.FillColor = Color.FromArgb(33, 136, 56);
            btnEdit.Location = new Point(50, 570);
            btnEdit.Name = "btnEdit";
            btnEdit.ShadowDecoration.CustomizableEdges = customizableEdges28;
            btnEdit.Size = new Size(180, 45);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Редактировать";
            btnEdit.Click += BtnEdit_Click;
            // 
            // panelEdit
            // 
            panelEdit.BackColor = Color.FromArgb(60, 60, 60);
            panelEdit.BorderRadius = 15;
            panelEdit.Controls.Add(txtEditHouse);
            panelEdit.Controls.Add(txtEditStreet);
            panelEdit.Controls.Add(txtEditTown);
            panelEdit.Controls.Add(txtEditPhone);
            panelEdit.Controls.Add(txtEditSnils);
            panelEdit.Controls.Add(txtEditPatronymic);
            panelEdit.Controls.Add(txtEditName);
            panelEdit.Controls.Add(txtEditSurname);
            panelEdit.Controls.Add(txtEditUserId);
            panelEdit.Controls.Add(lblEditHouse);
            panelEdit.Controls.Add(lblEditStreet);
            panelEdit.Controls.Add(lblEditTown);
            panelEdit.Controls.Add(lblEditPhone);
            panelEdit.Controls.Add(lblEditSnils);
            panelEdit.Controls.Add(lblEditPatronymic);
            panelEdit.Controls.Add(lblEditName);
            panelEdit.Controls.Add(lblEditSurname);
            panelEdit.Controls.Add(lblEditUserId);
            panelEdit.CustomizableEdges = customizableEdges47;
            panelEdit.Location = new Point(50, 136);
            panelEdit.Name = "panelEdit";
            panelEdit.ShadowDecoration.CustomizableEdges = customizableEdges48;
            panelEdit.Size = new Size(737, 408);
            panelEdit.TabIndex = 1;
            // 
            // txtEditHouse
            // 
            txtEditHouse.Animated = true;
            txtEditHouse.BorderColor = Color.FromArgb(100, 100, 100);
            txtEditHouse.BorderRadius = 8;
            txtEditHouse.Cursor = Cursors.IBeam;
            txtEditHouse.CustomizableEdges = customizableEdges29;
            txtEditHouse.DefaultText = "";
            txtEditHouse.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEditHouse.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEditHouse.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEditHouse.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEditHouse.FillColor = Color.FromArgb(70, 70, 70);
            txtEditHouse.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditHouse.Font = new Font("Segoe UI", 11F);
            txtEditHouse.ForeColor = Color.White;
            txtEditHouse.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditHouse.Location = new Point(200, 300);
            txtEditHouse.Margin = new Padding(4, 5, 4, 5);
            txtEditHouse.Name = "txtEditHouse";
            txtEditHouse.PlaceholderText = "";
            txtEditHouse.SelectedText = "";
            txtEditHouse.ShadowDecoration.CustomizableEdges = customizableEdges30;
            txtEditHouse.Size = new Size(488, 45);
            txtEditHouse.TabIndex = 17;
            // 
            // txtEditStreet
            // 
            txtEditStreet.Animated = true;
            txtEditStreet.BorderColor = Color.FromArgb(100, 100, 100);
            txtEditStreet.BorderRadius = 8;
            txtEditStreet.Cursor = Cursors.IBeam;
            txtEditStreet.CustomizableEdges = customizableEdges31;
            txtEditStreet.DefaultText = "";
            txtEditStreet.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEditStreet.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEditStreet.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEditStreet.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEditStreet.FillColor = Color.FromArgb(70, 70, 70);
            txtEditStreet.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditStreet.Font = new Font("Segoe UI", 11F);
            txtEditStreet.ForeColor = Color.White;
            txtEditStreet.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditStreet.Location = new Point(200, 240);
            txtEditStreet.Margin = new Padding(4, 5, 4, 5);
            txtEditStreet.Name = "txtEditStreet";
            txtEditStreet.PlaceholderText = "";
            txtEditStreet.SelectedText = "";
            txtEditStreet.ShadowDecoration.CustomizableEdges = customizableEdges32;
            txtEditStreet.Size = new Size(488, 45);
            txtEditStreet.TabIndex = 16;
            // 
            // txtEditTown
            // 
            txtEditTown.Animated = true;
            txtEditTown.BorderColor = Color.FromArgb(100, 100, 100);
            txtEditTown.BorderRadius = 8;
            txtEditTown.Cursor = Cursors.IBeam;
            txtEditTown.CustomizableEdges = customizableEdges33;
            txtEditTown.DefaultText = "";
            txtEditTown.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEditTown.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEditTown.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEditTown.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEditTown.FillColor = Color.FromArgb(70, 70, 70);
            txtEditTown.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditTown.Font = new Font("Segoe UI", 11F);
            txtEditTown.ForeColor = Color.White;
            txtEditTown.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditTown.Location = new Point(200, 180);
            txtEditTown.Margin = new Padding(4, 5, 4, 5);
            txtEditTown.Name = "txtEditTown";
            txtEditTown.PlaceholderText = "";
            txtEditTown.SelectedText = "";
            txtEditTown.ShadowDecoration.CustomizableEdges = customizableEdges34;
            txtEditTown.Size = new Size(488, 45);
            txtEditTown.TabIndex = 15;
            // 
            // txtEditPhone
            // 
            txtEditPhone.Animated = true;
            txtEditPhone.BorderColor = Color.FromArgb(100, 100, 100);
            txtEditPhone.BorderRadius = 8;
            txtEditPhone.Cursor = Cursors.IBeam;
            txtEditPhone.CustomizableEdges = customizableEdges35;
            txtEditPhone.DefaultText = "";
            txtEditPhone.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEditPhone.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEditPhone.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEditPhone.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEditPhone.FillColor = Color.FromArgb(70, 70, 70);
            txtEditPhone.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditPhone.Font = new Font("Segoe UI", 11F);
            txtEditPhone.ForeColor = Color.White;
            txtEditPhone.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditPhone.Location = new Point(200, 120);
            txtEditPhone.Margin = new Padding(4, 5, 4, 5);
            txtEditPhone.Name = "txtEditPhone";
            txtEditPhone.PlaceholderText = "";
            txtEditPhone.SelectedText = "";
            txtEditPhone.ShadowDecoration.CustomizableEdges = customizableEdges36;
            txtEditPhone.Size = new Size(488, 45);
            txtEditPhone.TabIndex = 14;
            // 
            // txtEditSnils
            // 
            txtEditSnils.Animated = true;
            txtEditSnils.BorderColor = Color.FromArgb(100, 100, 100);
            txtEditSnils.BorderRadius = 8;
            txtEditSnils.Cursor = Cursors.IBeam;
            txtEditSnils.CustomizableEdges = customizableEdges37;
            txtEditSnils.DefaultText = "";
            txtEditSnils.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEditSnils.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEditSnils.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEditSnils.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEditSnils.FillColor = Color.FromArgb(70, 70, 70);
            txtEditSnils.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditSnils.Font = new Font("Segoe UI", 11F);
            txtEditSnils.ForeColor = Color.White;
            txtEditSnils.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditSnils.Location = new Point(200, 65);
            txtEditSnils.Margin = new Padding(4, 5, 4, 5);
            txtEditSnils.Name = "txtEditSnils";
            txtEditSnils.PlaceholderText = "";
            txtEditSnils.SelectedText = "";
            txtEditSnils.ShadowDecoration.CustomizableEdges = customizableEdges38;
            txtEditSnils.Size = new Size(488, 45);
            txtEditSnils.TabIndex = 13;
            // 
            // txtEditPatronymic
            // 
            txtEditPatronymic.Animated = true;
            txtEditPatronymic.BorderColor = Color.FromArgb(100, 100, 100);
            txtEditPatronymic.BorderRadius = 8;
            txtEditPatronymic.Cursor = Cursors.IBeam;
            txtEditPatronymic.CustomizableEdges = customizableEdges39;
            txtEditPatronymic.DefaultText = "";
            txtEditPatronymic.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEditPatronymic.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEditPatronymic.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEditPatronymic.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEditPatronymic.FillColor = Color.FromArgb(70, 70, 70);
            txtEditPatronymic.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditPatronymic.Font = new Font("Segoe UI", 11F);
            txtEditPatronymic.ForeColor = Color.White;
            txtEditPatronymic.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditPatronymic.Location = new Point(200, 5);
            txtEditPatronymic.Margin = new Padding(4, 5, 4, 5);
            txtEditPatronymic.Name = "txtEditPatronymic";
            txtEditPatronymic.PlaceholderText = "";
            txtEditPatronymic.SelectedText = "";
            txtEditPatronymic.ShadowDecoration.CustomizableEdges = customizableEdges40;
            txtEditPatronymic.Size = new Size(488, 45);
            txtEditPatronymic.TabIndex = 12;
            // 
            // txtEditName
            // 
            txtEditName.Animated = true;
            txtEditName.BorderColor = Color.FromArgb(100, 100, 100);
            txtEditName.BorderRadius = 8;
            txtEditName.Cursor = Cursors.IBeam;
            txtEditName.CustomizableEdges = customizableEdges41;
            txtEditName.DefaultText = "";
            txtEditName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEditName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEditName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEditName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEditName.FillColor = Color.FromArgb(70, 70, 70);
            txtEditName.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditName.Font = new Font("Segoe UI", 11F);
            txtEditName.ForeColor = Color.White;
            txtEditName.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditName.Location = new Point(200, -60);
            txtEditName.Margin = new Padding(4, 5, 4, 5);
            txtEditName.Name = "txtEditName";
            txtEditName.PlaceholderText = "";
            txtEditName.SelectedText = "";
            txtEditName.ShadowDecoration.CustomizableEdges = customizableEdges42;
            txtEditName.Size = new Size(600, 45);
            txtEditName.TabIndex = 11;
            // 
            // txtEditSurname
            // 
            txtEditSurname.Animated = true;
            txtEditSurname.BorderColor = Color.FromArgb(100, 100, 100);
            txtEditSurname.BorderRadius = 8;
            txtEditSurname.Cursor = Cursors.IBeam;
            txtEditSurname.CustomizableEdges = customizableEdges43;
            txtEditSurname.DefaultText = "";
            txtEditSurname.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEditSurname.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEditSurname.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEditSurname.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEditSurname.FillColor = Color.FromArgb(70, 70, 70);
            txtEditSurname.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditSurname.Font = new Font("Segoe UI", 11F);
            txtEditSurname.ForeColor = Color.White;
            txtEditSurname.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditSurname.Location = new Point(200, -120);
            txtEditSurname.Margin = new Padding(4, 5, 4, 5);
            txtEditSurname.Name = "txtEditSurname";
            txtEditSurname.PlaceholderText = "";
            txtEditSurname.SelectedText = "";
            txtEditSurname.ShadowDecoration.CustomizableEdges = customizableEdges44;
            txtEditSurname.Size = new Size(600, 45);
            txtEditSurname.TabIndex = 10;
            // 
            // txtEditUserId
            // 
            txtEditUserId.Animated = true;
            txtEditUserId.BorderColor = Color.FromArgb(100, 100, 100);
            txtEditUserId.BorderRadius = 8;
            txtEditUserId.Cursor = Cursors.IBeam;
            txtEditUserId.CustomizableEdges = customizableEdges45;
            txtEditUserId.DefaultText = "";
            txtEditUserId.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEditUserId.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEditUserId.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEditUserId.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEditUserId.FillColor = Color.FromArgb(70, 70, 70);
            txtEditUserId.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditUserId.Font = new Font("Segoe UI", 11F);
            txtEditUserId.ForeColor = Color.White;
            txtEditUserId.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtEditUserId.Location = new Point(200, 360);
            txtEditUserId.Margin = new Padding(4, 5, 4, 5);
            txtEditUserId.Name = "txtEditUserId";
            txtEditUserId.PlaceholderText = "";
            txtEditUserId.ReadOnly = true;
            txtEditUserId.SelectedText = "";
            txtEditUserId.ShadowDecoration.CustomizableEdges = customizableEdges46;
            txtEditUserId.Size = new Size(488, 43);
            txtEditUserId.TabIndex = 9;
            // 
            // lblEditHouse
            // 
            lblEditHouse.BackColor = Color.Transparent;
            lblEditHouse.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditHouse.ForeColor = Color.White;
            lblEditHouse.Location = new Point(50, 313);
            lblEditHouse.Name = "lblEditHouse";
            lblEditHouse.Size = new Size(56, 32);
            lblEditHouse.TabIndex = 8;
            lblEditHouse.Text = "Дом:";
            // 
            // lblEditStreet
            // 
            lblEditStreet.BackColor = Color.Transparent;
            lblEditStreet.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditStreet.ForeColor = Color.White;
            lblEditStreet.Location = new Point(50, 253);
            lblEditStreet.Name = "lblEditStreet";
            lblEditStreet.Size = new Size(76, 32);
            lblEditStreet.TabIndex = 7;
            lblEditStreet.Text = "Улица:";
            // 
            // lblEditTown
            // 
            lblEditTown.BackColor = Color.Transparent;
            lblEditTown.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditTown.ForeColor = Color.White;
            lblEditTown.Location = new Point(50, 193);
            lblEditTown.Name = "lblEditTown";
            lblEditTown.Size = new Size(74, 32);
            lblEditTown.TabIndex = 6;
            lblEditTown.Text = "Город:";
            // 
            // lblEditPhone
            // 
            lblEditPhone.BackColor = Color.Transparent;
            lblEditPhone.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditPhone.ForeColor = Color.White;
            lblEditPhone.Location = new Point(50, 133);
            lblEditPhone.Name = "lblEditPhone";
            lblEditPhone.Size = new Size(102, 32);
            lblEditPhone.TabIndex = 5;
            lblEditPhone.Text = "Телефон:";
            // 
            // lblEditSnils
            // 
            lblEditSnils.BackColor = Color.Transparent;
            lblEditSnils.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditSnils.ForeColor = Color.White;
            lblEditSnils.Location = new Point(50, 73);
            lblEditSnils.Name = "lblEditSnils";
            lblEditSnils.Size = new Size(87, 32);
            lblEditSnils.TabIndex = 4;
            lblEditSnils.Text = "СНИЛС:";
            // 
            // lblEditPatronymic
            // 
            lblEditPatronymic.BackColor = Color.Transparent;
            lblEditPatronymic.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditPatronymic.ForeColor = Color.White;
            lblEditPatronymic.Location = new Point(50, 18);
            lblEditPatronymic.Name = "lblEditPatronymic";
            lblEditPatronymic.Size = new Size(108, 32);
            lblEditPatronymic.TabIndex = 3;
            lblEditPatronymic.Text = "Отчество:";
            // 
            // lblEditName
            // 
            lblEditName.BackColor = Color.Transparent;
            lblEditName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditName.ForeColor = Color.White;
            lblEditName.Location = new Point(50, -55);
            lblEditName.Name = "lblEditName";
            lblEditName.Size = new Size(56, 32);
            lblEditName.TabIndex = 2;
            lblEditName.Text = "Имя:";
            // 
            // lblEditSurname
            // 
            lblEditSurname.BackColor = Color.Transparent;
            lblEditSurname.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditSurname.ForeColor = Color.White;
            lblEditSurname.Location = new Point(50, -115);
            lblEditSurname.Name = "lblEditSurname";
            lblEditSurname.Size = new Size(110, 32);
            lblEditSurname.TabIndex = 1;
            lblEditSurname.Text = "Фамилия:";
            // 
            // lblEditUserId
            // 
            lblEditUserId.BackColor = Color.Transparent;
            lblEditUserId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditUserId.ForeColor = Color.White;
            lblEditUserId.Location = new Point(50, 373);
            lblEditUserId.Name = "lblEditUserId";
            lblEditUserId.Size = new Size(111, 32);
            lblEditUserId.TabIndex = 0;
            lblEditUserId.Text = "ID учетки:";
            // 
            // TitleLabelEdit
            // 
            TitleLabelEdit.BackColor = Color.Transparent;
            TitleLabelEdit.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            TitleLabelEdit.ForeColor = Color.FromArgb(0, 122, 204);
            TitleLabelEdit.Location = new Point(50, 30);
            TitleLabelEdit.Name = "TitleLabelEdit";
            TitleLabelEdit.Size = new Size(339, 56);
            TitleLabelEdit.TabIndex = 0;
            TitleLabelEdit.Text = "Редактирование";
            // 
            // tabPagePassword
            // 
            tabPagePassword.BackColor = Color.FromArgb(45, 45, 45);
            tabPagePassword.Controls.Add(panelPassword);
            tabPagePassword.Controls.Add(TitleLabelPassword);
            tabPagePassword.Location = new Point(184, 4);
            tabPagePassword.Name = "tabPagePassword";
            tabPagePassword.Size = new Size(952, 863);
            tabPagePassword.TabIndex = 2;
            tabPagePassword.Text = "Смена пароля";
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.FromArgb(60, 60, 60);
            panelPassword.BorderRadius = 15;
            panelPassword.Controls.Add(btnShowPassword);
            panelPassword.Controls.Add(btnChangePassword);
            panelPassword.Controls.Add(txtConfirmNewPassword);
            panelPassword.Controls.Add(txtNewPassword);
            panelPassword.Controls.Add(txtCurrentPassword);
            panelPassword.Controls.Add(lblConfirmPassword);
            panelPassword.Controls.Add(lblNewPassword);
            panelPassword.Controls.Add(lblCurrentPassword);
            panelPassword.CustomizableEdges = customizableEdges59;
            panelPassword.Location = new Point(50, 100);
            panelPassword.Name = "panelPassword";
            panelPassword.ShadowDecoration.CustomizableEdges = customizableEdges60;
            panelPassword.Size = new Size(721, 402);
            panelPassword.TabIndex = 1;
            // 
            // btnShowPassword
            // 
            btnShowPassword.Animated = true;
            btnShowPassword.BackColor = Color.Transparent;
            btnShowPassword.BorderColor = Color.FromArgb(100, 100, 100);
            btnShowPassword.BorderRadius = 8;
            btnShowPassword.BorderThickness = 1;
            btnShowPassword.CustomizableEdges = customizableEdges49;
            btnShowPassword.DisabledState.BorderColor = Color.DarkGray;
            btnShowPassword.DisabledState.CustomBorderColor = Color.DarkGray;
            btnShowPassword.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnShowPassword.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnShowPassword.FillColor = Color.FromArgb(60, 60, 60);
            btnShowPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnShowPassword.ForeColor = Color.White;
            btnShowPassword.HoverState.FillColor = Color.FromArgb(80, 80, 80);
            btnShowPassword.Location = new Point(567, 180);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.ShadowDecoration.CustomizableEdges = customizableEdges50;
            btnShowPassword.Size = new Size(124, 45);
            btnShowPassword.TabIndex = 7;
            btnShowPassword.Text = "показать";
            btnShowPassword.Click += BtnShowPassword_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Animated = true;
            btnChangePassword.BorderRadius = 10;
            btnChangePassword.CustomizableEdges = customizableEdges51;
            btnChangePassword.DisabledState.BorderColor = Color.DarkGray;
            btnChangePassword.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChangePassword.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChangePassword.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChangePassword.FillColor = Color.FromArgb(0, 122, 204);
            btnChangePassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.HoverState.FillColor = Color.FromArgb(0, 98, 163);
            btnChangePassword.Location = new Point(50, 320);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.ShadowDecoration.CustomizableEdges = customizableEdges52;
            btnChangePassword.Size = new Size(510, 44);
            btnChangePassword.TabIndex = 6;
            btnChangePassword.Text = "Сменить пароль";
            btnChangePassword.Click += BtnChangePassword_Click;
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.Animated = true;
            txtConfirmNewPassword.BorderColor = Color.FromArgb(100, 100, 100);
            txtConfirmNewPassword.BorderRadius = 8;
            txtConfirmNewPassword.Cursor = Cursors.IBeam;
            txtConfirmNewPassword.CustomizableEdges = customizableEdges53;
            txtConfirmNewPassword.DefaultText = "";
            txtConfirmNewPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtConfirmNewPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtConfirmNewPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtConfirmNewPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtConfirmNewPassword.FillColor = Color.FromArgb(70, 70, 70);
            txtConfirmNewPassword.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtConfirmNewPassword.Font = new Font("Segoe UI", 11F);
            txtConfirmNewPassword.ForeColor = Color.White;
            txtConfirmNewPassword.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtConfirmNewPassword.Location = new Point(253, 245);
            txtConfirmNewPassword.Margin = new Padding(4, 5, 4, 5);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.PasswordChar = '•';
            txtConfirmNewPassword.PlaceholderText = "Подтвердите новый пароль";
            txtConfirmNewPassword.SelectedText = "";
            txtConfirmNewPassword.ShadowDecoration.CustomizableEdges = customizableEdges54;
            txtConfirmNewPassword.Size = new Size(307, 45);
            txtConfirmNewPassword.TabIndex = 5;
            txtConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Animated = true;
            txtNewPassword.BorderColor = Color.FromArgb(100, 100, 100);
            txtNewPassword.BorderRadius = 8;
            txtNewPassword.Cursor = Cursors.IBeam;
            txtNewPassword.CustomizableEdges = customizableEdges55;
            txtNewPassword.DefaultText = "";
            txtNewPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNewPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNewPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNewPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNewPassword.FillColor = Color.FromArgb(70, 70, 70);
            txtNewPassword.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtNewPassword.Font = new Font("Segoe UI", 11F);
            txtNewPassword.ForeColor = Color.White;
            txtNewPassword.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtNewPassword.Location = new Point(253, 180);
            txtNewPassword.Margin = new Padding(4, 5, 4, 5);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '•';
            txtNewPassword.PlaceholderText = "Введите новый пароль";
            txtNewPassword.SelectedText = "";
            txtNewPassword.ShadowDecoration.CustomizableEdges = customizableEdges56;
            txtNewPassword.Size = new Size(307, 45);
            txtNewPassword.TabIndex = 4;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Animated = true;
            txtCurrentPassword.BorderColor = Color.FromArgb(100, 100, 100);
            txtCurrentPassword.BorderRadius = 8;
            txtCurrentPassword.Cursor = Cursors.IBeam;
            txtCurrentPassword.CustomizableEdges = customizableEdges57;
            txtCurrentPassword.DefaultText = "";
            txtCurrentPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCurrentPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCurrentPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCurrentPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCurrentPassword.FillColor = Color.FromArgb(70, 70, 70);
            txtCurrentPassword.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            txtCurrentPassword.Font = new Font("Segoe UI", 11F);
            txtCurrentPassword.ForeColor = Color.White;
            txtCurrentPassword.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            txtCurrentPassword.Location = new Point(253, 120);
            txtCurrentPassword.Margin = new Padding(4, 5, 4, 5);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '•';
            txtCurrentPassword.PlaceholderText = "Введите текущий пароль";
            txtCurrentPassword.SelectedText = "";
            txtCurrentPassword.ShadowDecoration.CustomizableEdges = customizableEdges58;
            txtCurrentPassword.Size = new Size(307, 50);
            txtCurrentPassword.TabIndex = 3;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.BackColor = Color.Transparent;
            lblConfirmPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.White;
            lblConfirmPassword.Location = new Point(50, 245);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(186, 32);
            lblConfirmPassword.TabIndex = 2;
            lblConfirmPassword.Text = "Подтверждение:";
            // 
            // lblNewPassword
            // 
            lblNewPassword.BackColor = Color.Transparent;
            lblNewPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.White;
            lblNewPassword.Location = new Point(50, 185);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(167, 32);
            lblNewPassword.TabIndex = 1;
            lblNewPassword.Text = "Новый пароль:";
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.BackColor = Color.Transparent;
            lblCurrentPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCurrentPassword.ForeColor = Color.White;
            lblCurrentPassword.Location = new Point(50, 125);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(189, 32);
            lblCurrentPassword.TabIndex = 0;
            lblCurrentPassword.Text = "Текущий пароль:";
            // 
            // TitleLabelPassword
            // 
            TitleLabelPassword.BackColor = Color.Transparent;
            TitleLabelPassword.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            TitleLabelPassword.ForeColor = Color.FromArgb(0, 122, 204);
            TitleLabelPassword.Location = new Point(50, 30);
            TitleLabelPassword.Name = "TitleLabelPassword";
            TitleLabelPassword.Size = new Size(290, 56);
            TitleLabelPassword.TabIndex = 0;
            TitleLabelPassword.Text = "Смена пароля";
            // 
            // guna2ShadowForm
            // 
            guna2ShadowForm.TargetForm = this;
            // 
            // PatientProfileForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 931);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "PatientProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Профиль пациента";
            MainPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPageView.ResumeLayout(false);
            tabPageView.PerformLayout();
            panelView.ResumeLayout(false);
            panelView.PerformLayout();
            tabPageEdit.ResumeLayout(false);
            tabPageEdit.PerformLayout();
            panelEdit.ResumeLayout(false);
            panelEdit.PerformLayout();
            tabPagePassword.ResumeLayout(false);
            tabPagePassword.PerformLayout();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            ResumeLayout(false);
        }
    }
}