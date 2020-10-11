#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Sun Oct 11 15:11:09 2020
@author: ornwipa
"""

# resource: https://pypi.org/project/csv-to-sqlite/

# import csv_to_sqlite 

# options = csv_to_sqlite.CsvOptions(typing_style="full", encoding="windows-1250") 
# input_files = ["books.csv", "ratings.csv"]
# csv_to_sqlite.write_csv(input_files, "book_rating_database.sqlite", options)

# resource: https://stackoverflow.com/questions/2887878/importing-a-csv-file-into-a-sqlite3-database-table-using-python

import csv, sqlite3, pandas

con = sqlite3.connect("recommender.db")
cur = con.cursor()

df = pandas.read_csv("books.csv")
df.to_sql("Books", con, if_exists='append', index=False)

df = pandas.read_csv("ratings.csv")
df.to_sql("Ratings", con, if_exists='append', index=False)