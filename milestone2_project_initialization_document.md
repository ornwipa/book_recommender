# Project Initialization Document

## Scope

A section of text explaining what will be delivered to the project stakeholders (in this case the instructors). It should explain the use cases of the program and what problem(s) it attempted to solve. It should also include a paragraph outlining what frameworks will be used to develop the application.

*For the ComIT .NET course in Saskatoon, an online sentiment analysis application will be developed.*


## Top Level Design

A brief outline of what the user experience of the final product will be. What user interface will be provided to the user? What interactions with the program include? Does the program contain a backend database? Will it be hosted on the web, or will it be a desktop/mobile application?

*This application will serve a chatbot-like responsive graphical user interface through modern web browsers. A Model View Controller design pattern will be used within the ASP.NET Core framework.*

*There will be a number of primary models that define the application data, including:*
- *A pre-loaded dataset of corpura with labels*
- *A ngram method for building features from corpura and input text*
- *A training method for sentiment classification based on pre-defined features and labels*
- *A prediction mehtod on input text and classification model*

*The application will consist of a number of primary views, including:*
- *A homepage explaining how the application works and asking the user to get started*
- *A text input page where the program asked the user to describe what they think about a certain product then the user can enter their opinion in a form and submit it*
- *A output page where the application predicts whether the user likes the product*


## Risks / Unknowns

The student should consider what areas of the project may cause problems for them, and provide detail into how those risks will be addressed. 

*Issues will likely to be listed on-the-go. As of now, existing and forseen problems are:*
- *Real-time communication may be difficult or slow.*
- *Connecting to database have not been successful.* 
- *When using Ubuntu 20.04 LTS, there have been issues related to* <System.Globalization.Invariant>*. Also, any commands using* <dotnet-aspnet-codegenerator> *and* <dotnte-ef> *tools cannot be executed. For the course project, switching back to Ubuntu 18.04 LTS or another distribution might be a solution.*
