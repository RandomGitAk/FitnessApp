using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Controller;
using Fitness.BL.Model;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello",culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));

            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine("EnterGender",culture);
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("Дата народження");
                double weight = ParseDouble("Вага");
                double height = ParseDouble("Зріст");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

           
            while (true)
            {

                Console.WriteLine("Що ви хочете зробити");
                Console.WriteLine("E - ввести прийом їжі");
                Console.WriteLine("A - ввести  вправу");
                Console.WriteLine("Q - вихід");

                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t {item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exe = EnterExercise();
                       
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t {item.Activity} з {item.Start.ToShortDateString()} до {item.Finish.ToShortDateString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadKey();
            }
        }

        private static(DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("ВВедіть назву вправи: ");
            var name = Console.ReadLine();
            var energy = ParseDouble("Розхід енергії в хвилину");
            var begin = ParseDateTime("Початок вправи");
            var end = ParseDateTime("Кінець вправи");
            var activity = new Activity(name, energy);
            return  (begin, end, activity);
        }

        private static ( Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введіть ім'я продукта");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорійність");
            var prots = ParseDouble("білки");
            var fats = ParseDouble("жири");
            var carbs = ParseDouble("вуглеводи");

            var weight = ParseDouble("вага порції ");

            var product = new Food(food, calories, prots, fats, carbs);
            return(Food: product, Weight: weight);
        }


        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Введіть {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Невірний формат {value}");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введіть {name} ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Невірний формат поля {name}");
                }
            }
        }
    }
}
