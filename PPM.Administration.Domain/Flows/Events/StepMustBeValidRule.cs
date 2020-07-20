using PPM.Administration.Domain.Exceptions;
using PPM.Domain;
using PPM.Domain.Exceptions;

namespace PPM.Administration.Domain.Flows.Events
{
    public class StepMustBeValidRule : IBusinessRule
    {
        public PPMException Exception => new FlowException("Flow must be valid", ErrorCodes.FlowMustBeValid);

        private bool _valid;
        public StepMustBeValidRule(bool valid)
        {
            _valid = valid;
        }
        public bool IsBroken()
        {
            return !_valid;
        }
    }
}
