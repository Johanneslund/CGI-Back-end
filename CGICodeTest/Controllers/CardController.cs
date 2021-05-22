using CGICodeTest.Data;
using CGICodeTest.Models;
using CGICodeTest.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace CGICodeTest.Controllers
{
    public class CardController : Controller
    {


        private readonly ICardService _service;

        public CardController( ICardService service)
        {
          
            _service = service;
        }

        
        [Route("api/card")]
        [HttpGet]
        //[EnableCors("AllowAll")]
        public async Task<IEnumerable<BusinessCard>> GetAllCards()
        {
            var allCards = await _service.GetAllAsync();
            return allCards;
        }

        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<BusinessCard> GetCardById(int id)
        {

            try
            {
                var card = await _service.GetCardByIdAsync(id);
                return card;
            }
            catch (Exception)
            {
                if (await _service.GetCardByIdAsync(id) == null)
                {
                    return null;
                }
                throw;
            }

        }

        [Route("api/card")]
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<OkResult> AddCard([FromBody] BusinessCard card)
        {


            try
            {
                await _service.AddAsync(card);

            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<BusinessCard>> UpdateCard(int id, [FromBody] BusinessCard card)
        {
            if (await _service.GetCardByIdAsync(id) == null)
            {
                return NotFound("Card was not found");
            }

            try
            {
                card.Id = id;
                await _service.UpdateAsync(card);
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }


        [HttpDelete("{id:int}")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            try
            {
                var cardToUpdate = _service.GetCardByIdAsync(id);
                if (cardToUpdate == null)
                {
                    return NotFound("The card was not found");
                }
                await _service.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw ;
            }
            

            return Ok();
        }

    }
}
