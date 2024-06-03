namespace BlazorAuto.WithServices.ApplicationShared.Handlers
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
