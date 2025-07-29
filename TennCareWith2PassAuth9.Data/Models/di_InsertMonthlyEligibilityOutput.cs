using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class di_InsertMonthlyEligibilityOutput
    {
        public di_InsertMonthlyEligibilityOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_InsertMonthlyEligibilityOutputColumnsList =
                new List<di_InsertMonthlyEligibilityOutputColumns>(); 
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_InsertMonthlyEligibilityOutputColumns>
            di_InsertMonthlyEligibilityOutputColumnsList { get; set; }
    }
}
