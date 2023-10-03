using _5._5___More_classes;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bet;
            double total;
            double money = 100;
            bool done = false;
            Random coinFlip = new Random();
            int flip;
            double results;
            Die die1 = new Die();
            Die die2 = new Die();
            Console.WriteLine("Hello, care to play a little game?");
            Thread.Sleep(200);
            Console.WriteLine("You'll make a bet, and win money back if you guess correctly.");
            Thread.Sleep(200);
            Console.WriteLine("If you say 'Doubles', and the dice roll the same number, you'll gain double your bet.");
            Thread.Sleep(200);
            Console.WriteLine("If you say 'Not double', amd the die roll different numbers, you'll gain half yuour bet.");
            Thread.Sleep(200);
            Console.WriteLine("If you say 'Even sum', and the sum of the die roll is even you'll win your bet.");
            Thread.Sleep(200);
            Console.WriteLine("If you say 'Odd sum', and the sum of the die is even, you'll also win your bet. Now, let's play");
            Thread.Sleep(200);


            while (!done)
            {
                Console.WriteLine("What option will you pick?");
                Thread.Sleep(200);
                string choice = Convert.ToString(Console.ReadLine().ToUpper());
                while (choice != "DOUBLES" && choice != "NOT DOUBLES" && choice != "NOT" && choice != "EVEN SUM" && choice != "ODD SUM")
                {
                    Console.WriteLine("Please give a valid response.");
                    choice = Console.ReadLine().ToUpper();
                }

                if (choice == "DOUBLES")
                {
                    Console.WriteLine("You are rolling for doubles.");

                }

                else if (choice == "NOT DOUBLE" || choice == "NOT")
                {
                    Console.WriteLine("You are rolling for NOT doubles.");
                }

                else if (choice == "EVEN")
                {
                    Console.WriteLine("You are rolling for an even sum.");
                }

                else if (choice == "ODD")
                {
                    Console.WriteLine("You are rolling for an odd sum.");
                }

                Console.WriteLine($"How much are you betting for this round? You have ${money} left.");
                bet = Convert.ToDouble(Console.ReadLine());
                while (bet < 0)
                {
                    Console.WriteLine("Invalid bet, please bet again");
                    Console.ReadLine();
                }
                if (bet < 0 && bet > money)
                {
                    Console.WriteLine($"You are betting {bet.ToString("C")}. May the odds be in your favour, good luck.");
                }

                else if (bet > money)
                {
                    bet = money;
                    Console.WriteLine($"I'll just assume you're betting all of your money, and are specifically betting {money.ToString("C")}");
                }
                Thread.Sleep(500);
                Console.WriteLine("Rolling...");
                Thread.Sleep(500);

                die1.RollDice();
                die1.DrawDie();
                die2.RollDice();
                die2.DrawDie();


                if (choice == "DOUBLES")
                {
                    total = bet;

                    if (die1.Roll == die2.Roll)
                    {
                        total = bet * 2;
                        money = money + total;
                        Console.WriteLine($"Hey look at that, you won! You earned {total.ToString("C")}.");
                    }

                    else if (die1 != die2)
                    {
                        money = money - total;
                        Console.WriteLine($"Oh no! You lost! You lost {total.ToString("C")}!");
                    }

                }

                else if (choice == "NOT DOUBLES" || choice == "NOT")
                {
                    total = bet;

                    if (die1 != die2)
                    {
                        total = bet / 2;
                        money = money + total;
                        Console.WriteLine($"Hey look at that, you won! You earned {total.ToString("C")}.");

                    }

                    else if (die1.Roll == die2.Roll)
                    {
                        money = money - total;
                        Console.WriteLine($"Oh no! You lost! You lost {total.ToString("C")}!");
                    }
                }

                else if (choice == "EVEN")
                {
                    total = bet;
                    money = money + total;
                    int rollTotal = die1.Roll + die2.Roll;
                    if (rollTotal == 2|| rollTotal == 4 || rollTotal == 6 || rollTotal == 8 || rollTotal == 10 || rollTotal == 12 ) 
                    {
                        Console.WriteLine($"Hey look at that, you won! You earned {total.ToString("C")}.");
                    }
                    else if (rollTotal == 1 || rollTotal == 3 || rollTotal == 5 || rollTotal == 7 || rollTotal == 9 || rollTotal == 11)
                    {
                        Console.WriteLine($"Oh no! You lost! You lost {total.ToString("C")}!");
                    }

                }

                else if (choice == "ODD")
                {
                    total = bet;
                    money = money + total;
                    int rollTotal = die1.Roll + die2.Roll;
                    if (rollTotal == 1 || rollTotal == 3 || rollTotal == 5 || rollTotal == 7 || rollTotal == 9 || rollTotal == 11)
                    {
                        Console.WriteLine($"Hey look at that, you won! You earned {total.ToString("C")}.");
                    }

                    else if (rollTotal == 2 || rollTotal == 4 || rollTotal == 6 || rollTotal == 8 || rollTotal == 10 || rollTotal == 12)
                    {
                        Console.WriteLine($"Oh no! You lost! You lost {total.ToString("C")}!");
                    }


                }




               

                if (money == 0)
                {
                    Console.WriteLine("It seems you have ran out of money, you can no longer play. Goodbye.");

                }



            }

            if (done == true) 
            {
                Console.WriteLine($"Sorry to hear you're leaving. :( But hey, at least you're leaving with some cash! :3");
            }

        }
    }
}