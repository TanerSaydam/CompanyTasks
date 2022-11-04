using CreateAQuizMVC.Context;
using CreateAQuizMVC.Dtos;
using CreateAQuizMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;
using System.Text;
using HtmlAgilityPack;

namespace CreateAQuizMVC.Controllers
{
    public class QuizController : Controller
    {
        private readonly CreateAQuizDb _createAQuiz;

        public QuizController(CreateAQuizDb createAQuiz)
        {
            _createAQuiz = createAQuiz;
        }

        public async Task<IActionResult> Index()
        {
            var quizes = await _createAQuiz.Quizzes.ToListAsync();
            return View(quizes);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var quiz = await _createAQuiz.Quizzes.FindAsync(Guid.Parse(id));
            if (quiz != null)
            {
                _createAQuiz.Remove(quiz);
                await _createAQuiz.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateANewQuiz()
        {
            string link = "https://www.wired.com/most-recent/";

            var result = await GetMostRecentsUrls(link);           

            return View(result);
        }

        async Task<List<New>> GetMostRecentsUrls(string url)
        {
            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString(url));
            var root = html.DocumentNode;
            var mostRecents = root.Descendants()
                .Where(n => n.GetAttributeValue("class", "").Equals("SummaryItemHedLink-cgaOJy hYdAev summary-item-tracking__hed-link summary-item__hed-link"))
                .Select(p => p.Attributes.Where(p => p.Name == "href").Select(s => s.Value))
                .Take(5)
                .ToList();


            List<New> icerikListesi = new List<New>();
            foreach (var recetNews in mostRecents)
            {
                New newModel = new()
                {
                    Title = GetNewsTitle(recetNews.First()),
                    Description = GetNewsDescription(recetNews.First())
                };

                var check = await _createAQuiz.News.Where(p => p.Title == newModel.Title).FirstOrDefaultAsync();
                if(check == null)
                    icerikListesi.Add(newModel);

            }

            await _createAQuiz.News.AddRangeAsync(icerikListesi);
            await _createAQuiz.SaveChangesAsync();

            var result = await _createAQuiz.News.OrderByDescending(p=> p.Id).Take(5).ToListAsync();

            return result;
        }

        string GetNewsTitle(string url)
        {
            url = $"https://wired.com{url}";
            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString(url));
            var root = html.DocumentNode;
            var title = root.Descendants("title")
                .Select(s => s.InnerText)
                .First();
            return title;
        }

        string GetNewsDescription(string url)
        {
            url = $"https://wired.com{url}";
            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString(url));
            var root = html.DocumentNode;
            var description = root.Descendants("p")
                .Select(s => s.InnerText)
                .ToList();
            return string.Join(" ", description).Replace("To revist this article, visit My Profile, then View saved stories. To revist this article, visit My Profile, then View saved stories. Eric Ravenscraft Matt Jancer To revist this article, visit My Profile, then View saved stories. To revist this article, visit My Profile, then View saved stories.", "");

        }

        [HttpPost]
        public async Task<IActionResult> CreateANewQuiz(Quiz quiz)
        {
            quiz.Id = Guid.NewGuid();
            quiz.CreatedDate = DateTime.Now;
            await _createAQuiz.Quizzes.AddAsync(quiz);
            await _createAQuiz.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AnswerQuiz(string id)
        {
            var quiz = await _createAQuiz.Quizzes.FindAsync(Guid.Parse(id));
            return View(quiz);
        }

        [HttpGet]
        public async Task<JsonResult> CheckAnswer(string quizId, string answer1, string answer2, string answer3, string answer4)
        {
            Quiz quiz = await _createAQuiz.Quizzes.FindAsync(Guid.Parse(quizId));
            AnswerDto answerDto = new();

            if (quiz.RightAnswer1 != answer1)
                answerDto.Answer1 = false;
            else if(quiz.RightAnswer1 == answer1)
                answerDto.Answer1 = true;

            if (quiz.RightAnswer2 != answer2)
                answerDto.Answer2 = false;
            else if (quiz.RightAnswer2 == answer2)
                answerDto.Answer2 = true;

            if (quiz.RightAnswer3 != answer3)
                answerDto.Answer3 = false;
            else if (quiz.RightAnswer3 == answer3)
                answerDto.Answer3 = true;

            if (quiz.RightAnswer4 != answer4)
                answerDto.Answer4 = false;
            else if (quiz.RightAnswer4 == answer4)
                answerDto.Answer4 = true;
          
            return Json(answerDto);
        }

        [HttpGet]
        public async Task<JsonResult> ReturnDescription(string selectTitle)
        {
            string description = await _createAQuiz.News.Where(p => p.Title == selectTitle).Select(s => s.Description).FirstOrDefaultAsync();

            return Json(description);
        }

    }
}

