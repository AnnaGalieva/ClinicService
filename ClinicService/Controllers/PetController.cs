using ClinicService.Models.Request;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Create([FromBody] CreatePetRequest createRequest)
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
    public IActionResult Update([FromBody] UpdatePetRequest updateRequest)
    {
        int res = _petRepository.Update(new Pet
        {
            PetId = updateRequest.PetId,
            Name = updateRequest.Name,
            ClientId = updateRequest.ClientId,
            Birthday = updateRequest.Birthday,
        });
        return Ok(res);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int petId)
    {
        int res = _petRepository.Delete(petId);
        return Ok(res);
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        return Ok(_petRepository.GetAll());
    }

    [HttpGet("get-by-id")]
    public IActionResult GetAll(int petId)
    {
        return Ok(_petRepository.GetById(petId));
    }


}
}