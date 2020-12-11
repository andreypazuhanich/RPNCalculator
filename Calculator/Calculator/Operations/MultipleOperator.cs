namespace Calculator
{
    public class MultipleOperation : BinaryOperator
    {
        public MultipleOperation() : base()
        {
                Priority = 2;
                Literal = "*";
        }
        public override decimal Calculate(decimal[] x) => x[0]*x[1];
    
        public override Operator Clone()
        {
            return new MultipleOperation()
            {
                Literal = Literal,
                Priority = Priority,
                ArgumentsCount = ArgumentsCount
            };
        }

    }
}