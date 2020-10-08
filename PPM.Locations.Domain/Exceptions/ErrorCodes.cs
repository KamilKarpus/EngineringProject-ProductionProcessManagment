using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Locations.Domain.Exceptions
{
    public enum ErrorCodes
    {
        LocatioNameIsTaken = 2001,
        LocationShortNameUnique = 2002,
        PackageCannotBeMoved = 2003,
        TransferNotFound = 2004,
        LocationNotFound = 2005,
        PackageNotFound = 2006,
        FlowNotFound = 2007
    }
}
