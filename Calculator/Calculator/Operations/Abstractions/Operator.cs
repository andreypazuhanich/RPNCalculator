using Calculator.Infrastructure;
using Microsoft.VisualBasic.CompilerServices;

namespace Calculator
{
    public abstract class Operator: Node
    {
        public string Literal { get; set;}
        public int Priority { get; set;}
        public abstract decimal Calculate(decimal[] x);
        public abstract Operator Clone();
    }
}