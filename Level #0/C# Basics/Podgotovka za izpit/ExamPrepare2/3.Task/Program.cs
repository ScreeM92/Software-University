using System;
    class Program
    {
        static void Main()
        {
            string expression = Console.ReadLine();
            double currentDigit = 0;
            double result = 0;
            char currentOperator = '\0';
            for (int i = 0; i < expression.Length - 1; i++)
            {
                if (char.IsDigit(expression[i])) //digit
                {
                    currentDigit = int.Parse(expression[i].ToString());
                    switch (currentOperator)
                    {
                        case '+':
                            result += currentDigit;
                            break;
                        case '-':
                            result -= currentDigit;
                            break;
                        case '*':
                            result *= currentDigit;
                            break;
                        case '/':
                            result /= currentDigit;
                            break;
                        default:
                            result = currentDigit;
                            break;
                    }
                }
                else if (expression[i] != '(' && expression[i] != ')') //operator
                {
                    switch (expression[i])
                    {
                        case '+':
                            currentOperator = '+';
                            break;
                        case '-':
                            currentOperator = '-';
                            break;
                        case '*':
                            currentOperator = '*';
                            break;
                        case '/':
                            currentOperator = '/';
                            break;
                        default:
                            currentOperator = '+';
                            break;
                    }
                }
                else // bracket
                {
                    i++;
                    while (true)
                    {
                        
                    }
                }
            }
        }
    }

