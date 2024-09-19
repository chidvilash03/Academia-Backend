using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities
{
    public class Hosteler
    {
        [Key]
        public int HostelerId { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public bool IsActive { get; set; }


        // Foreign key to Hostel
        public int HostelId { get; set; }
    }
}
