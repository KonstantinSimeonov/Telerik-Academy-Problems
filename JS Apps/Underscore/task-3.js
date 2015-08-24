/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName` and `age` properties
        *   Array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve() {
    return function (students) {
        function printFullName(student) {
            console.log(student.fullName);
        }

        function fullName(student) {
            return student.firstName + ' ' + student.lastName;
        }

        function fold(memo, mark) {
            return memo + mark;
        }

        function avgMark(student) {
            student.avgMark = (_.foldr(student.marks, fold) / student.marks.length);
        }

        var _ = require('underscore');

        var zubar = _.chain(students).each(avgMark).sortBy('avgMark').last().value();

        console.log(fullName(zubar) + ' has an average score of ' + zubar.avgMark);
    };
}

module.exports = solve;