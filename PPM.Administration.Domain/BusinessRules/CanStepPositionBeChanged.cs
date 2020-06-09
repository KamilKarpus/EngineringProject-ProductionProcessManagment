using PPM.Administration.Domain.Exceptions;
using PPM.Domain;
using PPM.Domain.Exceptions;

namespace PPM.Administration.Domain.BusinessRules
{
    public class CanStepPositionBeChanged : IBusinessRule
    {
        private int _stepMaxCount;
        private int _stepNumber;
        public CanStepPositionBeChanged(int stepMaxCounter, int stepNumber)
        {
            _stepMaxCount = stepMaxCounter;
            _stepNumber = stepNumber;
        }
        public PPMException Exception => new FlowException("The step is out of range", ErrorCodes.StepPositionCannotBeChanged);

        public bool IsBroken()
        {
           if(_stepMaxCount < _stepNumber)
           {
                return true;
           }
           return false;
        }
    }
}
