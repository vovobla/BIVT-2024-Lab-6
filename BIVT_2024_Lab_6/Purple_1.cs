using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BIVT_2024_Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _currentJump;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return default(double[]);

                    double[] coefs = new double[_coefs.Length];
                    Array.Copy(_coefs, coefs, _coefs.Length);
                    return coefs;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;

                    int[,] marks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, marks, _marks.Length);
                    return marks;
                }
            }

            public double TotalScore
            {
                get
                {
                    if (_marks == null || _coefs == null) return 0;

                    double totalScore = 0;

                    for (int jump = 0; jump < 4; jump++)
                    {
                        int minMark = int.MaxValue;
                        int maxMark = int.MinValue;
                        int score = 0;

                        for (int judge = 0; judge < 7; judge++)
                        {
                            int currentMark = _marks[jump, judge];

                            if (currentMark > maxMark)
                                maxMark = currentMark;

                            if (currentMark < minMark)
                                minMark = currentMark;

                            score += currentMark;
                        }

                        score -= minMark + maxMark;
                        totalScore += score * _coefs[jump];
                    }

                    return totalScore;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                _marks = new int[4, 7];
                _currentJump = 0;

                for (int i = 0; i < 4; i++)
                    _coefs[i] = 2.5;

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 7; j++)
                        _marks[i, j] = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length != _coefs.Length) return;

                for (int i = 0; i < coefs.Length; i++)
                    _coefs[i] = coefs[i];
            }

            public void Jump(int[] marks)
            {
                if (marks == null || _currentJump >= 4 || marks.Length != 7) return;

                for (int i = 0; i < marks.Length; i++)
                    _marks[_currentJump, i] = marks[i];

                _currentJump++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                int index = 0;

                while (index < array.Length)
                {
                    if (index == 0 || array[index].TotalScore <= array[index - 1].TotalScore)
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
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - Итоговый балл: {TotalScore:F2}");
            }
        }
        
    }
}