BOOKBUZZ - BOOK REVIEW APPLICATION
==============================

SOLID PRINCIPLES IMPLEMENTED
----------------------------

1. Single Responsibility Principle (SRP)
   - Implemented in the services layer with BookService and ReviewService, each handling only operations related to their respective domain.
   - Models (Book and Review) are focused on representing only their entity data without mixing concerns.
   - Location in codebase: Services/BookService.cs, Services/ReviewService.cs, Models/Book.cs, Models/Review.cs

2. Open/Closed Principle (OCP)
   - Implemented through the filter system with the IBookFilter interface.
   - New filters can be added by creating new implementations of IBookFilter without modifying existing code.
   - The BookFilterService can work with any filter implementation without changing its code.
   - Location in codebase: Filters/IBookFilter.cs, Filters/GenreFilter.cs, Filters/RatingFilter.cs, Filters/BookFilterService.cs

3. Interface Segregation Principle (ISP)
   - Implemented with specific interfaces (IBookService, IReviewService) that contain only methods relevant to their domain.
   - Clients only depend on the interfaces they need, not on methods they don't use.
   - Location in codebase: Services/IBookService.cs, Services/IReviewService.cs

4. Dependency Inversion Principle (DIP)
   - High-level modules depend on abstractions, not on low-level modules.
   - ReviewService depends on IBookService, not directly on BookService.
   - Components depend on service interfaces, not concrete implementations.
   - Location in codebase: Services/ReviewService.cs, Pages/Index.razor, Pages/BookDetail.razor, Components/FilterPanel.razor

HOW PRINCIPLES WERE APPLIED
---------------------------

1. SRP: Each class has a single responsibility and reason to change. For example, BookService is only responsible for operations related to books, while ReviewService is only responsible for operations related to reviews.

2. OCP: The filter system is designed so that new filtering strategies can be added without modifying existing code. This is achieved through the IBookFilter interface and the BookFilterService, which can work with any combination of filters.

3. ISP: Interfaces are specific to the needs of their clients. The IBookService interface contains only book-related methods, while the IReviewService interface contains only review-related methods.

4. DIP: Dependencies flow toward abstractions, not implementations. This allows for easy substitution of implementations and facilitates testing. For example, the ReviewService depends on the IBookService interface, not the BookService implementation. 