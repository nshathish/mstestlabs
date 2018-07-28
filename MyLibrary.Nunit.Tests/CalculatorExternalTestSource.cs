namespace MyLibrary.Nunit.Tests
{
  using System.Collections.Generic;
  using NUnit.Framework;

  public class CalculatorExternalTestSource
  {
    public static IEnumerable<TestCaseData> TestData
    {
      get
      {
        yield return new TestCaseData(1, 2).Returns(3);
        yield return new TestCaseData(3, 5).Returns(8)
          .SetName("3 + 5")
          .SetDescription("3 plus 5");
      }
    }
  }
}