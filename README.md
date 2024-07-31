# team-mangojs

Grammerhub | Team MangoJS

## Contributions

We are using the devcontainers VS Code extension for this app. Please have the [Remote Connections extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack) installed in VS Code and install the [Docker Desktop app](https://www.docker.com/).

When you open VS Code you will be asked to reopen in container. It will take a few minutes to download and run the provided image the first time, but it contains the necessary tooling for our project and should come right up after the first time.

## Front End

Created front end with `ng new`

To run:

```bash
cd base-client
npm i
npm start
```

"dev" branch deployed to https://black-sand-06df6ac0f.5.azurestaticapps.net/
"main" branch deployed to https://mango-plant-07699860f.5.azurestaticapps.net/

## Back End

Created back end with `dotnet new web`

To run:

```bash
cd base-api
dotnet run
```

"dev" branch deployed to https://mango-entertainment-dev-api.azurewebsites.net
"main" branch deployed to https://mango-entertainment-api.azurewebsites.net/
