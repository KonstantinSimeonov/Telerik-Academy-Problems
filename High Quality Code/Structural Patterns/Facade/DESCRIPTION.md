#Facade Pattern

+ Intuitive definition: a piece of code that provides a simpler/better way to use existing code that is badly/poorly designed
+ Scenario of use: when a simpler, more intuitive interface to a body of code is needed
+ Benefits:
	- simplifies usage of existing code by:
		- making the code more intuitive
		- reducing code volume
		- improving readability
		- improving cohesion by dividing responsibilities
		- improving coupling by inverting dependencies
		- providing customizible layers of abstraction
	- allows a way to improve the usage of 3d party code 
+ Cons:
	- usually hides poorly designed code(that code might need refactoring, instead of a facade)

+ Diagram:

![Facade pattern uml diagram](./FacadePattern.gif)