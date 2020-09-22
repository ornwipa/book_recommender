# Preparation for project check-in

## Completed work

The server side (collaborative filtering) of the book recommendation engine is completed. So does the basic version of the user interface. Users can enter their ```user_id``` to see the books they rated and the books recommended for them. Users can also search for books; the search string can contain parts of authors, titles, year and ISBN. For each book, user can see its full details including the picture of book cover.

## Work-in-progress

The UI is now being developed/improved. The remaining goals/tasks aimed for completion by the end of the course are:
- Proper/correct binding(?) of ```User``` instance and List of ```Book``` objects: currently users need to enter some value to retrieve something, e.g. ```user__id``` for rated books or recommended books and search keywords for other books. It would be more convenient and user-friendly if the users could simply enter their ```user_id``` just once and browse both rated books and recommended books.
- Functionality for users to change their ratings of books. This function will be available in the "search results" page and "recommended books" page.
- Ability for new users (without ```user_id```) to use the application, e.g. rate books and get recommendation for the next books they could read. This part has not been started.

## Questions/Problems

Remaining issues (indeed problems) so far are:
- Passing an object from view to controller: it is advised in [stackoverflow](https://stackoverflow.com/questions/14152575/pass-parameter-to-controller-from-html-actionlink-mvc-4) that the "model" parameter being passed can be ```Model.user__id``` instead of the ```User``` class (```Model```). Now, should a new instance of ```User``` be created each time? Or the record of ```current_user``` cab be retrieved somehow?
- Using or not using **Microsoft Entity Framework**? The barrier is not only the incompatibility with Ubuntu 20.04 (which was partially solved by using Ubuntu 18.04 for some part of the development, i.e. the initial migration) but also, frankly, I do not understand it deep enough to make use of it; in other words, I am not comfortable using something that I don't truly understand. Without using some kind of database, how a new users can be added or saved for later access? Same thing applies to the change of ratings.

## Next steps

This section includes actions that may or may not be done by the delivery of the final project but will be done at some point.
- Unit tests: the program itself and it's functions was tested over time while the application is being built; however, the test was done via console application or manually in the UI. Ideally, automated tests should also be built at the same time but focusing on too many things might lead to not getting anything done.
- Learning to use ```Task``` and ```async```/```await```: in case it helps with running several tasks in parallel, this will be used for optimizing the program. Are there other benefit?
- Deployment on Azure(?): it would be good if this project could the public and anyone can use this application, all not-for-profit.
