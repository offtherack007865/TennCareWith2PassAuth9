using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
   public class qy_GetMonthlyToLookUpOutput
    {
        public qy_GetMonthlyToLookUpOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetMonthlyToLookUpOutputColumnsList =
                new List<qy_GetMonthlyToLookUpOutputColumns>();
        }
        public bool IsOk {  get; set; } 
        public string ErrorMessage { get; set; }
        public List<qy_GetMonthlyToLookUpOutputColumns>
            qy_GetMonthlyToLookUpOutputColumnsList
                { get; set; }
    }
}
