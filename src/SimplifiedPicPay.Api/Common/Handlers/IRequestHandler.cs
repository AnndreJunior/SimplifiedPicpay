namespace SimplifiedPicPay.Api.Common.Handlers;

public interface IRequestHandler<in TRequest, TResponse> where TResponse : Result
{
    Task<TResponse> HandleAsync(TRequest request, CancellationToken ct = default);
}
