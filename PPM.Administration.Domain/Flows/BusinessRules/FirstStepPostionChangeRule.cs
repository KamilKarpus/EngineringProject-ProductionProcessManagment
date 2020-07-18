using PPM.Administration.Domain.Exceptions;
using PPM.Domain;
using PPM.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Administration.Domain.Flows.BusinessRules
{
    public class FirstStepPostionChangeRule : IBusinessRule
    {
        private IFirstLocationSupportPrinting _supportPrinting;
        private IEnumerable<Step> _steps;
        public PPMException Exception => throw new FlowException("First location must support printing", ErrorCodes.FirstLocationMustSupportPrinting);
        public FirstStepPostionChangeRule(IFirstLocationSupportPrinting supportPrinting,
            IEnumerable<Step> steps)
        {
            _supportPrinting = supportPrinting;
            _steps = steps;
        }
        public bool IsBroken()
        {
            var step = _steps.FirstOrDefault(p => p.Number == StepNumber.First);
            if(step != null)
            {
                return !_supportPrinting.IsSupport(step.LocationId);
            }
            return false;
        }
    }
}
