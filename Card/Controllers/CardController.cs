using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Cards.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class CardController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<ICollection<Card>>> GetCards([FromServices] IRepository<Card> repository)
        {
            var cards = await repository.GetItemsListAsync();

            return Ok(cards);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Card>> GetCard([FromQuery] int id, [FromServices] IRepository<Card> repository)
        {
            var card = await repository.GetItemAsync(id);
            return Ok(card);
        }

        [HttpPost]
        public async Task<ActionResult> AddCard([FromBody]Card card, [FromServices]IRepository<Card> repository)
        {
            await repository.AddItemAsync(card);
            await repository.SaveAsync();
            return Ok(card.Id);
        }

        [HttpPut]
        public async Task<ActionResult> ChangeCard([FromBody] Card card, [FromServices] IRepository<Card> repository)
        {
            await repository.UpdateItemAsync(card);
            await repository.SaveAsync();
            return Ok(card.Id);
        }

        [HttpDelete]
        public async Task<ActionResult> deleteCard([FromBody] int id, [FromServices] IRepository<Card> repository)
        {
            await repository.DeleteItemAsync(id);
            await repository.SaveAsync();
            return Ok(id);
        }
    }
}
