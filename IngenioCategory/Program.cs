using System;
using System.Linq;
using IngenioCategory.Repositories;

namespace IngenioCategory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var categoryRepo = new CategoryRepository();

            // Output info about category without own keywords
            int categoryId = 201;
            var tree = categoryRepo.GetCategoryTree();
            var node = tree.GetNode(categoryId);
            Console.WriteLine(node.ToString());

            categoryId = 202;            
            node = tree.GetNode(categoryId);
            Console.WriteLine(node.ToString());

            // Output categories on second depth level
            var nodes = tree.GetNodesOnLevel(2);
            Console.WriteLine(string.Join(", ", nodes.Select(c => c.Id)));

            // Output categories on second depth level
            nodes = tree.GetNodesOnLevel(3);
            Console.WriteLine(string.Join(", ", nodes.Select(c => c.Id)));

            Console.ReadLine();
        }
    }
}
