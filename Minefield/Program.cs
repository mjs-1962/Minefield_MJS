// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minefield.Services;
using Minefield.Models;
using Minefield.Services;

internal class Program
{
    const int ChessboardDimension = 8;
    const string Title = "MINEFIELD";
    const string Description = "Test game for Schneider Electric";

    const int DifficutyEasy = 0;
    const int DifficutyMedium = 1;
    const int DifficutyHard = 2;

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
            services =>
            {
                services.AddSingleton<IGameBoard, GameBoard>();
                services.AddSingleton<IMineList, MineList>();
                services.AddSingleton<IPlayer, Player>();

            })
            .Build();

      
        MinefieldGame ms = new(Title, Description, DifficutyEasy,
                               ChessboardDimension,
                               _host.Services.GetService<IGameBoard>(),
                               _host.Services.GetService<IMineList>()
                           );

        Player player = new Player("Mark", DifficutyEasy); //, _host.Services.GetService<IGameBoard>());
        ms.ResetPlayingField();
        ms.CreateMineList();
        ms.ApplyMinesToPlayingField();

        ConsoleKeyInfo key;

        while (true)
        {
            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (player.MoveDown())
                    {
                        Console.WriteLine("Down");
                    }
                    else
                    {
                        Console.WriteLine("No Down");
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (player.MoveUp())
                    {
                        Console.WriteLine("Up");
                    }
                    else
                    {
                        Console.WriteLine("No Up");
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (player.MoveLeft())
                    {
                        Console.WriteLine("Left");
                    }
                    else
                    {
                        Console.WriteLine("No Left");
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (player.MoveRight())
                    {
                        Console.WriteLine("Right");
                    }
                    else
                    {
                        Console.WriteLine("No Right");
                    }
                    break;

                case ConsoleKey.Multiply:
                    player.ResetLocation();
                    Console.Clear();
                    break;


            }

        }

    }
}