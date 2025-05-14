# BookBuzz - Book Review Application

BookBuzz is a Blazor WebAssembly application that allows users to browse books, read and write reviews, and filter books by genre and rating.

## SOLID Principles Implemented

This application demonstrates the implementation of the following SOLID principles:

### 1. Single Responsibility Principle (SRP)

The Single Responsibility Principle states that a class should have only one reason to change. This principle is implemented in:

- **BookService**: Responsible only for book-related operations such as retrieving books, getting books by genre, etc.
- **ReviewService**: Responsible only for review-related operations such as adding reviews and calculating average ratings.
- **Book and Review models**: Each model contains only the properties and behaviors relevant to its entity.

### 2. Open/Closed Principle (OCP)

The Open/Closed Principle states that software entities should be open for extension but closed for modification. This principle is implemented in:

- **Filter System**: The `IBookFilter` interface and concrete implementations (`GenreFilter`, `RatingFilter`) allow for new filtering strategies to be added without modifying existing code.
- **BookFilterService**: This service can apply any collection of filters that implement the `IBookFilter` interface without needing to be modified to accommodate new filters.

### 3. Interface Segregation Principle (ISP)

The Interface Segregation Principle states that clients should not be forced to depend upon interfaces they do not use. This principle is implemented in:

- **IBookService**: Defines operations related only to books.
- **IReviewService**: Defines operations related only to reviews.

### 4. Dependency Inversion Principle (DIP)

The Dependency Inversion Principle states that high-level modules should not depend on low-level modules. Both should depend on abstractions. This principle is implemented in:

- **ReviewService**: Depends on the `IBookService` interface rather than a concrete implementation.
- **Component Injection**: All components depend on service interfaces rather than concrete implementations, allowing for easy swapping of implementations.

## Key Components

1. **Models**: `Book` and `Review` classes
2. **Services**: `IBookService`, `IReviewService` interfaces and their implementations
3. **Filters**: `IBookFilter` interface with implementations for filtering by genre and rating
4. **Components**: Index page for book listing, BookDetail page, FilterPanel component

## Running the Application

1. Clone the repository
2. Open the solution in Visual Studio or your preferred IDE
3. Restore NuGet packages
4. Build and run the application 