using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.MiserableParodyCalculator
{
    public class MiserableParodyCalculator
    {
        private const string ErrorPrefix = "[[SYNTAX ERROR]]";

        private readonly char[] _validOrderedOperators = new char[]
        {
           '/', '*', '+', '-'
        };

        private readonly List<double> _digitList = new List<double>();
        private readonly List<char> _operatorList = new List<char>();


        public bool TryToCalculate(string input, out double result)
        {
            result = 0;

            if (char.IsDigit(input[0]) is false || char.IsDigit(input[input.Length - 1]) is false)
            {
                Console.WriteLine($"{ErrorPrefix} Input does not start or end with a digit.");
                return false;
            }

            _digitList.Clear();
            _operatorList.Clear();

            if (!TryParseInputAndPopulateLists(input))
            {
                return false;
            }

            // if digitList only contains a single number, there is nothing to calcuate so just return the value
            if (_digitList.Count == 1)
            {
                result = _digitList[0];
                return true;
            }


            // Go through the operators in order of execution.
            foreach (char currentOperator in _validOrderedOperators)
            {
                for (int i = 0; i < _operatorList.Count; i++)
                {
                    char charInList = _operatorList[i];
                    if (charInList.Equals(currentOperator))
                    {
                        double a = _digitList[i];
                        double b = _digitList[i + 1];
                        double newValue = 0;
                        switch (currentOperator)
                        {
                            case '/':
                                newValue = a / b;
                                break;
                            case '*':
                                newValue = a * b;
                                break;
                            case '+':
                                newValue = a + b;
                                break;
                            case '-':
                                newValue = a - b;
                                break;
                        }

                        _digitList[i] = newValue;

                        _digitList.RemoveAt(i+1);
                        _operatorList.RemoveAt(i);
                        i--;
                    }
                }
            }

            result = _digitList[0];
            return true;
        }

        private bool TryParseInputAndPopulateLists(string input)
        {
            bool lastCharWasOperator = false;
            int digitLength = 0;
            int nextDigitStartIndex = 0;
            char currentChar;

            for (int i = 0; i < input.Length; i++)
            {
                currentChar = input[i];
                if (char.IsDigit(currentChar))
                {
                    lastCharWasOperator = false;
                    digitLength++;
                }
                else if (IsOperator(currentChar))
                {
                    if (lastCharWasOperator is true)
                    {
                        Console.WriteLine($"{ErrorPrefix} Multiple operators in a row not allowed.");
                        return false;
                    }

                    if (!TryAddDigitToList(input, nextDigitStartIndex, digitLength))
                    {
                        return false;
                    }

                    _operatorList.Add(currentChar);

                    nextDigitStartIndex = i + 1; // Add 1 since i is currently on the operator
                    lastCharWasOperator = true;
                    digitLength = 0;
                }
                else
                {
                    Console.WriteLine($"{ErrorPrefix} '{currentChar}' is not a valid character.");
                    return false;
                }
            }

            // Add the last digit
            if (!TryAddDigitToList(input, nextDigitStartIndex, digitLength))
            {
                return false;
            }

            return true;
        }

        private bool TryAddDigitToList(string input, int substringStartIndex, int substringLength)
        {
            string digitSubstring = input.Substring(substringStartIndex, substringLength);
            if (double.TryParse(digitSubstring, out double digit))
            {
                _digitList.Add(digit);
                return true;
            }
            else
            {
                Console.WriteLine($"{ErrorPrefix} Failed to parse {digitSubstring} into a double.");
                return false;
            }
        }


        private bool IsOperator(char input)
        {
            return _validOrderedOperators.Contains(input);
        }
    }

}
