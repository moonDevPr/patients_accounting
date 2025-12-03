using PatientsAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsAcounting.Services
{
    internal class Patient
    {
        // получение полной информации о пользователе
        public static (Patients Patient, UsersCredentials Credential, UsersRole Role)? GetAllInformation(int patientId)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Patients
                    .Join(context.UsersCredentials,
                        patient => patient.id,
                        credential => credential.id_patient,
                        (patient, credential) => new { Patient = patient, Credential = credential })
                    .Join(context.UsersRoles,
                        combined => combined.Credential.id_users_role,
                        role => role.id,
                        (combined, role) => new
                        {
                            combined.Patient,
                            combined.Credential,
                            Role = role
                        })
                    .Where(elem => elem.Patient.id == patientId)
                    .Select(elem => new
                    {
                        elem.Patient,
                        elem.Credential,
                        elem.Role
                    })
                    .FirstOrDefault();

                if (query == null)
                    return null;

                return (query.Patient, query.Credential, query.Role);
            }
        }
    }


}
