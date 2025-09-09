using BookingManager.DTOs;
using BookingManager.Models;

namespace BookingManager.Services
{
    public interface ITableService
    {
        Task<List<TableDTO>> GetAllTablesAsync();
        Task<TableDTO?> UpdateTableAsync(TableDTO table, int id);
        Task<TableDTO> CreateTableAsync(CreateTableDTO table);
        Task<TableDTO?> GetTableByIdAsync(int id);
        Task<bool> DeleteTableAsync(int id);
        Task<List<TableDTO>?> GetAvailableTablesAsync(DateTime time, int numberOfGuests);

    }
}
