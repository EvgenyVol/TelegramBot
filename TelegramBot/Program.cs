using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TelegramBot
{
    class Program
    {
        private static Dictionary<string, string> Questions;
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать! Это бот-помощник. Введите свой вопрос:");
            
            var data = System.IO.File.ReadAllText(@"C:\Users\Uchotka1\Pictures\TelegramBot\TelegramBot\TelegramBot\answers.json");
            Questions = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            
            while (true)
            {
                var result = AnswerQuestions();

                if (!result)
                {
                    return;
                }
            }
        }

        private static bool AnswerQuestions()
        {
            var userQuestion = Console.ReadLine().ToLower();
            
            List<string> Answers = new List<string>();
            
            foreach (var question in Questions)
            {
                if (userQuestion.Contains(question.Key))
                {
                    Answers.Add(question.Value);
                }
            }

            if (userQuestion.Contains("сколько времени"))
            {
                var time = DateTime.Now.ToString("HH:mm:ss");
                Answers.Add($"Точное время: {time}");
            }

            if (userQuestion.Contains("какой сегодня день"))
            {
                var date = DateTime.Today.ToString("dd.MM.yyyy");
                Answers.Add($"Сегодня - {date}");
            }

            if (Answers.Count == 0)
            {
                Answers.Add("Я тебя не понимаю :(");
            }

            Console.WriteLine(String.Join(", ", Answers));

            if (userQuestion.Contains("надоело"))
            {
                Console.WriteLine("Спасибо за общение.");
                return false;
            }

            return true;
        }
    }
}