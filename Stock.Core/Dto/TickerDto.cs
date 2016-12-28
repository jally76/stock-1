using System;

namespace Stock.Core.Dto
{
    public class TickerDto
    {
        public Guid Id { get; set; }

        public string Company { get; set; }

        public string Code { get; set; }

        public int Price { get; set; }
    }
}
