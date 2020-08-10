using PPM.Domain;
using PPM.Locations.Domain.Transfer;
using PPM.Locations.Domain.Transfer.Events;
using PPM.Locations.Domain.Transfer.Rules;
using System;

namespace PPM.Locations.Domain
{
    public class TransferRequest : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid PackageId { get; private set; }
        public Guid FromLocationId { get; private set; }
        public Guid ToLocationId { get; private set; }
        public TransferStatus Status { get; private set; }
        public Guid RequestedByUser { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinishDate { get; private set; }

        public TransferRequest(Guid id, Guid packageId, Guid fromLocationId, 
            Guid toLocationId, int status, Guid requestedByUser, 
            DateTime startDate, DateTime finishDate)
        {
            Id = id;
            PackageId = packageId;
            FromLocationId = fromLocationId;
            ToLocationId = toLocationId;
            Status = TransferStatus.From(status);
            RequestedByUser = requestedByUser;
            StartDate = startDate;
            FinishDate = finishDate;
        }

        public TransferRequest(Guid id, Guid packageId, Guid fromLocationId,
            Guid toLocationId, int status, Guid requestedByUser,
            DateTime startDate, IGetLocationState locationState, ILocationExistance locationExistance)
        {
            CheckRule(new LocationMustExistsRule(locationExistance, fromLocationId));
            CheckRule(new LocationMustExistsRule(locationExistance, toLocationId));
            CheckRule(new CanPackageBeMovedToLocationRule(locationState, toLocationId));

            Id = id;
            PackageId = packageId;
            FromLocationId = fromLocationId;
            ToLocationId = toLocationId;
            Status = TransferStatus.From(status);
            RequestedByUser = requestedByUser;
            StartDate = startDate;

            var @event = new TransferCreatedDomainEvent()
            {
                TransferId = id,
                PackageId = packageId,
                FromLocationId = fromLocationId,
                ToLocationId = toLocationId,
                Status = status,
                RequestedByUser = requestedByUser,
                StartDate = startDate,
            };
            AddDomainEvent(@event);
        }

        public static TransferRequest Create(Guid id, Guid packageId, Guid fromLocationId,
            Guid toLocationId, Guid requestedByUser, IGetLocationState locationState,
            ILocationExistance locationExistance)
        {
            return new TransferRequest(id, packageId, fromLocationId, toLocationId,TransferStatus.InProgressId,
                requestedByUser, DateTime.Now, locationState, locationExistance);
        }
        public void Finish()
        {
            Status = TransferStatus.Completed;
            FinishDate = DateTime.Now;

            var @event = new TransferFinishedDomainEvent()
            {
                TransferId = Id,
                FromLocationId = FromLocationId,
                ToLocationId = ToLocationId,
                PackageId = PackageId,
                FinishDate = FinishDate,
                Status = TransferStatus.CompletedId,
            };

            AddDomainEvent(@event);
        }
    }
}
