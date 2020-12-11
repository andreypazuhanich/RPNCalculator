namespace Calculator
{
    public class DivisionOperator : BinaryOperator
    {
        public DivisionOperator() : base()
        {
            Priority = 2;
            Literal = "/";
        }
        public override decimal Calculate(decimal[] x) => x[0]/x[1];
    
        public override Operator Clone()
        {
            return new DivisionOperator()
            {
                Literal = Literal,
                Priority = Priority,
                ArgumentsCount = ArgumentsCount
            };
        }
    }
}