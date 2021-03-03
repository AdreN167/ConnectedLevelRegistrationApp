using RegistrationLoginApp.Models;
using RegistrationLoginApp.Services;
using System;
using System.Runtime;

namespace RegistrationLoginApp.UI
{
    public class Menu
    {
        public Menu() {
            ConfigurationService.Init();
        }

        public void MainMenu()
        {
            var isEnd = false;

            while (!isEnd)
            {
                ShowMenu("-------------Главное меню------------", "Зарегистрироваться", "Войти", "Закрыть");
                Console.Write("Ваш выбор: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    ThrowError("Некорректный ввод!");
                }

                switch (choice)
                {
                    case 1:
                        RegistrationMenu();
                        break;

                    case 2:
                        LogInMenu();
                        break;

                    case 3:
                        isEnd = false;
                        break;

                    default:
                        ThrowError("Такого пункта нет!");
                        break;
                }
            }
        }

        private void RegistrationMenu()
        {
            Console.Clear();

            bool isEnd = false;
            bool isNextMenu = false;

            while (!isEnd)
            {
                Console.WriteLine("-------------Регистрация------------");

                Console.Write("Введиет логин: ");
                var login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                var password = Console.ReadLine();

                Console.Write("Повторите пароль: ");
                var repitedPassword = Console.ReadLine();

                if (RegistrationService.Registration(login, password, repitedPassword))
                {
                    Console.WriteLine("Добро пожаловать!");
                    Console.ReadLine();

                    isNextMenu = true;
                }
                else
                {
                    ThrowError("Не удалось зарегистрироваться!");

                    ShowMenu("Побробовать еще раз?", "Да", "Нет");
                    Console.Write("Ваш выбор: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        ThrowError("Некорректный ввод!");
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            break;

                        case 2:
                            isEnd = false;
                            break;

                        default:
                            ThrowError("Такого пункта нет!");
                            break;
                    }
                }
            }

            if (isNextMenu)
            {
                ProfileMenu();
            }
        }

        private void LogInMenu()
        {
            Console.Clear();

            bool isEnd = false;
            bool isNextMenu = false;

            while (!isEnd)
            {
                Console.WriteLine("-------------Вход------------");

                Console.Write("Введиет логин: ");
                var login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                var password = Console.ReadLine();

                if (LoginService.Login(login, password))
                {
                    Console.WriteLine("Добро пожаловать!");
                    Console.ReadLine();
                    isNextMenu = true;
                    
                }
                else
                {
                    ThrowError("Не удалось войти!");

                    ShowMenu("Побробовать еще раз?", "Да", "Нет");
                    Console.Write("Ваш выбор: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        ThrowError("Некорректный ввод!");
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            break;

                        case 2:
                            isEnd = false;
                            break;

                        default:
                            ThrowError("Такого пункта нет!");
                            break;
                    }
                }
            }

            if (isNextMenu)
            {
                ProfileMenu();
            }
        }

        private void ProfileMenu()
        {
            bool isEnd = false;
            var profile = new Profile();

            while (!isEnd)
            {
                ShowMenu("-------------Профиль------------", "Имя", "Почта", "Аватарка", "Сохранить изменения", "Выйти");
                Console.Write("Ваш выбор: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    ThrowError("Некорректный ввод!");
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите ваше имя:");
                        profile.Name = Console.ReadLine();

                        break;

                    case 2:
                        Console.Write("Введите вашу почту:");
                        var email = Console.ReadLine();

                        if (ValidationService.CorrectEmail(email))
                        {   
                            profile.Email = email;
                        }
                        else
                        {
                            ThrowError("Некорректный ввод!");
                        }

                        break;

                    case 3:
                        Console.Write("Введите путь к картинке (*.png/*.jpg/*.jpeg):");
                        var path = Console.ReadLine();

                        if (ValidationService.PicturesExtension(path))
                        {
                            profile.Avatar = path;
                        }
                        else
                        {
                            ThrowError("Некорректный ввод!");
                        }
                        break;

                    case 4:
                        
                        break;

                    case 5:
                        isEnd = false;
                        break;

                    default:
                        ThrowError("Такого пункта нет!");
                        break;
                }
            }
        }

        private void ShowMenu(string head, params string[] arguments)
        {
            Console.WriteLine(head);
            for (int i = 0; i < arguments.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {arguments[i]}");
            }
        }

        private void ThrowError(string message)
        {
            Console.WriteLine(message);
        }
    }
}

