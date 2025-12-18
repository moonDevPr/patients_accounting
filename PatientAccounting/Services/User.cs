using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsAcounting.Services
{
    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static int RoleId { get; set; }
        public static int? PatientId { get; set; }
        public static string RoleName { get; set; }

        public static int? DoctorId { get; set; }
        public static string DoctorFullName { get; set; } = string.Empty;

        public static bool IsAuthenticated => UserId > 0;

       

       

        // Метод для установки данных пользователя
        public static void SetUserData(int userId, string username, int roleId, string roleName)
        {
            UserId = userId;
            Username = username;
            RoleId = roleId;
            RoleName = roleName;

            // Очищаем специфические данные
            PatientId = null;
            DoctorId = null;
            DoctorFullName = string.Empty;
        }

        // Метод для установки данных пациента
        public static void SetPatientData(int patientId)
        {
            PatientId = patientId;
        }

        // Метод для установки данных врача
        public static void SetDoctorData(int doctorId, string fullName)
        {
            DoctorId = doctorId;
            DoctorFullName = fullName;
        }

        public static void Clear()
        {
            UserId = 0;
            Username = string.Empty;
            RoleId = 0;
            PatientId = null;
            DoctorId = null;
            DoctorFullName = string.Empty;
            RoleName = string.Empty;
        }

    }
}
