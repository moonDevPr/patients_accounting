using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PatientsAccounting.Models;

namespace PatientAccounting
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                using var context = new ApplicationDbContext();
                context.Database.EnsureCreated();

                MessageBox.Show("Если открылось окно - подключение активно и БД была создана");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка БД: {ex.Message}", "Ошибка");
            }

        }
    }
}