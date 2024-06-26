﻿using ProjectTW.BusinessLogic.DBModel;
using ProjectTW.Domain.Entities.Admin;
using ProjectTW.Domain.Entities.Response;
using ProjectTW.Domain.Entities.User;
using ProjectTW.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjectTW.BusinessLogic.Core
{
     public class AdminAPI
     {
        public UserRegisterResponse DoctorRegisterResponse(DoctorRegisterData doctorRegisterData)
        {
            PatientDbTable resultPatient;
            DoctorDbTable resultDoctor;
            AdminDbTable resultAdmin;

            //Search in Patients Table
            using (var dbPatient = new PatientContext())
            {
                resultPatient = dbPatient.Patients.FirstOrDefault(u => u.Email == doctorRegisterData.Email);
            }
            if (resultPatient != null)
            {
                return new UserRegisterResponse() { Success = false, Message = "A user with this email already exists" };
            }

            //Search in Doctors Table
            using (var dbDoctor = new DoctorContext())
            {
                resultDoctor = dbDoctor.Doctors.FirstOrDefault(u => u.Email == doctorRegisterData.Email);
            }
            if (resultDoctor != null)
            {
                return new UserRegisterResponse() { Success = false, Message = "A user with this email already exists" };
            }

            //Search in Admins Table
            using (var dbAdmin = new AdminContext())
            {
                resultAdmin = dbAdmin.Admins.FirstOrDefault(u => u.Email == doctorRegisterData.Email);
            }
            if (resultAdmin != null)
            {
                return new UserRegisterResponse() { Success = false, Message = "A user with this email already exists" };
            }


            //Add new User Doctor
            var HashPassword = LoginHelper.HashGen(doctorRegisterData.Password);

            var todo = new DoctorDbTable
            {
                Password = HashPassword,
                Email = doctorRegisterData.Email,
                FullName = doctorRegisterData.FullName,
                Biography = doctorRegisterData.Biography,
                Specilality = doctorRegisterData.Speciality,
                Level = doctorRegisterData.Level,
                ProfileImage = doctorRegisterData.ProfileImagePath,
                LastLogin = DateTime.Now
            };

            using (var db = new DoctorContext())
            {
                db.Doctors.Add(todo);
                db.SaveChanges();
            }

            return new UserRegisterResponse { Success = true, Message = "Add Doctor Successful" };
        }

        public List<UserMinimal> AllDoctorsData()
        {
            using (var db = new DoctorContext())
            {
                var dbDoctors = db.Doctors.ToList();

                var doctors = dbDoctors.Select(d => new UserMinimal()
                {
                    Id = d.Id,
                    FullName = d.FullName,
                    Biography = d.Biography,
                    Speciality = d.Specilality,
                    Level = d.Level,
                    ProfileImagePath = d.ProfileImage
                }).ToList();

                return doctors;
            }
        }

        public HospitalData DoctorAndPatientNumber()
        {
            HospitalData hospitalData = new HospitalData();

            using (var db = new DoctorContext())
            {
                hospitalData.DoctorCount = db.Doctors.Count();
            }

            using (var db = new PatientContext())
            {
                hospitalData.PatientCount = db.Patients.Count();
            }

            return hospitalData;
        }

        public List<UserMinimal> AllDoctors()
        {
            using (var db = new DoctorContext())
            {
                var dbDoctors = db.Doctors
                    .OrderBy(d => d.Specilality)
                    .ThenBy(d => d.FullName)
                    .ToList();

                var doctors = dbDoctors.Select(d => new UserMinimal()
                {
                    Id = d.Id,
                    FullName = d.FullName,
                    Biography = d.Biography,
                    Speciality = d.Specilality,
                    Level = d.Level,
                    ProfileImagePath = d.ProfileImage
                }).ToList();

                return doctors;
            }
        }

        public bool DeleteDoctor(int id)
        {
            using (var db = new DoctorContext())
            {
                var doctor = db.Doctors.Find(id);
                if (doctor != null)
                {
                    string imagePath = doctor.ProfileImage;

                    db.Doctors.Remove(doctor);
                    db.SaveChanges();

                    // Sterg fisierul si folderul imaginii daca exista
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        string directoryPath = Path.GetDirectoryName(HttpContext.Current.Server.MapPath(imagePath));
                        if (Directory.Exists(directoryPath))
                        {
                            Directory.Delete(directoryPath, true);
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
