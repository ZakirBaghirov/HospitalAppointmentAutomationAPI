# Hospital Appointment Automation API

## Overview
The **Hospital Appointment Automation API** is a comprehensive solution designed to automate hospital operations. It facilitates seamless management of hospital appointments, doctors, users, and time slots through a robust and scalable RESTful API. Built using **ASP.NET Core** and **Entity Framework Core**, the API ensures high performance and reliability.

## Features
- **Appointment Management**: Create, update, and manage hospital appointments.
- **Doctor Management**: Manage doctor information and schedules.
- **User Management**: Handle patient and admin user data.
- **Time Slot Management**: Manage availability and scheduling of time slots.
- **Audit Logging**: Tracks actions and changes for security and traceability.
- **Database Migration**: Supports database versioning with Entity Framework.

## Project Structure
```
HospitalAppointmentAutomationAPI
│
├── Controllers
│   ├── AdminController.cs          # Handles admin operations
│   ├── AppointmentController.cs    # Manages appointments
│   ├── DoctorController.cs         # Handles doctor operations
│   ├── PeriyotController.cs        # Manages time slots
│   ├── UserController.cs           # Handles user management
│
├── Migrations
│   ├── Migrations.cs     # Initial migration file
│   ├── ApplicationDbContextModelSnapshot.cs
│
├── Models
│   ├── Admin.cs                   # Admin entity
│   ├── Appointment.cs             # Appointment entity
│   ├── AuditLog.cs                # Audit log entity
│   ├── Doctor.cs                  # Doctor entity
│   ├── Periyot.cs                 # Time slot entity
│   ├── User.cs                    # User entity
│
├── Services
│   ├── AdminService.cs            # Business logic for admin operations
│   ├── AppointmentService.cs      # Business logic for appointments
│   ├── AuditLog.cs                # Audit logging logic
│   ├── DoctorService.cs           # Business logic for doctors
│   ├── PeriyotService.cs          # Business logic for time slots
│   ├── UserService.cs             # Business logic for users
│
├── appsettings.json               # Application configuration
├── Program.cs                     # Entry point of the application
├── HospitalAppointmentAutomationAPI.sln # Solution file
```

## Technologies Used
- **Backend**: ASP.NET Core
- **Database**: Microsoft SQL Server, Entity Framework Core
- **API Design**: RESTful API principles
- **Architecture**: Layered Architecture (Controllers, Services, Repositories)

## Getting Started

### Prerequisites
Ensure the following tools are installed:
- **.NET 6.0 SDK**
- **Microsoft SQL Server**

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/HospitalAppointmentAutomationAPI.git
   cd HospitalAppointmentAutomationAPI
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

### Configuration
Update the `appsettings.json` file to configure:
- **Database Connection**: Add your SQL Server connection string.

## Usage
- **Base URL**: The API is accessible at `http://localhost:5000/api`.
- **Endpoints**:
  - `/api/appointments`: Manage appointments.
  - `/api/doctors`: Manage doctor records.
  - `/api/users`: Manage user information.
  - `/api/periyot`: Manage time slots.
  - `/api/admin`: Admin-specific operations.

## Contribution
Contributions are welcome! Follow these steps:
1. Fork the repository.
2. Create a new feature branch: `git checkout -b feature-name`
3. Commit your changes: `git commit -m 'Add feature'`
4. Push to the branch: `git push origin feature-name`
5. Submit a pull request.

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.

## Contact
For any inquiries or feedback, feel free to reach out:
- **Email**: eraykelesk@gmail.com
- **LinkedIn**: [Eray Keleş](https://linkedin.com/in/eraykeles)

