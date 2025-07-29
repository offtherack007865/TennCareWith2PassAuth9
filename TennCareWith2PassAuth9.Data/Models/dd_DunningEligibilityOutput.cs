using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class dd_DunningEligibilityOutput
    {
        public dd_DunningEligibilityOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            dd_DunningEligibilityOutputColumnsList =
                new List<dd_DunningEligibilityOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<dd_DunningEligibilityOutputColumns>
            dd_DunningEligibilityOutputColumnsList
            { get; set; }
    }
}
