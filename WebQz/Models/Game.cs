using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebQz.Models
{
    public class Game
    {
        public double _score = 0;
        public string _startGame = "true";
        public int _minStep = 0;
        public int maxSteps { get; set; }
        public string _rightAnswer;
        public string question { get; set; }
        public double _equal = 0;
        
    }
}
