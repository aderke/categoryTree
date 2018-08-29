using System.Collections.Generic;

namespace IngenioCategory.Models
{
    public class Category
    {
        public Category(int id, int parentId, string name, string keyword = null)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
            Keyword = keyword;
        }

        #region Properties
        public string Name { get; set; }

        public Category Parent { get; set; }

        public string Keyword { get; set; }

        public int Id { get; set; }

        public int ParentId { get; set; }

        public List<Category> Children { get; set; } = new List<Category>();
        #endregion

        public override string ToString()
        {
            return string.Format("ParentID = {0}, Name = {1}, Keywords = {2}",
               this.Parent?.Id.ToString() ?? "-1",
               this.Name,
               this.Keyword
               );
        }
    }
}
