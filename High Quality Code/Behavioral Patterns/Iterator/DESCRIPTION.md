#Iterator pattern

+ Intuitive definition: provides an abstract way to access data contained in a data structure
+ Scenario of use: when we want to facilitate and/or encapsulate the traversal details
+ Benefits:
	- simplicity of usage - the user of the iterator needs not concern himself with the concrete implementation
	- supports different types of traversal while maintaining the same interface
	- can be implemented separately from the data structure
	- keep the data structure unaware of how it's being iterated

+ Diagram:

![Iterator pattern uml diagram](./IteratorDiagram.svg)