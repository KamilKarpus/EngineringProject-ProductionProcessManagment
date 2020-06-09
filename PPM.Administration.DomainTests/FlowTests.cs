using PPM.Administration.Domain.Flows;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PPM.Administration.DomainTests
{
    public class FlowTests
    {
        [Fact]
        public void AddStep_Should_Add_New_Steps()
        {
            var flow = new ProductionFlow(Guid.NewGuid(), "Test", 10, 1, new LinkedList<Step>());
            flow.AddStep(Guid.NewGuid(), "Test", 10, new Location(), 10);
            flow.AddStep(Guid.NewGuid(), "Test2", 10, new Location(), 25);
            flow.AddStep(Guid.NewGuid(), "Test3", 10, new Location(), 50);
            flow.AddStep(Guid.NewGuid(), "Test4", 10, new Location(), 100);

            Assert.Collection(flow.Steps,  item => Assert.Equal(1, item.StepNumber),
                                           item => Assert.Equal(2, item.StepNumber),
                                           item => Assert.Equal(3, item.StepNumber),
                                           item => Assert.Equal(4, item.StepNumber));
        }


        [Fact]
        public void DeleteStep_Should_Sucessfully_DeleteStep()
        {
            var flow = new ProductionFlow(Guid.NewGuid(), "Test", 10, 1, new LinkedList<Step>());
            var id = Guid.NewGuid();
            flow.AddStep(id, "Test", 10, new Location(), 10);
            flow.AddStep(Guid.NewGuid(), "Test2", 10, new Location(), 25);
            flow.AddStep(Guid.NewGuid(), "Test3", 10, new Location(), 50);
            flow.AddStep(Guid.NewGuid(), "Test4", 10, new Location(), 100);

            flow.RemoveStep(id);

            Assert.Collection(flow.Steps, item => Assert.Equal(1, item.StepNumber),
                                           item => Assert.Equal(2, item.StepNumber),
                                           item => Assert.Equal(3, item.StepNumber));
           
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(3)]
        public void ChangeStepPostion_ASC_Should_ChangePosition(int stepData)
        {
            var flow = new ProductionFlow(Guid.NewGuid(), "Test", 10, 1, new LinkedList<Step>());
            var id = Guid.NewGuid();
            flow.AddStep(Guid.NewGuid(), "Test", 10, new Location(), 10);
            flow.AddStep(id, "Test2", 10, new Location(), 25);
            flow.AddStep(Guid.NewGuid(), "Test3", 10, new Location(), 50);
            flow.AddStep(Guid.NewGuid(), "Test4", 10, new Location(), 100);

            flow.ChangeStepPosition(id, stepData);
            var step = flow.Steps.FirstOrDefault(p => p.Id == id);
            Assert.Equal(stepData, step.StepNumber);

            Assert.Collection(flow.Steps.OrderBy(p=>p.StepNumber),  item => Assert.Equal(1, item.StepNumber),
                                           item => Assert.Equal(2, item.StepNumber),
                                           item => Assert.Equal(3, item.StepNumber),
                                           item => Assert.Equal(4, item.StepNumber));

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ChangeStepPostion_DESC_Should_ChangePosition(int stepData)
        {
            var flow = new ProductionFlow(Guid.NewGuid(), "Test", 10, 1, new LinkedList<Step>());
            var id = Guid.NewGuid();
            flow.AddStep(Guid.NewGuid(), "Test", 10, new Location(), 10);
            flow.AddStep(Guid.NewGuid(), "Test2", 10, new Location(), 25);
            flow.AddStep(Guid.NewGuid(), "Test3", 10, new Location(), 50);
            flow.AddStep(id, "Test4", 10, new Location(), 100);

            flow.ChangeStepPosition(id, stepData);
            var step = flow.Steps.FirstOrDefault(p => p.Id == id);
            Assert.Equal(stepData, step.StepNumber);

            Assert.Collection(flow.Steps.OrderBy(p => p.StepNumber), item => Assert.Equal(1, item.StepNumber),
                                           item => Assert.Equal(2, item.StepNumber),
                                           item => Assert.Equal(3, item.StepNumber),
                                           item => Assert.Equal(4, item.StepNumber));

        }
    }
}
