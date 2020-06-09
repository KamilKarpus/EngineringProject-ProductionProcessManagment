using PPM.Administration.Domain.Exceptions;
using PPM.Administration.Domain.Flows;
using PPM.Domain;
using PPM.Domain.Exceptions;
using System;

namespace PPM.Administration.Domain.BusinessRules
{
    public class IsFlowEditableRule : IBusinessRule
    {
        private Status _flowStatus;

        public PPMException Exception => new FlowException("The current flow is not editable", ErrorCodes.FlowIsNotEditable);

        public IsFlowEditableRule(Status status)
        {
            _flowStatus = status;
        }
        public bool IsBroken()
        {
            if (_flowStatus != Status.Construction)
                return true;
            return false;
        }
    }
}
