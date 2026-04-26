using System;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Предоставляет вспомогательные методы для работы с простыми числами.
/// </summary>
public static class PrimeUtils
{
    /// <summary>
    /// Определяет, является ли заданное число простым.
    /// </summary>
    /// <param name="number">Число для проверки.</param>
    /// <returns>
    /// <c>true</c>, если число простое; в противном случае — <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Алгоритм проверяет делимость числа на все нечётные делители до √n.
    /// Числа меньше 2 не считаются простыми.
    /// </remarks>
    public static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        int boundary = (int)Math.Floor(Math.Sqrt(number));
        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}
