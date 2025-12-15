namespace Lab0;

public class Interface
{
    private Machine _machine;
    private Admin _admin;

    public Interface(Machine machine, Admin admin)
    {
        _machine = machine;
        _admin = admin;
    }
    
    public void Runner()
    {
        bool running = true;

        while (running)
        {
            ShowMainMenu();
            string? choice = Console.ReadLine();
            Console.WriteLine();
            
            if (choice == "1")
            {
                ShowTheAssortment();
            }
            else if (choice == "2")
            {
                InsertMoney();
            }
            else if (choice == "3")
            {
                BuySomething();
            }
            else if (choice == "4")
            {
                ChangeReturning();
            }
            else if (choice == "5")
            {
                AdminMenu();
            }
            else if (choice == "0")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Такой команды не существует");
            }
        }
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("====Еда и напитки====");
        Console.WriteLine("1. Показать ассортимент");
        Console.WriteLine("2. Пополнить баланс");
        Console.WriteLine("3. Выбрать товар");
        Console.WriteLine("4. Сдача / Отмена");
        Console.WriteLine("5. Режим для администратора");
        Console.WriteLine("0. Завершение операции");
        Console.WriteLine();
        Console.Write("Операция: ");
        Console.Write(" ");
    }

    public void ShowTheAssortment()
    {
        Console.WriteLine("Ассортимент:");
        Console.WriteLine("1. Вода: 20 р.");
        Console.WriteLine("2. Газировка: 30 р.");
        Console.WriteLine("3. Чипсы: 45 р.");
    }

    public void InsertMoney()
    {
        Console.WriteLine("Допустимый номинал: 1, 2, 5, 10 р.");
        int value = -1;

        while (value != 0)
        {
            Console.WriteLine("Пополнение на сумму: ");
            string input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Введите число");
                continue;
            }

            if (!int.TryParse(input, out value))
            {
                Console.WriteLine("Некорректное число");
                value = -1;
            } 
            else if (value != 0)
            {
                _machine.Insert(value, out string response);
                Console.WriteLine(response);
            }
        }
    }

    public void BuySomething()
    {
        ShowTheAssortment();
        Console.WriteLine("Укажите номер товара: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int result))
        {
            Console.WriteLine("Введите корректный номер");
            return;
        }

        if (_machine.Buying(result, out string response))
        {
            Console.WriteLine(response);
            Console.WriteLine($"Остаток на счете: {_machine.Inserted} р.");
        }
        else
        {
            Console.WriteLine(response);
        }
    }

    public void ChangeReturning()
    {
        int change = _machine.ReturnChange();
        if (change == 0)
        {
            Console.WriteLine("Сдачи нет");
        }
        else
        {
            Console.WriteLine($"Выдача сдачи {change} р.");
        }
    }

    public void RestockProducts()
    {
        ShowTheAssortment();
        Console.Write("Номер товара: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int result))
        {
            Console.WriteLine("Такого товара не существует");
            return;
        }
        
        Console.Write("Введите количество: ");
        input = Console.ReadLine();
        if (!int.TryParse(input, out int amount))
        {
            Console.WriteLine("Неккоректное количество");
            return;
        }

        if (_admin.NewProducts(result, amount, out string response))
        {
            Console.WriteLine(response);
        }
        else
        {
            Console.WriteLine(response);
        }
    }

    public void AdminMenu()
    {
        Console.WriteLine("Введите код доступа администратора: ");
        string input = Console.ReadLine();
        bool running = true;
        if (!int.TryParse(input, out int result) || !_admin.Login(input))
        {
            Console.WriteLine("Неверный пароль");
            return;
        }

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("====РЕЖИМ АДМИНИСТРАТОРА====");
            Console.WriteLine($"Баланс машины: {_machine.Collected} р.");
            Console.WriteLine("1. Ассортимент");
            Console.WriteLine("2. Пополнить ассортимент");
            Console.WriteLine("3. Забрать выручку");
            Console.WriteLine("0. Выход");
            Console.WriteLine();
            Console.Write("Операция: ");
            Console.Write(" ");
            
            string? choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                ShowTheAssortment();
            }
            else if (choice == "2")
            {
                RestockProducts();
            }
            else if (choice == "3")
            {
                int money = _admin.GiveMeAllMoney();
                Console.WriteLine($"Администратор забрал выручку в {money} р.");
            }
            else if (choice == "0")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Такой команды не существует");
            }
        }
    }
}