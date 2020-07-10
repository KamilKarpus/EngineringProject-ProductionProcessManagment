﻿using PPM.Domain;
using System;

namespace PPM.Administration.Domain.Flows.Events
{
    public class ProductionFlowStatusChangedDomainEvent : DomainEventBase
    {
        public Guid FlowId { get; set; }
        public string StatusName { get; set; }
        public int StatusId { get; set; }
    }
}