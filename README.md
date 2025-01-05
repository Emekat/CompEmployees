# CompEmployees
To view logs on Seq, run
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest

Migration is applied with: 
ef migrations add --project CompanyEmployees.Infrastructure.Persistence\CompanyEmployees.Infrastructure.Persistence.csproj --startup-project CompanyEmployees\CompanyEmployees.csproj --context CompanyEmployees.Infrastructure.Persistence.RepositoryContext --configuration Debug --verbose DatabaseCreation --output-dir Migrations
