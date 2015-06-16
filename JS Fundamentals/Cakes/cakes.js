

var args0 =[
 "3 4",
 "1 3",
 "lrrd",
 "dlll",
 "rddd"];
 
 var args1 =[
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"];
 
 var args2 =[
 "5 8",
 "0 0",
 "rlrrrrrd",
 "rludulrd",
 "lurlddud",
 "urrrldud",
 "ulllllll"];



function solve(params) {
	var sizes = params[0];
	sizes = sizes.split(' ');
	var rows = parseInt(sizes[0]);
	var cols = parseInt(sizes[1]);
	
	sizes = params[1].split(' ');
	
	var r = parseInt(sizes[0]), c = parseInt(sizes[1]);
	var len = params.length;
	var cells = 1;
	var sum = 0;
	var dir = [];
	dir['l'] = [0, -1];
	dir['r'] = [0, 1];
	dir['u'] = [-1, 0];
	dir['d'] = [1, 0];
	var visited = [];
	visited[r + ' ' + c] = true;
	
	var field = params.slice(2, params.length);
	var rstore;
	while (r < rows && r >= 0 && c < cols && c >=0) {
		sum+= r * cols + c + 1;
		rstore = r;
		r+=dir[field[r][c]][0];
		c+=dir[field[rstore][c]][1];
		
		if(visited[r + ' ' + c] === true) {
			console.log('lost ' + cells);
			return;
		}
		visited[r + ' ' + c] = true;
		cells+=1;
	}
	
	console.log('out ' + sum);
}

solve(args2);

