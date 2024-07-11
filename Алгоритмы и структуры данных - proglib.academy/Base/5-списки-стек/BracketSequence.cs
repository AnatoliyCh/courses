using System.Data.Common;

namespace Base.ListStack;

public static class BracketSequence
{
    private static readonly string errorSequence = "IMPOSSIBLE";
    public static readonly IDictionary<char, char> oppositesLeft = new Dictionary<char, char>() { { ')', '(' }, { ']', '[' }, { '}', '{' }, };
    public static readonly IDictionary<char, char> oppositesRight = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' }, };

    public static string Execute(string sequence)
    {
        Stack<char> brackets = new();
        string? leftAnswer = null;
        string? rightAnswer = null;

        for (int i = 0; i < sequence.Length; i++)
        {
            var bracket = sequence[i];

            // удаление противоположных скобок
            // при одинаковом ТИПЕ и последовательном расположении
            if (brackets.Count > 0
                && GetOpposites(brackets.Peek()).item == bracket
                && oppositesRight.ContainsKey(brackets.Peek()) && oppositesLeft.ContainsKey(bracket))
            {
                brackets.Pop();

                continue;
            }

            brackets.Push(bracket);
        }

        // формирование ответа
        while (brackets.Count > 0)
        {
            var result = GetOpposites(brackets.Pop());
            if (result.collection == oppositesLeft)
            {
                leftAnswer += result.item;
            }
            else rightAnswer += result.item;
        }

        var answer = $"{leftAnswer}{sequence}{rightAnswer}";

        return HasWrongSequence(answer) ? errorSequence : answer;
    }

    /// <summary>
    ///     Возвращает противоположную скобку.
    /// </summary>
    /// <param name="bracket">Скобочная последовательность.</param>
    /// <returns>противоположность скобки: коллекция</returns>
    public static (char item, IDictionary<char, char> collection) GetOpposites(char bracket)
    {
        if (oppositesLeft.ContainsKey(bracket))
        {
            return (oppositesLeft[bracket], oppositesLeft);
        }

        return (oppositesRight[bracket], oppositesRight);
    }

    /// <summary>
    ///     Проверка скобочной последовательности на правильность.
    /// </summary>
    /// <param name="value">Скобочная последовательность.</param>
    /// <returns>Правильная ли скобочная последовательность?</returns>
    public static bool HasWrongSequence(string value)
    {
        Stack<char> brackets = new();
        foreach (var bracket in value)
        {
            if (brackets.Count > 0)
            {
                var bracketPrev = brackets.Peek();
                var opposites = GetOpposites(bracketPrev);

                // пред. смотрит вправо прим.: {
                // тек. смотрит влево прим.: } 
                // и они НЕ одного типа прим.: {]
                if (oppositesRight.ContainsKey(bracketPrev) && oppositesLeft.ContainsKey(bracket)
                    && opposites.item != bracket)
                {
                    return true;
                }

                // тут закрывающие скобки () уничтожаются
                if (opposites.item == bracket)
                {
                    brackets.Pop();

                    continue;
                }
            }

            brackets.Push(bracket);
        }

        return brackets.Count != 0;
    }
}