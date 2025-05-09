
using System.Security.AccessControl;

namespace HelloWorld
{
  class Program // can technically be called anything but Program is best practice
  {
    static void Main(string[] args) // this method has to be called Main if it going to be the entrypoint and there is no Top-level statements file
    {
      Console.Clear();
      Console.WriteLine("\nHello!\n");

      Console.Write("Please input you name: ");
      string? userName = Console.ReadLine(); // username can be string or possibly null, Console.ReadLine() returns string generally

      Console.Clear();
      Console.WriteLine("\n\n" + @"\~~~~~ Welcome" + (string.IsNullOrEmpty(userName) ? "" : " " + userName) + " to Walkingtale with the cat! =^.^=  ~~~~~/\n\n"); //https://stackoverflow.com/questions/26338571/checking-console-readline-null
      Console.WriteLine("Let us figure out you average walking speed...\n");
      double walkingDistance = GetConvertedDoubleInput("Enter a distance in kilometers that you have walked: ");
      double walkingTime = GetConvertedDoubleInput("Enter the time in minutes it took to walk that distance: ");
      double averageWalkingSpeed = walkingDistance / (walkingTime / 60);

      Console.WriteLine("\nYou average walking speed was " + averageWalkingSpeed + " km/h!\n\n"); //https://stackoverflow.com/questions/26338571/checking-console-readline-null

      Console.WriteLine("Let us see how many steps that was...\n");

      double walkingStepWidth = GetConvertedDoubleInput("Enter how wide your walking step is in centimeter: ");
      double numberOfSteps = walkingDistance * 100000 / walkingStepWidth;
      Console.WriteLine("\nOn your way you took " + numberOfSteps + " steps! Great work! \\./\n\n");

      string[] routes = ["Park", "Forest", "City"];
      MenuChoices("There are " + routes.Length + " routes that the cat let you choose from: \n", routes);

      int routeChoiceNumber = GetConvertedIntMenuInput("\nEnter the number of the route you choose: ", routes.Length);

      string routeChoice = routes[routeChoiceNumber - 1];

      Console.Clear();
      Console.WriteLine("\nYou chose the " + routeChoice + ", and the cat is running off in that direction.");

      string[] signs = [routeChoice + " Entrance", routeChoice + " Exit"];
      string[] reversedSigns = new string[signs.Length];
      int index = 0;

      foreach (string sign in signs)
      {
        reversedSigns[index] = ReverseString(sign).ToUpper();
        index++;
      }

      MenuChoices("\nAt the arrival to the " +
      routeChoice + " you see two gates ahead. You will need to pass through one of the to get into the " +
      routeChoice + ". There are old signs beside each of the gates that has become reversed by time:\n"
      , reversedSigns);

      int signChoiceNumber = GetConvertedIntMenuInput("\nEnter the number of the gate you choose to enter: ", signs.Length);

      if (signChoiceNumber == 1)
      {
        Console.Clear();
        Console.WriteLine("\nYou chose the " + signs[signChoiceNumber - 1] +
        ", and the cat is greeting you with a meow and make stroke loop around your legs when you get in." +
        " Then you continue on the main path.");
      }
      else
      {
        Console.Clear();
        Console.WriteLine("\nYou chose the " + signs[signChoiceNumber - 1] +
        ", and the reversal of time throws you out and back in time to the point that you no longer have met the cat," +
        " and you just continue on with you daily business.");
        GameOver();
      }

      string[] yesOrNoAnswerArray = ["Yes", "No"];
      Console.WriteLine("\nIt leads up to a fountain and a big sign that says: \n\n\"Koi pond\"\n\nThe cat try to catch a fish but failed, got a wet paw and now want you help.");
      MenuChoices("Will you help the cat to catch a fish?\n", ["Yes", "No"]);
      int catchFishAnswerNumber = GetConvertedIntMenuInput("\nEnter a number for your answer: ", yesOrNoAnswerArray.Length);

      if (catchFishAnswerNumber == 1)
      {
        Console.WriteLine("Let us try to catch fish!");

        // different ways of creating new instances (objects) of class Fish
        // Fish fish1 = new Fish();

        // Fish fish2 = new Fish
        // {
        //   Name = "Ebe",
        //   Color = "orange",
        //   Temper = "angry",
        //   Difficulty = "moderate"
        // };

        // Fish fish3 = new("Sandy", "white", "shy", "hard");

        // Fish fish4 = new()
        // {
        //   Name = "Obo",
        //   Color = "red",
        //   Temper = "social",
        //   Difficulty = "easy"
        // };

        // List<Fish> fishesList = [fish1, fish2, fish3, fish4]; // adding the fish objects to a List


        List<Fish> fishesList = [  // collection initialization
          new Fish {
            Name = "Fishe",
            Color = "red",
            Temper = "shy",
            Difficulty = "moderate",
          },
          new Fish {
            Name = "Ebe",
            Color = "orange",
            Temper = "angry",
            Difficulty = "moderate"
          },
          new Fish {
            Name = "Sandy",
            Color = "white",
            Temper = "shy",
            Difficulty = "hard"
          },
          new Fish {
            Name = "Obo",
            Color = "red",
            Temper = "social",
            Difficulty = "easy"
          },
        ];

        string[] fishesColors = [.. fishesList.Select(fish => fish.Color)]; // using LINQ (Language Integrated Query) querying data in collection

      }
      else
      {
        Console.WriteLine("The cat is disappointed and ignore you.");
        GameOver("(Don't worry, the cat might get over it.)");
      }

      Exit();
    }
    private static double GetConvertedDoubleInput(string prompt) // private utility method for class scoped clean refactoring, can be changed to public when it is needed outside of this class
    {
      double value = 0;
      bool isNotValidInput = true;
      while (isNotValidInput)
      {
        Console.Write(prompt);
        string? input = Console.ReadLine();


        if (double.TryParse(input, out value)) // https://stackoverflow.com/questions/14304591/check-if-user-input-is-a-number, out value assigns value with the parsed double if the TryParse was successful
        {
          isNotValidInput = false;
        }
        else
        {
          Console.WriteLine("Invalid input. Enter a number or decimal.");
        }
      }
      return value;
    }

    private static int GetConvertedIntMenuInput(string prompt, int menuLength)
    {
      int value = 1;
      bool isNotValidInput = true;
      while (isNotValidInput)
      {
        Console.Write(prompt);
        string? input = Console.ReadLine();


        if (int.TryParse(input, out value) && value > 0 && value <= menuLength)
        {
          isNotValidInput = false;
        }
        else
        {
          Console.WriteLine("Invalid input. Enter a number from 1 to " + menuLength + ".");
        }
      }
      return value;
    }

    private static void MenuChoices(string prompt, string[] alternatives)
    {
      Console.WriteLine(prompt);
      for (int i = 0; i < alternatives.Length; i++)
      {
        Console.WriteLine(i + 1 + ") " + alternatives[i]);
      }
    }

    private static string ReverseString(string initialString)
    {
      char[] initialStringCharArray = initialString.ToCharArray();
      Array.Reverse(initialStringCharArray);
      return string.Concat(initialStringCharArray);

    }

    public static void GameOver()
    {
      Console.WriteLine("\n\n***GAME OVER***");
      Exit();
    }

    public static void GameOver(string info) // overload GameOver function
    {
      Console.WriteLine("\n***GAME OVER***");
      Console.WriteLine(info);
      Exit();
    }

    private static void Exit()
    {
      Console.WriteLine("\n\nPress enter to exit...");
      Console.ReadLine();
      Environment.Exit(0); // https://stackoverflow.com/questions/12977924/how-do-i-properly-exit-a-c-sharp-application
    }
  }

  abstract class Animal // blueprint base class with abstract properties that must be implemented in non-abstract derived classes
  {
    public abstract string Name { get; set; }
    public abstract string Color { get; set; }
    public abstract string Temper { get; set; }
    public abstract string Difficulty { get; set; }

    public abstract string Sound { get; set; }

  }

  class Fish : Animal // non-abstract derived class that is implementing base class abstract properties by override
  {
    public override string Name { get; set; }
    public override string Color { get; set; }
    public override string Temper { get; set; }
    public override string Difficulty { get; set; }

    public Fish() // constructor with default values
    {
      Name = "Fishe";
      Color = "red";
      Temper = "shy";
      Difficulty = "moderate";
    }

    public Fish(string name, string color, string temper, string difficulty) // overload constructor with parameter values
    {
      Name = name;
      Color = color;
      Temper = temper;
      Difficulty = difficulty;
    }
    public override string Sound { get; set; } = "blub";

  }


}