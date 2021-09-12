using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebQz.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string TextQ { get; set; }
        public string RightAnswer { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        
    }
}
