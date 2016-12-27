using NSubstitute;
using NUnit.Framework;
using Stock.Core.DataAccess;

namespace Stock.Core.Tests
{
    public abstract class AbstractServiceTests
    {
        protected IDataProvider DataProvider { get; private set; }

        [SetUp]
        public void AbstractServiceTestSetUp()
        {
            DataProvider = Substitute.For<IDataProvider>();
        }
    }

}
