﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.Data.Models
{
    public class MainOpsOutput
    {
        public MainOpsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            MailBodyLineList = new List<string>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> MailBodyLineList { get; set; }
    }
}
