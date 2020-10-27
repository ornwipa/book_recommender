# Final Project Presentation

## Immediate Feedback after Presentation

This section has feedback received on October 21, 2020, as well as the list of follow-up actions to be taken.

1. **User experience** can be improved. One way is to rank the recommended book when displaying them to the user.

Response: The book ranking has been considered and started to implement right away.

2. **Login and Register pages** can be created using `Identity Framework`.

Response: Incorporating this feature into the application would complete the training/portfolio in MVC. 

Current resources to learn are the ComIT lecture on October 19 and [Little ASP.NET Book](https://nbarbettini.gitbooks.io/little-asp-net-core-book/content/chapters/security-and-identity/), which add the authentication/authorization/security component after the application was created using `Entity Framework`.

Still, there is a difficulty in implementing this feature. `User` is a class in the current application with but would also be overridden during the migration once revising the Data/ApplicationDbContext to inherit from `IdentityDbContext` instead of `DbContext`. A thought on this potential problem is to start creating the new application from scratches.

3. **Deploying the application** may be helpful in getting a job as the application can be shown at an interview or even prior.

Response: It would also be a good skill to learn. **Docker** and **Azure** seem to be good options. Resource to follow is [Little ASP.NET Book](https://nbarbettini.gitbooks.io/little-asp-net-core-book/content/chapters/deploy-the-application/).

Two phases of deployment are being considered:

A. Keep the current application with some modifications (#1) but without Login and Register pages (#2). It was the initial goal to allow users to try the application without having to enter all their personal information (or even the fake one) as they might give up trying it at this step. If guests/visitors like (essentially, get hooked into) the application, they can register to have their book ratings kept in the database. This phase can be **Beta version**. 

There is one issue regarding the guest use. The current application is handling ONE visitor at a time so modifications are still needed to allow simultaneous users to interact with database.

B. After adding `IdentityUser`, all necessary components are completed. This phase may also include the link to a trial version for new users as well.

## Other Follow-up Thoughts

As of October 27, 2020

4. Later Pablo also suggested is to add public **reviews** to the books, and with that can be a tool for book club.

Response: This is a good idea for enhancement. It would be necessary to fetch review data via API, since the referred data repository in Kaggle does not include book review. Above all, work with API is a good skill that would be an asset for working in industry.

Main external resource can be [Goodreads API documentation](https://www.goodreads.com/api/index#review.show) with [tutorial](https://www.hongkiat.com/blog/goodreads-ratings-api/).

5. Since there are only 10k books, users cannot always find the books they want, which may result in discontinuing their use. Thus, it is important to include more books.

Besides Goodreads, another very large dataset is [UCSD Book Graph](https://sites.google.com/eng.ucsd.edu/ucsdbookgraph/home) which has meta-data of 2.36M books in *json*, 229M user-book interactions i.e. ratings in *csv*, and 15.7M review texts in *json*.
