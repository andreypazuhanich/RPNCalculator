using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class ReversePolishNotationParser : IReversePolishNotationParser
    {
        private readonly Dictionary<string, Operator> _hashedOperators;

        public ReversePolishNotationParser(Dictionary<string, Operator> hashedOperators)
        {
            _hashedOperators = hashedOperators;
        }
        
        public List<string> GetPostfixExpression(string input)
        {
            List<string> result = new List<string>();
            Stack<string> operStack = new Stack<string>();

            foreach(var token in GetNextToken(input))
            {
                if (IsNumber(token))
                    result.Add(token);
                else
                {
                    if (IsBracket(token))
                    {
                        if (token.Equals("("))
                            operStack.Push(token);
                        else
                        {
                            var oper = operStack.Pop();
                            while (!oper.Equals("("))
                            {
                                result.Add(oper);
                                oper = operStack.Pop();
                            }
                        }
                    }
                    else
                    {
                        if (IsOperation(token))
                        {
                            while(operStack.Count > 0 && GetPriority(token) <= GetPriority(operStack.Peek()))
                                    result.Add(operStack.Pop());
                            operStack.Push(token);
                        }
                    }
                }
            }
            
            while (operStack.Count > 0)
                result.Add(operStack.Pop().ToString());

            return result;
        }
        
        private IEnumerable<string> GetNextToken(string input)
        {
            int i = 0;
            while (i < input.Length)
            {
                var item = string.Empty + input[i];
                if (IsNumber(input[i]))
                    for (int j = i + 1; j < input.Length && IsNumber(input[j]); j++)
                        item += input[j];
                
                else if(!IsBracket(input[i]))
                {
                    for (int j = i + 1; j < input.Length && !IsNumber(input[j]) && !IsBracket(input[j]); j++)
                        item += input[j];
                }
                yield return item;
                i += item.Length;
            }
        }

        private int GetPriority(string oper)
        {
            if (IsBracket(oper))
                return 0;
            return _hashedOperators[oper].Priority;
        }

        private bool IsOperation(string oper) => _hashedOperators[oper] != null;
        
        
        private bool IsBracket(char symbol) => "()".IndexOf(symbol) != -1 ? true : false;
        private bool IsBracket(string token) => IsBracket(char.Parse(token));


        private bool IsNumber(char symbol) => Char.IsDigit(symbol) || (",.".IndexOf(symbol) != -1);

        private bool IsNumber(string token)
        {
            foreach (var c in token)
            {
                if (!IsNumber(c))
                    return false;
            }
            return true;
        }
    }
}