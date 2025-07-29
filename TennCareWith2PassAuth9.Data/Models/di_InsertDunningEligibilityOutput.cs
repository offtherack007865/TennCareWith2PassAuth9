using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class di_InsertDunningEligibilityOutput
    {
        public di_InsertDunningEligibilityOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_InsertDunningEligibilityOutputColumnsList =
                new List<di_InsertDunningEligibilityOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<di_InsertDunningEligibilityOutputColumns>
            di_InsertDunningEligibilityOutputColumnsList
            { get; set; }
    }
}
