
using System.Text;

namespace Base.ArithmeticExpressionsQueueDec;

/// <summary>
///     Вычисление выражения.
/// </summary>
public static class ExpressionCalculation
{
    public static readonly IDictionary<string, int> operatorPriorities = new Dictionary<string, int>() { { "*", 1 }, { "/", 1 }, { "+", 0 }, { "-", 0 } };

    public static bool IsBracket(string c)
    {
        return c == "(" || c == ")";
    }

    /// <summary>
    ///     Преобразование выражения в массив.
    /// </summary>
    /// <param name="expression">Арифметическое выражение.</param>
    /// <returns>Арифметическое выражение в виде массива.</returns>
    public static string[] Parse(string expression)
    {
        var result = new List<string>();
        var builder = new StringBuilder();
        for (int i = 0; i < expression.Length; i++)
        {
            var convert = Convert.ToString(expression[i]);

            if (IsBracket(convert) ||
                operatorPriorities.ContainsKey(convert))
            {
                if (builder.Length > 0)
                {
                    result.Add(builder.ToString());
                    builder.Clear();
                }

                result.Add(convert);

                continue;
            }

            builder.Append(convert);
        }

        if (builder.Length > 0)
        {
            result.Add(builder.ToString());
            builder.Clear();
        }

        return result.ToArray();
    }

    /// <summary>
    ///     Преобразование в обратную польскую запись (ОПЗ).
    /// </summary>
    /// <param name="expression">Входящее выражение в виде массива.</param>
    /// <returns>Преобразованное выражение (постфиксная запись).</returns>
    public static string[] ConvertToOpz(string[] expression)
    {
        var operators = new Stack<string>();
        var opz = new List<string>();
        foreach (string current in expression)
        {
            // если скобки
            if (IsBracket(current))
            {
                if (current == ")")
                {
                    // всё внутри скобок вытаскиваем
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        opz.Add(operators.Pop());
                    }

                    // удаление "("
                    operators.Pop();

                    continue;
                }

                operators.Push(current);

                continue;
            }

            // если операторы
            if (operatorPriorities.TryGetValue(current, out int value))
            {
                // вытаскиваются операторы, приоритет которых больше чем текущий
                while (operators.Count > 0)
                {
                    var prev = operators.Peek();
                    if (IsBracket(prev) || operatorPriorities[prev] < value)
                    {
                        break;
                    }

                    opz.Add(operators.Pop());
                }

                operators.Push(current);

                continue;
            }

            opz.Add(current);
        }

        // добавление оставшихся операция в порядке приоритета
        while (operators.Count > 0)
        {
            opz.Add(operators.Pop());
        }

        return opz.ToArray();
    }

    /// <summary>
    ///     Вычисление обратной польской записи (ОПЗ).
    /// </summary>
    /// <param name="expression">Входящее выражение в виде массива.</param>
    /// <returns>Результат вычисления.</returns>
    public static float Calculation(string[] expression)
    {
        var compute = new Stack<string>();
        foreach (var item in ConvertToOpz(expression))
        {
            // если не оператор
            if (!operatorPriorities.ContainsKey(item))
            {
                compute.Push(item);

                continue;
            }

            var operands = (compute.Pop(), compute.Pop());
            compute.Push(Calculate(operands, item));
        }

        return float.Parse(compute.Pop());

        static string Calculate((string, string) operands, string @operator)
        {
            // тут из-зв взятия из стека наоборот
            float operand1 = float.Parse(operands.Item2);
            float operand2 = float.Parse(operands.Item1);
            float result = @operator switch
            {
                "*" => operand1 * operand2,
                "/" => operand1 / operand2,
                "+" => operand1 + operand2,
                "-" => operand1 - operand2,
                _ => throw new NotImplementedException($"{nameof(Calculate)} switch ex"),
            };

            return result.ToString();
        }
    }
}
