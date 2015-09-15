#Composite Pattern

+ Intuitive definition: tree-like object structure that lets the client treat objects of different types in the same way
+ Scenario of use: when a uniformal way to treat different objects is needed(usually when developers find they're using different objects in the same ways) or a flexible hierarchy needs to be defined
+ Benefits:
	- facilitates addition of new components
	- facilitates the use of the existing components
	- makes the client part of the code simpler, because the client treats the different components in the same way
+ Cons:
	- type restrictions become harder to implement
	- breaks the single responsability principle(a component has both the responsabilities of a component and a leaf/node)
	
+ Diagram:

![Composite pattern uml diagram](./CompositeDiagram.gif)

+ Real world examples:
	- the DOM tree is a composite - lets you treat different types of objects as DOM elements, while also presenting a hierarchy of objects
	- Windows XAML elements