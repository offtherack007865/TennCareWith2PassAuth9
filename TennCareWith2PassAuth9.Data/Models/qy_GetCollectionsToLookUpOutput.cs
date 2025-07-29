using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class qy_GetCollectionsToLookUpOutput
    {
        public qy_GetCollectionsToLookUpOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetCollectionsToLookUpOutputColumnsList =
                new List<qy_GetCollectionsToLookUpOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetCollectionsToLookUpOutputColumns>
            qy_GetCollectionsToLookUpOutputColumnsList
               { get; set; }

    }
}
