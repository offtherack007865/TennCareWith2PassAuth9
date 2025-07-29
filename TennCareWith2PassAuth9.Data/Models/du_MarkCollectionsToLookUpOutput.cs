using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class du_MarkCollectionsToLookUpAsLookedUpOutput
    {
        public du_MarkCollectionsToLookUpAsLookedUpOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            du_MarkCollectionsToLookUpAsLookedUpOutputColumnsList =
                new List<du_MarkCollectionsToLookUpAsLookedUpOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<du_MarkCollectionsToLookUpAsLookedUpOutputColumns>
            du_MarkCollectionsToLookUpAsLookedUpOutputColumnsList
                { get; set; }
    }
}
