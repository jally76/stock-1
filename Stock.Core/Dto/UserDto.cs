using System;
using System.Collections.Generic;

namespace Stock.Core.Dto
{
    public class UserDto
    {
        public UserDto()
        {
            Tickers = new List<TickerDto>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<TickerDto> Tickers { get; set; }
    }
}
