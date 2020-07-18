
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
            var maxPercentage = entity.Steps.Max(p => p.Percentage);
            if(maxPercentage != Percentage.Max)
            {
                SetMessage("Last stap must have value of 100%", ErrorCodes.ValidationErrorMaxPercentage);
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
