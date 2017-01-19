using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.Domain.Adapters.Data;
using CalculatorService.Domain.Entities;
using CalculatorService.Domain.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalculatorService.Domain.Tests.UseCases
{
    [TestClass]
    public class ProcessOperationUseCaseTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_AddOperationWithNoAddends_Then_ArgumentNullException()
        {
            Mock<IClientOperationsRepository> clientOperationsRepositoryMock = new Mock<IClientOperationsRepository>();

            var useCase = new ProcessOperationUseCase(clientOperationsRepositoryMock.Object);
            var result = useCase.Execute(new AddOperation(new List<int>()), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void When_AddOperationWithInsufficientAddends_Then_ArgumentException()
        {
            Mock<IClientOperationsRepository> clientOperationsRepositoryMock = new Mock<IClientOperationsRepository>();

            var useCase = new ProcessOperationUseCase(clientOperationsRepositoryMock.Object);
            var result = useCase.Execute(new AddOperation(new List<int>() {3}), null);
        }

        [TestMethod]
        public void When_AddOperationValidData_Then_SumIsOk()
        {
            Mock<IClientOperationsRepository> clientOperationsRepositoryMock = new Mock<IClientOperationsRepository>();
            
            clientOperationsRepositoryMock.Setup(x => x.GetOperations(It.IsAny<string>())).Returns(new ClientOperations() {Operations = new List<IOperation>()});
            clientOperationsRepositoryMock.Setup(x => x.Save(It.IsAny<string>(), It.IsAny<IOperation>()));

            var useCase = new ProcessOperationUseCase(clientOperationsRepositoryMock.Object);
            var result = useCase.Execute(new AddOperation(new List<int>() {2, 3, 5}), null);
            Assert.AreEqual((result as AddOperationResult).Sum, 10);
        }

        [TestMethod]
        public void When_AddOperationValidDataAndClientId_Then_SumIsOk()
        {
            Mock<IClientOperationsRepository> clientOperationsRepositoryMock = new Mock<IClientOperationsRepository>();

            clientOperationsRepositoryMock.Setup(x => x.Save(It.IsAny<string>(), It.IsAny<IOperation>()));

            var useCase = new ProcessOperationUseCase(clientOperationsRepositoryMock.Object);
            var result = useCase.Execute(new AddOperation(new List<int>() { 2, 3, 5 }), "client_1");
            Assert.AreEqual((result as AddOperationResult).Sum, 10);
        }
    }
}
