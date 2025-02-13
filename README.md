# Blog Page Project - Developed with C# MVC and MSSQL

This project aims to create a simple blog page using the C# MVC framework and MSSQL database.

## Table of Contents

- [Project Description](#project-description)
- [Technologies](#technologies)
- [Installation](#installation)
- [Usage](#usage)
- [Database Schema](#database-schema)
- [File Structure](#file-structure)

## Project Description

This project provides the basic functionality of a blog page. Users can view blog posts, authors can add new posts, and filter posts by category.

## Technologies

- **Language:** C#
- **Framework:** ASP.NET MVC
- **Database:** Microsoft SQL
- **ORM:** Entity Framework Core
- **Other:** HTML, CSS, JavaScript

## Installation

1. Clone the project: `git clone https://github.com/furkandlkdr/MVC-Blog.git`
2. Open the project in Visual Studio.
3. Configure the database connection string in the `appsettings.json` file.
4. Install the necessary NuGet packages.
5. Migrate the database: `dotnet ef database update`

## Usage

1. Run the project via using HTTPS.
2. Navigate to `http://localhost:5275` in your browser.
3. View blog posts, add new posts, or filter by category.

## Database Schema

- **BlogPosts Table:**
    - `Id` (int, primary key, identity)
    - `Title` (nvarchar(255), not null)
    - `Summary` (nvarchar(500), not null)  
    - `Content` (nvarchar(max), not null)
    - `CreatedAt` (datetime, not null) 
    - `AuthorId` (int, foreign key, not null)
    - `CategoryId` (int, foreign key, not null)

- **Authors Table:**
    - `Id` (int, primary key, identity)
    - `Name` (nvarchar(255), not null)

- **Categories Table:**
    - `Id` (int, primary key, identity)
    - `Name` (nvarchar(255), not null)


## File Structure
```
Blog/ 
├── Controllers/ 
│   ├── AuthorController.cs 
│   ├── CategoryController.cs
│   ├── ContentController.cs
│   ├── EditorController.cs
│   └── HomeController.cs
├── Data/ 
│   ├── ApplicationDbContext.cs 
│   └── SeedData.cs
├── Models/ 
│   ├── Author.cs 
│   ├── AuthorsCategoriesViewModel.cs 
│   ├── BlogPost.cs 
│   └── Category.cs 
├── Views/ 
│   ├── Author/ 
│   │   ├── Create.cshtml
│   │   ├── Details.cshtml 
│   │   └── Index.cshtml 
│   ├── Category/
│   │   ├── Create.cshtml 
│   │   ├── Details.cshtml 
│   │   └── Index.cshtml 
│   ├── Content/
│   │   └── AuthorsAndCategories.cshtml
│   ├── Editor/ 
│   │   └── Create.cshtml 
│   ├── Home/
│       ├── Details.cshtml
│       └── Index.cshtml
│   └── Shared/ 
│       └── _Layout.cshtml 
├── wwwroot/ 
│   ├── css/ 
│   │   └── site.css 
├── appsettings.json 
└── Program.cs 


```
