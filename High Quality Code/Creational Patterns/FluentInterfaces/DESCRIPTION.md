#Fluent Interfaces

+ Intuitive definition: object-oriented API that aims to make the code more intuitive/readable/easy to use
+ Scenario of use: based on my expirience, it's mostly used in OO languages and takes advantage of method cascading/chaining
+ Pros:
	- more readable/intuitive code
	- shorter code(usually)
	- better developer performance
	- can act as facade(encapsulating and improving poorly designed APIs)
- Cons:
	- has negative impact on cohesion(example: chaining in methods, that would normally be void)
	- could reduce performance
	- more code to implement them === more tests
	- more code === more bugs
	- could actually make code less intuitive
	
##Examples:
+ C#'s LINQ methods
+ LINQ in general
+ Chaining in Javascript
+ jQuery
+ cin/cout in C++