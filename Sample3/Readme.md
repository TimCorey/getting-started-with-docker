# Sample 3 - Manual ASP.NET Core with HTTPS
You can create a dockerfile with ASP.NET Core automatically that will set you up for success. However, launching that file manually will be more problematic. This sample walks you through how to configure a manual setup.

## Create the docker file
The sample dockerfile is in the root of the folder with the solution. It uses the same SDK and slim versions of the images that Microsoft uses for their dockerfile.

## Create the image
`docker build -t webapp:1.0.0 .`

## Run without HTTPS support
`docker run -d -p 8000:80 -p 8443:443 --name=first_attempt webapp:1.0.0`

## Testing the image
Note that the HTTP site works fine but that the HTTPS site returns an error like it isn't even there.

## Investigate the issue
`docker inspect first_attempt` - This gives you a look into all of the settings of the container. Note that the environment variables do not include port 443 (even though those ports are listed in other sections). This means that the application is not listening on port 443.

## Clean up the container
`docker rm -f first_attempt`

## Create a dev certificate
In order to trust the certificate on the container image, you need to create it on the host (your computer). That can be done using the following command:
`dotnet dev-certs https -v -ep c:\temp\docker\cert-aspnetcore.pfx -p <yourPassword>`

**Note**: you will need to change the file path and the password at least. You may want to change the file name as well.

## Run a new container with HTTPS support
`docker run -d -p 8000:80 -p 8443:443 -e ASPNETCORE_HTTPS_PORT=8443 -e ASPNETCORE_URLS="https://+:443;http://+:80" -e Kestrel__Certificates__Default__Path=/root/.dotnet/https/cert-aspnetcore.pfx -e Kestrel__Certificates__Default__Password=<yourPassword> -v C:\temp\docker\:/root/.dotnet/https --name=second_attempt webapp:1.0.0`

**Note**: You will need to change the password and possibly the file path and certificate name if you changed those when you were creating the certificate. Also note that we named this container differently than the first one (that choice is up to you).

## Verify and Cleanup
Verify that you can access the site via HTTP and that it redirects to HTTPS (on the correct port). Once done, run the cleanup commands to stop and remove the image: 

`docker rm -f second_attempt`

## Add in Unit Testing
Uncomment the two lines in the dockerfile (lines 5 and 8 - the ones with # signs in front of them). Then save the file and create a new image like so:

`docker build -t webapp:1.0.1 .`

**Note**: The output includes that the tests were run and passed.

## Failing Tests
A failing test will fail the image build. Nothing will proceed after that point. To demonstrate this, go into the unit test project (`TestProj.csproj`) and uncomment the test case in the `CalculationTests.cs` file. Attempt to create a new image like so:

`docker build -t webapp:1.0.2 .`

**Note**: The build fails and does not continue. It does not create a version 1.0.2 of our image.