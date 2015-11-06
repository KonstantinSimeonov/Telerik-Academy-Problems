var spin = (function () {
	function spin(n, current, report) {
		
		var i;
		
		if(current > n) {
			console.log(report);
			return;
		}
		
		for (i = 1; i <= n; i++) {
			spin(n, current + 1, report + ' ' + i);
		}

	}
	
	return function (n) {
		spin(n, 1, '');	
	};
} ());

// spin(2);
// spin(3);