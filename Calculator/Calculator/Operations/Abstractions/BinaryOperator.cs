namespace Calculator
{
    public abstract class BinaryOperator : Operator, IContainsArgumentsCount
    {
        public int ArgumentsCount { get; set; } = 2;
    }
}