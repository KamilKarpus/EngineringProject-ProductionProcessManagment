using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Printing.Domain;
using PPM.Printing.Infrastructure.Documents;
using System;

namespace PPM.Printing.Infrastructure.Domain
{
    public class PrintingRequestExistance : IPrintingRequestExistance
    {
        private readonly IMongoRepository<PrintingRequestDocument> _repository;
        public PrintingRequestExistance(IMongoRepository<PrintingRequestDocument> repository)
        {
            _repository = repository;
        }
        public bool WasPrintingRequested(Guid packageId)
        {
            var result = _repository.ExistsAsync(p => p.PackageId == packageId);
            result.Wait();
            return result.Result;
        }
    }
}
