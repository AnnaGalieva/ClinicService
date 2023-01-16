/*using ClinicService.Models.Request;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetRepository _petRepository;
    
        public PetController(IPetRepository petRepository)
    {
           _petRepository = petRepository;
    }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "PetCreate")]

        public ActionResult<int> Create([FromBody] CreatePetRequest createRequest)
    {
        int res = _petRepository.Create(new Pet
        {
            Name = createRequest.Name,
            ClientId = createRequest.ClientId,
            Birthday = createRequest.Birthday,
        });
        return Ok(res);
    }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "PetUpdate")]

        public ActionResult<int>Update([FromBody] UpdatePetRequest updateRequest)
    {
        int res = _petRepository.Update(new Pet
        {
            PetId = updateRequest.PetId,
            Name = updateRequest.Name,    
            Birthday = updateRequest.Birthday,
        });
        return Ok(res);
    }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "PetDelete")]

        public ActionResult<int>Delete(int petId)
    {
        int res = _petRepository.Delete(petId);
        return Ok(res);
    }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "PetGetAll")]

        public ActionResult<List<Pet>> GetAll(int clientId)
    {
        return Ok(new List<Pet>());
    }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "PetGetAllById")]

        public ActionResult<Pet>GetById(int petId)
    {
        return Ok(new Pet());
    }


}
}*/
using ClinicService.Models;
using ClinicService.Models.Request;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "PetCreate")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createRequest)
        {

            // return BadRequest(1); // BadRequestObjectResult - False
            return Ok(1); // OkObjectResult - Ok
            //return BadRequest(1);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "PetUpdate")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updateRequest)
        {
            return Ok(1);
        }


        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "PetDelete")]
        public ActionResult<int> Delete(int petId)
        {
            if (petId <= 0)
                return BadRequest(0);
            return Ok(1);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "PetGetAll")]
        public ActionResult<List<Pet>> GetAll(int clientId)
        {
            return Ok(new List<Pet>());
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "PetGetAllById")]
        public ActionResult<Pet> GetById(int petId)
        {

            return Ok(new Pet());
        }

    }

    /*
    public abstract class MyActionResult<T>
    {
        protected int _code;
        protected T _value;

        public abstract int GetCode();  

        public T Value
        {
            get { return _value; }
        }
    }

    public class OkObjectResult<T> : MyActionResult<T>
    {
        public OkObjectResult(T value)
        {
            _code = 200;
            _value = value;
        }

        public override int GetCode()
        {
            return _code;
        }
    }

    public class BadObjectResult<T> : MyActionResult<T>
    {

        public BadObjectResult(T value)
        {
            _code = 400;
            _value = value;
        }

        public override int GetCode()
        {
            return _code;
        }
    }*/


}
