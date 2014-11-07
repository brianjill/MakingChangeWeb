using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MakingChange.Data;
using MakingChange.Data.Entities;

namespace MakingChange.Controllers
{
    public class MakingChangeController : ApiController
    {
        private MakingChangeContext _context;

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            
            //code first creates tables in db
            
            FnhConfig.Create();

            var project = new Project
                          {
                              Name="Making Change App",
                              Manager = new Person
                                        {
                                            ShortName = "Ino",
                                            Type = PersonType.Member.ToString()
                                        },
                              Departments = new List<Department>
                                            {
                                                new Department
                                                {
                                                    Name = "Finance"
                                                    
                                                }
                                            }
                          };
            FnhConfig.AddProject(project);
             
            _context = new MakingChangeContext();
        }

        [HttpGet]
        public String Metadata()
        {
            return _context.Metadata();
        }

        [HttpGet]
        public IQueryable<Project> Projects()
        {
            var projects = _context.Projects;
            return projects;
        }
    }
}