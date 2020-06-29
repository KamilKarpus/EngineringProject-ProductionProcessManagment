using PPM.Administration.Domain.Exceptions;
using PPM.Domain;
using PPM.Domain.Exceptions;
using System;

namespace PPM.Administration.Domain.Flows.BusinessRules
{
    public class FirstLocationMustSupportPrintingRule : IBusinessRule
    {
        private int _stepCount;
        private IFirstLocationSupportPrinting _locationPrinting;
        private Guid _locationId;
        public FirstLocationMustSupportPrintingRule(int stepCount, IFirstLocationSupportPrinting locationSupport,
            Guid locationId)
        {
            _stepCount = stepCount;
            _locationPrinting = locationSupport;
            _locationId = locationId;
        }
        public PPMException Exception => new FlowException("First location of flow should support printing.", ErrorCodes.FirstLocationMustSupportPrinting);

        public bool IsBroken()
        {
            return _stepCount == 0 && _locationPrinting.IsSupport(_locationId) == false;
        }
    }
}
