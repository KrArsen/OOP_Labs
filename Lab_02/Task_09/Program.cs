﻿using System;

class Task09
{
    static void Main()
    {
        char[] alphabet = new char[26];
        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)('a' + i);
        }
        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            char ch = word[i];
            int index = ch - 'a';
            Console.WriteLine(ch + " -> " + index);
        }
    }
}