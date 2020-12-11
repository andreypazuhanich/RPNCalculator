using System.Collections.Generic;

namespace Calculator.Infrastructure
{
    public abstract class Node
    {
        public List<Node> Args { get; set; } = new List<Node>();
    }
}