using System;

namespace PPM.Printing.Domain
{
    public interface IPrintingRequestExistance
    {
        bool WasPrintingRequested(Guid packageId);
    }
}
