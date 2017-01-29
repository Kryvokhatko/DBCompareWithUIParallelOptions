using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System;
using DBCompareWithUIParallelOptions.HelperClass;

namespace DBCompareWithUIParallelOptions.Tests
{
    [TestClass]
    public class ParallelTests : TestBaseClass
    {
        [TestMethod]
        public void ParallelTest()
        {
            var externalIds = InfoFromDB.getAllExternalIdFromStaging();
            ParallelOptions options = new ParallelOptions();
            //number of parallel tests (number of opened browsers) 
            options.MaxDegreeOfParallelism = 2;
            //unique externalId for each test (for each opened browser)
            Parallel.ForEach(externalIds, options, externalId =>
            {
                try
                {
                    MainTestLogicClass test = new MainTestLogicClass();
                    test.MainTest(externalId);
                }
                catch (Exception ex)
                {
                    //just catch any errors
                }
            });
        }
    }
}
