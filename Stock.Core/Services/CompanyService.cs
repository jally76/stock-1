using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Stock.Core.AutoMapper;
using Stock.Core.DataAccess;
using Stock.Core.Domain;
using Stock.Core.Dto;

namespace Stock.Core.Services
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> Find(string findSubString, int count = 10);
        IEnumerable<CompanyDto> Select(string param);
    }

    public class CompanyService : ICompanyService
    {
        private readonly IDataProvider _dataProvider;

        public CompanyService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        protected MappingEngine Mapper => AutoMapperConfiguration.Mapper;
        
        public IEnumerable<CompanyDto> Find(string findSubString, int count = 10)
        {
            var query = _dataProvider.Where<Company>(c => c.Name.Contains(findSubString) || c.StockCode.Contains(findSubString)).Take(count);
            
            return query.Project(Mapper).To<CompanyDto>();
        }

        public IEnumerable<CompanyDto> Select(string param)
        {
            throw new System.NotImplementedException();
        }
    }
}
