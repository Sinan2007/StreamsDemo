using Exercise;

public class Team
{
    public string Name { get; set; }
    private List<IPlayer> players = new List<IPlayer>();
    private ILog txtLog;
    private ILog xcelLog;
    public Team(string name)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        this.Name = name;
        this.txtLog = new TXT(@$"{path}\{this.Name}.txt");
        this.xcelLog = new ExcelLog(@$"{path}\{this.Name}.xlsx");
        txtLog.Save($"{this.Name} was created at {DateTime.Now}");
        xcelLog.Save($"{this.Name} was created at {DateTime.Now}");
    }
    public void PrintLog(string type)
    {
        if (type == "txt")
        {
            this.txtLog.PrintLogger();
            return;
        }

        this.xcelLog.PrintLogger();
    }

    public void Log(string typeOfLog)
    {
        if (typeOfLog != "txt" && typeOfLog != "excel")
        {
            throw new ArgumentException("Incorrect form of typing");
        }
        if (typeOfLog == "txt")
        {
            Console.WriteLine("The information wa saved in a txt file.");
            this.txtLog.WriteLog();
            return;
        }
        Console.WriteLine("The information wa saved in a xlsx file.");
        this.xcelLog.WriteLog();
    }

    public void AddPlayer(IPlayer player)
    {
        var playerToFind = this.players.Find(x => x.Name == player.Name && x.Position == player.Position);
        if (playerToFind is not null)
        {
            Console.WriteLine($"The player:{player.Name} already is in the team.");
            return;
        }
        this.players.Add(player);
        txtLog.Save($"{player.Name} was added - {DateTime.Now}.");
        xcelLog.Save($"{player.Name} was added - {DateTime.Now}.");
        Console.WriteLine($"{player.Name} is added.");
    }

    public void RemovePlayer(string name)
    {
        var player = this.players.FirstOrDefault(p => p.Name == name);
        if (player != null)
        {
            this.players.Remove(player);
            txtLog.Save($"Position:{player.Position} Name:{player.Name} was removed - {DateTime.Now}.");
            xcelLog.Save($"Position:{player.Position} Name:{player.Name} was removed - {DateTime.Now}.");
            Console.WriteLine($"Player:{name} is removed.");
            return;
        }
        Console.WriteLine($"Player:{name} does not exist");
        txtLog.Save($"Player:{name} does not exist");
        xcelLog.Save($"Player:{name} does not exist");
    }
}

