﻿using System;
using System.Data.Entity;
using Task1ASP.Models;

namespace Task1ASP.EF
{
	public class BlogContext : DbContext
	{
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Article> Articles { get; set; }
		public DbSet<Questionnaire> Questionnaires { get; set; }

		//TODO Он нужен или и без него работает?
		public BlogContext()
		{
		}

		public BlogContext(string connection) : base(connection)
		{
		}
		static BlogContext()
		{
			Database.SetInitializer(new DbInitializer());
		}
	}

	internal class DbInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
	{
		protected override void Seed(BlogContext db)
		{
			db.Comments.Add(
				new Comment
				{
					Text = "Some text......",
					Author = "Anna",
					Date = DateTime.Now
				});

			db.Articles.Add(
				new Article
				{
					Date = DateTime.Now,
					Name = "Article1",
					Text = "text text text text textext"
					+ " text text tex ext text text tex"
					+ "ext text text texext text text tex"
					+ "ext text text tex"
					+ "ext text text tex "
				});

			db.SaveChanges();
			base.Seed(db);
		}
	}
}