using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaptiveIQTest.SharedObjs;

namespace CaptiveIQTest.ViewModels
{
    public class UserViewModel
    {
        public CIQUser CIQUser { get; set; } = new CIQUser();
        
        public string FormulaBarContent { get; set; }
    }
}
