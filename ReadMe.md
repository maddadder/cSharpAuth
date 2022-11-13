# Dependencies
```
dotnet add package Microsoft.Identity.Web
dotnet add package Microsoft.AspNetCore.Authentication.OpenIdConnect
dotnet add package Microsoft.Identity.Web.UI
```

# Docker
```
rename appsettings.example.json to appsettings.Development.json

For role based security you need to: https://learn.microsoft.com/en-us/azure/active-directory/develop/howto-add-app-roles-in-azure-ad-apps#assign-users-and-groups-to-roles

For email verification you need to configure Domain verification in Amazon SES

docker-compose build
```
# Testing
```
docker-compose up

Navigate to http://localhost:5001
```
# Done Testing?
```
docker-compose down
```
# on client
```
npm run buildcss
docker-compose build
docker push neon-registry.18e7-091a-7bb4-d81e.neoncluster.io/leenet/csharpauth:1.0.82
helm upgrade csharpauth ./csharpauth --namespace leenet

```