#Strategy pattern

+ Intuitive definition: encapsulation of a family of algorithms in classes that share common interface
+ Scenario of use: when we want to be able to select a behavior of an algorithm during execution time
+ Benefits:
	- separates usage from implementation
	- helps to maintain the open/close principle
	- abstracts usage
	- lets algorithm evolve on their own
	- facilitates the addition of new algorithms(just add a new class which implements the common interface)
+ Cons:
	- client has to choose an implementation
	- increased number of objects
	
+ Diagram:

![Strategy pattern uml diagram](./StrategyPattern.png)