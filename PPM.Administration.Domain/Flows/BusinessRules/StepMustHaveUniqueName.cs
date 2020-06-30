using PPM.Administration.Domain.Exceptions;
using PPM.Domain;
using PPM.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Administration.Domain.Flows.BusinessRules
{
    public class StepMustHaveUniqueName : IBusinessRule
    {
        private readonly IEnumerable<Step> _steps;
        private readonly string _name;
        public StepMustHaveUniqueName(IEnumerable<Step> steps,
            string name)
        {
            _steps = steps;
            _name = name;
        }
        public PPMException Exception => new FlowException("Step name must be unique", ErrorCodes.StepNameMustBeUnique);

        public bool IsBroken()
        {
            return _steps.FirstOrDefault(p => p.StepName == _name) != null;
        }
    }
}
