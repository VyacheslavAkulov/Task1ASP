﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Task1ASP.Models
{
	//TODO Языки, все на разных в атрибутах
	public class Comment
	{
		public int Id { get; set; }

		[DataType(DataType.DateTime)]
		[Display(Name = "Date of adding")]
		public DateTime Date { get; set; }

		//TODO [Display]
		[Required]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Length must be from 3 to 100 characters")]
		public string Author { get; set; }

		[Display(Name = "Текст отзыва")]
		[StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина отзыва должна быть от 3 до 1000 символов")]
		[Required(ErrorMessage = "Введите текст")]
		[DataType(DataType.MultilineText)]
		public string Text { get; set; }
	}
}