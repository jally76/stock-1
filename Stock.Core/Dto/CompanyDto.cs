using System;

namespace Stock.Core.Dto
{
    public class CompanyDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string StockCode { get; set; }
    }
}
