using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class qy_GetCollectionsEligibilityOutputColumns
    {
        public string ImportFileName { get; set; }
        public int PatientID { get; set; }
        public DateTime DOB { get; set; }
        public string SSN { get; set; }
        public DateTime DOS { get; set; }
        public DateTime DateImported { get; set; }
        public string MCO { get; set; }
        public string Medicare { get; set; }
        public string PCP { get; set; }
        public string Status { get; set; }
        public string TennCareEligibility { get; set; }
        public DateTime OutputFileDate { get; set; }
        public string OutputFileName { get; set; }
    }
}
