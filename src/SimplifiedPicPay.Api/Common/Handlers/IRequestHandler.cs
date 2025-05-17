namespace SimplifiedPicPay.Api.Common.Handlers;

public interface IRequestHandler<in TRequest>
{
    Task<Result> HandleAsync(TRequest request, CancellationToken ct = default);
}

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken ct = default);
}
