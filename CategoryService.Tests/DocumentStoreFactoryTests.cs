using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Quotefish.CategoryService.DataAccess;

namespace Quotefish.CategoryService.Tests
{
    [TestFixture]
    public class DocumentStoreFactoryTests
    {

        [Test]
        public void Instance_AccessInstance_InstanceIsReturned()
        {
            // Arrange / Act
            var documentStoreFactory = DocumentStoreFactory.Instance;

            // Assert
            Assert.NotNull(documentStoreFactory);
        }

        [Test]
        public void DocumentStore_AccessProperty_ReferenceIsReturned()
        {
            // Arrange / Act
            var documentStore = DocumentStoreFactory.Instance.DocumentStore;

            // Assert
            Assert.NotNull(documentStore);
        }
    }
}
