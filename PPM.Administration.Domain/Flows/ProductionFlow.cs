using PPM.Administration.Domain.BusinessRules;
using PPM.Administration.Domain.Flows.BusinessRules;
using PPM.Administration.Domain.Flows.Events;
using PPM.Administration.Domain.Flows.Events.Steps;
using PPM.Administration.Domain.Validators;
using PPM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Administration.Domain.Flows
{
    public class ProductionFlow : Entity, IAggregateRoot
    {
        private LinkedList<Step> _steps;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int RequiredDaysToFinish { get; private set; }
        public Status Status { get; private set; }
        public bool IsValid { get; private set; }
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
            IsValid = false;
            var @event = new ProductionFlowCreatedDomainEvent() 
            { 
                ProductionId = Id,
                Name = Name,
                StatusName = Status.Name,
                StatusId = Status.Id,
                RequiredDaysToFinish = RequiredDaysToFinish,
                IsValid = IsValid
            };
            AddDomainEvent(@event);
        }
        public ProductionFlow(Guid id, string name, int requiredDaysToFinish, int statusId,
                LinkedList<Step> steps, bool isValid)
        {
            Id = id;
            Name = name;
            RequiredDaysToFinish = requiredDaysToFinish;
            Status = Status.From(statusId);
            _steps = steps;
            IsValid = isValid;

        }
        public void AddStep(Guid id, string name, int days, Guid locationId, int percentage, ILocationExistence locationExistence,
            IFirstLocationSupportPrinting supportPrinting)
        {
            CheckRule(new IsFlowEditableRule(Status));
            CheckRule(new LocationMustExistsRule(locationExistence, locationId));
            CheckRule(new FirstLocationMustSupportPrintingRule(_steps.Count, supportPrinting, locationId));
            CheckRule(new StepMustHaveUniqueName(_steps, name));
            
            int stepNumber = 1;
            if (_steps.Count > 0)
            {
                stepNumber = _steps.Max(p => p.Number).GetStepAfter().Value;
            }
            RequiredDaysToFinish += days;
            var step = new Step(id, locationId, percentage, days, name, stepNumber);
            _steps.AddLast(step);
            ValidateFlow();
            CheckRule(new StepPercentageRule(_steps));
            var @event = new StepAddedDomainEvent()
            {
                FlowId = Id,
                Steps = _steps.ToInfoArray(),
                Days = RequiredDaysToFinish,
                IsValid = IsValid
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
                Steps = _steps.ToInfoArray(),
                IsValid = IsValid
            };

            AddDomainEvent(@event);


        }
        private void RecalculateStepsNumbers()
        {
            CheckRule(new IsFlowEditableRule(Status));
            ValidateFlow();
            var percentages = _steps.Select(p => p.Percentage).OrderBy(p => p.Value).ToArray();
            for (int i = 0; i < _steps.Count; i++)
            {
                var percentage = percentages[i];
                _steps.ElementAt(i).ChangeStepNumber(i + 1, percentage);
            }

        }
        private void ValidateFlow()
        {
            var validator = new ProductionFlowValidator();
            IsValid = validator.IsValid(this);
        }
        public void ChangeStepPosition(Guid stepId, int number, IFirstLocationSupportPrinting supportPrinting)
        {
            CheckRule(new CanStepPositionBeChanged(_steps.Count, number));
            CheckRule(new IsFlowEditableRule(Status));
            var step = _steps.FirstOrDefault(p => p.Id == stepId);
            var stepNumber = StepNumber.From(number);
            _steps.Remove(step);
            var takenStepNumberValue = stepNumber.GetStepBefore().Value;
            var stepValue = _steps.ElementAt(takenStepNumberValue - 1);
            var stepNode = _steps.Find(stepValue);
            var nodeIndex = _steps.TakeWhile(n => n.Id != stepId).Count();

            if (stepNumber.IsFirstStep())
            {
                _steps.AddBefore(stepNode, step);
            }
            else
            {
                _steps.AddAfter(stepNode, step);
            }
            RecalculateStepsNumbers();

            CheckRule(new FirstStepPostionChangeRule(supportPrinting, _steps));

            var @event = new StepPositionChangedDomainEvent()
            {
                FlowId = Id,
                Steps = _steps.ToInfoArray(),
                IsValid = IsValid
            };

            AddDomainEvent(@event);
        }

        public void ReadyToUse()
        {
            CheckRule(new IsFlowEditableRule(Status));
            CheckRule(new StepMustBeValidRule(IsValid));
            Status = Status.ReadyToUse;

            var @event = new ProductionFlowStatusChangedDomainEvent
            {
                FlowId = Id,
                StatusId = Status.Id,
                StatusName = Status.Name,
                FlowName = Name,
                Steps = _steps.ToInfoArray()
            };
            AddDomainEvent(@event);

        }

        public void Construction()
        {
            Status = Status.Construction;

            var @event = new ProductionFlowStatusChangedDomainEvent
            {
                FlowId = Id,
                StatusId = Status.Id,
                StatusName = Status.Name,
                FlowName = Name,
                Steps = _steps.ToInfoArray()
            };
            AddDomainEvent(@event);
        }
    }
}
