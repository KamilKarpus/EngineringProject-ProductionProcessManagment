
namespace PPM.Locations.Domain
{
    public class LocationAttributes
    {
        public bool IsHandleQrCode { get; private set; }

        public LocationAttributes(bool isHandleQrCode)
        {
            IsHandleQrCode = isHandleQrCode;
        }
    }
}
