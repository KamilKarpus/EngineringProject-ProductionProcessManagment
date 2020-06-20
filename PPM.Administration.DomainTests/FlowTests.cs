using Moq;
using PPM.Administration.Domain.Flows;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PPM.Administration.DomainTests
{   
    public class FlowTests
    {
        private readonly ProductionFlow _flow;
        private readonly Mock<ILocationExistence> _locationExistence;
        public FlowTests()
        {
            _flow = new ProductionFlow(Guid.NewGuid(), "Test");
            _locationExistence = new Mock<ILocationExistence>();
            _locationExistence.Setup(p => p.IsExists(It.IsAny<Guid>())).Returns(true);
            _flow.AddStep(Guid.NewGuid(), "Test", 10, Guid.NewGuid(), 10, _locationExistence.Object);
            _flow.AddStep(Guid.NewGuid(), "Test2", 10, Guid.NewGuid(), 25, _locationExistence.Object);
            _flow.AddStep(Guid.NewGuid(), "Test3", 10, Guid.NewGuid(), 50, _locationExistence.Object);
            _flow.AddStep(Guid.NewGuid(), "Test4", 10, Guid.NewGuid(), 100, _locationExistence.Object);
        }
        [Fact]
        public void AddStep_Should_Add_New_Steps()
        {
            Assert.Collection(_flow.Steps, item => Assert.Equal(1, item.Number.Value),
                                           item => Assert.Equal(2, item.Number.Value),
                                           item => Assert.Equal(3, item.Number.Value),
                                           item => Assert.Equal(4, item.Number.Value));
        }


        [Fact]
        public void DeleteStep_Should_Sucessfully_DeleteStep()
        {
            var step = _flow.Steps.FirstOrDefault(p => p.StepName == "Test2");
            _flow.RemoveStep(step.Id);

            Assert.Collection(_flow.Steps, item => Assert.Equal(1, item.Number.Value),
                                           item => Assert.Equal(2, item.Number.Value),
                                           item => Assert.Equal(3, item.Number.Value));

        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(3)]
        public void ChangeStepPostion_ASC_Should_ChangePosition(int stepData)
        {
            Assert.Collection(_flow.Steps , item => Assert.Equal(1, item.Number.Value),
                                           item => Assert.Equal(2, item.Number.Value),
                                           item => Assert.Equal(3, item.Number.Value),
                                           item => Assert.Equal(4, item.Number.Value));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ChangeStepPostion_DESC_Should_ChangePosition(int stepData)
        {

            var step = _flow.Steps.FirstOrDefault(p => p.StepName == "Test2");
            _flow.ChangeStepPosition(step.Id, stepData);
            Assert.Equal(stepData, step.Number.Value);

            Assert.Collection(_flow.Steps, item => Assert.Equal(1, item.Number.Value),
                                           item => Assert.Equal(2, item.Number.Value),
                                           item => Assert.Equal(3, item.Number.Value),
                                           item => Assert.Equal(4, item.Number.Value));

        }
    }
}
