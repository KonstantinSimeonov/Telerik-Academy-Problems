#Simple Factory and Abstract Factory patterns

##1.Simple Factory pattern
+ Scenario of use: the factory pattern is used with a type hierarchy to facilitate and organize creation of concrete types that implement the same interface/inherit the same class
+ Benefits:
  - reduces coupling to the 'new' operator
  - reduces coupling to concrete types, instead works with interfaces/base classes
  - improves other classes' cohesion by taking the responsibility to create the correct type of object
  - encapsulates object creation logic(also handles internal dependancies)
  - improves modifiability of the creation of objects
  - improves consistency(when you need an object of a type, you use the factory)
  - facilitates the addition of new types
  

##2.Abstract Factory pattern
+ Scenario of use: 