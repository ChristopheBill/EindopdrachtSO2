using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.Weerberichten.Managers;
using WeerEventsApi.WeerBerichten.Managers;
using WeerEventsApi.WeerStations.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMetingLogger>(MetingLoggerFactory.Create(true,true));
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<IDomeinController, DomeinController>();
builder.Services.AddSingleton<IWeerbericht, WeerBericht>();
builder.Services.AddSingleton<WeerStationManager>();

var app = builder.Build();

app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");

app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());

app.MapGet("/weerstations", (IDomeinController dc) => dc.GeefWeerstations());

app.MapGet("/metingen", (IDomeinController dc) => dc.GeefMetingen());

app.MapGet("/GeefWeerbericht", (IDomeinController dc) => dc.GeefWeerbericht());


//TODO api aanvullen

IServiceProvider serviceProvider = app.Services;
IStadManager stadManager = serviceProvider.GetRequiredService<IStadManager>();
WeerStationManager weerStationManager = serviceProvider.GetRequiredService<WeerStationManager>();
IEnumerable<WeerEventsApi.Steden.Stad> steden = stadManager.GeefSteden();
weerStationManager.SetupRandomWeerstations(steden, 12);


app.Run();