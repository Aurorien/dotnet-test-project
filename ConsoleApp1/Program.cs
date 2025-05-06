
namespace HelloWorld
{
  class Program // can technically be called anything but Program is best practice
  {
    static void Main(string[] args) // this method has to be called Main if it going to be the entrypoint and there is no Top-level statements file
    {
      Console.WriteLine("Hello, World!");
      Console.WriteLine("Press enter to exit...");
      Console.ReadLine();
    }
  }
}
