using System;

public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата {amount} с использованием кредитной карты.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата {amount} через PayPal.");
    }
}

public class CryptoPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата {amount} с использованием криптовалюты.");
    }
}

public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ExecutePayment(decimal amount)
    {
        _paymentStrategy.Pay(amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        PaymentContext paymentContext = new PaymentContext();

        paymentContext.SetPaymentStrategy(new CreditCardPayment());
        paymentContext.ExecutePayment(100);

        paymentContext.SetPaymentStrategy(new PayPalPayment());
        paymentContext.ExecutePayment(200);

        paymentContext.SetPaymentStrategy(new CryptoPayment());
        paymentContext.ExecutePayment(300);
    }
}
