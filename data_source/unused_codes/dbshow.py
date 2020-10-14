#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Sun Oct 11 16:40:17 2020
@author: ornwipa
"""

# resource: https://pythonprogramming.net/sqlite-part-3-reading-database-python/

import sqlite3

con = sqlite3.connect("recommender.db")
cur = con.cursor()
cur.execute('SELECT * FROM Books')
data = cur.fetchall()
print(data)
for row in data:
    print(row)
cur.execute('SELECT * FROM Ratings')
data = cur.fetchall()
print(data)
for row in data:
    print(row)