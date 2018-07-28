
namespace MyLibrary.Nunit.Tests
{
  using System;
  using System.Collections;
  using MyLibraray;
  using NUnit.Framework;

  [TestFixture]
  public class CalculatorTests
  {
    private Calculator Sut { get; set; }

    private static IEnumerable SourceProperty
    {
      // ReSharper disable once UnusedMember.Local
      get
      {
        yield return new TestCaseData(1, 2).Returns(3);
        yield return new TestCaseData(3, 5).Returns(8)
          .SetName("3 + 5")
          .SetDescription("Add 3 plus 5");
      }
    }

    [SetUp]
    public void SetUp()
    {
      Sut = new Calculator();
    }
    
    [Test]
    public void Adding_Two_Numbers_Should_Return_Correct_Sum()
    {
      var sut = new Calculator();
      var result = sut.Add(1, 2);
      Assert.AreEqual(result, 3);
    }

    [Test]
    [TestCase(3, 7, ExpectedResult = 10)]
    [TestCase(-2, -3, ExpectedResult = -5)]
    public int Adding_Twn_Numbers_Should_Return_Correct_Sum_With_TestCases(int a, int b) => Sut.Add(a, b);

    [Test]
    public void Adding_To_MaxValue_Throws_Exception()
    {
      var exception = Assert.Catch<OverflowException>(() => Sut.Add(int.MaxValue, 1));
      Assert.That(exception, Is.TypeOf<OverflowException>());
    }


    [Test]
    [TestCaseSource(nameof(SourceProperty))]
    public int Adding_Two_Numbers_Should_Return_Correct_Sum_With_TestCaseSource(int a, int b) => Sut.Add(a, b);

    [Test]
    [TestCaseSource(typeof(CalculatorExternalTestSource), nameof(CalculatorExternalTestSource.TestData))]
    public int Adding_Two_Numbers_Should_Return_Correct_Sum_With_External_TestCaseSource(int a, int b) => Sut.Add(a, b);

    [Test]
    [Sequential]
    public void Add_Test_Sequntial(
      [Values(1, 3, 5)] int a,
      [Values(2, 5, 6)] int b,
      [Values(3, 8, 11)] int expected)
    {
      var result = Sut.Add(a, b);
      Assert.AreEqual(result, expected);
    }

    [Test]
    [Combinatorial]
    public void Run_Every_Combination_Test(
      [Values(1, 2, 3)] int a,
      [Values(3, 4, 5)] int b) => Sut.Add(a, b);


  }
}
