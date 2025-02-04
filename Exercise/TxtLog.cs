public class TxtLog : ILog
{
    private string FilePath;

    public TxtLog(string filePath)
    {
        FilePath = filePath;
    }

    public void WriteLog(string message)
    {
        File.AppendAllText(FilePath, message + Environment.NewLine);
    }
}