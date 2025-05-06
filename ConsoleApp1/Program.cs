
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

      Console.Write("Enter a distance in kilometers that you have walked: ");
      int walkingDistance = Convert.ToInt32(Console.ReadLine()); // https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input
      Console.Write("Enter the time in minutes it took to walk that distance: ");
      int walkingTime = Convert.ToInt32(Console.ReadLine());

      int averageWalkingSpeed = walkingDistance / (walkingTime / 60);

      Console.WriteLine("\n\nYou average walking speed was " + averageWalkingSpeed + "!\n\n"); //https://stackoverflow.com/questions/26338571/checking-console-readline-null


      Console.WriteLine("Press enter to exit...");
      Console.ReadLine();
    }
  }
}
