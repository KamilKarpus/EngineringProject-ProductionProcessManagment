using PPM.Domain;
using PPM.Printing.Domain.Event;
using PPM.Printing.Domain.Rules;
using System;

namespace PPM.Printing.Domain
{
    public class PrintingRequest : Entity
    {
        public Guid Id { get; private set; }
        public Guid PackageId { get; private set; }
        public DateTime RequestedDate { get; private set; }
        public DateTime ProcessedDate { get; private set; }
        public PrintingStatus Status { get; private set; }

        public PrintingRequest(Guid id, Guid packageId, DateTime requestedDate, DateTime processedDate,
            PrintingStatus status)
        {
            Id = id;
            PackageId = packageId;
            RequestedDate = requestedDate;
            ProcessedDate = processedDate;
            Status = status;
        }

        public PrintingRequest(Guid id, Guid packageId, DateTime requestedDate,
            PrintingStatus status, IPackageExistance packageExistance,
            IPrintingRequestExistance existance)
        {
            CheckRule(new PackageExistanceBusinessRule(packageId, packageExistance));
            CheckRule(new PrintingRequestExistanceRule(existance, packageId));
            Id = id;
            PackageId = packageId;
            RequestedDate = requestedDate;
            Status = status;
            var @event = new PrintingRequestCreatedDomainEvent()
            {
                RequestId = Id,
                PackageId = PackageId,
                RequestDate = RequestedDate,
                Status = Status.Id,
                StatusName = Status.Name
            };
            AddDomainEvent(@event);
        }
        public static PrintingRequest Create(Guid id, Guid packageId, IPackageExistance packageExistance,
            IPrintingRequestExistance existance)
        {
            return new PrintingRequest(id, packageId, DateTime.Now, PrintingStatus.Requested, packageExistance, existance);
        }

        public void Fail()
        {
            Status = PrintingStatus.Failed;

            var @event = new FailStatusDomainEvent() 
            { 
                RequestId = Id,
                StatusId = Status.Id,
                StatusName = Status.Name
            };
            AddDomainEvent(@event);
           
        }

        public void Successful(string fileUrl, Guid orderId)
        {
            ProcessedDate = DateTime.Now;
            Status = PrintingStatus.Successful;
            var @event = new SuccessfulStatusDomainEvent()
            {
                RequestId = Id,
                StatusId = Status.Id,
                StatusName = Status.Name,
                ProcessedDate = ProcessedDate,
                FileUrl = fileUrl,
                OrderId = orderId
            };
            AddDomainEvent(@event);
        }
    }
}
