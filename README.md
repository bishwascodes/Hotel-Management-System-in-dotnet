This was also a part of a project that I did for my Programming Fundamentals class:

---

# Hotel Management System in .NET

This **Hotel Management System** is a .NET-based application designed for managing hotel operations, including room bookings, customer management, and reservations. The system is structured to handle complex business processes while providing a clean, maintainable, and scalable solution.

The project features a layered architecture, ensuring a clear separation of concerns between data handling, business logic, and user interaction. It's designed to be both modular and extensible, allowing for easy updates and improvements.

---

## Project Architecture

The solution is composed of four distinct projects:

1. **Hotel.Data**: Responsible for data storage and persistence, managing file operations for rooms, customers, and reservations.
2. **Hotel.Logic**: Contains the core business logic for managing hotel operations, such as reservation handling and room availability.
3. **Hotel.UI**: A console-based user interface, providing users with an intuitive, menu-driven interface to interact with the system.
4. **Hotel.Logic.Tests**: A unit testing project for validating the core business logic and ensuring the system's reliability.

This architecture promotes a clean separation of concerns, making the application easier to maintain and extend in the future.

---

## Key Features

The system offers a comprehensive set of features, including both core functionalities and advanced capabilities:

### **Core Features**
- **Room Management**: Manage room creation, updates, and availability checks, with persistent storage for room data.
- **Customer Management**: Easily add and update customer details for smooth reservation processing.
- **Reservation System**: Create and manage reservations with real-time availability checks and conflict resolution.
- **Search and Reporting**: Search for available rooms by date and generate reservation reports for customers and specific dates.

### **Additional Features**
- **Multi-Day Reservations**: Support for reservations across multiple days, ensuring rooms are unavailable during booked periods.
- **Discount Programs**: Frequent Traveler discounts and coupon code-based savings.
- **Advanced Reporting**: Generate detailed reports on room utilization, revenue, and cleaning costs for daily and date-range periods.
- **Reservation Management**: View and manage past reservations, including refund processing.

---

## Learning Highlights

Key takeaways from this project include:

- **Modular Design**: The system is divided into logical modules for data management, business logic, and user interaction, improving maintainability and scalability.
- **File Handling**: Data persistence is managed through efficient file operations, with error handling for cases like missing files.
- **Test-Driven Development (TDD)**: Unit tests ensure the correctness of business logic, covering critical features like reservation handling and room availability.
- **Menu-Driven Console Applications**: An organized, user-friendly interface is created with nested menus for easy navigation.
- **Dynamic Data Management**: The system uses dynamic data structures, such as `List`, for efficient CRUD operations on rooms, customers, and reservations.

---

## Technical Setup

### Prerequisites

- .NET SDK 6.0 or higher
- Visual Studio 2022 (or any compatible IDE)

### Steps to Run the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/bishwascodes/Hotel-Management-System-in-dotnet.git
   ```
2. Open the solution in Visual Studio.
3. Build and run the solution to start the application.

---

## Conclusion

The **Hotel Management System** project provides a solid implementation of a real-world application, utilizing .NET technologies to manage hotel operations efficiently. Its modular design, combined with the core and advanced features, showcases the power of well-structured, maintainable code.
