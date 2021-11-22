using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Controller;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас вітає програма Fitness");

            Console.WriteLine("Введіть ім'я користувача");
            var name = Console.ReadLine();

            Console.WriteLine("Ввeдіть гендер");
            var gender = Console.ReadLine();

            Console.WriteLine("Ввeдіть дату народження");
            var birthDate = DateTime.Parse(Console.ReadLine()); //

            Console.WriteLine("Ввeдіть вагу");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Ввeдіть зріст");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name,gender,birthDate,weight,height);
            userController.Save();

            Console.ReadKey();
        }
    }
}
