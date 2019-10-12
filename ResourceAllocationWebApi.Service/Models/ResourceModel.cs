using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAllocationWebApi.Service.Models
{
    public class ResourceModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Threshold { get; set; }
    }
}
