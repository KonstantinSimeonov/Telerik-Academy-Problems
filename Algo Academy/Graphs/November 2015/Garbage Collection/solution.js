function solve(input) {
	var districts = {},
		helpers = (function () {

			function fillWithZero(array, count) {

				for (var k = 0; k < count; k += 1) {
					array[k] = 0;
				}
			}

			function parseEdge(edge) {
				return edge.split(' ').map(function (node) {
					return (+node) - 1;
				});
			}
			
			return {
				fillWithZero: fillWithZero,
				parseEdge: parseEdge	
			};

		} ());

	function getDistrictsInformation(input) {

		var inputLength = input.length,
			edgeCount,
			districtInfo,
			edge,
			streets,
			i,
			j;

		for (i = 1; i < inputLength; i += edgeCount + 1) {

			districtInfo = input[i].split(' ');
			edgeCount = +districtInfo[2];

			streets = [];

			helpers.fillWithZero(streets, +districtInfo[1]);

			for (j = i + 1; j < i + 1 + edgeCount; j += 1) {

				edge = helpers.parseEdge(input[j]);

				streets[+edge[0]] += 1;
				streets[+edge[1]] += 1;
			}
			
			districts[districtInfo[0]] = 0;
			
			streets.forEach(function(s) {
				districts[districtInfo[0]] += s % 2;
			});
		}

		return districts;
	}

	return function (input) {
		
		var garbageCollectors = {
			0: 'Wolf',
			2: 'Titan'
		},
			districtsInfo = getDistrictsInformation(input);
		
		return Object.keys(districtsInfo).forEach(function (d) {
			
			console.log(d + ' ' + (garbageCollectors[districtsInfo[d]] || 'Dirty'));
		});
	}(input);
}

// exports.solve = solve;