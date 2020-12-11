namespace Calculator
{
    public abstract class UnaryOperator : Operator, IContainsArgumentsCount
    {
        public int ArgumentsCount { get; set; } = 1;
    }
}