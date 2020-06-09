
using PPM.Administration.Domain.Exceptions;
using PPM.Administration.Domain.Flows;
using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.Domain.ValueObject;
using System.Linq;

namespace PPM.Administration.Domain.Validators
{
    public class ProductionFlowValidator : IBusinessValidation<ProductionFlow>
    {
        private string _message;
        private ErrorCodes _code;
        public PPMException Exception => new ValidatorException(_message, _code);

        public bool IsValid(ProductionFlow entity)
        {
            var lastStep = Percentage.Zero;
            int daysCounter = 0;
            var maxStepPercentage = entity.Steps.Max(p=>p.Percentage.Value);
            if (maxStepPercentage != Percentage.Max.Value)
            {
                SetMessage("Max pecentage value should be 100%", ErrorCodes.ValidationErrorMaxPercentage);
                return false;
            }
            foreach (var step in entity.Steps)
            {
                if (step.Percentage < lastStep)
                {
                    SetMessage($"The stap {step.StepName} should be greater then last step" , ErrorCodes.ValidationErrorStepPercentage);
                    return false;
                }
                lastStep = step.Percentage;
                daysCounter += step.MaxDaysRequiredToFinish;
            }
            if(daysCounter != entity.RequiredDaysToFinish)
            {
                SetMessage("The sum of required days to finish is not equal to Max Days Required To Finish", ErrorCodes.ValidationErrorMaxDaysError);
                return false;
            }
            return true;
        }

        private void SetMessage(string message, ErrorCodes code)
        {
            _message = message;
            _code = code;
        }

    }
}
