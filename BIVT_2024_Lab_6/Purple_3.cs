using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIVT_2024_Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _places;
            private double[] _marks;
            private int _currentJudge;

            public string Name => _name;
            public string Surname => _surname;
            public int Score
            {
                get
                {
                    if (_places == null) return 0;
                    
                    int score = 0;

                    foreach (int x in _places)
                        score += x;

                    return score;
                }
            }

            public int[] Places
            {
                get
                {
                    if (_places == null) return null;

                    int[] places = new int[_places.Length];
                    Array.Copy(_places, places, _places.Length);
                    return places;
                }
            }
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;

                    double[] marks = new double[_marks.Length];
                    Array.Copy(_marks, marks, _marks.Length);
                    return marks;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _currentJudge = 0;

                for (int i = 0; i < 7; i++)
                {
                    _marks[i] = 0;
                    _places[i] = 0;
                }
            }

            public void Evaluate(double result)
            {
                if (_marks == null || _currentJudge > 7) return;

                _marks[_currentJudge] = result;
                _currentJudge++;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;

                for (int judgeIndex = 0; judgeIndex < 7; judgeIndex++)
                {
                    SortByJudge(participants, judgeIndex);

                    for (int i = 0; i < participants.Length; i++)
                    {
                        participants[i]._places[judgeIndex] = i + 1;
                    }
                }
            }

            private static void SortByJudge(Participant[] array, int judgeIndex)
            {
                if (array == null || array.Length == 0) return;

                int index = 0;

                while (index < array.Length)
                {
                    if (index == 0 || array[index].Marks[judgeIndex] <= array[index - 1].Marks[judgeIndex])
                    {
                        index++;
                    }
                    else
                    {
                        Participant temp = array[index];
                        array[index] = array[index - 1];
                        array[index - 1] = temp;
                        index--;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                int index = 0;

                while (index < array.Length)
                {
                    if (index == 0 || CompareParticipants(array[index], array[index - 1]))
                    {
                        index++;
                    }
                    else
                    {
                        Participant temp = array[index];
                        array[index] = array[index - 1];
                        array[index - 1] = temp;
                        index--;
                    }
                }
            }

            private static bool CompareParticipants(Participant first, Participant second)
            {
                if (first.Score != second.Score)
                {
                    return first.Score > second.Score; 
                }

                int firstMinPlace = first.Places.Min();
                int secondMinPlace = second.Places.Min();

                if (firstMinPlace != secondMinPlace)
                {
                    return firstMinPlace > secondMinPlace; 
                }

                double firstMarksSum = first.Marks.Sum();
                double secondMarksSum = second.Marks.Sum();

                return firstMarksSum > secondMarksSum;
            }

            public void Print()
            {
                Console.WriteLine($"{Name,-10} | {Surname,-10} | {Score,5} | {Places.Min(), 8} | {Marks.Sum(),8:F2}");
            }
        }
    }
}
