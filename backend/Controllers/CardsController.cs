using System.Threading.Tasks;
using backend.Context;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
public class CardsController : ControllerBase
{
    private readonly RememberNowContext _context;

    public CardsController(RememberNowContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> getCards()
    {
        var cards = await _context.Cards.ToListAsync();

        if (cards.Count == 0)
        {
            return NotFound("No letters were found.");
        }

        return Ok(cards);
    }

    [HttpGet]
    public async Task<ActionResult<Card>> getCardById(Guid id)
    {
        var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

        if (card == null)
        {
            return NotFound("No card was found.");
        }

        return Ok(card);
    }

    [HttpPost]
    public async Task<ActionResult<Card>> addCard(Card card)
    {
        var response = await _context.Cards.AddAsync(card);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> editCard(Guid id, Card card)
    {
        var entity = await _context.Cards.FindAsync(id);

        if (entity == null)
        {
            return NotFound("No card was found with this id");
        }

        entity.Name = card.Name;
        entity.Description = card.Description;

        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete]
    public async Task<ActionResult> deleteCard(Guid id)
    {
        var card = await _context.Cards.FindAsync(id);

        if (card == null)
        {
            return NotFound("No card was found with this id");
        }

        _context.Cards.Remove(card);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}