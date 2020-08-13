using PPM.Locations.Application.Configuration.Queries;
using PPM.Locations.Application.ReadModels;
using System;

namespace PPM.Locations.Application.Queries.Transfer
{
    public class GetTransferInfoQuery : IQuery<TransferReadModel>
    {
        public Guid TransferId { get; set; }
    }
}
