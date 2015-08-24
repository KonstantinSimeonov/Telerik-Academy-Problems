/*
Create a function that:
*   Takes an array of students
    *   Each student has a `firstName`, `lastName` and `age` properties
*   **finds** the students whose age is between 18 and 24
*   **prints**  the fullname of found students, sorted lexicographically ascending
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
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

		function withValidAge(student) {
			return 18 <= student.age && student.age <= 24;
		}

		var _ = require('underscore');

		_.chain(students)
		.filter(withValidAge)
		.each(fullName)
		.sortBy('fullName')
		.each(printFullName);
	};
}

module.exports = solve;