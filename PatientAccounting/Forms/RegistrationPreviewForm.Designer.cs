using System;
using System.Windows.Forms;
using System.Drawing;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;

namespace PatientsAccounting.Forms
{
    partial class RegistrationPreviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel MainPanel;
        private Guna2HtmlLabel TitleLabel;
        private PictureBox pictureBoxCaptcha;
        private Guna2TextBox textBox1;
        private Guna2Button ConfirmButton;
        private Guna2HtmlLabel instructionLabel;
        private Guna2HtmlLabel inputLabel;

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
            CustomizableEdges customizableEdges5 = new CustomizableEdges();
            CustomizableEdges customizableEdges6 = new CustomizableEdges();
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            CustomizableEdges customizableEdges3 = new CustomizableEdges();
            CustomizableEdges customizableEdges4 = new CustomizableEdges();
            MainPanel = new Guna2Panel();
            inputLabel = new Guna2HtmlLabel();
            ConfirmButton = new Guna2Button();
            textBox1 = new Guna2TextBox();
            instructionLabel = new Guna2HtmlLabel();
            pictureBoxCaptcha = new PictureBox();
            TitleLabel = new Guna2HtmlLabel();
            guna2ShadowForm1 = new Guna2ShadowForm(components);
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(45, 45, 45);
            MainPanel.Controls.Add(inputLabel);
            MainPanel.Controls.Add(ConfirmButton);
            MainPanel.Controls.Add(textBox1);
            MainPanel.Controls.Add(instructionLabel);
            MainPanel.Controls.Add(pictureBoxCaptcha);
            MainPanel.Controls.Add(TitleLabel);
            MainPanel.CustomizableEdges = customizableEdges5;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(2);
            MainPanel.Name = "MainPanel";
            MainPanel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            MainPanel.Size = new Size(600, 550);
            MainPanel.TabIndex = 1;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // inputLabel
            // 
            inputLabel.BackColor = Color.Transparent;
            inputLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            inputLabel.ForeColor = Color.White;
            inputLabel.Location = new Point(150, 339);
            inputLabel.Name = "inputLabel";
            inputLabel.Size = new Size(304, 32);
            inputLabel.TabIndex = 10;
            inputLabel.Text = "Введите данные с картинки";
            // 
            // ConfirmButton
            // 
            ConfirmButton.Animated = true;
            ConfirmButton.BackColor = Color.Transparent;
            ConfirmButton.BorderRadius = 15;
            ConfirmButton.CustomizableEdges = customizableEdges1;
            ConfirmButton.DisabledState.BorderColor = Color.DarkGray;
            ConfirmButton.DisabledState.CustomBorderColor = Color.DarkGray;
            ConfirmButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ConfirmButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ConfirmButton.FillColor = Color.FromArgb(0, 122, 204);
            ConfirmButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ConfirmButton.ForeColor = Color.White;
            ConfirmButton.HoverState.FillColor = Color.FromArgb(0, 98, 163);
            ConfirmButton.Location = new Point(150, 457);
            ConfirmButton.Margin = new Padding(2);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ConfirmButton.Size = new Size(300, 50);
            ConfirmButton.TabIndex = 9;
            ConfirmButton.Text = "Подтвердить";
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // textBox1
            // 
            textBox1.Animated = true;
            textBox1.BorderColor = Color.FromArgb(100, 100, 100);
            textBox1.BorderRadius = 8;
            textBox1.CustomizableEdges = customizableEdges3;
            textBox1.DefaultText = "";
            textBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            textBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            textBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            textBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            textBox1.FillColor = Color.FromArgb(60, 60, 60);
            textBox1.FocusedState.BorderColor = Color.FromArgb(0, 122, 204);
            textBox1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.ForeColor = Color.White;
            textBox1.HoverState.BorderColor = Color.FromArgb(0, 122, 204);
            textBox1.Location = new Point(150, 379);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderForeColor = Color.Gray;
            textBox1.PlaceholderText = "Введите код с картинки";
            textBox1.SelectedText = "";
            textBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            textBox1.Size = new Size(300, 45);
            textBox1.TabIndex = 8;
            // 
            // instructionLabel
            // 
            instructionLabel.BackColor = Color.Transparent;
            instructionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            instructionLabel.ForeColor = Color.White;
            instructionLabel.Location = new Point(86, 82);
            instructionLabel.Name = "instructionLabel";
            instructionLabel.Size = new Size(442, 34);
            instructionLabel.TabIndex = 7;
            instructionLabel.Text = "Пройдите капчу для подтверждения";
            instructionLabel.Click += instructionLabel_Click;
            // 
            // pictureBoxCaptcha
            // 
            pictureBoxCaptcha.BackColor = Color.White;
            pictureBoxCaptcha.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCaptcha.Location = new Point(120, 142);
            pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            pictureBoxCaptcha.Size = new Size(389, 181);
            pictureBoxCaptcha.TabIndex = 6;
            pictureBoxCaptcha.TabStop = false;
            // 
            // TitleLabel
            // 
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TitleLabel.ForeColor = Color.FromArgb(0, 122, 204);
            TitleLabel.Location = new Point(175, 22);
            TitleLabel.Margin = new Padding(2);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(244, 67);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Проверка";
            TitleLabel.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // guna2ShadowForm1
            // 
            guna2ShadowForm1.TargetForm = this;
            // 
            // RegistrationPreviewForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 550);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "RegistrationPreviewForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HealthHub - Проверка капчи";
            Load += RegistrationPreviewForm_Load;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna2ShadowForm guna2ShadowForm1;

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

       
    }
}