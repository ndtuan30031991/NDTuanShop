using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NDTuanShop.Data.Infrastructure;
using NDTuanShop.Data.Repositories;
using NDTuanShop.Model.Models;
using NDTuanShop.Service;
using System.Collections.Generic;

namespace NDTuanShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() { ID = 1, Name = "Test01", Status = true },
                new PostCategory() { ID = 2, Name = "Test02", Status = true },
                new PostCategory() { ID = 3, Name = "Test03", Status = true },
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            //call action
            var reesult = _categoryService.GetAll() as List<PostCategory>;

            Assert.IsNotNull(reesult);
            Assert.AreEqual(3, reesult.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory();

            int id = 1;
            category.Name = "Test";
            category.Alias = "test";
            category.Status = true;

            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });

            var result = _categoryService.Add(category);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}