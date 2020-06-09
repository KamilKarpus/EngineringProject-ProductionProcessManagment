
namespace PPM.Locations.Domain
{
    public class LocationAttributes
    {
        public bool IsExamination { get; private set; }
        public bool IsHandleQrCode { get; private set; }

        public LocationAttributes(bool isExamination, bool isHandleQrCode)
        {
            IsExamination = isExamination;
            IsHandleQrCode = isHandleQrCode;
        }
    }
}
