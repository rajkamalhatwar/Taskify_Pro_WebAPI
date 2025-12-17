# Taskify Pro – Smart Task & Work Tracker

A secure and scalable **backend REST API** built with ASP.NET Core to support task and work management features. This repository contains **backend services only**; the frontend application is maintained in a separate repository.

---

## 📌 Overview

**Taskify Pro** is a smart task and work tracking system designed to improve productivity and task organization. The application allows users to create, manage, and track tasks securely while following modern RESTful API design principles. It includes authentication, cloud-based document storage, and a clean, responsive user interface.

---

## 🚀 Features

* RESTful APIs for creating, updating, deleting, and tracking tasks
* Secure user authentication and authorization using JWT
* Role-based API access control
* Cloud-based document upload and retrieval using Azure Blob Storage
* Clean and scalable API architecture following REST principles
* DTO-based request/response handling for better performance and security

---

## 🛠 Tech Stack

* **Framework:** ASP.NET Core API (.NET 8)
* **Database:** SQL Server
* **Authentication:** JWT (JSON Web Token)
* **Cloud Services:** Azure Blob Storage
* **API Tools:** Swagger / Postman
* **Development Tools:** Visual Studio, Git

---

## 🏗️ Project Architecture (7‑Layer Structure)

This project follows a **7‑layer architecture** to ensure separation of concerns, scalability, and maintainability.

### 🔹 Layers Overview

1. **Entity Layer**

   * Contains database entities (tables representation)
   * Used by Entity Framework Core

2. **ViewModel Layer**

   * Used for API request and response models (DTOs)
   * Prevents exposing database entities directly

3. **Interface Layer**

   * Defines repository contracts
   * Promotes loose coupling and testability

4. **Repository Layer**

   * Handles database operations
   * Implements data access logic using EF Core

5. **ServiceInterface Layer**

   * Defines business logic contracts
   * Acts as a bridge between controllers and services

6. **Service Layer**

   * Contains core business logic
   * Calls repositories and applies validations

7. **Controller Layer**

   * Exposes RESTful API endpoints
   * Handles HTTP requests and responses

---

## 📂 Project Structure

```
TaskifyPro
│── Entities
│── ViewModels
│── Interfaces
│── Repositories
│── ServiceInterfaces
│── Services
│── Controllers
│── appsettings.json
│── Program.cs
│── README.md
```  

---

## ⚙️ Setup & Installation

1. Clone the repository

   ```bash
   git clone https://github.com/rajkamalhatwar/Taskify_Pro_WebAPI.git
   ```

2. Open the project in **Visual Studio**

3. Update the database connection string in `appsettings.json` 

5. Run the project 

---

## 🔑 Configuration

* Update **ConnectionStrings** in `appsettings.json`
* Configure JWT settings (if used)
* Set environment variables if required

--- 

## 🧪 Testing 

* API testing via Postman

---

## 📈 Future Enhancements

* Add role-based authorization
* Improve UI/UX
* Implement caching
* Add unit & integration tests

---

## 🔗 Related Repositories

* **Frontend Repository:** [Taskify Pro – Frontend](https://github.com/rajkamalhatwar/Taskify_Pro_Frontend)

> This repository contains the **backend REST API only**. The frontend application (UI) is developed and maintained separately to follow a clean separation of concerns.

---

## 👨‍💻 Author

**Rajkamal Hatwar**
Junior Software Developer
📧 Email: [rajkamalhatwar@gmail.com](mailto:rajkamalhatwar@gmail.com)
🔗 GitHub: https://github.com/rajkamalhatwar
🔗 LinkedIn: https://www.linkedin.com/in/rajkamal-hatwar-2b014b1b5/

---
 

⭐ If you like this project, give it a star on GitHub!
