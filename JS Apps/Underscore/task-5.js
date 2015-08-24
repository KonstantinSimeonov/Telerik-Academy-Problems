/* 
Create a function that:
*   **Takes** an array of animals
    *   Each animal has propeties `name`, `species` and `legsCount`
*   **finds** and **prints** the total number of legs to the console in the format:
    *   "Total number of legs: TOTAL_NUMBER_OF_LEGS"
*   **Use underscore.js for all operations**
*/

function solve() {
  return function (animals) {

    var _ = require('underscore');

    var totalNumberOfLegs = _.chain(animals).pluck('legsCount').foldl(function (memo, legs) {
      return memo + legs;
    }).value();

    console.log('Total number of legs: ' + totalNumberOfLegs);
  };
}

module.exports = solve;