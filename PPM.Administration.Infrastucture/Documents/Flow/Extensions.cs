﻿using PPM.Administration.Domain.Flows;
using PPM.Administration.Infrastucture.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Administration.Infrastucture.Documents.Flow
{
    public  static class Extensions
    {
        public static ProductionFlowDocument ToDocument(this ProductionFlow flow)
        => new ProductionFlowDocument()
        {
            Id = flow.Id,
            RequiredDaysToFinish = flow.RequiredDaysToFinish,
            Name = flow.Name,
            Status = flow.Status.Id,
            Steps = flow.GetFieldValue<LinkedList<Step>>("_steps")?.Select(p=>p.ToDocument()).ToArray()
        };
        public static StepDocument ToDocument(this Step step)
            => new StepDocument()
            {
                Id = step.Id,
                MaxDaysRequiredToFinish = step.MaxDaysRequiredToFinish,
                Location = new LocationDocument() { Id = step.Location.Id, Name = step.Location.Name },
                StepName = step.StepName,
                Percentage = step.Percentage.Value
            };

        public static Step ToEntity(this StepDocument document)
           => new Step(document.Id, new Location(document.Location.Id, document.Location.Name),
               document.Percentage, document.MaxDaysRequiredToFinish, document.StepName, document.StepNumber);
           
        public static ProductionFlow ToEntity(this ProductionFlowDocument flow)
        {
            var enumerableSteps = flow.Steps?.Select(p => p?.ToEntity());
            var steps = new LinkedList<Step>(enumerableSteps);
            return new ProductionFlow(flow.Id, flow.Name, flow.RequiredDaysToFinish, flow.Status, steps);
        }
        
            
        
    }
}