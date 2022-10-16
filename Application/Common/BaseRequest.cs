using MediatR;

namespace Application.Common
{
    public class BaseRequest<T> : IRequest<T>
    {
    }
}