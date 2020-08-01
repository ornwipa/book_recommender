# Proposals

Draft v.2

1. **Web application for (chronic disease e.g. cancer) patient scheduling**

	An application to assist health administrators to schedule patient visits under limited time availability. Assume no walk-in patients as the application is for chronic disease clinics which patients would be previously diagnosed from elsewhere and referred to. The goal is to have patients treated as soon as possible under given resources. Certain facilities can accommodate only some number of patients at a time. For example, there may be four rooms for chemotherapy. Patients will need continuous time slot to complete treatment such as 30 days in a row for radiation. 

	1.1 demand forecast: how many incoming patients and what are their characteristics of treatment needed (chemotherapy or radiotherapy, how many courses and duration), weekly -> either Holt-Winter's exponential smoothing method for trend and seasonality, or machine learning, i.e. regression on some predictors

	1.2 scheduling solutions: exact (optimization to minimize wait time/days or number of patients waiting for their first treatment session -> mixed integer programming) and/or heuristic (good enough algorithm for consolidation or to guide a tree search)

	1.3 interface for administrators: how to display solution to the users (preferably as an interactive table), how to add the next patient into the system/queue

	Pros: can show lots of other skills - statistics / data science (1.1), operation research (1.2), etc. although those skills might not be among employers' interest

	Cons/Challenges: may need input data from reliable source to get started if not making assumptions; can get lost into developing solutions; difficult stakeholders

2. **Web application as simple chatbot on product (e.g. movie, book) ratings**

	A chatbot asking users to comment on a given product $"What do you think about {product}?" Then the system take this input and process to decide whether the particular user likes or dislikes a particular product. Finally, the robot talks to the users $"We think you like {product}." or $"We think you dislike {product}." Optionally, the next phase is to allow the system to collect more data by asking if the prediction is correct and record the new input: X = features derived from users' comments, y = 0/1 representing negative/positive sentiment of users. This way, the model will always adapt and re-train itself.
	
	2.1 user interface of the chatbot: a web application, something newly-learned from ComIT
	
	2.2 natural language processing: build bags of words as n-gram to practice/demonstrate working with string commands for tokenization, uses of iterations and conditional statements, understanding of human languages e.g. importance of removing stop words.
	
	2.3 training models: split data for training and testing, split data for k-fold cross validation, train models with artificial neural network (either build ANN algorithm from scratch will be a good knowledge review, or use an opensource package will develop/show ability to code from previous work)
	
	Pros: demonstrate skills in NLP and AI, seems feasible as already did 2.2 and 2.3 (with stochastic gradient descent) on Python for the AI class at Columbia University. The result done in C# could be comparable.

	Cons/Challenges: how to store the large corpus, this may be computationally heavy if model is re-trained every time.
	
	Resource for NLP, including chatbot
	- [SharpNLP on CodePlex Archive](https://archive.codeplex.com/?p=sharpnlp)
	- [Google Cloud Natural Language API with C#](https://codelabs.developers.google.com/codelabs/cloud-natural-language-csharp/index.html?index=..%2F..index#0)
	- [BotSharp on GitHub](https://github.com/SciSharp/BotSharp)
	
	Resource for ANN
	- [Rubik's Code: Implementing Simple Neural Network in C#](https://rubikscode.net/2018/01/29/implementing-simple-neural-network-in-c/)
	- [Microsoft: Deep Neural Network IO Using C#](https://docs.microsoft.com/en-us/archive/msdn-magazine/2017/august/test-run-deep-neural-network-io-using-csharp)
	- [NeuralNetwork.NET, a .NET 2.0 standard library built from scratch with C#](https://github.com/Sergio0694/NeuralNetwork.NET)

