InsuranceQuoteApp

A simple insurance quoting application with a .NET 8 backend (ASP.NET Core Web API) and an Angular 20 frontend. Users can submit insurance quote requests and view the resulting quote including premium details and mock premiums from four imaginary insurance companies.

Project Structure
InsuranceQuoteApp/
├─ Backend/             <- .NET API project
│  ├─ Controllers/
│  ├─ Models/
│  ├─ Program.cs
│  ├─ InsuranceQuoteAPI.csproj
│  └─ ...
├─ Frontend/            <- Angular project
│  ├─ src/
│  ├─ angular.json
│  ├─ package.json
│  └─ ...
├─ .gitignore
└─ README.md

Backend (.NET 8 API)
Endpoints

Submit Quote

URL: POST /api/quote/submit

Request Body Example:

{
  "Term": 10,
  "SumInsured": 10000,
  "Age": 23,
  "CoverageType": "Standard",
  "RiskFactor": 1
}


Response Example:

{
  "quoteId": "ed8c6ff8-a375-4e43-ad78-062bf35eebe0"
}


Retrieve Quote

URL: GET /api/quote/{quoteId}

Response Example:

{
  "Id": "ed8c6ff8-a375-4e43-ad78-062bf35eebe0",
  "Term": 10,
  "SumInsured": 10000,
  "Age": 23,
  "CoverageType": "Standard",
  "RiskFactor": 1,
  "Premiums": {
    "COMP1": 120.5,
    "COMP2": 115.0,
    "COMP3": 130.25,
    "COMP4": 125.75
  },
  "CreatedAt": "2025-10-19T00:00:00Z"
}

Running Backend

Open the Backend folder in Visual Studio 2022.

Restore NuGet packages.

Run the project. By default, it runs on https://localhost:7005.

Frontend (Angular 20)
Features

Form to submit insurance quote requests:

Term

Sum Insured

Age

Coverage Type

Risk Factor

Displays the returned quote:

Quote ID

Premiums from four mock insurance companies

Running Frontend

Open a terminal in the Frontend folder.

Install dependencies:

npm install


Start the development server:

ng serve


Open your browser and navigate to http://localhost:4200
.

How It Works

Submit Quote: The frontend form sends a POST request to the backend with user input.

Quote ID Generated: The backend returns a unique quoteId.

Retrieve Quote: Using the quoteId, the frontend fetches the full quote including the mock premiums.

Premiums Displayed: The four mock insurance premiums are displayed in the UI.

Dependencies
Backend

.NET 8

ASP.NET Core Web API

Frontend

Angular 20

Node.js / npm

