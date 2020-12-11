using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Infrastructure;

namespace Calculator
{
    public class Calculator
    {
        private readonly IReversePolishNotationParser _parser;
        private static List<Operator> _operators;
        private static Dictionary<string, Operator> _hashedOperators;
        static Calculator()
        {
            _operators = new List<Operator>()
            {
                new MinusOperator(),
                new PlusOperator(),
                new MultipleOperation(),
                new DivisionOperator()
            };

             _hashedOperators = _operators.Select(oper => 
                    new
                    {
                        Oper = oper,
                        literal = oper.Literal
                    })
                .ToDictionary(s => s.literal, s => s.Oper);
        }

        public Calculator()
        {
            _parser = new ReversePolishNotationParser(_hashedOperators);
        }

        public decimal Calculate(string input)
        {
            var reversePolishNotation = _parser.GetPostfixExpression(input);
            var node = GetExpressionTree(reversePolishNotation);
            return (CalculateResult(node) as Operand).Number;
        }

        private static Node GetExpressionTree(List<string> reversePolishNotation)
        {
            var itr = new Stack<string>();
            reversePolishNotation.Reverse();
            reversePolishNotation.ForEach(x => itr.Push(x));
            
            Node node = null;
            var nodeStack = new Stack<Node>();

            while (itr.Any())
            {
                var token = itr.Pop();
                decimal result;
                if (!decimal.TryParse(token.Replace(".", ","), out result))
                {
                    node = _operators.FirstOrDefault(s => s.Literal == token).Clone();
                    
                    for (int i = 0; i < (node as IContainsArgumentsCount).ArgumentsCount; i++)
                        node.Args.Add(nodeStack.Pop());

                    node.Args.Reverse();
                    nodeStack.Push(node);
                }
                else
                {
                    node = new Operand() { Number = result };
                    nodeStack.Push(node);
                }
            }
            return nodeStack.Pop();
        }
        
        private Operand CalculateResult(Node node)
        {
            
            for (int i = 0; i < node.Args.Count; i++)
            {
                var arg = node.Args[i];
                if (arg != null && !(arg is Operand))
                {
                    var operand = CalculateResult(arg);
                    node.Args[i] = operand;
                }
            }
            
            var decimals = node.Args.Select(a => (a as Operand).Number).ToArray();
            var result = new Operand()
            {
                Number =  (node as Operator).Calculate(decimals)
            };
            
            return result;
        }
    }
}