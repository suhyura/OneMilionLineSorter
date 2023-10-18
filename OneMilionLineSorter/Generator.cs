internal class Generator
{
    private readonly Random random = new Random();
    private readonly string[] words;
    public Generator()
    {
        words = GenerateWords();
    }

    private string[] GenerateWords()
    {
        return Enumerable.Range(0, 10_000)
                            .Select(i => new string(
                                         Enumerable.Range(0, random.Next(20, 100))
                                            .Select(z => (char)random.Next('A', 'Z')).ToArray()
                                            )
                            ).ToArray();
    }

    public string Generate(int linesCount)
    {
        var fileName = $"Lines {linesCount}.txt";

        using (var writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < linesCount; i++)
            {
                writer.WriteLine(GenerateNumer() + ". " + GenerateString());
            }
        }
        return fileName;
    }

    private string GenerateString()
    {
        return words[random.Next(0, words.Length)];
    }

    private string GenerateNumer()
    {
        return random.Next(0, 10_000).ToString();
    }
}