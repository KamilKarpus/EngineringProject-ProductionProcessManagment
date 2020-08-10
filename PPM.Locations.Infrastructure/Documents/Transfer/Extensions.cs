using PPM.Locations.Domain;

namespace PPM.Locations.Infrastructure.Documents.Transfer
{
    public static class Extensions
    {
        public static TransferRequestDocument ToDocument(this TransferRequest request)
        {
            return new TransferRequestDocument() 
            { 
                PackageId = request.PackageId,
                FinishDate = request.FinishDate,
                StartDate = request.StartDate,
                FromLocationId = request.FromLocationId,
                RequestedByUser = request.RequestedByUser,
                Id = request.Id,
                StatusId = request.Status.Id,
                ToLocationId = request.ToLocationId
            };
        }
        public static TransferRequest AsEntity(this TransferRequestDocument document)
        {
            return new TransferRequest(document.Id, document.PackageId,
                document.FromLocationId, document.ToLocationId,
                document.StatusId, document.RequestedByUser,
                document.StartDate, document.FinishDate);
        }
    }
}
