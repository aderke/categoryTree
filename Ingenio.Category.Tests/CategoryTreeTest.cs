using System.Linq;
using IngenioCategory.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IngenioCategory.Repositories;
using IngenioCategory.Models;
using System;
using System.Collections.Generic;

namespace IngenioCategory.Tests
{
    [TestClass]
    public class CategoryTreeTest
    {
        private CategoryTree<Category> _categoryTree;

        [TestInitialize]
        public void Init()
        {
            // Arrange
            var categoryRepo = new CategoryRepository();            
            _categoryTree = categoryRepo.GetCategoryTree();
        }

        [TestMethod]
        public void GetCategory_WithoutKeyword_ParentKeyword1()
        {
            // Act 
            var category = _categoryTree.GetNode(201);
            
            // Assert
            Assert.AreEqual(200, category.ParentId);
            Assert.AreEqual("Computer", category.Name);
            Assert.AreEqual("Teaching", category.Keyword);
        }

        [TestMethod]
        public void GetCategory_WithoutKeyword_ParentKeyword2()
        {
            // Act
            var category = _categoryTree.GetNode(202);

            // Assert
            Assert.AreEqual(201, category.ParentId);
            Assert.AreEqual("Operating System", category.Name);
            Assert.AreEqual("Teaching", category.Keyword);
        }

        [TestMethod]
        public void GetCategory_WithKeyword_Success()
        {
            // Act
            var category = _categoryTree.GetNode(200);
            var result = category.ToString();

            // Assert
            Assert.AreEqual(-1, category.ParentId);
            Assert.AreEqual("Tutoring", category.Name);
            Assert.AreEqual("Teaching", category.Keyword);

        }

        [TestMethod]
        public void GetCategories_OnLevel2_Success()
        {
            // Act
            var nodes = _categoryTree.GetNodesOnLevel(2).ToList();

            // Assert
            Assert.AreEqual(3, nodes.Count());
            Assert.AreEqual(101, nodes[0].Id);
            Assert.AreEqual(102, nodes[1].Id);
            Assert.AreEqual(201, nodes[2].Id);
        }

        [TestMethod]
        public void GetCategories_OnLevel3_Success()
        {
            // Act
            var nodes = _categoryTree.GetNodesOnLevel(3).ToList();

            //Assert
            Assert.AreEqual(3, nodes.Count());
            Assert.AreEqual(103, nodes[0].Id);
            Assert.AreEqual(109, nodes[1].Id);
            Assert.AreEqual(202, nodes[2].Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InitializeCategoryTree_DuplicateCategoryId_Fail()
        {
            // Arrange
            var list = new List<Category>
            { 
                // id, parentId, name, keyword
                new Category(100, -1, "Business", "Money"),
                new Category(200, -1, "Tutoring", "Teaching"),
                new Category(101, 100, "Accounting1", "Taxes"),
                new Category(101, 100, "Accounting2", "Taxes")                
            };
            
            // Act
            var _categoryTree = new CategoryTree<Category>();
            _categoryTree.Build(list);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InitializeCategoryTree_NoParentCategory_Fail()
        {
            // Arrange
            var list = new List<Category>
            { 
                // id, parentId, name, keyword               
                new Category(200, -1, "Tutoring", "Teaching"),
                new Category(101, 100, "Accounting1", "Taxes"),
                new Category(102, 100, "Accounting2", "Taxes")
            };

            // Act
            var _categoryTree = new CategoryTree<Category>();
            _categoryTree.Build(list);
        }
    }
}
