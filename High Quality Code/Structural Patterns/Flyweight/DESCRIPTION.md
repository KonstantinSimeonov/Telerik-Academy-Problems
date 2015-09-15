#Flyweight Pattern

+ Intuitive definition: using of shared resource to reduce memory cost and the cost of object instantiation
+ Scenario of use: when memory is limited/when object instantiation is expensive/when a lot of objects are created that share a common trait
+ Benefits:
	- performance gains
	- reduces memory usage
+ Cons:
	- sometimes it's difficult to implement the flyweight object type in such way, that it would be unaware of the way it's used

+ Diagram:

![Flyweight pattern uml diagram](./FlyweightDiagram.gif)

+ Real world examples: 
	- word processors use flyweight for character. The intrinsic state of the character is the symbol itself, while the extrinsic state is composed of font, location, color, etc
	- flyweight can be used for emotes, because their animation/picture/text stays pretty much the same for every use, while the location changes