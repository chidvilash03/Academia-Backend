using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities
{
    public class Hostel
    {
        [Key]
        public int HostelId { get; set; }
        public string HostelName { get; set; }
        public string HostelGender { get; set; }
    }
}
