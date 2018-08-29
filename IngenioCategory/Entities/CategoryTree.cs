using IngenioCategory.Infrastructure;
using IngenioCategory.Models;
using System;
using System.Collections.Generic;

namespace IngenioCategory.Entities
{
    public class CategoryTree<T>  where T : Category
    {
        private  readonly List<T> collection = new List<T>();

        public IList<T> Collection
        {
            get { return collection; }
        }

        #region Methods

        public CategoryTree<T> Build(IList<T> categories)
        {
            foreach (var category in categories)
            {
                Add(category);
            }

            return this;
        }

        public IEnumerable<T> GetNodesOnLevel(int level)
        {
            return collection.FindNodesOnLevel(level, 1);
        }

        public T GetNode(int id)
        {
            var node = collection.Find(id);
            node.Keyword = GetKeyword(node);
            return node;
        }

        public void Add(T node)
        {
            var duplicateNode = collection.Find(node.Id);
            var parentNode = collection.Find(node.ParentId);

            if (duplicateNode != null)
            {
                throw new Exception("Node with this id already exist");
            }

            if (node.ParentId == -1)
            {
                node.Parent = null;
                collection.Add(node);
            }
            else
            {
                if (parentNode == null)
                {
                    throw new Exception("Node with this ParentId not exist");
                }

                node.Parent = parentNode;
                parentNode.Children.Add(node);
            }
        }
           
        private string GetKeyword(T node)
        {
            return Helper.GetKeyword(node);           
        }

        #endregion
    }
}
