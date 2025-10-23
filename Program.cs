// Max Sultan, October 22nd, Lab 7: Pig Latin
using System.Linq; 

string TraslateToPigLatin (string text){
    return string.Join(" ", text.Split(" ").Select(word => {
        string vowels = "aeiou";
        int firstVovelIndex = Array.FindIndex(word.ToCharArray(), character => vowels.Contains(character));
        string backHalf = word.Substring(firstVovelIndex);
        string consonantCluster = word.Substring(0, firstVovelIndex);
        return firstVovelIndex == 0 ?$"{word}way" : $"{backHalf}{consonantCluster}ay";
    }));
} 

Console.WriteLine("Welcome to Pig Latin encrytion tool");
Console.Write("Please enter the message: ");
string input = Console.ReadLine();
Console.WriteLine($"In pig latin that's: {TraslateToPigLatin(input)}");
