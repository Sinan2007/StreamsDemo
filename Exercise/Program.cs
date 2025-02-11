Console.OutputEncoding = System.Text.Encoding.UTF8;

string command = Console.ReadLine();

List<Team> teams = new List<Team>();

List<IPlayer> players = new List<IPlayer>();

while (command != "exit")
{
    string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    switch (commands[0])
    {
        case "create_team":
            Team team = new Team(commands[1]);
            teams.Add(team);
            Console.WriteLine($"{team.Name} was created");
            break;
        case "create_player":
            Player player = new Player(commands[1], commands[2]);
            players.Add(player);
            Console.WriteLine($"{player.Name} was created");
            break;
        case "add_player":
            var teamToAdd = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToAdd is null)
            {
                Console.WriteLine("The team does not exist.");
                break;
            }
            var playerToAdd = players.FirstOrDefault(x => x.Name == commands[2]);
            if (playerToAdd is null)
            {
                Console.WriteLine("The player does not exist.");
                break;
            }
            teamToAdd.AddPlayer(playerToAdd);
            Console.WriteLine($"The player {playerToAdd.Name} was added");//
            break;
        case "remove_player":
            var teamToRemove = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToRemove is null)
            {
                Console.WriteLine("The team does not exist.");
                break;
            }
            teamToRemove.RemovePlayer(commands[2]);
            Console.WriteLine($"The team {teamToRemove.Name} has removed the player");//
            break;
        case "print_team":
            var teamToLog = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToLog is null)
            {
                Console.WriteLine("The team does not exist.");
                break;
            }
            Console.WriteLine("Select type of writing - txt or excel:");
            try
            {
                teamToLog.Log(Console.ReadLine());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "print_log_txt":
            var teamToLogTxt = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToLogTxt is null)
            {
                Console.WriteLine("The team does not exist.");
                break;
            }
            teamToLogTxt.PrintLog(commands[0].Split("_").Last());
            break;
        case "print_log_excel":
            var teamToLogExcel = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToLogExcel is null)
            {
                Console.WriteLine("The team does not exist.");
                break;
            }
            teamToLogExcel.PrintLog(commands[0].Split("_").Last());
            break;
        default:
            Console.WriteLine("The command does not exist.");
            break;
    }
    command = Console.ReadLine();
}