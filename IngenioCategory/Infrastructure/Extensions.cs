using IngenioCategory.Models;
using System.Collections.Generic;

namespace IngenioCategory.Infrastructure
{
    public static class Extensions
    {    
        public static List<T> FindNodesOnLevel<T>(this IEnumerable<T> nodes, int levelToFind, int currentLevel) where T : Category
        {
            var result = new List<T>();

            foreach (var node in nodes)
            {
                if (currentLevel == levelToFind)
                {
                    result.Add(node);
                }

                currentLevel++;

                foreach (var childCategory in FindNodesOnLevel(node.Children, levelToFind++, currentLevel))
                {
                    result.Add((T) childCategory);
                }
            }

            return result;
        }

        public static T Find<T>(this IEnumerable<T> nodes, int categoryId) where T : Category
        {
            foreach (var rootNode in nodes)
            {
                if (rootNode.Id == categoryId)
                {
                    return rootNode;
                }

                if (rootNode.Children.Count > 0)
                {
                    var node = Find(rootNode.Children, categoryId);

                    if (node != null)
                    {
                        return (T) node;
                    }
                }
            }

            return null;
        }
    }
}
