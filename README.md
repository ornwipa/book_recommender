# Book Recommender

**Update:** web application is working now. Existing users can see the books they rated and the books recommended for them, as well as the books' details. The part for new users is under development.

## Theoretical Framework

This recommender system is based on collaborative filtering.

--- explain the proof of concept

--- figures: how readers recommend books to other readers, using principle of cosine similarity.

The server side of the recommender system was initially built and tested on Python. The prototype is presented in this [notebook](https://www.kaggle.com/ornwipathamsuwan/book-recommender-using-collaborative-filtering).

## Web Application

--- explain model-view-controller

--- screenshots of the view pages

## How to set up

- Clone this repository and install required packages
```
git clone https://github.com/ornwipa/book_recommender.git
dotnet add package TinyCsvParser
```

- Download **books.csv** and **ratings.csv** from **goodbooks-10k** dataset available on [Kaggle](https://www.kaggle.com/zygmunt/goodbooks-10k) and save them to the folder [data](https://github.com/ornwipa/book_recommender/tree/master/data).

- Run the application
```
cd book_recommender/recommender
dotnet run
```

## Acknowledgement

This repository serves as the final project for [ComIT](https://www.comit.org/)'s FULL STACK .NET course from July 20 to October 21, 2020.

The author would like to thank **ComIT** for this opportunity to showcase her aptitude in **artificial intelligence** through the mode of her newly-learned skills in **software development**.
