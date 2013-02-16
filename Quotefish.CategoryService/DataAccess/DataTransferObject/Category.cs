using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quotefish.CategoryService.DataAccess.DataTransferObject
{
    public class Category : RavenDbDocument
    {
        public SubCategoryList SubCategories { get; set; }        
    }
}
