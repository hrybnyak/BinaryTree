using System;
using TreeLibrary;
using StudentLibrary;
using System.Collections.Generic;
namespace StudentScoreBook
{
    public static class Menu
    {
        public static void RunMenu()
        {
            var scoreBook = new BinaryTree<TestResult>();
            scoreBook.NodeAdded += PrintMessageAboutNode;
            int key = 1;
            while (key != 0)
            {
                Console.WriteLine("Press 0 to exit");
                Console.WriteLine("Print 1 to add test result to the score book");
                Console.WriteLine("Print 2 to show all test results");
                Console.WriteLine("Print 3 to change the tree search setting of the score book");
                Console.WriteLine("Print 4 to remove record from the score book");
                if (Int32.TryParse(Console.ReadLine(), out key))
                {
                    switch (key)
                    {
                        case 1:
                            {
                                Console.WriteLine("Please enter student name:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Please enter test name:");
                                string test = Console.ReadLine();
                                Console.WriteLine("Please enter score:");
                                double score;
                                if (Double.TryParse(Console.ReadLine(), out score))
                                {
                                    Console.WriteLine("Please enter date:");
                                    DateTime date;
                                    if (DateTime.TryParse(Console.ReadLine(), out date))
                                    {
                                        TestResult testResult = new TestResult(name, test, score, date);
                                        scoreBook.Add(testResult);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorry, your input was wrong, try again");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, your input was wrong, try again");
                                }
                                break;
                            }
                          case 2:
                            {
                                Console.WriteLine("This is all test records in the score book");
                                foreach(TestResult t in scoreBook)
                                {
                                    Console.WriteLine($"{t.StudentName} has taken the test {t.TestName} on {t.DayTaken:MM/dd/yyyy} and has score of {t.Score} points");
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Press 1 to choose In-Order(LNR) option, press 2 to choose Pre-Order(NLR) option");
                                if (Int32.TryParse(Console.ReadLine(), out int option) && (option == 1 || option ==2))
                                {
                                    if (option == 1)
                                    {
                                        var search = new InOrderTreeSearch<TestResult>();
                                        scoreBook.TreeSearchStrategy = search;
                                    }
                                    else
                                    {
                                        var search = new PreOrderTreeSearch<TestResult>();
                                        scoreBook.TreeSearchStrategy = search;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Wring input, try again");
                                }
                                
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Please enter record information to delete");
                                Console.WriteLine("Please enter student name:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Please enter test name:");
                                string test = Console.ReadLine();
                                Console.WriteLine("Please enter score:");
                                double score;
                                if (Double.TryParse(Console.ReadLine(), out score))
                                {
                                    Console.WriteLine("Please enter date:");
                                    DateTime date;
                                    if (DateTime.TryParse(Console.ReadLine(), out date))
                                    {
                                        TestResult testResult = new TestResult(name, test, score, date);
                                        bool check = scoreBook.Remove(testResult);
                                        if (check == true)
                                        {
                                            Console.WriteLine("The record was succesfully removed");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorry, your input was wrong, try again");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, your input was wrong, try again");
                                }
                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong input, try again");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Please, try again");
                }
            }
        }
        public static void PrintMessageAboutNode(object sender, NodeAddedEventArgs<TestResult> e)
        {
            Console.WriteLine("The record was successfully added to the score book");
        }
    }
}
