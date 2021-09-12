using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQz.Models;

namespace WebQz.Service
{
    public interface IQuestionsService
    {
        public IEnumerable<Questions> Shuffle();
        public void StartStopGame(Game game, string originalTitle, string start);
        public void ShowInfo(string someString, Game game);
        public bool GameProcess(Game game, string originalTitle, int maxSteps);
        public List<Questions> GetQuestions();
        public List<string> GetRandomTitle();
        public void SetQuestionValue(List<string> collection);
        public void SetRandomTitle(List<string> collection);
    }
}
