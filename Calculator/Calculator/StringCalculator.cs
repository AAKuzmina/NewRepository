using System.Linq;

namespace Calculator
{
    public class StringCalculator
    {     
        public StringCalculator()
        {
            Sum = 0;
        }
        public int Sum { get; set; }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return Sum;

            var numb = Parser(numbers);
            foreach (var n in numb)
                Sum += n;

            return Sum;
        }

        public int [] Parser(string numbers)
        {
            var numb = numbers.Split(',').Select(int.Parse).ToArray();
            
            return numb;
        }
    }
}
