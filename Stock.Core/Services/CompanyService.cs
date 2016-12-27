using System.Collections.Generic;
using Stock.Core.Dto;

namespace Stock.Core.Services
{
    interface ICompanyService
    {
        IEnumerable<CompanyDto> Find(string findSubString, int count = 10);
        IEnumerable<CompanyDto> Select(string param);
    }

    public class CompanyService : ICompanyService
    {
        public IEnumerable<CompanyDto> Find(string findSubString, int count = 10)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CompanyDto> Select(string param)
        {
            throw new System.NotImplementedException();
        }
    }
}
