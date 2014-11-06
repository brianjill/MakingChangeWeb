using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakingChange.Data;
using MakingChange.Data.Entities;

namespace MakingChange.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string dbFile = @"D:\GitHub\MakingChange\MakingChange\App_Data\MC.db";
            OcDataRepository.Create(dbFile);

            var project = new Project
                              {
                                  Name = "App",
                                  Manager = new Person
                                  {
                                      ShortName = "Ino",
                                      Type = PersonType.Member.ToString(),
                                  }
 
                              };

            OcDataRepository.AddProject(dbFile,project);
            return View();
        }
    }
}
