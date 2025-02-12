# Quests Management

> **Quests Management** is a web application designed for managing quests. The project was created as part of a hackathon and showcases modern development practices, including clean architecture, Domain-Driven Design (DDD), and the use of popular technologies.

---

## Table of Contents

- [Quests Management](#quests-management)
  - [Table of Contents](#table-of-contents)
  - [Project Overview](#project-overview)
  - [Technologies Used](#technologies-used)
  - [First Run](#first-run)
    - [Prerequisites](#prerequisites)
    - [Steps to Run](#steps-to-run)
  - [Project Structure](#project-structure)
  - [License](#license)

---

## Project Overview

> The **Quests Management** project allows users to create, manage, and track the progress of quests. This can be useful for educational platforms, gaming services, or any other systems where task organization and completion are required.

---

## Technologies Used

- **Backend**: C# (.NET), ASP.NET Core Web API, EF Core, DDD
- **Frontend**: HTML, SCSS, JavaScript, React, Vite, Axios, react-router, Zustand, Material UI, react-hook-form, styled-components, react-spinners, react-select
- **Containerization**: Docker
- **Cloud Services**:
  ‣ [Vercel](https://vercel.com/) (Frontend Hosting)
  ‣ [Aiven IO](https://console.aiven.io/) (PostgreSQL Database)

---

## First Run

### Prerequisites

1. Ensure you have the following installed:
   - Docker

### Steps to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/quests-management.git
   cd quests-management
   ```
2. Create a .env file based on .env.example:
   ```bash
   cp .env.example .env
   ```
3. Edit the .env file to specify the necessary environment variables.
4. Run the application using Docker Compose:
   ```bash
   docker-compose up --build
   ```
> The application will be available at:
> - Frontend: https://net-core-quests.vercel.app/
> - Backend: http://localhost:8001

---

## Project Structure

> - **docker-compose.yml** : File for running containers.
> - **/backend** : Backend part of the application (ASP.NET Core Web API).
> - **/backend/src/Quests.API/.env.example** : Example environment variables file.
> - **/frontend** : Frontend part of the application (React + Vite).

---

## License

This project is distributed under the MIT License!