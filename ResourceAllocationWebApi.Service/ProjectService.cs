using ResourceAllocationWebApi.Data.Context;
using ResourceAllocationWebApi.Data.Models;
using ResourceAllocationWebApi.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAllocationWebApi.Service
{
    public class ProjectService
    {
        DatabaseContext dbcontext = new DatabaseContext();
        BooleanInformationModel B;
   
        public BooleanInformationModel StoreProjectValues(ProjectModel project)
        {
            Project value = new Project() { ProjectName = project.ProjectName, NoOfResources = project.NoOfResources };
            dbcontext.Projects.Add(value);
            dbcontext.SaveChanges();
            B = new BooleanInformationModel() { TrueOrFalse = true };
            return B;
        }

        public List<ProjectModel> GetProjectData()
        {
            var result = dbcontext.Projects.Select(x =>
            new ProjectModel()
            {
                ProjectName = x.ProjectName,
                NoOfResources = x.NoOfResources
            }).ToList();
            return result;
        }
    }
}
