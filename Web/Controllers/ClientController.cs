using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Repositories;
using Infrastructure;
using Application.Services;
using Microsoft.AspNetCore.Authorization;


namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [Authorize(Policy = "Client")]
        [HttpPost("{clientId}/events/{eventId}/buy-ticket")]
        public IActionResult BuyTicket(int clientId, int eventId)
        {
           var result = _clientService.BuyTicket(clientId, eventId);

            if (result) //arreglo temporal
            {
                return Ok("Ticket purchased succesfully");
            }
            else
            {
                return BadRequest("Failed to purchase ticket");
            }
        }

        [Authorize(Policy = "Client")]
        [HttpGet("{clientId}/get-tickets")]
        public IActionResult GetMyTickets(int clientId)
        {
            var tickets = _clientService.GetAllMyTickets(clientId);

            if (tickets == null)
            {
                return NotFound("No tickets found for the client");
            }

            return Ok(tickets);
        }

        [Authorize(Policy = "EventOrganizer")]
        [HttpGet("{clientId}/get-client")]
        public IActionResult GetClientById(int clientId) 
        {
            var client = _clientService.GetClientById(clientId);
            if (client == null)
            {
                return NotFound("Client not found");
            }
            return Ok(client);
        }

        [Authorize(Policy = "Client")]
        [HttpGet("get-all-events")]
        public IActionResult GetAllEvents()
        {
            return Ok(_clientService.GetAll());
        }

    }
}
