# ASP.NET Core Web API + React Frontend Template
This took 9 hours to make...

## Backend
- Runs on .NET 9.0 (I love hot reload)
- Controller-based routing

## Frontend
- React with TypeScript
- Uses `react-router-dom` for routing
- Uses `axios` for API requests
- Automatic client generation based on the backend API (build the backend then run `npm run genapi`)
- ESLint and Prettier configured

## Other Features
- Comes with Rider launch profiles and settings
- GitHub Actions on PR to main for:
  - Linting and Formatting the frontend code with ESLint and Prettier
  - Building the backend with `warnaserror` and unit testing
  - Running the client generation script

## How to Run
1. Clone the repository (duh)
2. Open the solution in Rider
3. Build the backend `dotnet build API/API.csproj`
4. Run the frontend  `cd frontend && npm run devapi`
5. Run the compound Rider Profile and pray that it works.
6. See [Detailled Instructions](Detailed%20How-To/HowTo.md) for more info