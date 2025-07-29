using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class FirefoxEligInfoForPatient
    {
        public FirefoxEligInfoForPatient()
        {
            ImportFileName = string.Empty;
            PatientID = string.Empty;
            DOB = new DateTime(1900, 1, 1);
            SSN = string.Empty;
            DOS = new DateTime(1900, 1, 1);
            DateImported = new DateTime(1900, 1, 1);
            MCO = string.Empty;
            Medicare = string.Empty;
            PCP = string.Empty;
            Status = string.Empty;
            TennCareEligibility = string.Empty;
            OutputFileDate = new DateTime(1900, 1, 1);
            OutputFileName = string.Empty;
            PatientName = string.Empty;
        }
        public string ImportFileName { get; set; }
        public string PatientID { get; set; }
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
        public string PatientName { get; set; }

    }
}
