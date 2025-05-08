
namespace HelloWorld
{
  class Program // can technically be called anything but Program is best practice
  {
    static void Main(string[] args) // this method has to be called Main if it going to be the entrypoint and there is no Top-level statements file
    {
      Console.WriteLine("\nHello!\n");

      Console.Write("Please input you name: ");
      string? userName = Console.ReadLine(); // username can be string or possibly null, Console.ReadLine() returns string generally

      Console.WriteLine("\n\n~~~~~ Welcome" + (string.IsNullOrEmpty(userName) ? "" : " " + userName) + " to Walkingtale with the cat! =^.^=  ~~~~~\n\n"); //https://stackoverflow.com/questions/26338571/checking-console-readline-null
      Console.WriteLine("Let us figure out you average walking speed!\n");



      double walkingDistance = GetConvertedDoubleInput("Enter a distance in kilometers that you have walked: ");
      double walkingTime = GetConvertedDoubleInput("Enter the time in minutes it took to walk that distance: ");
      double averageWalkingSpeed = walkingDistance / (walkingTime / 60);

      Console.WriteLine("\nYou average walking speed was " + averageWalkingSpeed + " km/h!\n\n"); //https://stackoverflow.com/questions/26338571/checking-console-readline-null

      Console.WriteLine("Let us see how many steps that was!\n");

      double walkingStepWidth = GetConvertedDoubleInput("Enter how wide your walking step is in centimeter: ");
      double numberOfSteps = walkingDistance * 100000 / walkingStepWidth;
      Console.WriteLine("\nOn your way you took " + numberOfSteps + " steps!\n\n");

      string[] routes = ["Park", "Forest", "City"];
      Console.WriteLine("There are " + routes.Length + " routes that the cat let you choose from: \n");
      for (int i = 0; i < routes.Length; i++)
      {
        Console.WriteLine(i + 1 + ") " + routes[i]);
      }

      int menuChoice = GetConvertedIntMenuInput("\nEnter the number of the route you choose: ", routes.Length);



      Console.WriteLine("\nYou chose the " + routes[menuChoice - 1] + ", and the cat is running off in that direction.");



      Console.WriteLine("\n\nPress enter to exit...");
      Console.ReadLine();
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
  }


}