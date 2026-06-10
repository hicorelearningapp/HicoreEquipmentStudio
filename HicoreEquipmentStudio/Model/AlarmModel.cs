using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HicoreEquipmentStudio.Model
{
    public class AlarmModel
    {
        public int ALID { get; set; }

        public string AlarmName { get; set; }

        public string SourceType { get; set; }

        public string Address { get; set; }

        public string Condition { get; set; }

        public string Severity { get; set; }

        public string Category { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }
    }
}
