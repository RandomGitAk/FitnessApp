using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Користувач.
    /// </summary>
    /// 


    public class User
    {
        #region Властивості
        /// <summary>
        /// Ім'я.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Гендер.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата народження.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Вага.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Зріст.
        /// </summary>
        public double Height { get; set; }

        public int Age { get {
                //DateTime nowDate = new DateTime();
                //int age = nowDate.Year - BirthDate.Year;
                //if (BirthDate > nowDate.AddYears(-age)) age--;
                //return age;
                return DateTime.Now.Year - BirthDate.Year;
            }
        }
        #endregion

        /// <summary>
        /// Створити нового користувача
        /// </summary>
        /// <param name="name">Ім'я</param>
        /// <param name="gender">Гендер</param>
        /// <param name="birthDate">Дата народження</param>
        /// <param name="weight">Вага</param>
        /// <param name="height">Зріст</param>
        public User (string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Перевірка умов
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Ім'я користувача не може бути пустим чи null.", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Гендер не може бути пустим чи null.", nameof(gender));
            }
            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Неможлива дата народження.", nameof(BirthDate));
            }
            if(weight <= 0)
            {
                throw new ArgumentNullException("Вага не може бути більше чи рівна нулю.", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentNullException("Зріст не може бути більше чи рівна нулю.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Ім'я користувача не може бути пустим чи null.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
