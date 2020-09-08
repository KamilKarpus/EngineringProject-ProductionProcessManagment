using System;
using System.Threading.Tasks;

namespace PPM.Printing.Domain.Repository
{
    public interface IPrintingRequestRepository
    {
        Task Add(PrintingRequest request);
        Task<PrintingRequest> GetById(Guid id);
        Task Update(PrintingRequest request);
    }
}
