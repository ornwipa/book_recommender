# Book Recommender

**Update:** web application is working now. Existing users (registered members) can see the books they rated and the books recommended for them, as well as the books' details. The part for new users is under development.

## Theoretical Framework

This recommender system is based on collaborative filtering. That is, a user receives their book recommendation from a set of "similar" users, determined by cosine similarity.

> Collaborative filtering is a technique that can filter out items that a user might like on the basis of reactions by similar users. It works by searching a large group of people and finding a smaller set of users with tastes similar to a particular user. It looks at the items they like and combines them to create a ranked list of suggestions.
> - Abhinav Ajitsaria, written in [realpython.com](https://realpython.com/build-recommendation-engine-collaborative-filtering/#reader-comments)

In contrast to the content-based recommender systems where the descriptions of each item (product, book, movie, etc.) or even of users are required to create their profiles to apply k-nearest neighbors, collaborative filtering is indeed a social process that leveraes data from the crowd directly without creating item or user profile features. 

> To address some of the limitations of content-based filtering, collaborative filtering uses similarities between users and items simultaneously to provide recommendations. This allows for serendipitous recommendations; that is, collaborative filtering models can recommend an item to user A based on the interests of a similar user B. Furthermore, the embeddings can be learned automatically, without relying on hand-engineering of features.
> - [developers.google.com](https://developers.google.com/machine-learning/recommendation/collaborative/basics)

More "academic" (yet well-described) readings about collaborative filtering in recommender systems are in [ScienceDirect](https://www.sciencedirect.com/topics/computer-science/collaborative-filtering)

The server side of the recommender system was initially built and tested on Python. The prototype is presented in this [Kaggle Notebook](https://www.kaggle.com/ornwipathamsuwan/book-recommender-using-collaborative-filtering).

## Web Application

This web application was built using ASP.NET Model-View-Controller.

--- screenshots of the view pages

## How to set up

- Clone this repository and install required packages
```
git clone https://github.com/ornwipa/book_recommender.git
cd book_recommender/recommender
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package TinyCsvParser
```

- Download **books.csv** and **ratings.csv** from **goodbooks-10k** dataset available on [Kaggle](https://www.kaggle.com/zygmunt/goodbooks-10k) and save them to the folder named [data_source](https://github.com/ornwipa/book_recommender/tree/master/data_source).

- Connect to database by applying `migrations` to create data tables and `update` to move data from .csv file to the database 
```
dotnet ef migrations add existingData
dotnet ef database update
```

- Run the application
```
dotnet run
```

## Acknowledgement

This repository serves as the final project for [ComIT](https://www.comit.org/)'s FULL STACK .NET course from July 20 to October 21, 2020.

The author would like to thank **ComIT** for this opportunity to combine the previously-developed knowledge/ability in **artificial intelligence** and the newly-learned skills in **software development** into a showcase that can reach the public.
