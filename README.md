# Book Recommender

## Theoretical Framework

A recommender system based on collaborative filtering

--- explain the proof of concept here

--- figures here: how readers of 50+ books recommend some books to other readers, using principle of cosine similarity.

The server side of the recommender system was initially built and tested on Python. The prototype is presented in this [notebook](https://www.kaggle.com/ornwipathamsuwan/book-recommender-using-collaborative-filtering).

## Web Application

### ASP.NET MVC Pattern

--- explain model-view-controller here

--- screenshots of the view pages here

### How to set up

- clone this repository and install required packages
```
git clone https://github.com/ornwipa/book_recommender.git
dotnet add package TinyCsvParser
```

- download **books.csv** and **ratings.csv** from **goodbooks-10k** dataset available on [Kaggle](https://www.kaggle.com/zygmunt/goodbooks-10k) and save them to the folder [data](https://github.com/ornwipa/book_recommender/tree/master/data).

- run the application
```
cd book_recommender/recommender
dotnet run
```

## Acknowledgement

This repository serves as the final project for [ComIT](https://www.comit.org/)'s FULL STACK .NET course from July 20 to October 21, 2020.

The author would like to thank **ComIT** for this opportunity to showcase her aptitude in **artificial intelligence** through the mode of her newly-learned skills in **software development**.
