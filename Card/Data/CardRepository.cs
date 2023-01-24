using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class CardRepository : IRepository<Card>
{
    private readonly ApplicationContext _context;
    public CardRepository(ApplicationContext appContext) => _context = appContext;
    public async Task<ICollection<Card>> GetItemsListAsync() => await _context.Cards.ToListAsync();
    public async Task<Card> GetItemAsync(int id) => await _context.Cards.FindAsync(new object[] { id });
    public async Task AddItemAsync(Card item) => await _context.Cards.AddAsync(item);
    public async Task DeleteItemAsync(int id)
    {
        var cardFromRepository = await _context.Cards.FindAsync(new object[] { id });
        if (cardFromRepository == null) throw new Exception("This card not exist");
        _context.Cards.Remove(cardFromRepository);
    }
    public async Task UpdateItemAsync(Card item)
    {
        var cardFromRepository = await _context.Cards.FindAsync(new object[] { item.Id });
        if (cardFromRepository == null) throw new Exception("This card not exist");
        cardFromRepository.Name = item.Name;
        cardFromRepository.SerialNumber = item.SerialNumber;
        cardFromRepository.Date = item.Date;
        cardFromRepository.Cvv = item.Cvv;
    }
    public async Task SaveAsync() => await _context.SaveChangesAsync();


    #region Dispose
    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}