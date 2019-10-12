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
    public class ResourceAllocationService
    {
        DatabaseContext dbcontext = new DatabaseContext();
        BooleanInformationModel B;

        public List<ProjectNameModel> GetProjectNames()
        {
            var result = dbcontext.Projects.Select(x =>
            new ProjectNameModel()
            {
                ProjectID = x.ProjectID,
                ProjectName = x.ProjectName
            }).ToList();
            return result;
        }

        public List<ResourceNameModel> GetResourceNames(SingleIDModel s)
        {
            var result = (from r in dbcontext.Resources
                          where !dbcontext.ResourceAllocations.Any(rs => (rs.ResourceID == r.ResourceID) && (rs.ProjectID == s.ID1))
                          select
                             new ResourceNameModel()
                             {
                                 ResourceID = r.ResourceID,
                                 Name = r.Name
                             }
                         ).ToList();
            return result;
        }

        public List<ResourceNameModel> GetResources()
        {
            var result = (from r in dbcontext.Resources
                          select
                            new ResourceNameModel()
                            {
                                ResourceID = r.ResourceID,
                                Name = r.Name
                            }
                         ).ToList();
            return result;
        }

        public List<ProjectNameOnlyModel> GetProjectNameForTheResource(SingleIDModel s)
        {
            var result = (from pro in dbcontext.Projects
                          join resall in dbcontext.ResourceAllocations
                          on pro.ProjectID equals resall.ProjectID
                          where resall.ResourceID == s.ID1
                          select new ProjectNameOnlyModel()
                          {
                              ProjectName = pro.ProjectName
                          }).ToList();
            return result;
        }

        public BooleanInformationModel StoreResourceAllocationValues(DoubleIDModel d)
        {
            B = new BooleanInformationModel();
            int Rcount = dbcontext.ResourceAllocations.Where(c => c.ResourceID == d.ID2).Count();
            var Rresult = dbcontext.Resources.Any(c => c.ResourceID == d.ID2 && c.Threshold > Rcount);
            if (Rresult == true)
            {
                ResourceAllocation value = new ResourceAllocation() { ProjectID = d.ID1, ResourceID = d.ID2 };
                dbcontext.ResourceAllocations.Add(value);
                dbcontext.SaveChanges();

                int RAcount = dbcontext.ResourceAllocations.Where(c => c.ProjectID == d.ID1).Count();
                Project Pr = dbcontext.Projects.Single(proj => proj.ProjectID == d.ID1);
                Pr.NoOfResources = RAcount;
                dbcontext.SaveChanges();
                B.TrueOrFalse = true;
            }
            else
            {
                B.TrueOrFalse = false;
            }
            return B;
        }

        public List<ResourceNameOnlyModel> GetResourceNamesOnly(SingleIDModel single)
        {
            var result = (from res in dbcontext.Resources
                          join resall in dbcontext.ResourceAllocations
                          on res.ResourceID equals resall.ResourceID
                          where resall.ProjectID == single.ID1
                          select new ResourceNameOnlyModel()
                          {
                              ResourceNames = res.Name
                          }).ToList();
            return result;


        }
    }
}
