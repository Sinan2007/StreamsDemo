public interface IPlayer
{
    string Name { get; }
    string Position { get; }

    void SetPosition(string position);
}
