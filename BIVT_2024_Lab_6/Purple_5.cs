using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            private string _animal;
            private string _characterTrait;
            private string _concept;

            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;

            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null || questionNumber < 1 || questionNumber > 3) return 0;

                int answered = 0;

                for (int i = 0; i < responses.Length; i++)
                {
                    switch (questionNumber)
                    {
                        case 1:
                            if (responses[i].Animal != null && responses[i].Animal != "" && responses[i].Animal == _animal) answered++;
                            break;
                        case 2:
                            if (responses[i].CharacterTrait != null && responses[i].CharacterTrait != "" && responses[i].CharacterTrait == _characterTrait) answered++;
                            break;
                        case 3:
                            if (responses[i].Concept != null && responses[i].Concept != "" && responses[i].Concept == _concept) answered++;
                            break;
                        default:
                            return 0;
                    }
                }

                return answered;
            }

            public void Print()
            {
                Console.WriteLine($"{Animal} {CharacterTrait} {Concept}");
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;
            public Response[] Responses => _responses;

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null || _responses == null || answers.Length < 3) return;

                Response[] newResponses = new Response[_responses.Length + 1];
                Array.Copy(_responses, newResponses, _responses.Length);
                newResponses[newResponses.Length - 1] = new Response(answers[0], answers[1], answers[2]);

                _responses = newResponses;
            }

            public string[] GetTopResponses(int question)
            {
                if (_responses == null || _responses.Length == 0 || question < 1 || question > 3) return null;

                string[] responses = new string[0];
                int[] counts = new int[0];
                int[] firstOccurrenceIndices = new int[0]; 

                foreach (var response in _responses)
                {
                    string answer = null;

                    switch (question)
                    {
                        case 1:
                            answer = response.Animal;
                            break;
                        case 2:
                            answer = response.CharacterTrait;
                            break;
                        case 3:
                            answer = response.Concept;
                            break;
                    }

                    if (!string.IsNullOrEmpty(answer))
                    {
                        int index = Array.IndexOf(responses, answer);

                        if (index == -1)
                        {
                            Array.Resize(ref responses, responses.Length + 1);
                            Array.Resize(ref counts, counts.Length + 1);
                            Array.Resize(ref firstOccurrenceIndices, firstOccurrenceIndices.Length + 1);

                            responses[responses.Length - 1] = answer;
                            counts[counts.Length - 1] = 1;

                            firstOccurrenceIndices[firstOccurrenceIndices.Length - 1] = FindFirstOccurrenceIndex(answer, question);
                        }
                        else
                        {
                            counts[index]++;
                        }
                    }
                }

                for (int i = 0; i < counts.Length; i++)
                {
                    for (int j = i + 1; j < counts.Length; j++)
                    {
                        if (counts[i] < counts[j])
                        {
                            int tempCount = counts[i];
                            counts[i] = counts[j];
                            counts[j] = tempCount;
                            
                            string tempResponse = responses[i];
                            responses[i] = responses[j];
                            responses[j] = tempResponse;
                            
                            int tempIndex = firstOccurrenceIndices[i];
                            firstOccurrenceIndices[i] = firstOccurrenceIndices[j];
                            firstOccurrenceIndices[j] = tempIndex;
                        }
                    }
                }

                for (int i = 0; i < counts.Length; i++)
                {
                    for (int j = i + 1; j < counts.Length; j++)
                    {
                        if (counts[i] == counts[j] && firstOccurrenceIndices[i] > firstOccurrenceIndices[j])
                        {
                            string tempResponse = responses[i];
                            responses[i] = responses[j];
                            responses[j] = tempResponse;

                            int tempIndex = firstOccurrenceIndices[i];
                            firstOccurrenceIndices[i] = firstOccurrenceIndices[j];
                            firstOccurrenceIndices[j] = tempIndex;
                        }
                    }
                }

                int resultSize = Math.Min(5, responses.Length);
                string[] topResponses = new string[resultSize];
                Array.Copy(responses, topResponses, resultSize);

                return topResponses;
            }

            private int FindFirstOccurrenceIndex(string answer, int question)
            {
                for (int i = 0; i < _responses.Length; i++)
                {
                    switch (question)
                    {
                        case 1:
                            if (_responses[i].Animal == answer)
                                return i;
                            break;
                        case 2:
                            if (_responses[i].CharacterTrait == answer)
                                return i;
                            break;
                        case 3:
                            if (_responses[i].Concept == answer)
                                return i;
                            break;
                    }
                }
                return -1;
            }

            public void Print()
            {
                Console.WriteLine(_name);
                foreach (var response in _responses)
                {
                    response.Print();
                }
            }
        }
    }
}

