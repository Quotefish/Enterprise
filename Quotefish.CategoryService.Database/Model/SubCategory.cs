using Quotefish.Core.RavenDb;

namespace Quotefish.CategoryService.Database.Model
{
    public class SubCategory : RavenDbDocument
    {
        SubCategorySynonymList Synonyms { get; set; }
    }
}