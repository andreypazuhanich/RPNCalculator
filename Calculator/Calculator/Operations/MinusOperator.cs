namespace Calculator
{
    public class MinusOperator : BinaryOperator
    {
        public MinusOperator(): base()
        {
            Priority = 1;
            Literal = "-";
        }

        public override decimal Calculate(decimal[] x) => x[0]-x[1];

        public override Operator Clone()
        {
            return new MinusOperator()
            {
                Literal = Literal,
                Priority = Priority,
                ArgumentsCount = ArgumentsCount
            };
        }

    }
}