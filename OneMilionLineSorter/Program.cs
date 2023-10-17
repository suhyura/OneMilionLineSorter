internal class Program
{
    private static void Main(string[] args)
    {
        new Generator().Generate(1000);
        Console.WriteLine("Hello, World!");
    }
}
class Generator
{
    private readonly Random random = new Random();
    private readonly string[] words;
    public Generator()
    {
        words = Enumerable.Range(0, 10_000)
            .Select(i => new string(
                         Enumerable.Range(0, random.Next(20, 100))
                            .Select(z => (char)random.Next('A', 'Z')).ToArray()
                            )
            ).ToArray();

    }
    public void Generate(int linesCount)
    {
        var fileName = $"Lines {linesCount}.txt";

        using (var writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < linesCount; i++)
            {
                writer.WriteLine(GenerateNumer() + ". " + GenerateString());
            }
        }
    }

    private string GenerateString()
    {
        return words[random.Next(0,words.Length)];
    }

    private string GenerateNumer()
    {
        return random.Next(0, 10_000).ToString();
    }
}