using Exercise;

public interface ITeam
{
    string Name { get; }
    IReadOnlyList<IPlayer> Players { get; }
    List<string> History { get; }

    void AddPlayer(IPlayer player);
    void RemovePlayer(string playerName);
    void AddToHistory(string message);
}
