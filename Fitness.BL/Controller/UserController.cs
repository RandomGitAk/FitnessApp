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
        public List<User> Users { get; }
        public  User CurrentUser { get; }
        /// <summary>
        /// Перевірка чи це новий користувач.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Створення нового контролеру користувавча
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Ім'я користувача не може бути порожнім.", nameof(userName));
            }
            Users = GetUsersDate();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);

                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// отримати збережений список користувачів.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersDate()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Перевірка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }




        /// <summary>
        /// Зберегти данні крпистувача.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users); 
            }
        }
        

        
    }
}
