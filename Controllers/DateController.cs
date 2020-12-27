using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lab1_1.Models;
using System.IO;

namespace lab1_1.Controllers
{
    public class DateController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            string path = @"event.txt";
            List<string> list = new List<string>();
             using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            TimeSpan difference = Convert.ToDateTime(list[0]) - DateTime.Now;
            float dayCount = 365;
            float year = difference.Days / dayCount;
            string result = $"Подія: {list[1]} \nРоки: {year} \nДні: {difference.Days} Години: {difference.Hours} Хвилини: {difference.Minutes} Секунди: {difference.Seconds} \nСьогодні: {DateTime.Now} \nДата події: {Convert.ToDateTime(list[0])}";
            return Content(result);
        }

    }
}
