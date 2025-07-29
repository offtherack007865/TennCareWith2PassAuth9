using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class GetCollectionsExcelCellStringValueOutput
    {
        public GetCollectionsExcelCellStringValueOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            OutputStringValue = string.Empty;
        }
        public bool IsOk { get;set; }
        public string ErrorMessage { get;set; }
        public string OutputStringValue { get; set; }
    }
}
