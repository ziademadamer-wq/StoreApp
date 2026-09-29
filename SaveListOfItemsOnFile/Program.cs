using ConsoleApp1;

namespace SaveListOfItemsOnFile
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MainApp mainApp = new MainApp();
            await mainApp.MainProgram();
        }
    }
}
