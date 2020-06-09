using PPM.Domain.Exceptions;

namespace PPM.Domain
{
    public interface IBusinessRule
    {
        PPMException Exception { get; }
        bool IsBroken();
    }
}
