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
        Console.Clear();

        IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
            services =>
            {
                services.AddSingleton<IGameBoard, GameBoard>();
                services.AddSingleton<IMineList, MineList>();
                services.AddSingleton<IPlayer, Player>();

            })
            .Build();

        Player player = (Player)_host.Services.GetService<IPlayer>();
        player.PlayerName = "Fred Bloggs";
        

        MinefieldGame ms = new(Title, Description, DifficutyEasy,
                               ChessboardDimension,
                               _host.Services.GetService<IGameBoard>(),
                               _host.Services.GetService<IMineList>(),
                               _host.Services.GetService<IPlayer>());


        Display display = new Display(ms.Title, ms.Description,
                                _host.Services.GetService<IGameBoard>(),
                               _host.Services.GetService<IMineList>(),
                               _host.Services.GetService<IPlayer>(),
                               ChessboardDimension);
        ms.ResetPlayingField();
        ms.CreateMineList();
        ms.ApplyMinesToPlayingField();

        ConsoleKeyInfo key;
        
        display.Draw();

        while (true)
        {
            key = Console.ReadKey(true);

            ms.PlayerMove(key);

            display.Draw();
        }

    }
}