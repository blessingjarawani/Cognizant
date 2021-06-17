
namespace Cognizant.Infrastructure.Shared.Responses.Abstracts
{
   public interface IResponse <T> : IBaseResponse
    {
        T Result { get; }
    }

}
