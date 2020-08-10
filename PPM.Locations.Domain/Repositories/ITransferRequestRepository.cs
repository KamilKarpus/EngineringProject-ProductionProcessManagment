using System;
using System.Threading.Tasks;

namespace PPM.Locations.Domain.Repositories
{
    public interface ITransferRequestRepository
    {
        Task Add(TransferRequest request);
        Task<TransferRequest> GetById(Guid id);
        Task Update(TransferRequest request);
    }
}
