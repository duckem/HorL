using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HorL
{
    class Program
    {
        static int points = 0;
        static bool answer;
        static bool guess;
        static string userInput;

        static void Main(string[] args)
        {
            EnterName();
        }

        static void EnterName()
        {
            Console.WriteLine("Please type in your name");

            try
            {
                string enteredName = Console.ReadLine();
                if (enteredName.Length > 0)
                {
                    Console.WriteLine(UserName(enteredName));
                    DrawCards();
                }
                else
                {
                    Console.WriteLine("There was an error. Please try again");
                    EnterName();
                }
            }

            catch
            { }
        }

        static string UserName (string name)
        {
            return $"Hi {name}! Welcome to HorL. Press 's' anytime to show your score.";
        }

        static void SetPostion()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void DrawCards()
        {
            Debug.AutoFlush = true;
            SetPostion();
            try
            {
                int firstCard;
                int secondCard;
                Random r = new Random();

                firstCard = r.Next(1, 11);
                secondCard = r.Next(1, 11);

                Debug.WriteLine(firstCard + "    " + secondCard);

                if (secondCard != firstCard)
                {
                    Console.WriteLine("Is the second card higher(h) or lower(l) than " + firstCard + "?");
                    SetWin(firstCard, secondCard);

                    userInput = Console.ReadLine();

                    if (userInput.Length < 1 || userInput.Length > 1)
                    {
                        Console.WriteLine("Please try again");
                        DrawCards();
                    }
                    else
                    {
                        UserGuess(userInput);
                        switch (guess)
                        {
                            case true:
                                if (answer == true)
                                {
                                    Console.WriteLine("Yay! You win the round!");
                                    points++;
                                    DrawCards();
                                }
                                else
                                {
                                    Console.WriteLine("Whoops. You lose this round");
                                    DrawCards();
                                }
                                break;

                            case false:
                                if (answer == false)
                                {
                                    Console.WriteLine("Yay! You win the round!");
                                    points++;
                                    DrawCards();
                                }
                                else
                                {
                                    Console.WriteLine("Whoops. You lose this round");
                                    DrawCards();
                                }
                                break;
                        }
                    }

                }

                else
                {
                    DrawCards();
                }
            }
            catch
            {
                Console.Write("Whoops. Enter 'h' for higher or 'l' for lower");
                DrawCards();
            }
        }

        static void SetWin(int first, int second)
        {
            if (second > first)
            {
                answer = true;
            }

            else
            {
                answer = false;
            }

        }

        static void UserGuess(string input)
        {
            try
            {
                if (input.ToLower() == "h")
                {
                    guess = true;
                }

                else if(input.ToLower() == "l")
                {
                    guess = false;
                }

                else if(input.ToLower() == "s")
                {
                    ShowScore();
                    DrawCards();
                }

                else
                {
                    Console.WriteLine("Whoops. Enter 'h' for higher or 'l' for lower");
                    DrawCards();
                }
            }
            catch
            {
                Console.WriteLine("There was an error. Please try again");
            }
        }

        static void ShowScore()
        {
            if (points == 0 || points > 1)
            {
                Console.WriteLine(points + " points");
            }

            else
            {
                Console.WriteLine(points + " point");
            }
        }
    }
}

