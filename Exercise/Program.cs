using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamManagementApp
{
    class Program
    {
        static void Main()
        {
            var teams = new Dictionary<string, ITeam>();
            var players = new Dictionary<string, IPlayer>();

            while (true)
            {
                Console.WriteLine("Enter command:");
                string command = Console.ReadLine();

                if (command == "exit")
                {
                    break;
                }

                string[] parts = command.Split(' ');
                switch (parts[0])
                {
                    case "create_team":
                        if (parts.Length == 2)
                        {
                            string teamName = parts[1];
                            if (!teams.ContainsKey(teamName))
                            {
                                teams[teamName] = new Team(teamName);
                                Console.WriteLine($"Team {teamName} created.");
                            }
                            else
                            {
                                Console.WriteLine($"Team {teamName} already exists.");
                            }
                        }
                        break;

                    case "create_player":
                        if (parts.Length == 3)
                        {
                            string playerName = parts[1];
                            string position = parts[2];
                            if (!players.ContainsKey(playerName))
                            {
                                players[playerName] = new Player(playerName, position);
                                Console.WriteLine($"Player {playerName} created.");
                            }
                            else
                            {
                                Console.WriteLine($"Player {playerName} already exists.");
                            }
                        }
                        break;

                    case "add_player":
                        if (parts.Length == 4)
                        {
                            string teamName = parts[1];
                            string playerName = parts[2];
                            string position = parts[3];

                            if (teams.ContainsKey(teamName) && players.ContainsKey(playerName))
                            {
                                IPlayer player = players[playerName];
                                teams[teamName].AddPlayer(player);
                                Console.WriteLine($"Player {playerName} added to {teamName}.");
                            }
                            else
                            {
                                Console.WriteLine("Team or player not found.");
                            }
                        }
                        break;

                    case "remove_player":
                        if (parts.Length == 3)
                        {
                            string teamName = parts[1];
                            string playerName = parts[2];

                            if (teams.ContainsKey(teamName))
                            {
                                teams[teamName].RemovePlayer(playerName);
                                Console.WriteLine($"Player {playerName} removed from {teamName}.");
                            }
                            else
                            {
                                Console.WriteLine("Team not found.");
                            }
                        }
                        break;

                    case "print_team":
                        if (parts.Length == 2)
                        {
                            string teamName = parts[1];

                            if (teams.ContainsKey(teamName))
                            {
                                ITeam team = teams[teamName];
                                Console.WriteLine($"Team {team.Name}:");

                                foreach (var player in team.Players)
                                {
                                    Console.WriteLine($"- {player.Name} ({player.Position})");
                                }
                                Console.WriteLine("History:");
                                foreach (var history in team.History)
                                {
                                    Console.WriteLine(history);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Team not found.");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
    }
}
