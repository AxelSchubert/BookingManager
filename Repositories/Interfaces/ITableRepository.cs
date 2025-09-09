using BookingManager.Models;

namespace BookingManager.Repositories.Interfaces
{
    public interface ITableRepository
    {
        Task<List<Table>> GetAllTablesAsync();
        Task<Table?> UpdateTableAsync(Table table);
        Task<Table> CreateTableAsync(Table table);
        Task<Table?> GetTableByIdAsync(int id);
        Task<bool> DeleteTableAsync(int id);
        Task<List<Table>?> GetAvailableTablesAsync(DateTime time, int numberOfGuests);
    }
}
