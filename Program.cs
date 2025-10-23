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

int UpperBounded (int min, int max, int number) {
    while (number > max) {
        int overflow = number - max;
        number = min + overflow;
    }
    return number;
}

string OffsetCharacter(string text, int seed){
    int characterMin = 96;
    int characterMax = 122;
    return string.Join(" ", text.Split(" ").Select(word =>
        string.Join("", word.ToCharArray().Select(letter => {
            Console.WriteLine($"{UpperBounded(characterMin, characterMax, (int)letter + seed)} {(char)UpperBounded(characterMin, characterMax, (int)letter + seed)}");
            return (char)(UpperBounded(characterMin, characterMax, (int)letter + seed));
        }))
    ));
}

Random rand = new Random();
Console.WriteLine("Welcome to Pig Latin encrytion tool");
Console.Write("Please enter the message: ");
string input = Console.ReadLine();
Console.WriteLine($"In pig latin that's: {TraslateToPigLatin(input)}");
int seed = rand.Next(1,26);
Console.WriteLine($"We can encrypt that as: {OffsetCharacter(TraslateToPigLatin(input), seed)}");
