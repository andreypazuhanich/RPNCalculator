namespace Calculator
{
    public class PlusOperator : BinaryOperator
    {
        public PlusOperator() : base()
        {
            Priority = 1;
            Literal = "+";
        }
        public override decimal Calculate(decimal[] x) => x[0]+x[1];
        
        public override Operator Clone()
        {
            return new PlusOperator()
            {
                Literal = Literal,
                Priority = Priority,
                ArgumentsCount = ArgumentsCount
            };
        }
    }
}