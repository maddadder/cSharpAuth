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

docker push 192.168.1.84:32000/csharpauth:1.0.6
microk8s helm3 install csharpauth ./csharpauth

# on daffy
kubectl create namespace websites
docker push 192.168.1.151:32000/csharpauth:1.0.6
helm install csharpauth ./csharpauth --namespace websites
