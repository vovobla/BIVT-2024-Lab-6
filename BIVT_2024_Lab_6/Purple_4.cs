using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIVT_2024_Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;
            private bool _timeSet;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
                _timeSet = false;
            }

            public void Run(double time)
            {
                if (_timeSet) return;
                
                _time = time;
                _timeSet = true;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - Итоговое время: {Time}");
            }
        }

        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;

                    var sportsmen = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen, sportsmen, _sportsmen.Length);
                    return sportsmen;
                }
            }

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group group)
            {
                _name = group.Name;

                if(group.Sportsmen != null)
                {
                    _sportsmen = new Sportsman[0];
                    return;
                }

                _sportsmen = new Sportsman[group.Sportsmen.Length];
                Array.Copy(group.Sportsmen, _sportsmen, group.Sportsmen.Length);
            }

            public void Add(Sportsman newSportsman)
            {
                if (_sportsmen == null) return;

                var sportsmen = new Sportsman[_sportsmen.Length + 1];
                Array.Copy(_sportsmen, sportsmen, _sportsmen.Length);
                sportsmen[sportsmen.Length - 1] = newSportsman;

                _sportsmen = sportsmen;
            }

            public void Add(Sportsman[] newSportsmen)
            {
                if (_sportsmen == null || newSportsmen == null) return;

                var sportsmen = new Sportsman[_sportsmen.Length + newSportsmen.Length];
                Array.Copy(_sportsmen, sportsmen, _sportsmen.Length);
                Array.Copy(newSportsmen, 0, sportsmen, _sportsmen.Length, newSportsmen.Length);

                _sportsmen = sportsmen;
            }

            public void Add(Group otherGroup)
            {
                if (_sportsmen == null || otherGroup.Sportsmen == null) return;

                Add(otherGroup.Sportsmen);
            }

            public void Sort()
            {
                if (_sportsmen == null || _sportsmen.Length == 0) return;

                int index = 0;

                while (index < _sportsmen.Length)
                {
                    if (index == 0 || _sportsmen[index - 1].Time <= _sportsmen[index].Time)
                    {
                        index++;
                    }
                    else
                    {
                        Sportsman temp = _sportsmen[index];
                        _sportsmen[index] = _sportsmen[index - 1];
                        _sportsmen[index - 1] = temp;
                        index--;
                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                if (group1.Sportsmen == null || group2.Sportsmen == null) return default(Group);
                
                Group finalists = new Group("Финалисты");

                group1.Sort();
                group2.Sort();
                int i = 0, j = 0;

                while (i < group1.Sportsmen.Length && j < group2.Sportsmen.Length)
                {
                    if (group1.Sportsmen[i].Time <= group2.Sportsmen[j].Time)
                        finalists.Add(group1.Sportsmen[i++]); 
                    else
                        finalists.Add(group2.Sportsmen[j++]); 
                }

                while (i < group1.Sportsmen.Length)
                    finalists.Add(group1.Sportsmen[i++]);

                while (j < group2.Sportsmen.Length)
                    finalists.Add(group2.Sportsmen[j++]);

                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {Name}");

                foreach (var sportsman in _sportsmen)
                {
                    if (sportsman.Time > 0)
                    {
                        sportsman.Print();
                    }
                }
            }
        }
    }
}
