using PPM.Administration.Domain.Exceptions;
using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.Domain.ValueObject;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Administration.Domain.Flows.BusinessRules
{
    public class StepPercentageRule : IBusinessRule
    {
        private readonly IEnumerable<Step> _steps;
        public PPMException Exception => new FlowException("The stap should be greater then last step", ErrorCodes.ValidationErrorStepPercentage);

        public StepPercentageRule(IEnumerable<Step> steps)
        {
            _steps = steps;
        }
        public bool IsBroken()
        {
            var percentage = Percentage.Zero;
            foreach(var step in _steps)
            {
                if (step.Percentage <= percentage)
                {
                    return true;
                }
                percentage = step.Percentage;
            }
            return false;
        }
    }
}
