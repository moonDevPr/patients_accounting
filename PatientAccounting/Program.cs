using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PatientsAccounting.Forms;
using PatientsAccounting.Models;

namespace PatientsAcounting
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            
            try
            {
                // вызов подключения к бд + проверка успешного соединения
                using var context = new ApplicationDbContext();
                context.Database.EnsureCreated();

                if (context.Database.CanConnect())
                {
                    MessageBox.Show("БД подключена успешно");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.Message}");
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new PatientsMenu());
        }
    }
}