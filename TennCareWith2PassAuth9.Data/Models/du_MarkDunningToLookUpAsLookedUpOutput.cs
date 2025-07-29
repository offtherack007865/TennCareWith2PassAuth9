using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class du_MarkDunningToLookUpAsLookedUpOutput
    {
        public du_MarkDunningToLookUpAsLookedUpOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            du_MarkDunningToLookUpAsLookedUpOutputColumnsList =
                new List<du_MarkDunningToLookUpAsLookedUpOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<du_MarkDunningToLookUpAsLookedUpOutputColumns>
            du_MarkDunningToLookUpAsLookedUpOutputColumnsList
                { get; set; }
    }
}
