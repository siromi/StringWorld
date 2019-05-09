using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mainは長くなりがちなのでルールを管理するクラスに移動してみました
            var controller = new ConsoleGameController();
            controller.PlayGame();

            Console.ReadLine();
        }
    }
}