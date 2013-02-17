using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Document;

namespace Quotefish.CategoryService.Database
{
    public class CategoryDocumentStore : DocumentStore
    {
        public CategoryDocumentStore() : base()
        {
            ConnectionStringName = "CategoryService";
            this.Initialize();
        }
    }
}
