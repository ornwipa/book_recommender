# Proposals

Draft v.1

The order of preferred topics: 5-4-1-2-3

1. **Cancer patient scheduling**

	1.1 demand forecast: how many incoming patients and what are their characteristics of treatment needed (chemotherapy or radiotherapy, how many courses and duration), weekly -> either Holt-Winter's exponential smoothing method for trend and seasonality, or machine learning, i.e. regression on some predictors

	1.2 scheduling solutions: exact (optimization to minimize wait time/days or number of patients waiting for their first treatment session -> mixed integer programming) and/or heuristic (good enough algorithm for tree search --> decompose into several small strips and model small a piece as knapsack problem)

	1.3 interface for administrators: how to display solution to the users (preferably as a table), how to add the next patient into the system/queue

	Pros: can show lots of other skills - statistics / data science (1.1), operation research (1.2), etc. although those skills might not be among employers' interest

	Cons/Challenges: need input data from reliable source to get started; can get lost into developing solutions; difficult stakeholders; maybe too much focus on backend

2. **Data visualization dashboard**

	- Interactive web application similar to [IHME's GBD Compare](https://vizhub.healthdata.org/gbd-compare/) or [WHO monitoring health for SDGs](https://apps.who.int/gho/data/node.sdg)
	
	- Examples of data/information to display: individual-level blood glucose to help control diabetes

	Pros: can show creativity and attract diverse employers if it is very good

	Cons: lack of uniqueness, can easily fade out as there are many other existing works, show only frontend 

3. **Foreign language e-learning platform**

	Description: a language-learning web application, inspired by Clic en Ligne, taylored to new immigrants in Canada.

	3.1 Student
		- Reading: text + comprehension questions
		- Listening: audio + comprehension questions
		- Writing: instructions + submission channel
		- Speaking: features to schedule a video-call with teacher
	
	3.2 Teacher
		- Writing: access to assignment, grading rubric, features to make comments/corrections
		- Speaking: choose availability, set up group video-calls
		
	Pros: not sure, but interesting and can be helpful for people

	Cons: features are mostly independent from one another, maybe tedious on relatively easier tasks but fewer complicated tasks to present

4. **Personal errand routing | trip planner**

	Use case A user wants to do several things in a day, what is a sequence of activities that she/he should do in order to take the shortest time to complete all tasks. For example, on Saturday, Madame Smith wants to go to Gord's No Frills on Clarence & Taylor, J.S. Wood Library, Home Depot in Stonebridge, Shaw Centre, Corman Park Vet Service, Floral Acres Greenhouses, and Scotia Bank on CumberLand & 8th. In what order should she take to visit all the places in the shortest time? Assume that all the places always open when she arrives, and traveling time is deterministic. These two assumptions can be relaxed as the next step of the project.
	
	Approach: 'traveling salesman problem' -> user's input location's names (frontend) -> system gets a collection of geographical locations (from where?) (backend) -> system calculate sequences using TSP (backend) -> system tells user the solution (frontend)
	
	Pros: simple enough?, show both IEOR skills (math) and user's interface (aesthetic), show data collection capacity

	Cons/Challenges: need base map (shape files for road and business location?) ... google? openstreetmap?
	
	Other aspects: time of the day matter! ... to add a brach or an issue for the next development if not considered at the beginning

5. **Simple chatbot on movie ratings**

	Use case: A console asking users to comment on a given movie if they already watch it e.g. "What do you think about The Lion King movie?" Then the system take this input and process to decide whether the particular user likes or dislikes a particular movie. Finally, the console talks to the users "We think you like this movie." or "We think you dislike this movie." Optionally, the next phase is to allow the system to collect more data by asking if the prediction is correct and record the new input: X = comments, y = 0/1 representing negative/positive sentiment of users. This way, the model will always adapt and re-train itself.
	
	Approach: based on the existing database of movie ratings from _Andrew L. Maas, Raymond E. Daly, Peter T. Pham, Dan Huang, Andrew Y. Ng, and Christopher Potts. (2011). Learning Word Vectors for Sentiment Analysis. The 49th Annual Meeting of the Association for Computational Linguistics (ACL 2011)_, create features using NLP and use the features and ground truths to build a supervised learning machine
	
	5.1 user interface of the chatbot: a console application, something newly-learned from ComIT
	
	5.2 natural language processing: build bags of words as n-gram ... demonstrate working with string commands for tokenization, uses of iterations and conditional statements, understanding of human languages e.g. importance of removing stop words.
	
	5.3 training models: split data for training and testing, split data for k-fold cross validation, train models with artificial neural network (either 5.3.1 build ANN algorithm from scratch will be a good review, or 5.3.2 use an opensource package will show ability to develop codes from previous work)
	
	Pros: demonstrate skills in NLP and AI, seems feasible as I already did the 5.2 and 5.3 (with stochastic gradient descent) on Python for the AI class at Columbia University. The result done in C# could be comparable.

	Cons/Challenges: how to store the large corpus, this may be computationally heavy if model is re-trained every time.
	
	Resource for NLP, including chatbot
	- [SharpNLP on CodePlex Archive](https://archive.codeplex.com/?p=sharpnlp)
	- [Google Cloud Natural Language API with C#](https://codelabs.developers.google.com/codelabs/cloud-natural-language-csharp/index.html?index=..%2F..index#0)
	- [BotSharp on GitHub](https://github.com/SciSharp/BotSharp)
	
	Resource for ANN
	- [Rubik's Code: Implementing Simple Neural Network in C#](https://rubikscode.net/2018/01/29/implementing-simple-neural-network-in-c/)
	- [Microsoft: Deep Neural Network IO Using C#](https://docs.microsoft.com/en-us/archive/msdn-magazine/2017/august/test-run-deep-neural-network-io-using-csharp)
	- [NeuralNetwork.NET, a .NET 2.0 standard library built from scratch with C#](https://github.com/Sergio0694/NeuralNetwork.NET)

