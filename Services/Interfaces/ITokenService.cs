using BookingManager.Models;

namespace BookingManager.Services
{
    public interface ITokenService
    {
        string GenerateToken(Admin admin);
    }
}
