using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebQz.Models;

namespace WebQz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Service.IQuestionsService _questionService;

        private static Game game = new();

        public HomeController(ILogger<HomeController> logger, Service.IQuestionsService questionService)
        {
            _logger = logger;
            _questionService = questionService;
        }

        public IActionResult Index(string title, string start, int maxSteps)
        {
            game.question = "Готовы начать игру?";
            _questionService.StartStopGame(game, title, start);
            if (start == "Старт" || title != null)
            {
                if (start == "Старт" || title.Contains("Answer"))
                {
                    try
                    {
                        if (_questionService.GameProcess(game, title, maxSteps) != false)
                            NextQuestion();
                    }
                    catch (Exception) { 
                        game._score = 0;
                        NextQuestion(); 
                        game.maxSteps = maxSteps - 1; 
                    }
                }
            }
            return View(game);
        }

        public void NextQuestion()
        {
            try
            {
                game.question = _questionService.GetQuestions().ElementAt(game._minStep).TextQ;

                _questionService.SetRandomTitle(_questionService.GetRandomTitle().OrderBy(i => new Random().Next()).ToList());

                ViewData[_questionService.GetRandomTitle()[0]] = _questionService.GetQuestions().ElementAt(game._minStep).Answer1;
                ViewData[_questionService.GetRandomTitle()[1]] = _questionService.GetQuestions().ElementAt(game._minStep).Answer2;
                ViewData[_questionService.GetRandomTitle()[2]] = _questionService.GetQuestions().ElementAt(game._minStep).Answer3;
                ViewData[_questionService.GetRandomTitle()[3]] = _questionService.GetQuestions().ElementAt(game._minStep).Answer4;

                List<string> questionsValue = new()
                {
                _questionService.GetQuestions().ElementAt(game._minStep).Answer1, 
                _questionService.GetQuestions().ElementAt(game._minStep).Answer2,
                _questionService.GetQuestions().ElementAt(game._minStep).Answer3,
                _questionService.GetQuestions().ElementAt(game._minStep).Answer4
                };
                _questionService.SetQuestionValue(questionsValue);
                game._rightAnswer = _questionService.GetQuestions().ElementAt(game._minStep).RightAnswer;
            }
            catch (Exception) { }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
