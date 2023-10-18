internal class Program
{
    private static void Main(string[] args)
    {
        var fileName = new Generator().Generate(10_000);
        new Sorter().Sort(fileName, 1000);
        Console.WriteLine("Hello, World!");
    }
    class Sorter
    {
        public void Sort(string filename, int partLinesCount)
        {
            var files = SplitFile(filename, partLinesCount);
            SortParts(files);
            SortResult(files);

        }

        private void SortResult(string[] files)
        {
            throw new NotImplementedException();
        }

        private void SortParts(string[] files)
        {
            throw new NotImplementedException();
        }

        private string[] SplitFile(string filename, int partLinesCount)
        {
            var parts = new List<string>();
            using (StreamReader sr = new StreamReader(filename))
            {
                int partNumber = 0;
                while (!sr.EndOfStream)
                {   
                    partNumber++;
                    string partFileName = partNumber + ".txt";
                    parts.Add(partFileName);
                    using (var writer = new StreamWriter(partFileName))
                    {

                        for (int i = 0; i < partLinesCount; i++)
                        {
                            if (sr.EndOfStream)
                                break;
                            writer.WriteLine(sr.ReadLine());
                        }
                    }

                }
            }
            return parts.ToArray();
        }
    }

}
