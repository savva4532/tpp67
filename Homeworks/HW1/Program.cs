using System;
using System.Collections.Generic;

class Program
{
    static double Deposit(double balance, List<string> history)
    {
        Console.Write("Введите сумму пополнения: ");
        double sum = Convert.ToDouble(Console.ReadLine());

        if (sum > 0)
        {
            balance += sum;
            history.Add($"Пополнение: +{sum} ₽");
            Console.WriteLine("Счёт пополнен.");
        }
        else
        {
            Console.WriteLine("Сумма должна быть больше нуля.");
        }

        return balance;
    }

    static double Withdraw(double balance, List<string> history)
    {
        Console.Write("Введите сумму снятия: ");
        double sum = Convert.ToDouble(Console.ReadLine());

        if (sum <= 0)
        {
            Console.WriteLine("Сумма должна быть больше нуля.");
        }
        else if (sum > balance)
        {
            Console.WriteLine("Недостаточно денег на счёте.");
        }
        else
        {
            balance -= sum;
            history.Add($"Снятие: -{sum} ₽");
            Console.WriteLine("Деньги сняты.");
        }

        return balance;
    }

    static void PrintBalance(double balance, string currency = "₽")
    {
        Console.WriteLine($"Текущий баланс: {balance} {currency}");
    }

    static void PrintHistory(List<string> history)
    {
        Console.WriteLine("История операций:");

        if (history.Count == 0)
        {
            Console.WriteLine("Операций пока нет.");
        }
        else
        {
            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {history[i]}");
            }
        }
    }

    static void Main()
    {
        Console.Write("Введите начальный баланс: ");
        double balance = Convert.ToDouble(Console.ReadLine());

        List<string> history = new List<string>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показать баланс");
            Console.WriteLine("2. Пополнить счёт");
            Console.WriteLine("3. Снять деньги");
            Console.WriteLine("4. Показать историю операций");
            Console.WriteLine("0. Выйти");

            Console.Write("Выберите пункт: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                PrintBalance(balance);
            }
            else if (choice == "2")
            {
                balance = Deposit(balance, history);
            }
            else if (choice == "3")
            {
                balance = Withdraw(balance, history);
            }
            else if (choice == "4")
            {
                PrintHistory(history);
            }
            else if (choice == "0")
            {
                Console.WriteLine("Программа завершена.");
                break;
            }
            else
            {
                Console.WriteLine("Неверный пункт меню.");
            }
        }
    }
}