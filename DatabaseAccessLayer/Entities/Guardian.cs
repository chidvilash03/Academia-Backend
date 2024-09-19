using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities
{
    public class Guardian
    {
        public int GuardianId { get; set; }
        public string GuardianName { get; set; }
        public string GuardianOCCupation { get; set; }
        public string GuardianMobile { get; set; }
        public string GuardianEmail { get; set; }
        public string GuardianAddress { get; set; }
        public string GuardianRelationShip { get; set; }


    }
}
