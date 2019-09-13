using System;
using System.Collections.Generic;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Dictionary<string, string> Questions = new Dictionary<string, string>()
            {
                {"привет", "Здарово!"},
                {"как дела", "Все хорошо!"},
                {"как тебя зовут", "меня зовут бот-помощник Broccoli"},
                {"чем занимаешься", "Отвечаю на дурацкие вопросы"},
                {"кто тебя создал", "Евгений Баланин"}
            };

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