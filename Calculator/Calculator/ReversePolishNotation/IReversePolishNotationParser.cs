using System.Collections.Generic;

namespace Calculator
{
    public interface IReversePolishNotationParser
    {
        List<string> GetPostfixExpression(string input);
    }
}