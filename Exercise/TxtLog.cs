public class TXT : ILog
{
    private List<string> data = new List<string>();
    string filepath;

    public TXT(string filepath)
    {
        this.filepath = filepath;
    }

    public void Save(string message)
    {
        data.Add(message);
    }
    public void PrintLogger()
    {
        string[] lines = File.ReadAllLines(this.filepath);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
    public void WriteLog()
    {
        File.WriteAllLines(this.filepath, data);
    }

    public void PrintLoggerWithStream()
    {
        using (var reader = new StreamReader(filepath))
        {
            foreach (var line in reader.ReadToEnd())
            {
                Console.WriteLine(line);
            }
        }
    }
    public void WriteWithStream()
    {
        using (var writer = new StreamWriter(filepath))
        {
            foreach (var line in data)
            {
                writer.WriteLine(data);
            }
        }
    }
}