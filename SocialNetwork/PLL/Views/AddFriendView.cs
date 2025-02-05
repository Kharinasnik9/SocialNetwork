using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        private readonly UserService _userService;

        public AddFriendView(UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public void Show(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                Console.WriteLine("Введите почтовый адрес пользователя, которого хотите добавить в друзья:");

                var friendEmail = Console.ReadLine();

                var userAddingFriendData = new UserAddFriendData
                {
                    FriendEmail = friendEmail,
                    UserId = user.Id
                };

                _userService.AddFriend(userAddingFriendData);

                SuccessMessage.Show("Вы успешно добавили пользователя в друзья!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с указанным почтовым адресом не существует!");
            }
            catch (Exception ex)
            {
                AlertMessage.Show($"Произошла ошибка при добавлении пользователя в друзья: {ex.Message}");
            }
        }
    }
}