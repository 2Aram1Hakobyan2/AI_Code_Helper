# CodeAssistant

CodeAssistant is a C# web application that utilizes OpenAI's GPT to refactor users' pieces of code. This project is built with ASP.NET Core and uses Entity Framework Core for object-relational mapping.

## Prerequisites

Before running the application, ensure you have the following installed:
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- An appropriate IDE such as [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/) with the C# extension, or [JetBrains Rider](https://www.jetbrains.com/rider/).
- Install the Entity Framework Core tools globally by running the following command:
```bash
dotnet tool install --global dotnet-ef
```

## Installation

First, clone the repository to your local machine:

```sh
git clone https://github.com/garikisraelyan/CodeAssistant.git
cd CodeAssistant
```

## Configuration

### Environment Variables

Set your OpenAI API key as an environment variable:

For Unix-based systems:
```sh
export OPENAI_API_KEY='your_api_key_here'
```

For Windows CMD:
```cmd
set OPENAI_API_KEY=your_api_key_here
```

For Windows PowerShell:
```ps
$Env:OPENAI_API_KEY='your_api_key_here'
```

Replace `'your_api_key_here'` with your actual OpenAI API key.

## Installation of Required Libraries

Before running the project, ensure that you have the necessary libraries installed. You can install all the required libraries by running the following command in the root directory of the project:

```bash
dotnet restore
```

### Database Setup

This application uses SQLite. Make sure the connection string in `appsettings.json` is correct.

Run the following command to create your database schema with Entity Framework migrations:

```sh
dotnet ef database update
```

## Running the Application

Once configuration and database setup are complete, start the application:

```sh
dotnet run
```

See the link the app is running through in the command prompt. By default, the application will be hosted at `http://localhost:5078`.