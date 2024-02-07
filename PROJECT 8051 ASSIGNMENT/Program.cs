// See https://aka.ms/new-console-template for more information

using System;
using System.Xml.Linq;

class VirtualPet
{   
    
    public string Pet;
    public string Name;
    public int H1;
    public int Happiness;
    public int Health;

    public VirtualPet(string petType, string name)      //Constructor
    {
        Pet = petType;
        Name = name;
        H1 = 5;
        Happiness = 5;
        Health = 5;
    }



    public void CheckCriticalStatus()
    {
        if (H1 >= 8 || Happiness <= 2 || Health <= 2)
        {
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.WriteLine("|Warning: Your pet is in critical condition!...Lets take care of the pet.......|");
            Console.WriteLine("|------------------------------------------------------------------------------|");
        }
    }

    public void Feed()
    {
        H1 = Math.Max(1, H1 - 3);
        Health = Math.Min(10, Health + 1);
        Console.WriteLine($"{Name} has been fed. Hunger is decreased and health increased.");
    }

    public void Play()
    {
        Happiness = Math.Min(10, Happiness + 2);
        H1 = Math.Min(10, H1 + 1);
        Console.WriteLine($"{Name} played happily. Happiness increased, but hunger also rose.");
    }

    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(1, Happiness - 1);
        Console.WriteLine($"{Name} is resting. Health increased, but happiness decreased slightly.");
    }

    public void TimePasses()
    {
        H1 = Math.Min(10, H1 + 1);
        Happiness = Math.Max(1, Happiness - 1);
    }

    public void Interaction()
    {
        if (H1 >= 8)
        {
            Console.WriteLine($"{Name} is too hungry to play or rest.");

        }
        else if (Happiness <= 3)
        {
            Console.WriteLine($"{Name} is too upset to play.");

        }

        {
            Console.WriteLine("------------***************----------------------");
            Console.Write($"\n\nWhat would you like to do with {Name} buddy? \n1.feed\n2.play\n3.rest\n4. Display Status\n5.Exit\n\n  ");
            Console.Write("----------------**************-------------------\n");
            Console.WriteLine("Enter Input: ") ;
            string ac = Console.ReadLine();
            int res = Convert.ToInt32(ac);

            switch (res)
            {
                case 1:
                    Feed();
                    break;
                case 2:
                    Play();
                    break;
                case 3:
                    Rest();
                    break;
                case 4:
                    {

                        Console.WriteLine($"\n{Name} ({Pet}) Status:");
                        Console.WriteLine($"1.Hunger: {H1}/10\n2.Happiness: {Happiness}/10\n3.Health: {Health}/10");

                        H1 = H1 - 1;                 // to excape time simulate to display status
                        Happiness = Happiness + 1;

                        break;

                    }
                case 5:
                    {
                        Console.WriteLine($"Thnks for playing the virtualpet game........");
                        Environment.Exit(0);

                        break;
                    }
                default:
                    Console.WriteLine("\n Invalid Input. Please select feed, play, rest, or exit.");
                    break;
            }
        }
    }

    public void NeglectConsequences()
    {
        if (H1 >= 8)
        {
            Health = Math.Max(1, Health - 2);
            Console.WriteLine($"Neglect warning: {Name}'s health is deteriorating due to hunger!");
        }

        if (Happiness <= 2)
        {
            Console.WriteLine($"Neglect warning: {Name} is very unhappy. Consider playing with them.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Choose a pet \n(e.g., cat, dog, rabbit,PARROT, Eagle, Horse ): ");
        string petType = Console.ReadLine();
        Console.Write("Give your pet a name: ");
        string petName = Console.ReadLine();

        VirtualPet pet = new VirtualPet(petType, petName);

        Console.WriteLine($"Welcome to the Virtual Pet  Meet {pet.Name}, your {pet.Pet}.");

        while (true)
        {

            pet.CheckCriticalStatus();

            pet.Interaction();
            pet.TimePasses();              //  consider this one hour or time simulate
            pet.NeglectConsequences();


            System.Threading.Thread.Sleep(1000);
        }
    }
}
