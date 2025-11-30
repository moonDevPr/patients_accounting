using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientsAccounting.Forms
{
    public partial class RegistrationPreviewForm : Form
    {
        Random rnd = new Random();
        string captchaCode = "";

        public RegistrationPreviewForm()
        {
            InitializeComponent();
        }

        private void RegistrationPreviewForm_Load(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        /*
         генерация капчи, шум на картинке рисуется в виде кружочков
         */
        private void GenerateCaptcha()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            captchaCode = new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());

            int imageWidth = 400;
            int imageHeight = 150;

            Bitmap picture = new Bitmap(imageWidth, imageHeight);
            using (Graphics g = Graphics.FromImage(picture))
            {
                g.Clear(Color.White);

                Font font = new Font("Arial", 48, FontStyle.Bold);

                SizeF textSize = g.MeasureString(captchaCode, font);

                float x = (imageWidth - textSize.Width) / 2;
                float y = (imageHeight - textSize.Height) / 2;

                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.DrawString(captchaCode, font, Brushes.Black, x, y);
                for (int i = 0; i < 30; i++)
                {
                    int x1 = rnd.Next(0, picture.Width);
                    int y1 = rnd.Next(0, picture.Height);
                    int size = rnd.Next(3, 8);
                    g.FillEllipse(Brushes.Black, x1, y1, size, size);
                }
            }

            // добавление картинки капчи
            pictureBoxCaptcha.Image = picture;
        }

        // проверка капчи после подтверждения ввода 
        private void ConfirmButton_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == captchaCode)
            {
                MessageBox.Show("Капча пройдена");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверная капча. Попробуйте снова.");
                GenerateCaptcha();
                textBox1.Clear();

            }
        }
        

        private void instructionLabel_Click(object sender, EventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
