using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendView
    {
        public void Show(IEnumerable<User> friends)
        {
            Console.WriteLine("Мои друзья");

            if (!friends.Any())
            {
                Console.WriteLine("У вас нет друзей");
                return;
            }

            foreach (var friend in friends)
            {
                Console.WriteLine($"Почтовый адрес друга: {friend.Email}. Имя друга: {friend.FirstName}. Фамилия друга: {friend.LastName}");
            }
        }
    }
}

