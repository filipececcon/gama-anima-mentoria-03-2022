using System;
using System.Collections.Generic;
using System.Linq;
using Anima.Banco.Application.Commands;
using Anima.Banco.Application.Requests;
using Anima.Banco.Domain.Core.Entities;
using Anima.Banco.Domain.Shared.Interfaces;
using Anima.Banco.Infrastructure.Data.Persistence.Contexts;
using Anima.Banco.Infrastructure.Data.Persistence.Repositories;
using Moq;
using NUnit.Framework;

namespace Anima.Banco.Tests
{
    [TestFixture]
    public class CustomerTest
    {
        private WriteRepository _writeRepository;

        //[SetUp]
        public void Setup()
        {
            var connectionString = "Server=localhost;Database=DB_ANIMA;User Id=sa;Password=MyPass@word;";

            var context = new AnimaContext(connectionString);

            _writeRepository = new WriteRepository(context);
        }

        // RGR => Red, Green, Refactor
        // primeiro => escreva todos os seus casos de teste dando falha
        // segundo => faz todos os nossos testes acertarem, ficarem verdes
        // terceiro => refatoração

        [Test]
        [TestCase("teste1@gmail.com")]
        [TestCase("teste2@gmail.com")]
        [TestCase("teste3@gmail.com")]
        public void ShouldReturnErrorWhenEmailIsAlreadyExists(string email)
        {
            var request = new AddCustomerRequest() { Name = "azdrubal", Email = email};

            var mock = new Mock<IWriteRepository>();

            var cmd = new AddCustomerCommand(mock.Object);

            mock
                .Setup(x => x.AsQueryable<Customer>())
                .Returns(
                new List<Customer>() {
                    new Customer("", "teste1@gmail.com")
                }
                .AsQueryable());


            var response = cmd.Handle(request);

            var result = response.Errors.Any(x => x == "Email ja existe");

            Assert.IsTrue(result);
        }
    }
}
