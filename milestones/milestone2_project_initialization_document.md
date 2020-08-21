# Project Initialization Document

## Scope

*A section of text explaining what will be delivered to the project stakeholders (in this case the instructors). It should explain the use cases of the program and what problem(s) it attempted to solve. It should also include a paragraph outlining what frameworks will be used to develop the application.*

For the ComIT .NET course in Saskatoon, a web application for book recommender systems with collaborative filtering will be developed.


## Top Level Design

*A brief outline of what the user experience of the final product will be. What user interface will be provided to the user? What interactions with the program include? Does the program contain a backend database? Will it be hosted on the web, or will it be a desktop/mobile application?*

For the user interface, a model-view-controller design pattern will be used within the ASP.NET Core framework; this will be coded on C# and HTML. For the server side, Python libraries will be used for builder the recommender. 

There will be a number of primary models that define the application data, including:
- A pre-loaded dataset can be obtained from [Kaggle](https://www.kaggle.com/zygmunt/goodbooks-10k?select=ratings.csv). Data used for this application are books.csv and ratings.csv.
- From ratings.csv, a matrix of similarities among users will be calculated based on euclidean distance and cosine distance of all the users' ratings on all the books.
- A list of n books will be recommended to a current user. This list are books with the highest ratings, averaged among the user's k-nearest neighbours.

The application will consist of a number of primary views, including:
- A homepage explaining how the application works and asking the user for an input of the user ID.
- A book recommendation page containing the list of N recommended books for certain user ID. This will will contains the controller linked to the detail of the books, 'mark as read', 'rate the book', etc.
- From books.csv, a book detail page for each book.


## Risks / Unknowns

*The student should consider what areas of the project may cause problems for them, and provide detail into how those risks will be addressed.*

As of now, existing and forseen problems are:
- Working with a very large dataset could take a long time to run from the point that a user enters ID in the home page until the list of recommendation is rendered on the book recommendation page.
- Separting UI and server might not allow real-time update. For instance, the book marked as read will still remain as recommended book unless the list is updated right away. This may be solved by having the server provide N+m books but show only N books. However, the immediate rating of the just read book will not be included in the dataset used for building the similarity matrix.
