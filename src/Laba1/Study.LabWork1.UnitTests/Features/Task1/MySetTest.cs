using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1;

[TestFixture]
public class MySetTest
{
    /// <summary>
    /// Тест конструктора
    /// </summary>
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, "{1, 2, 3, 4}")]
    [TestCase(new int[] { 4, 2, 6, 2, 4 }, "{4, 2, 6}")]
    [TestCase(new int[] { 5, 5, 3, 3 }, "{5, 3}")]
    public void ConstructorTest(int[] arr, string exp)
    {
        MySet<int> set = new MySet<int>(new List<int> (arr));
        Assert.That(set.ToString, Is.EqualTo(exp), $"Список не равен {exp}");
    }

    /// <summary>
    /// Тест объединения
    /// </summary>
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 3, 6, 6, 6, 8 }, new int[] { 1, 2, 3, 4, 6, 8 })]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 4, 3, 2, 2, 1 }, new int[] { 1, 2, 2, 3, 4 })]
    public void UnificationTest(int[] arr1, int[] arr2, int[] exp)
    {
        MySet<int> set1 = new MySet<int>(new List<int> (arr1));
        MySet<int> set2 = new MySet<int>(new List<int> (arr2));

        MySet<int> trueRes = new MySet<int>(new List<int> (exp));
        MySet<int> res = set1 | set2;

        Assert.That(res.ToString(), Is.EqualTo(trueRes.ToString()), $"Список не равен {trueRes.ToString()}");
    }

    /// <summary>
    /// Тест разности
    /// </summary>
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 3, 4, 5, 6 }, new int[] { 1, 2 })]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 5, 5, 6, 7 }, new int[] { 1, 2, 3, 4 })]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 4, 3, 2 }, new int[] { 1 })]
    public void DifferenceTest(int[] arr1, int[] arr2, int[] exp)
    {
        MySet<int> set1 = new MySet<int>(new List<int>(arr1));
        MySet<int> set2 = new MySet<int>(new List<int>(arr2));

        MySet<int> trueRes = new MySet<int>(new List<int>(exp));
        MySet<int> res = set1 - set2;

        Assert.That(res.ToString(), Is.EqualTo(trueRes.ToString()), $"Список не равен {trueRes.ToString()}");
    }

    /// <summary>
    /// Тест пересечения
    /// </summary>
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 3, 4, 5, 6 }, new int[] { 3, 4 })]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 1, 3, 2, 4 }, new int[] { 1, 2, 3, 4 })]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 4, 3, 2 }, new int[] { 2, 3, 4 })]
    public void IntersectionTest(int[] arr1, int[] arr2, int[] exp)
    {
        MySet<int> set1 = new MySet<int>(new List<int>(arr1));
        MySet<int> set2 = new MySet<int>(new List<int>(arr2));

        MySet<int> trueRes = new MySet<int>(new List<int>(exp));
        MySet<int> res = set1 & set2;

        Assert.That(res.ToString(), Is.EqualTo(trueRes.ToString()), $"Список не равен {trueRes.ToString()}");
    }

    /// <summary>
    /// Тест симметрической разности
    /// </summary>
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 3, 4, 5, 6 }, new int[] { 1, 2, 5, 6 })]
    [TestCase(new int[] { 1, 2, 2, 3, 4, 7 }, new int[] { 1, 3, 2, 4, 5 }, new int[] { 7, 5 })]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 4, 3, 2, 8 }, new int[] { 1, 8 })]
    public void SymmetricalDifferenceTest(int[] arr1, int[] arr2, int[] exp)
    {
        MySet<int> set1 = new MySet<int>(new List<int>(arr1));
        MySet<int> set2 = new MySet<int>(new List<int>(arr2));

        MySet<int> trueRes = new MySet<int>(new List<int>(exp));
        MySet<int> res = set1 / set2;

        Assert.That(res.ToString(), Is.EqualTo(trueRes.ToString()), $"Список не равен {trueRes.ToString()}");
    }

    /// <summary>
    /// Тест равенства 
    /// </summary>
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 3, 4, 5, 6 }, false)]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 4, 3, 2, 1 }, true)]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, true)]
    public void EqualityTest(int[] arr1, int[] arr2, bool exp)
    {
        MySet<int> set1 = new MySet<int>(new List<int>(arr1));
        MySet<int> set2 = new MySet<int>(new List<int>(arr2));

        Assert.That(set1 == set2, Is.EqualTo(exp));
    }


    /// <summary>
    /// Тест неравенства
    /// </summary>
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 3, 4, 5, 6 }, true)]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 4, 3, 2, 1 }, false)]
    [TestCase(new int[] { 1, 2, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, false)]
    public void InEqualityTest(int[] arr1, int[] arr2, bool exp)
    {
        MySet<int> set1 = new MySet<int>(new List<int>(arr1));
        MySet<int> set2 = new MySet<int>(new List<int>(arr2));

        Assert.That(set1 != set2, Is.EqualTo(exp));
    }
}
