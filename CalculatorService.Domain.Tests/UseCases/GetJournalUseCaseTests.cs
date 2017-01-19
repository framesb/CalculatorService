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
    public class GetJournalUseCaseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_GetJournalWithoutClientId_Then_ArgumentNullException()
        {
            Mock<IClientOperationsRepository> clientOperationsRepositoryMock = new Mock<IClientOperationsRepository>();

            var useCase = new GetJournalUseCase(clientOperationsRepositoryMock.Object);
            var result = useCase.Execute(new QueryOperation(null));
        }

        [TestMethod]
        public void When_GetJournalWithClientId_Then_ReturnsClientOperations()
        {
            Mock<IClientOperationsRepository> clientOperationsRepositoryMock = new Mock<IClientOperationsRepository>();

            clientOperationsRepositoryMock.Setup(x => x.GetOperations(It.IsAny<string>())).Returns(new ClientOperations() { Operations = new List<IOperation>() {new AddOperation(new List<int>() {2,3})} });
            clientOperationsRepositoryMock.Setup(x => x.Save(It.IsAny<string>(), It.IsAny<IOperation>()));

            var useCase = new GetJournalUseCase(clientOperationsRepositoryMock.Object);
            var result = useCase.Execute(new QueryOperation("client_1"));
            Assert.AreEqual(result.Operations.Count, 1);
        }
    }
}
