
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



      double walkingDistance = GetConvertedDoubleInput("Enter a distance in kilometers that you have walked: ");
      double walkingTime = GetConvertedDoubleInput("Enter the time in minutes it took to walk that distance: ");
      double averageWalkingSpeed = walkingDistance / (walkingTime / 60);

      Console.WriteLine("\n\nYou average walking speed was " + averageWalkingSpeed + " km/h!\n\n"); //https://stackoverflow.com/questions/26338571/checking-console-readline-null


      Console.WriteLine("Press enter to exit...");
      Console.ReadLine();
    }
    private static double GetConvertedDoubleInput(string prompt) // private method for class-scoped clean refactoring, can be changed to public when it is needed outside of this class
    {
      double value = 0;
      bool isNotValidInput = true;
      while (isNotValidInput)
      {
        Console.Write(prompt);
        string? walkingDistanceInput = Console.ReadLine();


        if (double.TryParse(walkingDistanceInput, out value)) // https://stackoverflow.com/questions/14304591/check-if-user-input-is-a-number, out value assigns value with the parsed double if the TryParse was successful
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
  }


}
