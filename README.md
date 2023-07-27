![](/docs/under_construction.gif)

# Firma

This project contains a service that downloads data from Brazilian companies available from the Federal Revenue Service and an api that serves the processed data.

## 💻 Dependencies

What do you need to have installed :

- [DotNet](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://docs.docker.com/get-docker/)

## 🛫 Run

Build the container image

```
docker compose build
```

The command bellow will start the database in docker, apply the migrations and start the api

```
docker compose up
```

## 🧪 Tests

To run all the test just run

```
dotnet test
```

## 💾 Populate database

Make a requisition to the endpoint /api/start-process, sit and wait. The process takes too long. Is almost 20GB of data to process!
