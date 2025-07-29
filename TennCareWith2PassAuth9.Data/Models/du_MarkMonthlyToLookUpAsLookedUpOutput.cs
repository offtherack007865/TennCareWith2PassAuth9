using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class du_MarkMonthlyToLookUpAsLookedUpOutput
    {
        public du_MarkMonthlyToLookUpAsLookedUpOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            du_MarkMonthlyToLookUpAsLookedUpOutputColumnsList =
                new List<du_MarkMonthlyToLookUpAsLookedUpOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<du_MarkMonthlyToLookUpAsLookedUpOutputColumns>
            du_MarkMonthlyToLookUpAsLookedUpOutputColumnsList
                { get; set; }
    }
}
