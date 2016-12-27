using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ninject;
using Stock.Core.AutoMapper;
using Stock.Core.DataAccess;
using Stock.Core.Domain;
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
        [Inject]
        public IDataProvider DataProvider { get; set; }

        protected MappingEngine Mapper => AutoMapperConfiguration.Mapper;
        
        public IEnumerable<CompanyDto> Find(string findSubString, int count = 10)
        {
            var query = DataProvider.Where<Company>(c => c.Name == findSubString || c.StockCode == findSubString).Take(count);
            
            return query.Project(Mapper).To<CompanyDto>();
        }

        public IEnumerable<CompanyDto> Select(string param)
        {
            throw new System.NotImplementedException();
        }
    }
}
