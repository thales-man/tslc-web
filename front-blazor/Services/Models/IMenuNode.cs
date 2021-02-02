using System.Collections.Generic;

namespace Front.Services.Models
{
    public interface IMenuNode
    {
        string Name { get; }
        string Topic { get; }
        string Year { get; }
        string Month { get; }
        string Article { get; }
        ICollection<IMenuNode> Children { get; }
        int Count { get; }

        void AddNode(IMenuNode newNode);
        void IncrementCount();
    }
}