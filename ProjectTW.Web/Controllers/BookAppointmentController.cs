﻿using ProjectTW.BusinessLogic.Interfaces;
using ProjectTW.Web.Extension;
using ProjectTW.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTW.Web.Controllers
{
    public class BookAppointmentController : Controller
    {

        public readonly IPatient _patient;
        public BookAppointmentController() 
        {
               var bl = new BusinessLogic.BusinessLogic();
               _patient = bl.GetPatientBL();
        }
        // GET: BookAppointment
        public ActionResult Index()
        {
            var user = System.Web.HttpContext.Current.GetMySessionObject();

            GlobalData globalData = new GlobalData()
            {
                Email = user.Email,
                FullName = user.FullName,
                Speciality = user.Specilality,
                Biography = user.Biography,
                ProfileImagePath = user.ProfileImagePath,
                Level = user.Level
            };

            return View(globalData);
        }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(GlobalData globalData)
          {
               var doctors = _patient.GetDoctorsBySpeciality(globalData.Speciality);

               globalData.DoctorList = doctors;
               return View(globalData);
          }
        
    }
}