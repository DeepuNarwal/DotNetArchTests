DotNetArchTests

DotNetArchTests is a set of architecture tests designed to ensure that naming conventions are followed within a .NET codebase. This repository contains tests for checking the adherence of naming conventions for Model properties, Repository classes, and Service classes. By automating these tests, you can ensure consistency and maintainability of your codebase.

Features

Model Property Naming Convention: Verifies that model properties follow the PascalCase naming convention.
Repository Naming Convention: Ensures that all classes in the Repositories namespace end with the Repository suffix.
Service Naming Convention: Checks that all classes in the Services namespace end with the Service suffix.

Requirements
.NET 6 or later
NetArchTest.Rules NuGet package (for performing architecture rules)