using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class dd_DunningComparisonOutput
    {
        public dd_DunningComparisonOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            dd_DunningComparisonOutputColumnsList =
                new List<dd_DunningComparisonOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<dd_DunningComparisonOutputColumns>
            dd_DunningComparisonOutputColumnsList
                { get; set; }
    }
}
