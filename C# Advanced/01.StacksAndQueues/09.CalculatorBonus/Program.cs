using System;
using System.Collections.Generic;

class ShuntingYard
{
    // Метод за определяне на приоритета на операторите
    private static int GetPrecedence(char op)
    {
        return op switch
        {
            '+' or '-' => 1,
            '*' or '/' => 2,
            _ => 0
        };
    }

    // Проверява дали даден символ е оператор
    private static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    // Алгоритъмът Shunting Yard започва тук
    public static string ConvertToRPN(string infix)
    {
        var output = new List<string>();  // Лист за съхранение на израза в RPN
        var operators = new Stack<char>();  // Стек за оператори и скоби

        for (int i = 0; i < infix.Length; i++)
        {
            char c = infix[i];

            if (char.IsDigit(c))
            {
                // Ако символът е цифра, го добавяме към резултата
                string number = c.ToString();
                while (i + 1 < infix.Length && (char.IsDigit(infix[i + 1]) || infix[i + 1] == '.'))
                {
                    number += infix[++i];
                }
                output.Add(number);
            }
            else if (c == '(')
            {
                // Ако срещнем лява скоба, я добавяме в стека
                operators.Push(c);
            }
            else if (c == ')')
            {
                // Ако срещнем дясна скоба, извеждаме операторите от стека до срещане на лява скоба
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    output.Add(operators.Pop().ToString());
                }
                operators.Pop(); // Премахва лявата скоба '(' от стека
            }
            else if (IsOperator(c))
            {
                // Ако срещнем оператор, проверяваме приоритета му и го поставяме в стека
                while (operators.Count > 0 && IsOperator(operators.Peek()) &&
                       GetPrecedence(operators.Peek()) >= GetPrecedence(c))
                {
                    output.Add(operators.Pop().ToString());
                }
                operators.Push(c);
            }
        }

        // След като обработим целия израз, извеждаме всички останали оператори от стека
        while (operators.Count > 0)
        {
            output.Add(operators.Pop().ToString());
        }

        return string.Join(" ", output);
    }
}

class RPNCalculator
{
    // Изчислява израза в RPN
    public static double EvaluateRPN(string rpnExpression)
    {
        var stack = new Stack<double>();
        var tokens = rpnExpression.Split(' ');

        foreach (var token in tokens)
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else
            {
                double rightOperand = stack.Pop();
                double leftOperand = stack.Pop();

                double result = token switch
                {
                    "+" => leftOperand + rightOperand,
                    "-" => leftOperand - rightOperand,
                    "*" => leftOperand * rightOperand,
                    "/" => leftOperand / rightOperand,
                    _ => throw new InvalidOperationException($"Unknown operator: {token}")
                };

                stack.Push(result);
            }
        }

        return stack.Pop();
    }

    static void Main()
    {
        Console.WriteLine("Въведете инфиксен математически израз:");

        string infixExpression = Console.ReadLine();

        try
        {
            // Преобразуване на инфиксния израз в RPN с Shunting Yard алгоритъма

            string rpnExpression = ShuntingYard.ConvertToRPN(infixExpression);
            Console.WriteLine($"RPN израз: {rpnExpression}");

            // Изчисление на крайния резултат от RPN израза

            double result = RPNCalculator.EvaluateRPN(rpnExpression);
            Console.WriteLine($"Резултат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Грешка: {ex.Message}");
        }
    }
}
