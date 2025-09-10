using BookingManager.DTOs;
using BookingManager.Models;
using BookingManager.Repositories;

namespace BookingManager.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _repository;
        public TableService(ITableRepository repository)
        {
            _repository = repository;
        }
        public async Task<TableDTO> CreateTableAsync(CreateTableDTO table)
        {
            var newTable = new Table
            {
                Capacity = table.Capacity
            };

            var createdTable = await _repository.CreateTableAsync(newTable);

            return new TableDTO
            {
                Id = createdTable.Id,
                Capacity = createdTable.Capacity
            };
        }

        public async Task<bool> DeleteTableAsync(int id)
        {
            return await _repository.DeleteTableAsync(id);
        }

        public async Task<List<TableDTO>> GetAllTablesAsync()
        {
            var tables = await _repository.GetAllTablesAsync();

            return tables.Select(t => new TableDTO
            {
                Id = t.Id,
                Capacity = t.Capacity
            }).ToList();
        }

        public async Task<List<TableDTO>?> GetAvailableTablesAsync(DateTime time, int numberOfGuests)
        {
            var availableTables = await _repository.GetAvailableTablesAsync(time, numberOfGuests);

            if (availableTables == null) { return null; }

            return availableTables.Select(t => new TableDTO
            {
                Id = t.Id,
                Capacity = t.Capacity
            }).ToList();
        }

        public async Task<TableDTO?> GetTableByIdAsync(int id)
        {
            var table = await _repository.GetTableByIdAsync(id);
            if (table == null) { return null; }

            return new TableDTO
            {
                Id = table.Id,
                Capacity = table.Capacity
            };
        }

        public async Task<TableDTO?> UpdateTableAsync(TableDTO table, int id)
        {
            var currentTable = await _repository.GetTableByIdAsync(id);

            if (currentTable == null) { return null; }

            if (table.Capacity != null) { currentTable.Capacity = table.Capacity.Value; }

            var updatedTable = await _repository.UpdateTableAsync(currentTable);

            return new TableDTO
            {
                Id = updatedTable.Id,
                Capacity = updatedTable.Capacity
            };
        }
    }
}
