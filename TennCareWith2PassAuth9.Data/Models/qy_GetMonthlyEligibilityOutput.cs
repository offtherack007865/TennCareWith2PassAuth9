using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class qy_GetMonthlyEligibilityOutput
    {
        public qy_GetMonthlyEligibilityOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetMonthlyEligibilityOutputColumnsList =
                new List<qy_GetMonthlyEligibilityOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetMonthlyEligibilityOutputColumns>
            qy_GetMonthlyEligibilityOutputColumnsList
        { get; set; }
    }
}
