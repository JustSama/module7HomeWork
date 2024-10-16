using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(decimal newRate);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class CurrencyExchange : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private decimal _rate;

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_rate);
        }
    }

    public void SetRate(decimal rate)
    {
        _rate = rate;
        Notify();
    }
}

public class Investor : IObserver
{
    public void Update(decimal newRate)
    {
        Console.WriteLine($"Инвестор: новый курс валюты {newRate}");
    }
}

public class Bank : IObserver
{
    public void Update(decimal newRate)
    {
        Console.WriteLine($"Банк: обновление курса валюты {newRate}");
    }
}

public class NewsAgency : IObserver
{
    public void Update(decimal newRate)
    {
        Console.WriteLine($"Новостное агентство: курс валюты изменился на {newRate}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        CurrencyExchange currencyExchange = new CurrencyExchange();

        Investor investor = new Investor();
        Bank bank = new Bank();
        NewsAgency newsAgency = new NewsAgency();

        currencyExchange.Attach(investor);
        currencyExchange.Attach(bank);
        currencyExchange.Attach(newsAgency);

        currencyExchange.SetRate(1.23m);
        currencyExchange.SetRate(1.45m);

        currencyExchange.Detach(bank);
        currencyExchange.SetRate(1.67m);
    }
}
