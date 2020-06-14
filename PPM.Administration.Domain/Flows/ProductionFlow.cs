using PPM.Administration.Domain.BusinessRules;
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
        public IReadOnlyCollection<Step> Steps
        {
            get => _steps;
        }
        public ProductionFlow(Guid id, string name)
        {
            Id = id;
            Name = name;
            Status = Status.Construction;
            RequiredDaysToFinish = 0;
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
        public void AddStep(Guid id, string name, int days, Location location, int percentage)
        {
            CheckRule(new IsFlowEditableRule(Status));
            int stepNumber = 1;
            if (_steps.Count > 0)
            {
                stepNumber = _steps.Max(p => p.StepNumber);
                stepNumber++;

            }
            RequiredDaysToFinish += days;
            var step = new Step(id, location,percentage,days, name, stepNumber);
            _steps.AddLast(step);
        }
        public void RemoveStep(Guid stepId)
        {
            CheckRule(new IsFlowEditableRule(Status));
            var step = _steps.FirstOrDefault(p => p.Id == stepId);
            _steps.Remove(step);
            RequiredDaysToFinish -= step.MaxDaysRequiredToFinish;
            RecalculateStepsNumbers();

        }
        private void RecalculateStepsNumbers()
        {
            CheckRule(new IsFlowEditableRule(Status));
            for (int i = 0; i < _steps.Count; i++)
            {
                _steps.ElementAt(i).SetSetNumber(i + 1);
            }

        }
        public void ChangeStepPosition(Guid stepId, int number)
        {
            CheckRule(new CanStepPositionBeChanged(_steps.Count, number));
           
            var stepValue = _steps.ElementAt((number - 1));
            var currentStepsCount = _steps.Count;
            var stepNode = _steps.Find(stepValue);
            var step = _steps.FirstOrDefault(p => p.Id == stepId);
            var index = _steps.TakeWhile(n => n.Id != stepId).Count();
            _steps.Remove(step);
            if (index >= number || number == 1)
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
