using PPM.Printing.Domain;

namespace PPM.Printing.Infrastructure.Documents
{
    public static class Extensions
    {
        public static PrintingRequestDocument ToDocument(this PrintingRequest request)
        {
            return new PrintingRequestDocument()
            {
                Id = request.Id,
                ProcessedDate = request.ProcessedDate,
                RequestedDate = request.RequestedDate,
                PackageId = request.PackageId,
                Status = request.Status.Id
            };
        }

        public static PrintingRequest AsEntity(this PrintingRequestDocument document)
        {
            return new PrintingRequest(document.Id,
                document.PackageId, document.RequestedDate, document.ProcessedDate,
                PrintingStatus.Of(document.Status));
        }

        public static PackageDocument ToDocument(this Package package)
        {
            return new PackageDocument()
            {
                OrderId = package.OrderId,
                Id = package.Id
            };
        }
        public static Package AsEntity(this PackageDocument package)
        {
            return new Package(package.Id, package.OrderId);
        }
    }
}
