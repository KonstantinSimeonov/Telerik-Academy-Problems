#Memento Pattern

+ Intuitive definition: a way to store/restore the internal state of an object
+ Scenario of use: when we want to enable rollback/undo or saving a state for later use(example: save in a game)
+ Benefits:
	- Takes on the responsibility of implementing undo/rollback/save(helps to keep the single responsibility rule)
	- Provides an abstraction of the saving/restoring process
	
+ Diagram: 

![Memento pattern uml diagram](./MementoDiagram.gif)