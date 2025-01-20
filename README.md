# ASP.NET MVC Blog Application

## Overview
This is a simple blog management application built using ASP.NET Core MVC. The application allows users to create, read, update, and delete blog posts. It also implements custom validation for blog categories and uses Entity Framework Core to interact with a SQL Server database.

## Features
- **CRUD operations** for blog posts (Create, Read, Update, Delete)
- **Category Validation**: Blog categories are validated to ensure they belong to a predefined list of allowed categories.
- **Blog Listing**: Blogs are listed with the most recent first.
- **Blog Details**: View detailed information about each blog.
- **Edit and Delete**: Update or delete a blog post.
- **Responsive Views**: The application uses Bootstrap to ensure responsiveness.

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap (for UI)

## Requirements
- .NET 6 or later
- SQL Server (or any other compatible database provider)
- Visual Studio (or any other compatible IDE)

## Setup and Installation

### 1. Clone the repository:
```bash
git clone https://github.com/your-repo/aspnet-mvc-blog.git

### 2. Set up the database:
#### 1. Create a new SQL Server database and configure it with the following connection string:

   ```plaintext
   "ConnectionStrings": {
      "Blogs": "Server=your-server;Database=your-database;User Id=your-username;Password=your-password;"
   }

#### 2. Ensure that the BlogContext is correctly set up to use this connection string.

#### 3. Apply migrations to the database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 2. Run the application:
Once the setup is complete, run the application using the following command:

``` bash
dotnet run
```
## Structure
### Controllers
- BlogsController: Handles the main CRUD operations for the blogs. It uses BlogContext to interact with the database.
### Models
- Blog: Represents the blog entity with properties like Title, Author, Excerpt, Category, and CreatedDate.
- BlogDTO: Data transfer object used to handle input from users.
- CategoryValidation: Custom validation to ensure that the blog category is one of the predefined categories.
### Views
- Index.cshtml: Displays a list of all blog posts.
- Create.cshtml: Form for creating a new blog post.
- Details.cshtml: Displays detailed information for a selected blog post.
- Edit.cshtml: Form for editing an existing blog post.
### Endpoints
- GET /Blogs/Index: Displays all blog posts.
- GET /Blogs/Create: Shows the form to create a new blog.
- POST /Blogs/Create: Submits the form to create a new blog.
- GET /Blogs/Details/{id}: Displays the details of a specific blog.
- GET /Blogs/Edit/{id}: Shows the form to edit an existing blog.
- POST /Blogs/Edit/{id}: Submits the form to update an existing blog.
- GET /Blogs/Delete/{id}: Deletes a specific blog.
