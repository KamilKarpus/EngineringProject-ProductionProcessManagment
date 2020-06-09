using PPM.Domain.Exceptions;

namespace PPM.Domain
{
    public interface IBusinessValidation<T> where T : class
    {
        PPMException Exception { get; }
        bool IsValid(T entity);
    }
}
