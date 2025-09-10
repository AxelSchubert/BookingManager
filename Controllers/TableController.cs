using BookingManager.DTOs;
using BookingManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }
        [HttpGet]
        public async Task<ActionResult<List<TableDTO>>> GetAllTables()
        {
            var tables = await _tableService.GetAllTablesAsync();
            return Ok(tables);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TableDTO>> GetTableById(int id)
        {
            var table = await _tableService.GetTableByIdAsync(id);
            if (table == null) { return NotFound(); }
            return Ok(table);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TableDTO>> CreateTable([FromBody] CreateTableDTO table)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var createdTable = await _tableService.CreateTableAsync(table);
            return CreatedAtAction(nameof(GetTableById), new { id = createdTable.Id }, createdTable);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<TableDTO>> UpdateTable(int id, [FromBody] TableDTO table)
        {
            if (table == null) { return BadRequest(); }
            var updatedTable = await _tableService.UpdateTableAsync(table, id);
            if (updatedTable == null) { return NotFound(); }
            return Ok(updatedTable);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<TableDTO>> DeleteTable(int id)
        {
            var result = await _tableService.DeleteTableAsync(id);
            if (!result) { return NotFound(); }
            return NoContent();
        }
        [HttpGet("available")]
        public async Task<ActionResult<List<TableDTO>>> GetAvailableTables([FromQuery] DateTime time, [FromQuery] int numberOfGuests)
        {
            if (numberOfGuests <= 0)
            {
                return BadRequest("Number of guests must be greater than zero.");
            }
            if (time < DateTime.Now)
            {
                return BadRequest("You cannot book in the past.");
            }
            var availableTables = await _tableService.GetAvailableTablesAsync(time, numberOfGuests);
            return Ok(availableTables);
        }
    }
}
