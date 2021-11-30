using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{/// <summary>
 /// Гендер.
 /// </summary>
 [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Назва.
        /// </summary>  
        public string Name { get; set; }
        public Gender() { }
        /// <summary>
        /// Створити новий гендер.
        /// </summary>
        /// <param name="name">Ім'я гендера</param>
        public Gender (string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Ім'я гендеру не може бути порожнім або null.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
