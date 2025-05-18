namespace SimplifiedPicPay.Api.Common.Logic;

public record Error(string Code, string Message, ErrorType Type)
{
    public static readonly Error None = new(
        string.Empty,
        string.Empty,
        ErrorType.Failure);
    public static readonly Error NullValue = new(
        "Null Value",
        "The provided value is nul",
        ErrorType.Failure);
}
