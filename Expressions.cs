using Program;
class Expression
{
    public static string? Execute(string expression)
    {
        char[] charExpression = expression.ToCharArray();
        int openParenthesisCount = 0, closeParenthesisCount = 0;
        foreach (char c in charExpression)
		{
            if (c == '(')
                openParenthesisCount++;
            else if (c == ')')
                closeParenthesisCount++;
        }
        if (openParenthesisCount != closeParenthesisCount)
        {
            int differenza = Math.Abs(openParenthesisCount - closeParenthesisCount);
            string chedire = differenza == 1 ? "C'è una parentesi aperta non chiusa" : $"Ci sono {differenza} parentesi aperte non chiuse";
            Console.WriteLine("Errore di sintassi: " + chedire + " o viceversa.");
            return null;
        }

        int[] openParenthesis = new int[openParenthesisCount];
        int[] closeParenthesis = new int[closeParenthesisCount];
        char charPrima;
        string[] numeriPrima = new string[openParenthesisCount];
        if (openParenthesisCount != 0)
        {
            int[] count = [0, 0];

            //Ciclo for che conta le parentesi
            for (int i = 0; i < charExpression.Length; i++)
            {
                if (charExpression[i] == '(') //Parentesi aperta trovata
                {
                    openParenthesis[count[0]] = i; //Imposta la posizione della n parentesi
                    //Controlla se la parentesi non è il primo carattere dell'equazione
                    if (i != 0)
                    {
                        bool bastaNumeri = false;
                        int doWhileCount = i;
                        numeriPrima[count[0]] = "";
                        do
                        {   
                            if (doWhileCount != 0)
                            {
                                charPrima = charExpression[doWhileCount - 1];
                                if (char.IsNumber(charPrima))
                                {
                                    numeriPrima[count[0]] += charPrima;
                                    doWhileCount--;
                                }
                                else
                                    bastaNumeri = true;
                            }
                            else
                            {
                                bastaNumeri = true;
                            }
                        }
                        while (!bastaNumeri);

                        //Invertiamo i numeri. Vengono "letti" da destra a sinistra perciò saranno al contrario
                        //numeriPrima[count[0]] = Programma.Reverse(numeriPrima[count[0]]);
                        Console.WriteLine(numeriPrima[count[0]]);
                    }
                    count[0]++;
                    Console.WriteLine($"Parentesi aperta trovata alla posizione {i}");
                }
                else if (charExpression[i] == ')')
                {
                    closeParenthesis[count[1]] = i;
                    count[1]++;
                    if (count[1] >= closeParenthesisCount)
                        break;       
                }
            }
            List<char> insideParenthesis = [];
            //Continuare == 1
            if (openParenthesisCount != 1)
            {
                for (int i = openParenthesis.Last() + 1; i < closeParenthesis.Last() - 1; i++)
                {
                    if (ExprValidCharacter(charExpression[i]))
                        insideParenthesis.Add(charExpression[i]);
                    else
                    {
                        Console.WriteLine("Non validooooo");
                        return null;
                    }
                }
            }
        }

        return openParenthesisCount.ToString();
    }

    public static bool ExprValidCharacter(char c)
    {
        char[] permessi = {'+', '-', '*', '/', '^', '.'};
        for (int i = 0; i < permessi.Length; i++)
        {
            if (c == permessi[i])
            {
                return true;
            }
        }
        if (char.IsNumber(c))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
