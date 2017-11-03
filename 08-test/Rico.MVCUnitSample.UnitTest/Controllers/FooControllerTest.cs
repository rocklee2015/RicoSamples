using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rico.MVCUnitSample;
using Rico.MVCUnitSample.Controllers;
using Rico.MVCUnitSample.Models;
using Moq;

namespace Rico.MVCUnitSample.UnitTest.Controllers
{
    [TestClass]
    public class FooControllerTest
    {
        private IFooRepository fooRepository;
        [TestInitialize]
        public void Initialize()
        {
            Mock<IFooRepository> mock = new Mock<IFooRepository>();
            mock.Setup(m => m.GetAll()).Returns(new Foo[]
            {
                new Foo(){Id = 1, Name = "Fake Foo 1"},
                new Foo(){Id = 2, Name = "Fake Foo 2"},
                new Foo(){Id = 3, Name = "Fake Foo 3"},
                new Foo(){Id = 4, Name = "Fake Foo 4"}
            }.AsQueryable());

            mock.Setup(m =>
                m.GetSingle(It.Is<int>(i => i == 1 || i == 2 || i == 3 || i == 4))).Returns<int>(r => new Foo
            {
                Id = r,
                Name = string.Format("Fake Foo {0}", r)
            });

            fooRepository = mock.Object;
        }
        [TestMethod]
        public void is_index_return_model_type_of_iqueryable_foo()
        {
            //Arragne
            FooController fooController = new FooController(fooRepository);

            //Act
            var indexModel = fooController.Index().Model;

            //Assert
            Assert.IsInstanceOfType(indexModel, typeof(IQueryable<Foo>));
        }

        [TestMethod]
        public void is_details_returns_type_of_ViewResult()
        {
            //Arrange
            FooController fooController = new FooController(fooRepository);

            //Act
            var detailsResult = fooController.Details(1);

            //Assert
            Assert.IsInstanceOfType(detailsResult, typeof(ViewResult));


        }

        [TestMethod]
        public void is_details_returns_type_of_HttpNotFoundResult()
        {
            //Arrange
            FooController fooController = new FooController(fooRepository);

            //Act
            var detailsResult = fooController.Details(5);

            //Assert
            Assert.IsInstanceOfType(detailsResult, typeof(HttpNotFoundResult));
        }
    }
}
