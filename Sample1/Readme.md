# Sample 1 - Simple Website
Learn how to take an HTML site and put the site onto a web server image that can then be launched as a container.

## Show no images loaded
`docker images`

## Show no containers running
`docker ps -a`

## Build the image
`docker build -t simple-web:1.0.0 .`

## Create a container and run it
`docker run --name simple-web-container -p 8080:80 simple-web:1.0.0`

## Fix the HTML and build a new image
`docker build -t simple-web:1.0.1 .`

## Create a new container and run it
`docker run --name simple-web-container-fixed -p 8081:80 simple-web:1.0.1`

## Stop and remove the containers
1. `docker stop simple-web-container`
2. `docker rm simple-web-container`
3. `docker stop simple-web-container-fixed`
4. `docker rm simple-web-container-fixed`

## Remove the images
1. `docker images`
2. `docker rmi simple-web:1.0.0`
3. `docker rmi simple-web:1.0.1`

## Alternate - remove all containers
`docker rm $(docker ps -a -q)` - use the `-f` command if you want to stop and remove the containers. **Be warned** that this can be bad for your containers and should only be run in development.

## Alternate - remove all images
`docker rmi $(docker images -q)` - Removes all images from your machine that are not currently being used for a container on your machine.

## Interacting with the container
`docker exec -it <container ID or name> bash` - you can run commands on the running container using this command. In this example, we are running bash on the container in interactive mode from our command prompt.