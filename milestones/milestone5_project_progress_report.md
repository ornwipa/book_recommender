# Final Project Progress

## Preparation for project check-in

As of September 22, 2020

### Completed work

The server side (collaborative filtering) of the book recommendation engine is completed. So does the basic version of the user interface. Users can enter their ```user_id``` to see the books they rated and the books recommended for them. Users can also search for books; the search string can contain parts of authors, titles, year and ISBN. For each book, user can see its full details including the picture of book cover.

### Work-in-progress

The UI is now being developed/improved. The remaining goals/tasks aimed for completion by the end of the course are:
- Proper/correct binding(?) of ```User``` instance and List of ```Book``` objects: to make sure that ```user_id``` is passed correctly from view to controller, especially when passing from search results or recommended books back to rated books. 
- Functionality for users to change their ratings of books: to create "rate" controller method available in the "search results" and "recommended books" page.
- Ability for new users (without existing ```user_id```) to use the application, e.g. rate books and get recommendation for the next books they could read. This part has not been started.

### Questions/Problems

Remaining issues (indeed problems) so far are:
- Passing an object from view to controller: it is advised in [stackoverflow](https://stackoverflow.com/questions/14152575/pass-parameter-to-controller-from-html-actionlink-mvc-4) that the "model" parameter being passed can be ```Model.user__id``` instead of the ```User``` class (```Model```). Now, a new instance of ```User``` is created by a constructor each time calling a controller method. How can a record of ```current_user``` be retrieved? Or is there any other way not to always have a new instance?
- Using or not using **Microsoft Entity Framework**? The barrier is not only the incompatibility with Ubuntu 20.04 (which was partially solved by using Ubuntu 18.04 for some part of the development, i.e. the initial migration) but also, frankly, I do not understand it deep enough to make use of it; in other words, I am not comfortable using something that I don't truly understand. Without using some kind of database, how a new users can be added or saved for later access? Same thing applies to the change of ratings.
- A back-up plan in case of not using database, new users can be treated as "guests" (opposite to "members"). They can start with no book ratings and are still able to search for books, rate books, and get recommended books. However, their work will not be stored and they have to re-do the rating each time to see recommended books.

### Next steps

This section includes actions that may or may not be done by the delivery of the final project but will be done at some point.
- Unit tests: the program itself and it's functions was tested over time while the application is being built; however, the test was done via console application or manually in the UI. Ideally, automated tests should also be built at the same time but focusing on too many things might lead to not getting anything done.
- Learning to use ```Task``` and ```async```/```await``` to run several tasks in parallel, this will be used for optimizing the program.
- Deployment on Azure(?) to the public so anyone can use this application.

## Summary of project progress meeting

September 24, 2020, 8:00-8:40 pm

### Main area to be done

Suggestions from Joel's are:
- **Database** is very important as part of ASP.NET MVC, and it will be good to develop skills that will eventually lead to completed work in building a website.
- Styling with ```CSS``` (Cascading Style Sheet): Joel gave a simple demo and reference to [Bootstrap](https://getbootstrap.com/docs/4.5/getting-started/introduction/).

### Others

In addition to primary suggestions about 
- With Joel's help, the issue about passing value from ```.cshtml``` View page to a Controller method was solved by using "hidden" input type included in the HTML form and pass ```@Model.user_id``` as "value".
