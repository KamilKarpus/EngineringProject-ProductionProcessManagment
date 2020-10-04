using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.Printing.Domain.Exception;
using System;

namespace PPM.Printing.Domain.Rules
{
    public class PrintingRequestExistanceRule : IBusinessRule
    {
        private readonly IPrintingRequestExistance _printingRequestExistance;
        private readonly Guid _packageId;
        public PrintingRequestExistanceRule(IPrintingRequestExistance printingRequestExistance, 
            Guid packageId)
        {
            _printingRequestExistance = printingRequestExistance;
            _packageId = packageId;
        }
        public PPMException Exception => new PrintingException("Printing is requested", ErrorCodes.PrintingWasRequested);

        public bool IsBroken()
        {
            return _printingRequestExistance.WasPrintingRequested(_packageId);
        }
    }
}
