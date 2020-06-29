using PPM.Administration.Domain.BusinessRules;
using PPM.Administration.Domain.Flows.BusinessRules;
using PPM.Administration.Domain.Flows.Events;
using PPM.Administration.Domain.Flows.Events.Steps;
using PPM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Administration.Domain.Flows
{
    public class ProductionFlow
        : Entity, IAggregateRoot
    {
        private LinkedList<Step> _steps;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int RequiredDaysToFinish { get; private set; }
        public Status Status { get; private set; }
        public IReadOnlyCollection<Step> Steps
        {
            get => _steps.OrderBy(p=>p.Number).ToList();
        }
        public ProductionFlow(Guid id, string name)
        {
            Id = id;
            Name = name;
            Status = Status.Construction;
            RequiredDaysToFinish = 0;
            _steps = new LinkedList<Step>();

            var @event = new ProductionFlowCreatedDomainEvent() 
            { 
                ProductionId = Id,
                Name = Name,
                StatusName = Status.Name,
                StatusId = Status.Id,
                RequiredDaysToFinish = RequiredDaysToFinish
            };
            AddDomainEvent(@event);
        }
        public ProductionFlow(Guid id, string name, int requiredDaysToFinish, int statusId,
                LinkedList<Step> steps)
        {
            Id = id;
            Name = name;
            RequiredDaysToFinish = requiredDaysToFinish;
            Status = Status.From(statusId);
            _steps = steps;

        }
        public void AddStep(Guid id, string name, int days, Guid locationId, int percentage, ILocationExistence locationExistence,
            IFirstLocationSupportPrinting supportPrinting)
        {
            CheckRule(new IsFlowEditableRule(Status));
            CheckRule(new LocationMustExistsRule(locationExistence, locationId));
            CheckRule(new FirstLocationMustSupportPrintingRule(_steps.Count, supportPrinting, locationId));
            int stepNumber = 1;
            if (_steps.Count > 0)
            {
                stepNumber = _steps.Max(p => p.Number).GetStepAfter().Value;
            }
            RequiredDaysToFinish += days;
            var step = new Step(id, locationId, percentage, days, name, stepNumber);
            _steps.AddLast(step);

            var @event = new StepAddedDomainEvent()
            {
                FlowId = Id,
                Steps = _steps.ToInfoArray(),
                Days = RequiredDaysToFinish
            };

            AddDomainEvent(@event);
        }
        public void RemoveStep(Guid stepId)
        {
            CheckRule(new IsFlowEditableRule(Status));
            var step = _steps.FirstOrDefault(p => p.Id == stepId);
            _steps.Remove(step);
            RequiredDaysToFinish -= step.MaxDaysRequiredToFinish;
            RecalculateStepsNumbers();

            var @event = new StepAddedDomainEvent()
            {
                FlowId = Id,
                Steps = _steps.ToInfoArray()
            };

            AddDomainEvent(@event);

        }
        private void RecalculateStepsNumbers()
        {
            CheckRule(new IsFlowEditableRule(Status));
            for (int i = 0; i < _steps.Count; i++)
            {
                _steps.ElementAt(i).ChangeStepNumber(i + 1);
            }

        }
        public void ChangeStepPosition(Guid stepId, int number)
        {
            CheckRule(new CanStepPositionBeChanged(_steps.Count, number));

            var stepNumber = StepNumber.From(number);
            var step = _steps.FirstOrDefault(p => p.Id == stepId);
            _steps.Remove(step);
            var stepValue = _steps.ElementAt(stepNumber.GetStepBefore().Value);
            var stepNode = _steps.Find(stepValue);
            var nodeIndex = _steps.TakeWhile(n => n.Id != stepId).Count();

            if (stepNumber.IsLowerThen(nodeIndex) ||  stepNumber.IsFirstStep())
            {
                _steps.AddBefore(stepNode, step);
            }
            else
            {
                _steps.AddAfter(stepNode, step);
            }
            RecalculateStepsNumbers();
        }

        public void ReadyToUse()
        {
            CheckRule(new IsFlowEditableRule(Status));
            Status = Status.ReadyToUse;
        }
    }
}
