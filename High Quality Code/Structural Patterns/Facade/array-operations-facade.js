(function () {
	function removeAt(index) {
		this.splice(index, 1);
	}

	function removeRange(from, to) {
		to = to || this.length - 1;
		this.splice(from, to - from + 1);
	}

	function insertElements(index, elements) {
		for (var i = elements.length - 1; i >= 0; i--) {
			this.splice(index, 0, elements[i]);

		}
	}

	function insert(afterIndex, elementsToInsert) {
		if (Array.isArray(elementsToInsert)) {
			insertElements.call(this, afterIndex, elementsToInsert);
		} else {
			this.splice(afterIndex, 0, elementsToInsert);
		}

	}

	function shallowClone(from, to) {
		from = from || 0;
		to = to || this.length;

		return [].slice.call(this, from, to);
	}

	function deepClone(from, to) {
		from = from || 0;
		to = to || this.length;

		var stringified = JSON.stringify(this.slice(from, to));
		var copied = JSON.parse(stringified);

		return copied;
	}

	var functions = {
		removeAt,
		removeRange,
		insert,
		shallowClone,
		deepClone
	};

	var functionNames = Object.keys(functions);

	functionNames.forEach(function (name) {
		Array.prototype[name] = functions[name];
	});

} ());

function demo() {

	var arr1 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

	arr1.removeAt(arr1.length - 1);
	arr1.removeAt(0);
	arr1.removeAt(arr1.length / 2);
		
	// without first, last and middle
	console.log('array with removed first, last and middle element' ,arr1);

	arr1.insert(1, [9, 10, 11]);

	console.log('array with inserted 9, 10, 11: ',arr1);

	// deep clone
	
	var persons = [
		{
			name: 'penka'
		},
		{
			name: 'domcho'
		},
		{
			name: 'bay ivan'
		}
	];
		
	// clone the first two
	var clonedPersons = persons.deepClone(0, 2);

	console.log(JSON.stringify(clonedPersons));
	
	console.log('seeting the first person of the copied to something else.')
	
	clonedPersons[0] = 'nqma veche person ;/';
		
	// should print unchanged persons array
	console.log('original array should be unchanged: ', persons);
	console.log('the deep copy should be different: ', clonedPersons);
	
	// shallow clone
	
	var shalloweClonedPersons = persons.shallowClone();
	
	shalloweClonedPersons[0] = 'gosho';
	
	// should be different now
	console.log('should be different: ', persons);
};

demo();