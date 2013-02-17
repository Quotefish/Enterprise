using Quotefish.Core.RavenDb;

namespace Quotefish.CategoryService.Database.Model
{
    public class Category : RavenDbDocument
    {
        public SubCategoryList SubCategories { get; set; }        
    }
}
