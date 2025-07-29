using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class FirefoxPatientInfoToLookUp
    {
        public string FileName { get; set; }
        public int PatientID { get; set; }
        public DateTime DOB { get; set; }
        public string SSN { get; set; }
        public DateTime DOS { get; set; }
        public DateTime DateImported { get; set; }
        public string PatientName { get; set; }
    }
}
