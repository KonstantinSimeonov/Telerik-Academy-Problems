function solve(params) {
	var sizes = params[0].split(' ');
	
	var rows = parseInt(sizes[0]), cols = parseInt(sizes[1]);
	
	var field = params.slice(1, params.length);
	
	var r = rows - 1, c = cols - 1;
	
	var dir = {
		1: [-2, 1],
		2: [-1, 2],
		3: [1, 2],
		4: [2, 1],
		5: [2, -1],
		6: [1, -2],
		7: [-1, -2],
		8: [-2, -1]
	};
	
	var sum = 0, cells = 0;
	var store;
	var used = [];
	while (r >= 0 && r < rows && c >= 0 && c < cols) {
		sum+= (1 << r) - c;
		used[r * cols + c] = false;
		store = r;
		r+=dir[field[r][c]][0];
		c+=dir[field[store][c]][1];
		cells+=1;
		if(used[r * cols + c] === false) {
			console.log("Sadly the horse is doomed in " + cells + " jumps");
			return;
		}
		
	}
	
	console.log("Go go Horsy! Collected " + sum + " weeds");
}

var args = [
  '3 5',
  '54361',
  '43326',
  '52188',
];

var args1 = [
  '3 5',
  '54561',
  '43328',
  '52388',
]; 


solve(args);