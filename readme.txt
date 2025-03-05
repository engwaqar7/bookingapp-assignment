Flight Search API

🚀 Overview

Flight Search API fetches real-time flight and airport data using the AviationStack API and stores it in a MySQL database. This project is built using ASP.NET Core, Entity Framework Core (Code First), and Docker.

📌 Prerequisites

Ensure you have the following installed:

Docker Desktop

Visual Studio 2022

.NET SDK 8.0

MySQL (optional, but Docker runs MySQL in a container)

📦 Installation & Setup

1️⃣ Clone the Repository

git clone https://github.com/engwaqar7/bookingapp-assignment.git
cd FlightSearchApp

2️⃣ Setup the Database

Before running the project with Docker, you must apply the initial migration to create the database schema.

Update-Database -Project FlightSearch.Infrastructure -StartupProject FlightSearch.Api

3️⃣ Run the Application with Docker

Start the API and MySQL using Docker Compose:

docker-compose up --build -d

4️⃣ Verify Services

Swagger API Documentation: http://localhost:5000/swagger/index.html

Database Adminer UI: http://localhost:8081/Credentials:

Server: mysql

Database: FlightDb

User: root

Password: root

📂 Project Structure

FlightSearchApp/
│── FlightSearch.Api/           # API Layer (Controllers, Startup, Configurations)
│── FlightSearch.Application/   # Business Logic (CQRS Handlers, DTOs, Services)
│── FlightSearch.Domain/        # Core Domain (Entities, Aggregates, Business Rules)
│── FlightSearch.Infrastructure/ # Data Access Layer (Repositories, EF Core, Migrations)
│── docker-compose.yml          # Docker Configuration
│── README.md                   # Project Documentation

🚀 API Endpoints

✈️ Flights API

Retrieve Flights

GET /api/flights?departure=SFO&arrival=DFW

🛫 Airports API

Retrieve Airports

GET /api/airports

🛠 Troubleshooting

1️⃣ If MySQL fails to start:

docker-compose down -v
docker-compose up --build -d

2️⃣ If API is not accessible on port 5000:

docker logs flightsearchapp

📝 License

This project is licensed under the MIT License.
