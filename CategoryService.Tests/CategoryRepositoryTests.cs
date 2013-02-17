using Quotefish.CategoryService.Worker.DataAccess;
using Quotefish.CategoryService.Worker.DataAccess.DataTransferObject;
using NUnit.Framework;

namespace Quotefish.CategoryService.Tests
{
    [TestFixture]
    class CategoryRepositoryTests
    {
        [Test]
        public void AddCategory_AddANewCategory_CategoryIsPersdisted()
        {
            var categoryRepository = new CategoryRepository();
            var category = new Category
                               {
                                   Name = "Building Services"
                               };

            categoryRepository.AddCategory(category);
            Assert.AreEqual("category/Building Services", category.Id);
        }

        [Test]
        public void AddCategory_AddACategoryWithSubCategories_EntireObjectGraphIsPersisted()
        {
            var categoryRepository = new CategoryRepository();
            var category = new Category
            {
                Name = "Advertising",
                SubCategories = new SubCategoryList
                                    {
                                        new SubCategory { Name = "Radio"},
                                        new SubCategory { Name = "Cinema"},
                                        new SubCategory { Name = "Television"},
                                        new SubCategory { Name = "Print"},
                                        new SubCategory { Name = "Web"},
                                        new SubCategory { Name = "Billboards"},
                                        new SubCategory { Name = "Signs"},
                                        new SubCategory { Name = "Signwriting"},
                                        new SubCategory { Name = "Internet"},
                                        new SubCategory { Name = "Other"},
                                    }
            };

            categoryRepository.AddCategory(category);
            Assert.AreEqual("category/Advertising", category.Id);
        }
    }
}
