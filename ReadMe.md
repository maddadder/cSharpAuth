# Dependencies

dotnet add package Microsoft.Identity.Web
dotnet add package Microsoft.AspNetCore.Authentication.OpenIdConnect
dotnet add package Microsoft.Identity.Web.UI

# Docker
docker-compose build

# Testing
docker-compose up

Navigate to http://localhost:5001

# Done Testing?
docker-compose down

# Deploy to microk8s

docker push 192.168.1.84:32000/csharpauth:1.0.49
microk8s helm3 install csharpauth ./csharpauth

# on client
npm run buildcss
docker-compose build
docker push 192.168.1.151:32000/csharpauth:1.0.49
helm upgrade csharpauth ./csharpauth
