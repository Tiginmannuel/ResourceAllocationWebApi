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
    [RoutePrefix("project")]
    public class ProjectController : ApiController
    {
        private ProjectService _service;

        public ProjectController()
        {
            _service = new ProjectService();
        }

        [Route("storeproject")]
        [HttpPost]
        public BooleanInformationModel StoreProject([FromBody] ProjectModel pro)
        {
            return _service.StoreProjectValues(pro);
        }

        [Route("showproject")]
        [HttpGet]
        public List<ProjectModel> ShowProject()
        {
            return _service.GetProjectData();
        }
    }
}
