Migration:

appsettings.json:

add:

"ConnectionStrings": {
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EmailProcessorApiDb;Trusted_Connection=True;MultipleActiveResultSets=true"
},

appsettings.development.json:

remove:

"ConnectionString": "Server=tcp:127.0.0.1,5433;Initial Catalog=Ecmanage.eProcessor.Services.OracleTestDb;User Id=sa;Password=Pass@word",

dotnet ef migrations add "InitialCreate" --project FakeFetch.Infrastructure --startup-project FakeFetch.API --output-dir Data\Migrations

program.cs uitcommenten:

builder.AddCustomConfiguration();
builder.AddCustomSerilog();
builder.AddCustomHealthChecks();
builder.AddCustomApplicationServices();

dotnet ef migrations remove --project FakeFetch.Infrastructure --startup-project FakeFetch.API --verbose
