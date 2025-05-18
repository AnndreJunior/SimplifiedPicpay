using SimplifiedPicPay.Api.Modules.Users.Domain;

namespace SimplifiedPicPay.Api.Modules.Transfers.Domain;

public sealed class Transfer : Entity
{
    public long PayerId { get; set; }
    public User Payer { get; set; } = null!;
    public long PayeeId { get; set; }
    public User Payee { get; set; } = null!;
    public decimal Value { get; set; }
    public DateTime TransferDate { get; set; } = DateTime.UtcNow;
}
