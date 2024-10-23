
namespace Program
{
    class Programma
    {
        static void Main()
        {
            Console.WriteLine("Benvenuto su Mathes!\nScegli un'opzione:\n1: Espressione");
            int scelta = Scelta(1);
            switch (scelta)
            {
                case 1:
                    string? solution = null;
                    do
                    {
                    Console.WriteLine("Inserisci espressione: ");
                    string? espr = Console.ReadLine();
                    solution = Expression.Execute(espr);
                    Console.WriteLine(solution);
                    }
                    while (solution == null || solution == "");
                    break;
                case 2:
                    string test = "3242";
                    test = Reverse(test);
                    Console.WriteLine(test);
                    break;
            }
        }
        static public int Scelta(int MaxValue)
        {
            int scelta = 0;
            bool valido = false;
            do
            {
                try
                {
                    scelta = int.Parse(Console.ReadLine());
                    if (scelta > MaxValue + 1)
                        throw new Exception();
                    valido = true;
                }
                catch(Exception)
                {
                    Console.WriteLine("Non valido!");
                }
            }
            while (!valido);
            return scelta;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}