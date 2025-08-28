namespace Untility
{
    public class PanelMath
    {
        private static PanelMath instance;

        public static PanelMath Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PanelMath();
                }

                return instance;
            }
        }

        public int Compute(int a, int b, string op)
        {
            switch (op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                default:
                    return -1;
            }
        }

    }
}