using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAllocationWebApi.Data.Models
{
    public class ResourceAllocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceAllocationID { get; set; }
        
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public int ResourceID { get; set; }
        public Resource Resource { get; set; }
    }
}
