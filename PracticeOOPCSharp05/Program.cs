// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using PracticeOOPCSharp05.Garage;
using PracticeOOPCSharp05.UI;

var services = new ServiceCollection();

services.AddSingleton<IGarageFactory, GarageFactory>();
services.AddSingleton<IGarageHandler, GarageHandler>();
services.AddSingleton<IUI, ConsoleUI>();

var serviceProvider = services.BuildServiceProvider();

var ui = serviceProvider.GetRequiredService<IUI>();

ui.Run();