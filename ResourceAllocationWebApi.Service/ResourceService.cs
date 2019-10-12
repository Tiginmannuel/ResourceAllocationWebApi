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
    public class ResourceService
    {
        DatabaseContext dbcontext = new DatabaseContext();
        BooleanInformationModel B;

        public BooleanInformationModel StoreResourceValues(ResourceModel obj)
        {
            Resource value = new Resource() { Name = obj.Name, Email = obj.Email, Threshold = obj.Threshold };
            dbcontext.Resources.Add(value);
            dbcontext.SaveChanges();
            B = new BooleanInformationModel() { TrueOrFalse = true };
            return B;
        }

        public List<ResourceModel> GetResourceData()
        {
            var result = dbcontext.Resources.Select(x =>
            new ResourceModel()
            {
                Name = x.Name,
                Email = x.Email,
                Threshold = x.Threshold
            }).ToList();
            return result;
        }
    }
}
