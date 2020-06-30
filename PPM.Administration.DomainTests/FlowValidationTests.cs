using Moq;
using PPM.Administration.Domain.Exceptions;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Validators;
using System;
using Xunit;

namespace PPM.Administration.DomainTests
{
    public class FlowValidationTests
    {
        private readonly ProductionFlow _flow;
        private readonly Mock<ILocationExistence> _locationExistence;
        private readonly Mock<IFirstLocationSupportPrinting> _supportPrinting;
        public FlowValidationTests()
        {
            _flow = new ProductionFlow(Guid.NewGuid(), "Test");
            _locationExistence = new Mock<ILocationExistence>();
            _locationExistence.Setup(p => p.IsExists(It.IsAny<Guid>())).Returns(true);
            _supportPrinting = new Mock<IFirstLocationSupportPrinting>();
            _supportPrinting.Setup(p => p.IsSupport(It.IsAny<Guid>())).Returns(true);
            _flow.AddStep(Guid.NewGuid(), "test1", 5, Guid.NewGuid(), 0, _locationExistence.Object, _supportPrinting.Object);
            _flow.AddStep(Guid.NewGuid(), "test2", 5, Guid.NewGuid(), 10, _locationExistence.Object, _supportPrinting.Object);
            _flow.AddStep(Guid.NewGuid(), "test3", 10, Guid.NewGuid(), 20, _locationExistence.Object, _supportPrinting.Object);
            _flow.AddStep(Guid.NewGuid(), "test4", 3, Guid.NewGuid(), 60, _locationExistence.Object, _supportPrinting.Object);
            _flow.AddStep(Guid.NewGuid(), "test5", 7, Guid.NewGuid(), 95, _locationExistence.Object, _supportPrinting.Object);
            _flow.AddStep(Guid.NewGuid(), "test6", 10, Guid.NewGuid(), 100, _locationExistence.Object, _supportPrinting.Object);
        }
        [Fact]
        public void FlowValidationTest_IsValid_ShouldRetunTrue()
        {
            var validator = new ProductionFlowValidator();
            Assert.True(validator.IsValid(_flow));
        }

        [Fact]
        public void FlowValidationTest_IsValid_ShouldReturnFalse_When_MaxPercentageGreaterThenHunderd()
        {
            _flow.AddStep(Guid.NewGuid(), "test7", 10, Guid.NewGuid(), 105, _locationExistence.Object, _supportPrinting.Object);
            var validator = new ProductionFlowValidator();
            Assert.False(validator.IsValid(_flow));
            Assert.Equal((uint)ErrorCodes.ValidationErrorMaxPercentage, validator.Exception.ExceptionCode);
        }

        [Fact]
        public void FlowValidationTest_IsValid_ShouldReturnFalse_When_LastStepPercentagteIsNotGreaterThenLastStep()
        {
            _flow.AddStep(Guid.NewGuid(), "test7", 10, Guid.NewGuid(), 95, _locationExistence.Object, _supportPrinting.Object);
            var validator = new ProductionFlowValidator();
            Assert.False(validator.IsValid(_flow));
            Assert.Equal((uint)ErrorCodes.ValidationErrorStepPercentage, validator.Exception.ExceptionCode);
        }
    }
}
