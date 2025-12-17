using PatientsAccounting.Models;
using System;
using System.Linq;

namespace PatientsAccounting.Services 
{
    internal class Doctor
    {
        public static (Doctors Doctor, UsersCredentials Credential, UsersRole Role)?        GetDoctorByUsername(string username) 
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Doctors
                    .Join(context.UsersCredentials,
                        doctor => doctor.id_user_credential,
                        credential => credential.id,
                        (doctor, credential) => new { Doctor = doctor, Credential = credential })
                    .Join(context.UsersRoles,
                        combined => combined.Credential.id_users_role,
                        role => role.id,
                        (combined, role) => new
                        {
                            combined.Doctor,
                            combined.Credential,
                            Role = role
                        })
                    .Where(elem => elem.Credential.username == username)
                    .Select(elem => new
                    {
                        elem.Doctor,
                        elem.Credential,
                        elem.Role
                    })
                    .FirstOrDefault();

                if (query == null)
                    return null;

                return (query.Doctor, query.Credential, query.Role);
            }
        }
    }
}
