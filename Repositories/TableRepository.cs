using BookingManager.Data;
using BookingManager.Models;
using BookingManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingManager.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly BookingManagerDBContext _context;
        public TableRepository(BookingManagerDBContext context)
        {
            _context = context;
        }
        public async Task<Table> CreateTableAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return table;
        }

        public async Task<bool> DeleteTableAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) { return false; }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Table>> GetAllTableAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<List<Table>?> GetAvailableTablesAsync(DateTime start, int numberOfGuests)
        {
            return await _context.Tables.Where(t => t.Capacity >= numberOfGuests && !t.Bookings.Any(b => b.Start < start.AddHours(2) && b.End > start)).ToListAsync();
        }

        public async Task<Table?> GetTableByIdAsync(int id)
        {
            return await _context.Tables.FindAsync(id);
        }

        public async Task<Table?> UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
            return table;
        }
    }
}
