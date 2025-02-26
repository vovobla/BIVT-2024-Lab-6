using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BIVT_2024_Lab_6.Purple_4;
using static BIVT_2024_Lab_6.Purple_5;

namespace BIVT_2024_Lab_6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Test_1();
            Console.WriteLine();
            Test_2();
            Console.WriteLine();
            Test_3();
            Console.WriteLine();
            Test_4();
            Console.WriteLine();
            Test_5();
        }

        static void Test_1()
        {
            var names = "Дарья,Тихонова,Александр,Козлов,Никита,Павлов,Юрий,Луговой,Юрий,Степанов,Мария,Луговая,Виктор,Жарков,Марина,Иванова,Марина,Полевая,Максим,Тихонов".Split(',');
            var jumps = new int[] { 3, 4, 1, 2, 1, 3, 1, 5, 3, 4, 3, 3, 3, 3, 2, 4, 1, 5, 6, 1, 2, 6, 4, 3, 2, 2, 1, 1, 3, 5, 4, 4, 5, 1, 4, 1, 6, 5, 2, 1, 4, 1, 6, 2, 4, 1, 2, 6, 5, 6, 5, 2, 2, 4, 3, 4, 1, 1, 3, 5, 5, 5, 2, 4, 1, 1, 2, 2, 2, 5, 5, 2, 3, 3, 2, 2, 3, 3, 1, 3, 4, 2, 4, 5, 3, 3, 5, 2, 1, 2, 4, 5, 5, 4, 2, 3, 2, 2, 6, 3, 1, 2, 2, 6, 6, 5, 1, 6, 6, 3, 2, 5, 4, 3, 5, 4, 5, 1, 1, 5, 3, 4, 2, 1, 1, 2, 2, 2, 4, 2, 6, 3, 4, 3, 2, 1, 3, 5, 1, 5, 6, 5, 5, 4, 2, 6, 4, 5, 4, 3, 2, 4, 6, 1, 1, 1, 3, 4, 4, 1, 6, 3, 1, 5, 1, 4, 3, 1, 4, 6, 1, 4, 5, 3, 4, 1, 2, 3, 1, 5, 4, 3, 3, 6, 2, 3, 1, 6, 3, 3, 3, 6, 6, 3, 6, 6, 6, 5, 3, 2, 6, 5, 3, 5, 4, 4, 2, 1, 2, 4, 4, 2, 2, 5, 1, 3, 1, 6, 5, 6, 1, 6, 3, 3, 3, 6, 3, 5, 4, 2, 3, 4, 6, 1, 4, 2, 1, 5, 1, 1, 3, 1, 3, 2, 6, 1, 4, 4, 6, 6, 2, 5, 3, 3, 1, 4, 5, 6, 2, 6, 4, 5, 4, 2, 3, 1, 3, 3, 4, 2, 2, 3, 6, 5, 1, 5, 5, 1, 3, 4 };
            var rate = new double[] { 2.58, 2.90, 3.04, 3.43, 2.95, 2.63, 3.16, 2.89, 2.56, 3.40, 2.91, 2.69, 2.86, 2.90, 3.19, 3.14, 2.81, 2.64, 2.76, 3.20, 2.74, 3.30, 2.94, 3.27, 2.57, 2.79, 2.71, 3.46, 3.09, 2.67, 2.90, 3.50, 2.65, 3.47, 3.11, 3.39, 3.14, 3.46, 2.96, 2.76 };
            var part = new Purple_1.Participant[names.Length / 2];
            int jumpIndex = 0;
            int rateIndex = 0;

            for (int i = 0; i < part.Length; i++)
            {
                part[i] = new Purple_1.Participant(names[i * 2], names[(i * 2) + 1]);
                double[] participantCoefs = new double[4];

                for (int j = 0; j < 4; j++)
                {
                    participantCoefs[j] = rate[rateIndex++]; 
                }

                part[i].SetCriterias(participantCoefs); 

                for (int jump = 0; jump < 4; jump++)
                {
                    int[] marks = new int[7];
                    for (int judge = 0; judge < 7; judge++)
                    {
                        marks[judge] = jumps[jumpIndex++];
                    }
                    part[i].Jump(marks);
                }
            }

            Purple_1.Participant.Sort(part);

            Console.WriteLine("Итоговая таблица участников:");
            Console.WriteLine("-------------------------------------------------");
            foreach (var participant in part)
            {
                participant.Print();
            }
            Console.WriteLine("-------------------------------------------------");
        }

        static void Test_2()
        {
            var names = "Оксана,Сидорова,Полина,Полевая,Дмитрий,Полевой,Евгения,Распутина,Савелий,Луговой,Евгения,Павлова,Егор,Свиридов,Степан,Свиридов,Анастасия,Козлова,Светлана,Свиридова".Split(',');
            var distance = new int[] { 135, 191, 147, 115, 112, 151, 186, 166, 112, 197 };
            var marks = new int[] { 15, 1, 3, 9, 15, 19, 14, 9, 11, 4, 20, 9, 1, 13, 6, 5, 20, 17, 9, 16, 19, 8, 1, 6, 17, 16, 12, 5, 20, 4, 5, 20, 3, 19, 18, 16, 12, 5, 4, 15, 7, 4, 19, 11, 12, 14, 3, 6, 17, 1 };
            var part = new Purple_2.Participant[names.Length / 2];
            int markIndex = 0;

            for (int i = 0; i < part.Length; i++)
            {
                part[i] = new Purple_2.Participant(names[i * 2], names[(i * 2) + 1]);

                int jumpDistance = distance[i];
                int[] judgeMarks = new int[5];

                for (int j = 0; j < 5; j++)
                {
                    judgeMarks[j] = marks[markIndex++];
                }

                part[i].Jump(jumpDistance, judgeMarks);
            }

            Purple_2.Participant.Sort(part);

            Console.WriteLine("Итоговая таблица участников:");
            Console.WriteLine("-------------------------------------------------");
            foreach (var participant in part)
            {
                participant.Print();
            }
            Console.WriteLine("-------------------------------------------------");
        }
        
        static void Test_3()
        {
            var names = "Виктор, Полевой, Алиса, Козлова, Ярослав, Зайцев, Савелий, Кристиан, Алиса, Козлова, Алиса, Луговая, Александр, Петров, Мария, Смирнова, Полина, Сидорова, Татьяна, Сидорова".Split(',');
            var marks = new double[] { 5.93, 5.44, 1.2, 0.28, 1.57, 1.86, 5.89, 1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79, 2.93, 3.1, 5.46, 4.88, 3.99, 4.79, 5.56, 4.2, 4.69, 3.9, 1.67, 1.13, 5.66, 5.4, 3.27, 2.43, 0.9, 5.61, 3.12, 3.76, 3.73, 0.75, 1.13, 5.43, 2.07, 2.68, 0.83, 3.68, 3.78, 3.42, 3.84, 2.19, 1.2, 2.51, 3.51, 1.35, 3.4, 1.85, 2.02, 2.78, 3.23, 3.03, 0.55, 5.93, 0.75, 5.15, 4.35, 1.51, 2.77, 3.86, 0.19, 0.46, 5.14, 5.37, 0.94, 0.84 };
            var part = new Purple_3.Participant[names.Length / 2];
            int markIndex = 0;

            for (int i = 0; i < part.Length; i++)
            {
                part[i] = new Purple_3.Participant(names[i * 2], names[(i * 2) + 1]);

                for (int j = 0; j < 7; j++)
                {
                    part[i].Evaluate(marks[markIndex++]);
                }
            }

            Purple_3.Participant.SetPlaces(part);
            Purple_3.Participant.Sort(part);

            Console.WriteLine("Итоговая таблица участников:");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("|   Name   |  Surname   | Score | TopPlace | TotalMark |");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var participant in part)
            {
                participant.Print();
            }
            Console.WriteLine("--------------------------------------------------------");
        }
        static void Test_4()
        {
            var names1 = "Полина,Луговая,Савелий,Козлов,Екатерина,Жаркова,Дмитрий,Иванов,Дмитрий,Полевой,Савелий,Петров,Евгения,Распутина,Екатерина,Луговая,Мария,Иванова,Степан,Павлов,Ольга,Павлова,Ольга,Полевая,Дарья,Павлова,Дарья,Свиридова,Евгения,Свиридова".Split(',');
            var names2 = "Анастасия,Жаркова,Александр,Павлов,Степан,Свиридов,Игорь,Сидоров,Евгения,Сидорова,Мария,Сидорова,Лев,Петров,Савелий,Козлов,Егор,Свиридов,Оксана,Жаркова,Светлана,Петрова,Полина,Петрова,Екатерина,Павлова,Юлия,Полевая,Евгения,Павлова".Split(',');
            var times1 = new double[] { 422.64, 142.05, 185.23, 294.32, 79.26, 230.63, 35.16, 376.12, 279.20, 292.38, 467.60, 473.82, 290.14, 368.60, 212.67 };
            var times2 = new double[] { 112.49, 472.11, 213.92, 102.13, 263.21, 350.75, 248.68, 325.28, 300.00, 252.16, 402.20, 397.33, 384.94, 8.09, 480.52 };
            var sport1 = new Sportsman[names1.Length / 2];
            var sport2 = new Sportsman[names2.Length / 2];

            for (int i = 0; i < sport1.Length; i++)
            {
                sport1[i] = new Sportsman(names1[i * 2], names1[i * 2 + 1]);
                sport1[i].Run(times1[i]);
            }

            for (int i = 0; i < sport2.Length; i++)
            {
                sport2[i] = new Sportsman(names2[i * 2], names2[i * 2 + 1]);
                sport2[i].Run(times2[i]);
            }
            
            var g1 = new Group("Группа 1");
            var g2 = new Group("Группа 2");

            g1.Add(sport1);
            g2.Add(sport2);
            g1.Sort();
            g2.Sort();

            var mergedGroup = Group.Merge(g1, g2);

            Console.WriteLine("Результаты");
            mergedGroup.Print();
        }
        static void Test_5()
        {
            var animals = "Макака,Тануки,Тануки,Кошка,Сима_энага,Макака,Панда,Сима_энага,Серау,Панда,Сима_энага,Кошка,Панда,Кошка,Панда,Серау,Панда,Сима_энага,Панда,Кошка".Split(',');
            var characterTraits = ",Проницательность,Скромность,Внимательность,Дружелюбность,Внимательность,Проницательность,Проницательность,Внимательность,,Дружелюбность,Внимательность,,Уважительность,Целеустремленность,Дружелюбность,,Скромность,Проницательность,Внимательность".Split(',');
            var concepts = "Манга,Манга,Кимоно,Суши,Кимоно,Самурай,Манга,Суши,Сакура,Кимоно,Сакура,Кимоно,Сакура,Фудзияма,Аниме,,Манга,Фудзияма,Самурай,Сакура".Split(',');

            var research = new Purple_5.Research("Test");

            for (int i = 0; i < animals.Length; i++)
            {
                research.Add(new string[] { animals[i], characterTraits[i], concepts[i] });
            }

            Console.WriteLine("Топ-5 ответов по каждому вопросу:");

            var topAnimals = research.GetTopResponses(1);
            Console.WriteLine("Animal:");
            foreach (var item in topAnimals)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var topTraits = research.GetTopResponses(2);
            Console.WriteLine("CharacterTrait:");
            foreach (var item in topTraits)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            var topConcepts = research.GetTopResponses(3);
            Console.WriteLine("Concept:");
            foreach (var item in topConcepts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
