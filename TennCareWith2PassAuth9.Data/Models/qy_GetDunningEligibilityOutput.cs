using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class qy_GetDunningEligibilityOutput
    {
        public qy_GetDunningEligibilityOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDunningEligibilityOutputColumnsList =
                new List<qy_GetDunningEligibilityOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDunningEligibilityOutputColumns>
            qy_GetDunningEligibilityOutputColumnsList
                { get; set; }
    }
}
