# Blue Archive Character Management System

This project implements a system for managing character data from the Blue Archive game. It utilizes a WebAPI and WorkerService hosted in separate .NET projects, following Clean Architecture combined with Domain-Driven Design (DDD) patterns. The data is stored in MSSQL using Entity Framework Core, and Hangfire is used for job scheduling. The frontend is a Vue.js application that displays the character data in a filterable grid.

## Project Overview

- **Backend**: The backend consists of two hosts:
  - **WebAPI**: Provides endpoints for interacting with character data.
  - **WorkerService**: Handles background jobs like data upserts using Hangfire.
  
- **Frontend**: A Vue.js frontend displays the character data in a filterable grid and communicates with the WebAPI.

- **Database**: MSSQL is used for data storage, and the `Characters` table is created to store character data.

## Technologies Used

- .NET 6 or the latest .NET Framework
- Clean Architecture
- Domain-Driven Design (DDD)
- Entity Framework Core
- Hangfire for job scheduling
- Vue.js (with TypeScript) for the frontend
- MSSQL for data storage

## Setup

### 1. Database Setup

Before running the application, create the database and table for storing the character data:

```sql
CREATE DATABASE BlueArchiveDB;

USE BlueArchiveDB;

CREATE TABLE Characters (
    Id INT PRIMARY KEY IDENTITY,
    Birthday NVARCHAR(255),
    DamageType NVARCHAR(255),
    ImageSchool NVARCHAR(255),
    Name NVARCHAR(255),
    PhotoUrl NVARCHAR(255),
    School NVARCHAR(255)
);
```

### 2. WebAPI

The WebAPI exposes endpoints to fetch character data from the Blue Archive API. These endpoints include:

- **Get all characters (pagination)**:  
  `GET /api/characters?page={number}&perPage={number}`

- **Get characters by name**:  
  `GET /api/characters?name={name}`

- **Get a random character**:  
  `GET /api/character/random?count={number}`

- **Get all students**:  
  `GET /api/characters/students`

- **Get characters by query**:  
  Query parameters like `name`, `age`, `birthday`, `school`, etc.

### 3. WorkerService

The WorkerService is responsible for periodic tasks such as upserting character data. It uses Hangfire to schedule the upsert job to run every hour.

### 4. Frontend

The frontend is built using Vue.js and TypeScript. It displays the character data in a grid and includes filtering and pagination features. The frontend communicates with the WebAPI to fetch the character data.

### 5. Running the Solution

1. **Database**: Make sure MSSQL is running and the database is created as shown in the database setup.
2. **Backend**: Run the WebAPI and WorkerService projects. These can be run separately or together in the same solution.
3. **Frontend**: Run the Vue.js frontend in your preferred environment.

## API Endpoints

### 1. Get All Characters (Paged)

- **URL**: `/api/characters?page={number}&perPage={number}`
- **Method**: GET
- **Description**: Fetch a paginated list of characters.
- **Query Parameters**:
  - `page`: Page number (default 1).
  - `perPage`: Number of characters per page (default 20).

### 2. Get Characters by Name

- **URL**: `/api/characters?name={name}`
- **Method**: GET
- **Description**: Fetch characters by name (e.g., `Aru`, `Asuna`, `Hibiki`).
- **Query Parameters**:
  - `name`: Character name.

### 3. Get Random Characters

- **URL**: `/api/character/random?count={number}`
- **Method**: GET
- **Description**: Fetch a random character(s).
- **Query Parameters**:
  - `count`: Number of random characters to fetch (default 1).

### 4. Get All Students

- **URL**: `/api/characters/students`
- **Method**: GET
- **Description**: Fetch all student characters (by default 4 characters).

### 5. Filter Characters by Query

- **URL**: `/api/characters`
- **Method**: GET
- **Description**: Fetch characters filtered by multiple query parameters such as `name`, `birthday`, `school`, etc.
- **Query Parameters**:
  - Any of the following: `name`, `names`, `age`, `birthday`, `height`, `school`, `hobbies`, `voice`, `damageType`, `role`, `armorType`, `affinity`, `weapon`, `releaseDate`.

## Running the Application

1. Clone this repository:
   ```bash
   git clone https://github.com/GabrielMeloBatista/CleanCSharpBlueArchiveAPICharacters.git
   cd CleanCSharpBlueArchiveAPICharacters
   ```

2. **Set up the database** by running the SQL script mentioned above in your MSSQL environment.

3. **Run the backend projects**:
	- Open both the WebAPI and WorkerService projects in Visual Studio.
	- Build and run each project.
4. **Alternative to run the backend
	- Ensure you have the following installed:
	- [Latest .NET SDK](https://dotnet.microsoft.com/download)
	```
	dotnet restore
	dotnet build
	```
	-  In two different terminals run
		```
		cd WorkerServiceHost
		dotnet run
		```
		And in the other terminal
		```
		cd WebAPIHost
		dotnet run
		```
		
5. **Run the frontend**:
   - Navigate to the `frontend` folder.
   - Install dependencies:
     ```bash
     npm install
     ```
   - Run the frontend:
     ```bash
     npm run dev
     ```

### Hangfire Setup

- The Hangfire job for upserting character data will run automatically every hour. You can configure it further in the WorkerService project.

## Conclusion

This project provides a simple, scalable solution for fetching and managing Blue Archive character data using .NET, Hangfire, and Vue.js. It demonstrates key concepts such as Clean Architecture, DDD, and job scheduling with Hangfire.
