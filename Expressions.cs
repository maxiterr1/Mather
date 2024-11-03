using Program;
class Expression
{
    public static string? Execute(string expression)
    {
        if (expression == "")
            return null;
        char[] charExpression = expression.ToCharArray();
        int openParenthesisCount = 0, closeParenthesisCount = 0;
        foreach (char c in charExpression)
		{
            if (!ExprValidCharacter(c))
            {
                Programma.ErroreSintassi("Ci sono dei caratteri non validi!");
                return null;
            }
            if (c == '(')
                openParenthesisCount++;
            else if (c == ')')
                closeParenthesisCount++;
        }
        if (openParenthesisCount != closeParenthesisCount)
        {
            int differenza = Math.Abs(openParenthesisCount - closeParenthesisCount);
            string chedire = differenza == 1 ? "C'è una parentesi aperta non chiusa" : $"Ci sono {differenza} parentesi aperte non chiuse";
            Programma.ErroreSintassi(chedire + " o viceversa.");
            return null;
        }
        char last = charExpression.Last();
        if (last == '+' || last == '-' || last == '^' || last == '*' || last == '/' || last == '.')
        {
            Programma.ErroreSintassi($"Non puoi inserire '{last}' come ultimo carattere dell'espressione");
            return null;
        }
        int[] openParenthesis = new int[openParenthesisCount];
        int[] closeParenthesis = new int[closeParenthesisCount];
        char charPrima;
        string[] numeriPrima = new string[openParenthesisCount];
        if (openParenthesisCount != 0)
        {
            int[] count = [0, 0]; //Il primo valore conta le parentesi aperte, il secondo le chiuse

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
                                bastaNumeri = true;
                        }
                        while (!bastaNumeri);

                        //Invertiamo i numeri. Vengono "letti" da destra a sinistra perciò saranno al contrario
                        numeriPrima[count[0]] = Programma.Reverse(numeriPrima[count[0]]);
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
            List<List<char>> insideParenthesis = new List<List<char>>();
            for (int i = 0; i < openParenthesisCount; i++)
            {
                insideParenthesis.Add(new List<char>());
                //Continuare trovare l'espressione corretta per il for
                //Guardare appunti sul quadernino
                for (int j = openParenthesis.Last() - i * 2 + 1; j < closeParenthesis.First() + i; j++)
                    insideParenthesis[i].Add(charExpression[j]);
                if (insideParenthesis[i].Count == 0)
                {
                    Programma.ErroreSintassi("ciao");
                    return null;
                }
                last = insideParenthesis[i].Last();
                if (last == '+' || last == '-' || last == '^' || last == '*' || last == '/' || last == '.')
                {
                    Programma.ErroreSintassi($"Non puoi inserire '{last}' come ultimo carattere nella parentesi");
                    return null;
                }
            }
            //Console.WriteLine($"ins {insideParenthesis[0].ElementAt(0)}");
        }

        return null;//openParenthesisCount.ToString();
    }

    public static bool ExprValidCharacter(char c)
    {
        char[] permessi = ['+', '-', '*', '/', '^', '.', '(', ')'];
        if (char.IsNumber(c))
            return true;
        else
        {
            for (int i = 0; i < permessi.Length; i++)
                if (c == permessi[i])
                    return true;
        }
        return false;
    }
}
