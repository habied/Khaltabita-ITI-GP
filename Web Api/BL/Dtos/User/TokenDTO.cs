using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos;

public class TokenDTO
{
    public string Token { get; init; } = string.Empty;
    public DateTime ExpiryDate { get; init; }

    public string Id { get; init; } = string.Empty;

    public string? Title { get; init; } = string.Empty;

}
