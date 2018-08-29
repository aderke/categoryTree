using IngenioCategory.Models;

namespace IngenioCategory.Infrastructure
{
    public class Helper
    {
        public static string GetKeyword<T>(T node) where T : Category
        {
            var keyword = node.Keyword;

            if (string.IsNullOrEmpty(keyword))
            {
                keyword = GetKeyword(node.Parent);
            }

            return keyword;
        }
    }
}
