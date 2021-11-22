using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контролер користувача
    /// </summary>
   public class UserController
    {
        /// <summary>
        /// Користувач
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Створення нового контролеру користувавча
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender,birthDay, weight,height);
           
        }
        /// <summary>
        /// отримати данні користувача.
        /// </summary>
        /// <returns>Користувач додатка.</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: Що робити якщо користувача не прочитали?
            }
        }

        /// <summary>
        /// Зберегти данні крпистувача.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User); 
            }
        }
        

        
    }
}
