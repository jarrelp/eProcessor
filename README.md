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

cd D:\AfstudeerstageECManage\Application\eProcessor\src\Services\Fetch

dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\Fetch.API --output-dir Data\Migrations

dotnet ef migrations remove --project src\Infrastructure --startup-project src\Fetch.API

dotnet ef database update --project src\Infrastructure --startup-project src\Fetch.API

fetch-api:
cd D:\AfstudeerstageECManage\Application\eProcessor\src\Services\Fetch\Fetch.API
dapr run --app-id fetch-api dotnet run

docker-compose up:
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --build sqldata maildev send-api send-api-dapr fake-fetch-ca-api redis seq zipkin dapr-placement process-api process-api-dapr rabbitmq webstatus fake-fetch-ca-api-dapr
