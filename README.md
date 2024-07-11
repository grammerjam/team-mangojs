# team-mangojs

Grammerhub | Team MANGOJS

## Contributions

We are using the devcontainers VSCODE extension for this app. Please have Docker Desktop and the Remote Connections extension installed in VSCODE.

When you open VSCODE you will be asked to reopen in container. You will be given two choices. Choose "C# (.NET) and PostgreSQL" for working on the API. Choose "Node.js & TypeScript" for working on the client. It will take a few minutes to download and run the provided images the first time, but they contain the necessary tooling for our project and should come right up after the first time. You will need to open two VSCODE windows to run the front end and the back end at the same time.

## Front End

Created front end with `ng new`

To run:

```bash
cd base-client
npm i
npm start
```

## Back End

Created back end with `dotnet new web`

To run:

```bash
cd base-api
dotnet run
```
