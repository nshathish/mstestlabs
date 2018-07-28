
namespace MyLibraray
{
  public class Calculator
  {

    // without checked, int.MaxValue + 1 will not throw an exception, but will roll over to the max negative value
    public int Add(int a, int b) => checked(a + b);
  }
}
