# Premium Calculator
This is a simple applicaton which calculates monthly premium for given inputs

## Description
As a Member user would like to have an ability to choose various options on the screen So that they can
view the monthly premiums calculated and displayed on the screen

Develop an UI which accepts the below data and return a monthly premium amount to be
calculated.
1. Name
2. Age
3. Date of Birth
4. Occupation
5. Death – Sum Insured.

Following assumptions are taken while implementing: 
1. For any given individual the monthly premium is calculated using the below formula
Death Premium = (Death Cover amount * Occupation Rating Factor * Age) / (1000 * 12)
2. All input fields are mandatory.
3. Given all the input fields are specified, change in the occupation dropdown should trigger
the premium calculation

# Architecture of the solution

There are different projects in the solution as follows:
1) WebAPI project
2) DAL layer - Data Access Layer
3) Business Access Layer
4) FrontendUI project with Angular 8
5) WebAPI Unit Tests project

# WebApi project (PremiumCalculator.WebAPI)
 - This has been implemented with Microsoft WebApi2
 - Used SQL Server database file to hold the data
 - Created two tables with date namely Occupation and Occupation Factor with the relevant keys
 - Create Entity model with entity framework
 - Used dependency injection with Autofac package 
 - Implemented exception handling for the controller methods 
 - Implemented Async programming for the methods
 - Implemented Error logging with package Elmah (Go to http://localhost:55867/elmah.axd to check errors) This needs access    to C drive    as logs are configured to path C:\ElmahBackendLogs.
 
## Build & Run

Check out the code and build the WebAPI solution and run the WebAPI first
Please hit the below URL to check if the WebAPI is running successfully
http://localhost:55867/api/MonthlyPremium/GetOccupations
 
# DAL layer (PremiumCalculator.DAL)
  - Create Entity model with entity framework
  - Used LINQ queries to return data
  - Used interfaces
  
# BAL layer (PremiumCalculator.BAL)
  - Used intefaces
  - Created business logic method to calculate premium value with given parameters
  
# WebApi Tests (PremiumCalculator.WebAPI.Tests)
 - Written test cases for the two endpoints created in the Web API
 - Testcases has been written which directly point to the database with time constraint in mind. This can be improvised using Mocking      framework with Microsoft Moq. 

# Front End with Angular 8 (PremiumCalculatorUI)

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 8.2.1.

This folder is placed in the same application path with the name PremiumCalculatorUI.
Please go to this path and run the angular applicaton by following the below steps.
Ideally you can run this with Visual Studio Code and typing the command 'npm start' in the terminal

## Implementation
- Used bootstrap for the application
- Implemented validations for the input fields (All fields are mandatory)
- Monthly premium will be generated on change of Occupation dropdown.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

