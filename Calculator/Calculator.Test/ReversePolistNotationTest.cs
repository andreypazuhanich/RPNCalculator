using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Calculator.ReversePolistNotationTest
{
    public class ReversePolistNotationTest
    {
        private static List<Operator> operators = new List<Operator>()
        {
            new MinusOperator(),
            new PlusOperator(),
            new MultipleOperation(),
            new DivisionOperator()
        };
        
        private static Dictionary<string,Operator> hashedOperators = operators.Select(oper => 
        new
        {
            Oper = oper,
            literal = oper.Literal
        })
        .ToDictionary(s => s.literal, s => s.Oper);
        
        [Fact]
        public void RpnParserIntegerExpression()
        {
            var reversePolishNotation = new ReversePolishNotationParser(hashedOperators);
            string input = "7-1-4/2-1";
            
            var expected = new List<string>()
            {
                "7", "1", "-", "4", "2", "/", "-", "1", "-"
            };
            var actual = reversePolishNotation.GetPostfixExpression(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RPNParserFractionalExpression()
        {
            var reversePolishNotation = new ReversePolishNotationParser(hashedOperators);
            
            string input = "2.3*3.8+4.31-1*2.57";
            var expected = new List<string>()
            {
                "2.3", "3.8", "*", "4.31", "+", "1", "2.57", "*", "-"
            };
            var actual = reversePolishNotation.GetPostfixExpression(input);
            Assert.Equal(expected,actual);

            
            
            string input2 = "2.332*3.3423+4.2341-1.4523*2.57";
            var expected2 = new List<string>()
            {
                "2.332", "3.3423", "*", "4.2341", "+", "1.4523", "2.57", "*", "-"
            };
            var actual2 = reversePolishNotation.GetPostfixExpression(input);
            Assert.Equal(expected,actual2);
        }
        
        [Fact]
        public void RPNParserExpressionWithBrackets()
        {
            var reversePolishNotation = new ReversePolishNotationParser(hashedOperators);
            
            string input = "2.3*(3.8+4.31)-1*2.57";
            var expected = new List<string>()
            {
                "2.3", "3.8", "4.31", "+", "*", "1", "2.57", "*", "-"
            };
            var actual = reversePolishNotation.GetPostfixExpression(input);
            Assert.Equal(expected,actual);
            
            string input2 = "5*3+(50/5)/(10-5)*3";
            var expected2 = new List<string>()
            {
                "5","3","*","50","5","/","10","5","-","/","3","*","+"
            };
            var actual2 = reversePolishNotation.GetPostfixExpression(input2);
            Assert.Equal(expected,actual);
        }
    }
}