
/* 
Create a function that:
*   Takes an array of students
    *   Each student has a `firstName` and `lastName` properties
*   **Finds** all students whose `firstName` is before their `lastName` alphabetically
*   Then **sorts** them in descending order by fullname
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   Then **prints** the fullname of founded students to the console
*   **Use underscore.js for all operations**
*/

function solve() {
  return function (students) {
	  
    function printFullName(student) {
      console.log(student.fullName);
    }

    function fullName(student) {
      student.fullName = student.firstName + ' ' + student.lastName;
    }

    function firstNameIsBeforeLast(student) {
      return student.firstName < student.lastName;
    }

    var _ = require('underscore');

    _.chain(students)
	.filter(firstNameIsBeforeLast)
	.each(fullName)
	.sortBy('fullName').reverse()
	.each(printFullName);
  };
}

module.exports = solve;