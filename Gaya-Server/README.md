# GayaProject  

## Project Description  
GayaProject is a .NET-based calculation service that enables arithmetic operations on various inputs.  
The system follows **Design Patterns** such as **Factory**, **Singleton**, and leverages technologies like **Entity Framework, SQL Server, React, and LINQ**.  

The project is implemented with **Dependency Injection (DI)** and includes a **Factory Pattern** to dynamically create calculation services based on the requested operation.  

## Key Features  
✅ **Uses Factory Pattern** for managing operator services  
✅ **Uses Singleton Pattern** for core service management  
✅ **Utilizes Entity Framework Core** for database interactions with SQL Server  
✅ **Supports multiple arithmetic operations** (+, -, *, /) with future extensibility  
✅ **Integrates with React** for frontend interaction  
✅ **Uses LINQ** for efficient data queries  

## Implemented Arithmetic Operations  

### Addition (+)  
- Performs numeric addition when inputs are numbers  
- Performs string concatenation when inputs are strings  

### Subtraction (-)  
- Performs numeric subtraction when inputs are numbers  
- Performs substring extraction when inputs are strings  

### Multiplication (*)  
- Performs standard numeric multiplication  

### Division (/)  
- Performs standard numeric division with handling for division by zero  

## Technologies Used  
- **C# .NET**  
- **Entity Framework Core**  
- **SQL Server**  
- **LINQ**  
- **React**  
- **Dependency Injection**  
- **Factory Pattern**  
- **Singleton Pattern**  

## Installation & Running Instructions  

### Clone the repository  
```bash
git clone https://github.com/your-repo/GayaProject.git

### Install dependencies
```bash
dotnet restore

### Run the project
```bash
dotnet run

### Clone the repository  
```bash
http://localhost:5012/swagger