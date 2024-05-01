# EProcessor

"ConnectionStrings": {
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=OracleFakeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}

"ConnectionStrings": {
"DefaultConnection": "DataSource=app.db;Cache=Shared"
}

"OracleTestDB": "Server=sqldata;Database=Ecmanage.eProcessor.Services.OracleTestDb;User Id=sa;Password=Pass@word;TrustServerCertificate=true"

"Server=tcp:127.0.0.1,5433;Initial Catalog=Ecmanage.eProcessor.Services.OracleTestDb;User Id=sa;Password=Pass@word",

migration:

cd D:\AfstudeerstageECManage\Application\eProcessor\src\Services\Fetch.API

dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\Web --output-dir Data\Migrations

dotnet ef migrations remove --project src\Infrastructure --startup-project src\Web

dotnet ef database update --project src\Infrastructure --startup-project src\Web
