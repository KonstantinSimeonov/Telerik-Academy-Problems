/* 
Create a function that:
*   **Takes** an array of animals
    *   Each animal has propeties `name`, `species` and `legsCount`
*   **groups** the animals by `species`
    *   the groups are sorted by `species` descending
*   **sorts** them ascending by `legsCount`
	*	if two animals have the same number of legs sort them by name
*   **prints** them to the console in the format:

```
    ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
    GROUP_1_NAME:
    ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
    NAME has LEGS_COUNT legs //for the first animal in group 1
    NAME has LEGS_COUNT legs //for the second animal in group 1
    ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
    GROUP_2_NAME:
    ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
    NAME has LEGS_COUNT legs //for the first animal in the group 2
    NAME has LEGS_COUNT legs //for the second animal in the group 2
    NAME has LEGS_COUNT legs //for the third animal in the group 2
    NAME has LEGS_COUNT legs //for the fourth animal in the group 2
```
*   **Use underscore.js for all operations**
*/
function solve() {
    return function (animals) {
        function printGroup(group) {
            var lines = new Array(group[0].species.length + 2).join('-');
            console.log(lines);
            console.log(group[0].species + ':');
            console.log(lines);
            _.each(group, function (animal) {
                console.log(animal.name + ' has ' + animal.legsCount + ' legs');
            })
        }

        var _ = require('underscore');

        _.chain(animals)
            .sortBy('name')
            .sortBy('legsCount')
            .groupBy('species')
            .sortBy(function (group) {
                return group[0].species;
            })
            .reverse()
            .each(printGroup);
    };
}


module.exports = solve;