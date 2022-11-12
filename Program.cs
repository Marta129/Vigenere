class Program 
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Text:");
        string input=Console.ReadLine();
        Console.WriteLine("Enter Key:");
        string key = Console.ReadLine();
        bool okay = true;
        for(int i=0;i<key.Length;i++)
        {
            int aux = (int)key[i];
            if(!(65<=aux && aux<=90 || 97<=aux && aux<=122))
            {
                okay = false;
                break;
            }
        }
        if(okay)
        {
            char[] letters = new char[26];
            int A = 65;
            for (int i = 0; i < 26; i++)
            {
                letters[i] = (char)A;
                A++;
            }
            Console.Write("Encrypted:");
            input = Encrypt_Decrypt(input, letters, key, true);
            Console.Write(input);
            Console.WriteLine();
            Console.Write("Decrypted:");
            input = Encrypt_Decrypt(input, letters, key, false);
            Console.Write(input);
        }
        else
        {
            Console.WriteLine("The key can not contain digits or special characters");
        }

    }
    static string Encrypt_Decrypt(string input, char[]letters,string key,bool okay)
    {
        input = Transform(input);
        key = Key(input, key);
        string aux = "";
        for(int i=0;i<input.Length; i++)
        {
            int a = (int)input[i];
            if (65<=a && a<=90)
            {
                int input_index = Array.IndexOf(letters, input[i]);
                int key_index = Array.IndexOf(letters, key[i]);
                int letter;
                switch (okay)
                {
                    case true:
                        letter = (input_index + key_index) % 26;
                        break;
                    case false:
                        letter = (input_index - key_index+26) % 26;
                        break;
                }
                aux += letters.GetValue(letter);
            }
            else
            {
                aux += input[i];
            }
        }
        input = aux;
        return input;
    }
    static string Key(string input,string key)
    {
        if (key.Length<input.Length)
        {
            string aux = "";
            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int a = (int)input[i];
                if (65<=a && a<=90)
                {
                    if (j == key.Length)
                    {
                        j = 0;
                    }
                    aux += key[j];
                    j++;
                }
                else
                {
                    aux += input[i];
                }
            }
            key = aux;
        }
        key = key.ToUpper();
        return key;
    }
    static string Transform(string input)
    {
        return input.ToUpper().Trim();
    }
}