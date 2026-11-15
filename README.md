# 🚗 DVLD - Driving & Vehicle License Department Management System

A comprehensive desktop application designed to automate and streamline the operations of a Driving & Vehicle License Department. Built using **C# (.NET Framework)** and **SQL Server**, the system follows a clean **3-Tier Architecture** to ensure scalability, maintainability, and separation of concerns.

---

## ✨ Key Features

* **👥 People & User Management:** Complete CRUD operations for managing individuals' records, system users, login authentication, and role-based permissions.
* **🪪 Local & International Driving Licenses:** Issue new local driving licenses, renew expired licenses, issue replacements for lost/damaged licenses, and issue international driving licenses.
* **📝 Applications & Workflow Tracking:** Manage various license application types, track application statuses (New, Cancelled, Completed), and handle service fees.
* **📅 Test Appointments & Scheduling:** Schedule, reschedule, and record results for Vision, Written (Theory), and Practical (Street) driving tests.
* **🚫 Detained Licenses Management:** Detain driving licenses for violations, calculate release fees, and process license releases.
* **🚘 Drivers Directory:** Maintain a centralized registry of all certified drivers and their complete license history.

---

## 🏗️ System Architecture & Tech Stack

The project is structured into three distinct layers:
1. **Presentation Layer (UI):** Windows Forms (`WinForms`) providing a responsive and user-friendly interface.
2. **Business Logic Layer (BLL):** Encapsulates all business rules, validations, and entities (`clsPeople`, `clsUsers`, `clsLicenses`, `clsApplications`, etc.).
3. **Data Access Layer (DAL):** Handles all database communications securely using **ADO.NET** and parameterized SQL queries.

* **Language:** C#
* **Framework:** .NET Framework 4.7.2
* **Database:** Microsoft SQL Server
* **Data Access:** ADO.NET

---

## 🚀 Getting Started

To run this project locally on your machine, follow these steps:

1. **Clone the repository:**
   `git clone https://github.com/anasswed/DVLDSystem.git`
2. **Database Setup:**
   * Open **SQL Server Management Studio (SSMS)**.
   * Restore the `.bak` database backup file (if included) or run the database creation script.
3. **Configure Connection String:**
   * Navigate to the `DataAccessLayer` project.
   * Open `clsDataAccessSettings.cs` and update the `ConnectionString` with your local SQL Server instance name and credentials.
4. **Build & Run:**
   * Open the `.sln` solution file in **Visual Studio**.
   * Build the solution (`Ctrl + Shift + B`) and press `F5` to run.

---

## 👨‍💻 Author

**Anas Swid**
* GitHub: [@anasswed](https://github.com/anasswed)
