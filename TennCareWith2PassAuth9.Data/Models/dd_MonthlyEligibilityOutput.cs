using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class dd_MonthlyEligibilityOutput
    {
        public dd_MonthlyEligibilityOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            dd_MonthlyEligibilityOutputColumnsList =
                new List<dd_MonthlyEligibilityOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<dd_MonthlyEligibilityOutputColumns>
            dd_MonthlyEligibilityOutputColumnsList
            { get; set; }
    }
}
