using SimplifiedPicPay.Api.Modules.Users.Domain.Enums;

namespace SimplifiedPicPay.Api.Modules.Users.Domain;

public sealed class User : Entity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
    public decimal WalletBalance { get; set; } = 0m;
    public UserType Type { get; set; }
}
