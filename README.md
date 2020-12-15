# Book Recommender

## Acknowledgement

This repository serves as the final project for [ComIT](https://www.comit.org/)'s FULL STACK .NET course from July 20 to October 21, 2020.

The author would like to thank **ComIT** for this opportunity to combine the previously-developed knowledge/ability in **artificial intelligence** and the newly-learned skills in **software development** into an application that can reach the public.

## Web Application

This web application was built using ASP.NET Core framework, Model-View-Controller pattern with three main functionalities:
1. Users can see the list of books they rated and change the ratings they gave to the books.
2. Users can get recommendation for books they may like. In the list of recommended books, users can also add their book ratings.
3. Users can search for other books in the database of 10k books by entering keywords of authors, title and ISBN, and add ratings to them.

The examples of web pages are shown in the [figures](https://github.com/ornwipa/book_recommender/tree/master/figures) folder and one as below:
![](https://github.com/ornwipa/book_recommender/blob/master/figures/rated.png)

## How to set up

- Clone this repository
```
git clone https://github.com/ornwipa/book_recommender.git
cd book_recommender/recommender
```

- Install required packages by running the following codes:
```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package TinyCsvParser
```

- Download **books.csv** and **ratings.csv** from **goodbooks-10k** dataset available on [Kaggle](https://www.kaggle.com/zygmunt/goodbooks-10k) and save them to the folder named [data_source](https://github.com/ornwipa/book_recommender/tree/master/data_source). The data will be seeded once at the first time the application is run.

- Optionally, to start fresh, remove all .db file and everything in the [Migrations](https://github.com/ornwipa/book_recommender/tree/master/recommender/Migrations) folder then re-create the database by running the following codes:
```
dotnet ef migrations remove
dotnet ef migrations add existingData
dotnet ef database update
```

- Run the application
```
dotnet run
```

Note that a Docker container image is also published on [Docker Hub](https://hub.docker.com/repository/docker/ornwipa/book_recommender).

## Theoretical Framework

This recommender system is based on collaborative filtering. That is, a user receives their book recommendation from a set of "similar" users, determined by cosine similarity.

> Collaborative filtering is a technique that can filter out items that a user might like on the basis of reactions by similar users. It works by searching a large group of people and finding a smaller set of users with tastes similar to a particular user. It looks at the items they like and combines them to create a ranked list of suggestions. 
>-- from [realpython.com](https://realpython.com/build-recommendation-engine-collaborative-filtering/#reader-comments)

In contrast to content-based recommender system where the descriptions of each item (product, book, movie, etc.) and of each user are required to create features for k-nearest-neighbors algorithm, collaborative filtering is indeed a social process that leverages data from the crowd directly without creating item or user profile features. 

> To address some of the limitations of content-based filtering, collaborative filtering uses similarities between users and items simultaneously to provide recommendations. This allows for serendipitous recommendations; that is, collaborative filtering models can recommend an item to user A based on the interests of a similar user B. Furthermore, the embeddings can be learned automatically, without relying on hand-engineering of features. 
>-- from [developers.google.com](https://developers.google.com/machine-learning/recommendation/collaborative/basics)

More "academic" readings about collaborative filtering in recommender systems are in [ScienceDirect](https://www.sciencedirect.com/topics/computer-science/collaborative-filtering).

The prototype of this recommender system was initially built and tested as presented in this [Kaggle Notebook](https://www.kaggle.com/ornwipathamsuwan/book-recommender-using-collaborative-filtering).
