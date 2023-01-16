using ClinicService.Models.Request;
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
}