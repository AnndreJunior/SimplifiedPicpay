namespace SimplifiedPicPay.Api.Common.Entities;

public abstract class Entity
{
    public long Id { get; init; }

    public override bool Equals(object? obj)
    {
        return obj is Entity other && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
