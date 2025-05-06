
namespace HelloWorld
{
  class Program // can technically be called anything but Program is best practice
  {
    static void Main(string[] args) // this method has to be called Main if it going to be the entrypoint and there is no Top-level statements file
    {
      Console.WriteLine("\nHello!\n");

      Console.Write("Please input you name: ");
      string? userName = Console.ReadLine(); // username can be string or possibly null, Console.ReadLine() returns string generally

      Console.WriteLine("\n\nWelcome" + (string.IsNullOrEmpty(userName) ? "" : " " + userName) + "!\n\n"); //https://stackoverflow.com/questions/26338571/checking-console-readline-null
      Console.WriteLine("Let figure out you average walking speed!\n");

      double walkingDistance = 0;

      bool isNotValidInput = true;
      while (isNotValidInput)
      {
        Console.Write("Enter a distance in kilometers that you have walked: ");
        string? walkingDistanceInput = Console.ReadLine();


        if (double.TryParse(walkingDistanceInput, out walkingDistance)) // https://stackoverflow.com/questions/14304591/check-if-user-input-is-a-number
        {
          walkingDistance = Convert.ToInt32(walkingDistanceInput); // https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input, double for decimals https://www.w3schools.com/cs/cs_data_types.php
          isNotValidInput = false;
        }
        else
        {
          Console.WriteLine("Invalid input. Enter a number or decimal.");
        }
      }

      double walkingTime = 0;

      isNotValidInput = true;
      while (isNotValidInput)
      {
        Console.Write("Enter the time in minutes it took to walk that distance: ");
        string? walkingTimeInput = Console.ReadLine();


        if (double.TryParse(walkingTimeInput, out walkingTime)) // https://stackoverflow.com/questions/14304591/check-if-user-input-is-a-number
        {
          walkingTime = Convert.ToInt32(walkingTimeInput); // https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input, double for decimals https://www.w3schools.com/cs/cs_data_types.php
          isNotValidInput = false;
        }
        else
        {
          Console.WriteLine("Invalid input. Enter a number or decimal.");
        }
      }

      double averageWalkingSpeed = walkingDistance / (walkingTime / 60);

      Console.WriteLine("\n\nYou average walking speed was " + averageWalkingSpeed + "!\n\n"); //https://stackoverflow.com/questions/26338571/checking-console-readline-null


      Console.WriteLine("Press enter to exit...");
      Console.ReadLine();
    }
  }

}
