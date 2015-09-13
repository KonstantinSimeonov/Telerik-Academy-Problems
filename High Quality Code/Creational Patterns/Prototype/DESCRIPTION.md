#Prototype pattern

+ Intuitive definition: a type of object which can clone itself
+ Scenario of use: usually used when conventional creation is slow or expensive, but copying/cloning is less expensive
+ Benefits:
	- performance gain
	- documents the intended behaviour of the object
+ Cons(in C#.NET):
	- ICloneable is bad(interface says nothing about whether the copy is deep or shallow, etc)

+ [Concrete Implementation](./WeatherReport.cs)

##Example:

Consider a weather report in a news feed page - instead of requesting weather report from the interner for every separate user, you create the report once and clone it for every user