using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quotefish.CategoryService.Worker.DataAccess.DataTransferObject;

namespace Quotefish.CategoryService.Worker.DataAccess
{
    public class CategoryRepository
    {
        public void AddCategory(Category category)
        {
            using (var session = DocumentStoreFactory.Instance.DocumentStore.OpenSession())
            {
                session.Store(category);
                session.SaveChanges();
            }
        }
    }
}
