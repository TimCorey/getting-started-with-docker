# Getting Started with Docker
The first thing you need to do is install Docker Desktop on your computer. Once it is installed, you can run Docker commands locally. From there, you can think about deploying to the cloud if you want.

## Getting Docker
Go to https://hub.docker.com/ and create an account (for free). Once you log in, look for the Download Docker Desktop link (right-hand side) to download and install Docker Desktop.

## Docker Desktop Configuration
1. **Shared Drives** - Enable these if you want to store data outside of your containers
2. **Container Type (on right-click menu)** - Choose Linux containers or Windows containers. I typically stick with Linux containers, even on Windows.

## Basic Commands
1. `docker --help` - get a list of available commands. You can also get `--help` on any docker command as well.
2. `docker images` - a list of the images on your machine.
3. `docker ps -a` - a list of all containers on your computer, including the ones that are stopped.
4. `docker --version` - get the current version of docker that is installed.
5. `docker rm <container ID or name>` - removes a stopped container from your machine.
6. `docker rmi <image ID or name>` - removes an image from your machine.