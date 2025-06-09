This project is a multi-layered .NET 8 application designed to manage a polyclinic’s core operations, including doctors, patients, and appointments. 
It follows a clean architecture with separate Data Access Layer (DAL), Service Layer (SLL), and a Console UI, making it easy to maintain and extend.

Features
•	Doctor Management: Add, update, delete, and list doctors.
•	Patient Management: Add, delete, and list patients.
•	Appointment Scheduling: Book, update, and cancel appointments, list appointments.
•	RESTful API: Exposes endpoints for all core operations using ASP.NET Core controllers.
•	Entity Framework Core: Handles database operations with code-first approach and configuration via appsettings.json.
Technologies
•	.NET 8 (C# 12)
•	ASP.NET Core Web API
•	Entity Framework Core
•	SQL Server (LocalDB)
•	Layered architecture (DAL, SLL, UI)

Getting Started
1.	Clone the repository.
2.	Update the appsettings.json with your SQL Server connection string.
3.	Build and run the solution.
4.	Use the Console UI or API endpoints to interact with the system.
