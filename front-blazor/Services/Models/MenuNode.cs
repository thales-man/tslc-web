using System.Collections.Generic;

namespace Front.Services.Models
{
    internal sealed class MenuNode :
        IMenuNode
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Article { get; set; }
        public ICollection<IMenuNode> Children { get; } = new List<IMenuNode>();
        public int Count { get; set; }

        public void AddNode(IMenuNode newNode)
        {
            Children.Add(newNode);
            IncrementCount();
        }

        public void IncrementCount()
        {
            Count++;
        }
    }
}