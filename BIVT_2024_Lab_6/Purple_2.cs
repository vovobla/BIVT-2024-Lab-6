﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIVT_2024_Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;

                    int[] marks = new int[_marks.Length];
                    Array.Copy(_marks, marks, _marks.Length);
                    return marks;
                }
            }

            public int Result
            {
                get
                {
                    if (_marks == null || _distance == 0) return 0;

                    int result = 0;
                    int minMark = int.MaxValue;
                    int maxMark = int.MinValue;

                    for (int judge = 0; judge < _marks.Length; judge++)
                    {
                        int currentMark = Marks[judge];

                        if (currentMark > maxMark)
                            maxMark = currentMark;

                        if (currentMark < minMark)
                            minMark = currentMark;

                        result += currentMark;
                    }

                    result -= minMark + maxMark;
                    result += 60;
                    result += (_distance - 120) * 2;

                    return result;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];

                for (int i = 0; i < 5; i++) 
                    _marks[i] = 0;
            }

            public void Jump(int distance, int[] marks)
            {
                if (marks == null || marks.Length != _marks.Length) return;

                _distance = distance;
                Array.Copy(marks, _marks, marks.Length);
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                int index = 0;

                while (index < array.Length)
                {
                    if (index == 0 || array[index].Result <= array[index - 1].Result)
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
                Console.WriteLine($"{Name} {Surname} - Итоговый балл: {Result:F2}");
            }
        }
    }
}

