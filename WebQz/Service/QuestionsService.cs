using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQz.Models;
using WebQz.Repository;

namespace WebQz.Service
{
    public class QuestionsService : IQuestionsService
    {
        private IEnumerable<Questions> _collection;
        private IQuestionsRepository _questionsRepository;
        public static List<Questions> _questions;

        public static List<string> _randomTitle = new List<string>() { 
            "Answer1", 
            "Answer2", 
            "Answer3", 
            "Answer4" };

        public static List<string> _questionsValue = new List<string>();
        public List<Questions> GetQuestions() => _questions;

        public List<string> GetRandomTitle() => _randomTitle;

        public void SetQuestionValue(List<string> collection) => _questionsValue = collection;

        public void SetRandomTitle(List<string> collection) => _randomTitle = collection;


        public QuestionsService(IQuestionsRepository questionsRepo)
        {
            _questionsRepository = questionsRepo;
        }

        public IEnumerable<Questions> Shuffle()
        {
            _collection = _questionsRepository.GetQuestions();
            return _collection.OrderBy(i => new Random().Next()).ToList();
        }

        public void StartStopGame(Game game, string title, string start)
        {
            try
            {
                if (game._startGame == "true" && title == null)
                {
                    _questions = Shuffle().ToList();
                    game._startGame = "false";
                }
                else
                {
                    game._startGame = "true";
                    game._rightAnswer = _questions.ElementAt(game._minStep).RightAnswer;
                }

            }
            catch (Exception){ }
                

        }

        public void ShowInfo(string value, Game game)
        {
            game.question = value;
            game._startGame = "false";
            game._minStep = 0;
            _questions = Shuffle().ToList();

        }

        public bool GameProcess(Game game, string title, int maxSteps)
        {
            double questionCost = (1000000 / (game.maxSteps + 1));
            bool flag = false;

            if (_questionsValue.ElementAt(Convert.ToInt32(_randomTitle.IndexOf(title))) == _questions.ElementAt(game._minStep).RightAnswer)
            {                
                if (game._minStep == game.maxSteps)
                {
                    ShowInfo("Поздравляем с победой! Вы миллионер!", game);
                    game._score = game._score + questionCost;
                    game._startGame = "false";
                    flag = true;
                }

                if (flag != true)
                {

                    game._score = game._score + questionCost;
                    game._minStep++;
                    return  true;
                }
            }
            else if (_questionsValue.ElementAt(Convert.ToInt32(_randomTitle.IndexOf(title))) != _questions.ElementAt(game._minStep).RightAnswer)
            {
                ShowInfo("К сожалению, Вы проиграли!", game);
                game._minStep = 0;
            }
            return false;
        }

        
    }
}
