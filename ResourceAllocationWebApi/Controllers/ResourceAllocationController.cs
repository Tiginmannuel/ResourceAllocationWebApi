using ResourceAllocationWebApi.Service;
using ResourceAllocationWebApi.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResourceAllocationWebApi.Controllers
{
    [RoutePrefix("resourceallocation")]
    public class ResourceAllocationController : ApiController
    {
        private ResourceAllocationService _service;

        public ResourceAllocationController()
        {
            _service = new ResourceAllocationService();
        }
        [Route("showprojectnames")]
        [HttpGet]
        public List<ProjectNameModel> ShowProjectNames()
        {
            return _service.GetProjectNames();
        }
        [Route("showresourcenames")]
        [HttpGet]
        public List<ResourceNameModel> ShowResourceNames()
        {
            return _service.GetResources();
        }
        [Route("getresourcenames")]
        [HttpPost]
        public List<ResourceNameOnlyModel> GetResourceNameOnly(SingleIDModel single)
        {
            return _service.GetResourceNamesOnly(single);
        }
        [Route("showresourcenames")]
        [HttpPost]
        public List<ResourceNameModel> ShowResourceNames(SingleIDModel s)
        {
            return _service.GetResourceNames(s);
        }
        [Route("storeresourceallocation")]
        [HttpPost]
        public BooleanInformationModel StoreResourceAllocation(DoubleIDModel d)
        {
            return _service.StoreResourceAllocationValues(d);
        }
        [Route("getprojectnamefortheresource")]
        [HttpPost]
        public List<ProjectNameOnlyModel> GetProjectNameAllocatedToResource(SingleIDModel s)
        {
            return _service.GetProjectNameForTheResource(s);
        }
    }
}
