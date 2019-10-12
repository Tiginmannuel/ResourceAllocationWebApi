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
    [RoutePrefix("resource")]
    public class ResourceController : ApiController
    {
        private ResourceService _service;

        public ResourceController()
        {
            _service = new ResourceService();
        }

        [Route("storeresource")]
        [HttpPost]
        public BooleanInformationModel StoreResource([FromBody]ResourceModel res)
        {
            return _service.StoreResourceValues(res);
        }

        [Route("showresource")]
        [HttpGet]
        public List<ResourceModel> ShowResource()
        {
            return _service.GetResourceData();
        }
    }
}
