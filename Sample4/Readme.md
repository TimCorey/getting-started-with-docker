# Sample 4 - Docker Compose / Orchestration
Docker Compose allows us to start more than one contain up and have them have access to each other. This can be useful for when you have an application that relies on data from another container. In this example, we have a .NET Core web application that writes log statements to a Seq server in a container.

## Create a docker-compose.yaml file
1. Spacing is important in this file. A missing space can cause the file to fail.
2. The version at the top corresponds to which version of Docker you are using. 3.7 is the latest version.
3. The services are your containers. They can either be built out of dockerfiles or they can be pulled from an image registry. We have an example of each here.
4. A container can reference the other containers in the group by specified service name. In our example, we will reference the Seq container by the `seqservice` name.
5. You can create a dependency on another container. This ensures that the container you depend on starts before the container that depends on it.
6. Dependent containers are started first but they might not be completely running before the container that depends on them starts. In this case, use a script like `wait-for-it.sh` to pause the system until the port is activated. You can get the `wait-for-it.sh` script at https://github.com/vishnubob/wait-for-it

## Commands
- `docker-compose up` - Starts up the orchestration process, builds the images (if needed), and launches the containers in order with the specified parameters. Use the `-d` for detached operation.
- `docker-compose up --build` - Starts the orchestration process like above but rebuilds the containers if they already exist (rather than just using the existing containers).
- `docker-compose stop` - Stops the containers but does not remove them.
- `docker-compose down` - Stops and removes the containers.