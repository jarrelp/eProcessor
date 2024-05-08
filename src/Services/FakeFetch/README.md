Migration:

appsettings.json:

add:

"ConnectionStrings": {
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EmailProcessorApiDb;Trusted_Connection=True;MultipleActiveResultSets=true"
},

dotnet ef migrations add "InitialCreate" --project FakeFetch.Infrastructure --startup-project FakeFetch.API --output-dir Data\Migrations
