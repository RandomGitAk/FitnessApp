using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
  public  class Food
    {
        public string Name { get; }
        public double Callories { get; }

        /// <summary>
        /// Білки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жири
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Вуглеводи
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калорії за 100грм продукта
        /// </summary>
        public double Calories { get; }

    

        public Food(string name) : this(name, 0, 0, 0, 0) {}

        public Food(string name, double callories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
