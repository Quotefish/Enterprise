using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quotefish.CategoryService.DataAccess.DataTransferObject;

namespace Quotefish.CategoryService.DataAccess
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
