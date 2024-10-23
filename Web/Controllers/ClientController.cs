using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Repositories;
using Infrastructure;


namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("{clientId}/but-ticket/{eventId}")]
        public IActionResult BuyTicket(int clientId, int eventId)
        {
           var result = _clientService.BuyTicket(clientId, eventId);

            if (result != null) //arreglo temporal
            {
                return Ok("Ticket purchased succesfully");
            }
            else
            {
                return BadRequest("Failed to purchase ticket");
            }
        }

        [HttpGet("{clientId}/tickets")]
        public IActionResult GetMyTickets(int clientId)
        {
            var tickets = _clientService.GetAllMyTickets(clientId);

            if (tickets == null || !tickets.Any())
            {
                return NotFound("No tickets found for the client");
            }

            return Ok(tickets);
        }
        
    }
}
