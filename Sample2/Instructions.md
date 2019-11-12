# Sample 2 - Storing Data Locally
A container is volatile. When you "upgrade" a container, you destroy it and create a new container. If you store data locally in the container, that data will be lost. An alternative is to store the data in a volume on the local computer rather than in a container.

## Create a container and run it
`docker run --name data-web-container -p 8080:80 -v C:\Temp\html\:/usr/local/apache2/htdocs/ httpd:alpine`

## Update the HTML
You don't need to rebuild the container. Just change the HTML and refresh the page to see the changes.

## Stop and remove the containers
1. `docker stop data-web-container`
2. `docker rm data-web-container`