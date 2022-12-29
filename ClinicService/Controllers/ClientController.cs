﻿using ClinicService.Models.Request;
using ClinicService.Models;
using ClinicService.Services;
using ClinicService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    /// <summary>
    /// ДОМАШНЯЯ РАБОТА
    /// 
    /// 1. Создать репозиторий и контроллер для работы с животными (Pet)
    /// 2***. Создать репозиторий и контроллер для работы с консультациями (Consultation)
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateClientRequest createRequest)
        {
            int res = _clientRepository.Create(new Client
            {
                Document = createRequest.Document,
                SurName = createRequest.SurName,
                FirstName = createRequest.FirstName,
                Patronymic = createRequest.Patronymic,
                Birthday = createRequest.Birthday,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateClientRequest updateRequest)
        {
            int res = _clientRepository.Update(new Client
            {
                ClientId = updateRequest.ClientId,
                Document = updateRequest.Document,
                SurName = updateRequest.SurName,
                FirstName = updateRequest.FirstName,
                Patronymic = updateRequest.Patronymic,
                Birthday = updateRequest.Birthday
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int clientId)
        {
            int res = _clientRepository.Delete(clientId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public IActionResult GetAll(int clientId)
        {
            return Ok(_clientRepository.GetById(clientId));
        }


    }
}