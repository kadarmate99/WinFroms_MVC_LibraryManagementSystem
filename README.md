# Library Management System

A simple WinForms application built as a learning project to practice implementing the MVC pattern and SOLID principles in C#.

This was a learning project focused on architecture patterns rather than a production application.

---

## Learning Goals

This project served as my hands-on practice for:

- **MVC Pattern**: Separating concerns between Models, Views, and Controllers  
- **SOLID Principles**: Writing maintainable, testable code  
- **Dependency Injection**: Using Microsoft's DI container with manual service lifetimes in WinForms  
- **Clean Architecture**: Organizing code with clear boundaries between layers  


## Features

Basic library functions:
- Add
- Edit
- Delete
- Search books  

Focus on architecture and separation of concerns over feature richness  


## Architecture Highlights

- Interface-based views (`IBookCatalogView`, `IBookEditorView`)  
- Abstracted service layer (`IBookService`)  
- Controllers manage flow between UI and logic  
- Proper DI setup with scoped dialogs  
- Event-driven communication  


## Running the Project

Clone the repository and open in Visual Studio. The project uses .NET with WinForms and includes sample data.





