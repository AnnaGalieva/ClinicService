using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServiceTests
{
    /// <summary>
    /// ДОМАШНЯЯ РАБОТА: разработать методы тестирования контроллера PetController:
    /// Обновление данных UpdateTest
    /// Получение данных (по всем животным) GetAllTest
    /// Получение данных (по конкретному животному) GetByIdTest
    /// </summary>
    public class PetControllerTests
    {
        private PetController _petController;

        public PetControllerTests()
        {
            _petController = new PetController();
        }


        [Fact]
        public void PetCreateTest()
        {
            MyList<string> myList = new MyList<string>();

            // МЕТОД ТЕСТИРОВАНИЯ СТОСТОИТ ИЗ 3 ЧАСТЕЙ

            // [1] Подготовка данных для тестирования
            CreatePetRequest createPetRequest = new CreatePetRequest();
            createPetRequest.Name = "Персик";
            createPetRequest.Birthday = DateTime.Now.AddYears(-15);
            createPetRequest.ClientId = 1;


            // [2] Исполнение тестируемой подпрограммы
            ActionResult<int> operationResult = _petController.Create(createPetRequest);

            // [3] Подготовка эталонного результата (expected), проверка результата
            int expectedOperationValue = 1;

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)(((OkObjectResult)operationResult.Result).Value));


        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-1000)]
        public void PetDeleteBadRequestTest(int petId)
        {
            // [2] Исполнение тестируемой подпрограммы
            ActionResult<int> operationResult = _petController.Delete(petId);

            // [3] Подготовка эталонного результата (expected), проверка результата
            int expectedOperationValue = 0;

            // Assert
            Assert.IsType<BadRequestObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)(((BadRequestObjectResult)operationResult.Result).Value));
        }


        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(500)]
        public void PetDeleteTest(int petId)
        {
            // [2] Исполнение тестируемой подпрограммы
            ActionResult<int> operationResult = _petController.Delete(petId);

            // [3] Подготовка эталонного результата (expected), проверка результата
            int expectedOperationValue = 1;

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)(((OkObjectResult)operationResult.Result).Value));
        }




        [Fact]
        public void PetUpdateTest()
        {
            MyList<string> myList = new MyList<string>();

            // МЕТОД ТЕСТИРОВАНИЯ СТОСТОИТ ИЗ 3 ЧАСТЕЙ

            // [1] Подготовка данных для тестирования
            UpdatePetRequest updatePetRequest = new UpdatePetRequest();
            updatePetRequest.Name = "Персик";
            updatePetRequest.Birthday = DateTime.Now.AddYears(-15);



            // [2] Исполнение тестируемой подпрограммы
            ActionResult<int> operationResult = _petController.Update(updatePetRequest);

            // [3] Подготовка эталонного результата (expected), проверка результата
            int expectedOperationValue = 1;

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)(((OkObjectResult)operationResult.Result).Value));


        }
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(500)]
        public void GetAllTest(int clientId)
        {
            // [2] Исполнение тестируемой подпрограммы
            ActionResult<List<Pet>> operationResult = _petController.GetAll( clientId);

            // [3] Подготовка эталонного результата (expected), проверка результата
            int expectedOperationValue = 1;

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)(((OkObjectResult)operationResult.Result).Value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(500)]
        public void GetAllByIdTest(int PetId)
        {
            // [2] Исполнение тестируемой подпрограммы
            ActionResult<Pet> operationResult = _petController.GetById( PetId);

            // [3] Подготовка эталонного результата (expected), проверка результата
            int expectedOperationValue = 1;

            // Assert
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)(((OkObjectResult)operationResult.Result).Value));
        }

        public class MyList<TElement>
        {

            private TElement[] arr;

        }
    }
}

