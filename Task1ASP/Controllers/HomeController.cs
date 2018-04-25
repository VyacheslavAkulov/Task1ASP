using System;
using System.Linq;
using System.Web.Mvc;
using Task1ASP.EF;
using Task1ASP.Models;

namespace Task1ASP.Controllers
{
	//TODO  Вынести все по своим контроллерам. Статьи к статьм, Отпросы к опросам, разбить кароч.
	public class HomeController : Controller
	{
		//TODO Строку подключения в конфиг файл.
		private readonly BlogContext _context = new BlogContext("MyBlogDB");

		public ActionResult Articles()
		{
			return View(_context.Articles);
		}

		[HttpGet]
		public ActionResult Guest()
		{
			var comments = _context.Set<Comment>().OrderByDescending(o => o.Date);

			return View(comments);
		}

		//TODO ModelState.IsValid? Проверяй модельку 
		[HttpPost]
		public ActionResult Guest(Comment comment)
		{
			_context.Comments.Add(new Comment()
			{
				Text = comment.Text,
				Author = comment.Author,
				Date = DateTime.Now
			});

			_context.SaveChanges();

			var comments = _context.Set<Comment>().OrderByDescending(o => o.Date);

			return View(comments);
		}

		//TODO ModelState.IsValid? Проверяй модельку 
		public ActionResult Questin(Questionnaire questionnaire, string[] names, string eye)
		{
			if (Request.HttpMethod == "GET")
			{
				return View("Questin");
			}

			questionnaire.Eye = eye;

			questionnaire.Animals = names;

			return View("QuestinPost", questionnaire);
		}
	}
}