using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAllocationWebApi.Data.Models
{
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public int Threshold { get; set; }

        public ICollection<ResourceAllocation> ResourceAllocations { get; set; }
    }
}
