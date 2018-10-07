using System;

namespace TextGame
{
    class Program
    {
        static void Main()
        {
            bool complete;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to the cavern of secrets!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");
            Console.WriteLine("Do you take it? [y/n]: ");
            string ch1 = Console.ReadLine();
            bool stick = false;

            //STICK TAKEN
            if(ch1 =="Y"||ch1 =="y"||ch1=="Yes"||ch1=="yes"||ch1=="YES")
            {
                Console.WriteLine("You have taken the stick!");
                System.Threading.Thread.Sleep(2000);
                stick = true;
            }

            //STICK NOT TAKEN
            else
            {
                Console.WriteLine("You did not take the stick!");
                stick = false;
            }
            Console.WriteLine("As you proceed further into the cave, you see a small glowing object");
            Console.WriteLine("Do you approach the object? [y/n]");
            string ch2 = Console.ReadLine();

            //APPROACH SPIDER
            if(ch2 =="Y"||ch2 =="y"||ch2=="Yes"||ch2=="yes"||ch2=="YES")
            {
                Console.WriteLine("You approach the object...");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("The eye belongs to a giant spider!");
                Console.WriteLine("Do you try to fight it? [Y/N]");
                string ch3 = Console.ReadLine();

                //FIGHT SPIDER
                if(ch3 =="Y"||ch3 =="y"||ch3=="Yes"||ch3=="yes"||ch3=="YES")
                {

                    //WITH STICK
                    if(stick == true)
                    {
                        Console.WriteLine("You only have a stick to fight with!");
                        Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("                  Fighting...                   ");
                        Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                        Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        System.Threading.Thread.Sleep(2000);
                        Random random = new Random();
                        int fdmg1 = random.Next(3,10); 
                        string fdmg1string = fdmg1.ToString();
                        int edmg1 = random.Next(1,5);
                        string edmg1string = edmg1.ToString();
                        Console.WriteLine("you hit a " + fdmg1string);
                        Console.WriteLine("the spider hits a " + edmg1string);
                        System.Threading.Thread.Sleep(2000);
                        if(edmg1 > fdmg1)
                        {
                            Console.WriteLine("The spider has dealt more damage than you!");
                            complete = false;
                        }
                        else if(fdmg1 < 5)
                        {
                            Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
                            complete = true;
                        }
                        else
                        {
                            Console.WriteLine("You killed the spider!");
                            complete = true;
                        }
                    }

                    //WITHOUT SITCK
                    else
                    {
                        Console.WriteLine("You don't have anything to fight with!");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("                  Fighting...                   ");
                        Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                        Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        System.Threading.Thread.Sleep(2000);
                        Random random = new Random();
                        int fdmg1 = random.Next(1,8); 
                        string fdmg1string = fdmg1.ToString();
                        int edmg1 = random.Next(1,5);
                        string edmg1string = edmg1.ToString();
                        Console.WriteLine("you hit a " + fdmg1string);
                        Console.WriteLine("the spider hits a " + edmg1string);
                        System.Threading.Thread.Sleep(2000);
                        if(edmg1 > fdmg1)
                        {
                            Console.WriteLine("The spider has dealt more damage than you!");
                            complete = false;
                        }
                        else if(fdmg1 < 5)
                        {
                            Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
                            complete = true;
                        }
                        else{
                            Console.WriteLine("You killed the spider!");
                            complete = true;
                        }
                    }
                }

                //DON'T FIGHT SPIDER
                else
                {
                    Console.WriteLine("You choose not to fight the spider.");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("As you turn away, it ambushes you and impales you with it's fangs!!!");
                    complete = false;
                }
            }

            //DON'T APPROACH SPIDER
            else
            {
                Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("But something won't let you....");
                complete = false;
            }

            //Game Loop
            bool alivebool = true;
            string alivestring;
            while(alivebool)
            {
               if(complete == true)
                {
                   Console.WriteLine("You managed to escape the cavern alive! Would you like to play again? [y/n]: ");
                   alivestring = Console.ReadLine();
                   if(alivestring =="Y"||alivestring =="y"||alivestring=="Yes"||alivestring=="yes"||alivestring=="YES")
                   {
                       Main();
                   }
                   else{
                       break;
                   } 
               }
               else
               {
                   Console.WriteLine("You have died! Would you like to play again? [y/n]: ");
                   alivestring = Console.ReadLine();
                   if(alivestring =="Y"||alivestring =="y"||alivestring=="Yes"||alivestring=="yes"||alivestring=="YES")
                   {
                       Main();
                   }
                   else{
                       break;
                   } 
               }
            }
        }
    }
}
