// ECOMERCE/ECommerce.Domain/ValueObjects/Money.cs
namespace ECommerce.Domain.ValueObjects;

public class Money : IEquatable<Money>
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = "ARS";

    private Money() { } // Para EF Core

    public Money(decimal amount, string currency = "ARS")
    {
        if (amount < 0)
            throw new ArgumentException("El monto no puede ser negativo.");

        Amount = amount;
        Currency = currency;
    }

    public static Money FromDecimal(decimal amount) => new Money(amount);

    public override bool Equals(object? obj) => obj is Money other && Equals(other);

    public bool Equals(Money? other)
    {
        if (other is null) return false;
        return Amount == other.Amount && Currency == other.Currency;
    }

    public override int GetHashCode() => HashCode.Combine(Amount, Currency);

    public static bool operator ==(Money? left, Money? right) => left?.Equals(right) ?? right is null;
    public static bool operator !=(Money? left, Money? right) => !(left == right);
}