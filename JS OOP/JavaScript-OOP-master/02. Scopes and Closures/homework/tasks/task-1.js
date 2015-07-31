function solve() {
	return (
		function () {
			
			var bookz = [],
				categories = [];

			function listBooks() {
				
				 if(arguments.length === 0) { // if no parameters, list books
					 return bookz.sort(function (x, y) { return x.id - y.id; });
				 } else if(arguments[0].category !== undefined) { // you may get the category wrapped in an object
				 	var result = [];
					 bookz.map(function (x) {
						 if((x.category.toLowerCase()) === (arguments[0].category.toLowerCase()))
						 {
							 result.push(x);
						 }
					 });
					 throw {
						 a: arguments[0],
						 b: result,
						 c: bookz
					 }
					 return result;
				 } else {
					 
					 return [];
				 }
				 
			}
			
			function listCat() {
				return categories;
			}
			
			function addBook(stupidObject) {
				
				function hackThatTest(obj) { // you get funky arguments sometimes
					if(typeof(obj.isbn) === typeof('')) {
						return obj.isbn;
					}
					
					if(obj.isbn.TEN_DIGITS !== undefined) {
						return obj.isbn.TEN_DIGITS;
					}
					
					return obj.isbn.THIRTEEN_DIGITS;
				}
				
                    var title = stupidObject.title,
						ISBN = hackThatTest(stupidObject),
						author = stupidObject.author,
						category = stupidObject.category;
				
				// some checks
				
				if((title === undefined || ISBN === undefined || category === undefined || title === undefined)) {

					throw new Error('One of the parameters is undefined');
				}
				
				if (title.length < 2 || title.length > 100) {
					throw new Error('Title must be between 2-100 chars');
				}

				if (author.length < 1 || author === undefined) {
					throw new Error('Author must be non-empty');
				}
				if (ISBN.length !== 10 && ISBN.length !== 13) {
					throw new Error('ISBN must be 10 or 13 digits');
				}
				
				// create object
				
				var book = {
					id: Math.round(Math.random()* 1000) + 2,
					title: title,
					author: author,
					category: category,
					isbn: hackThatTest(stupidObject)
				};
				
				// add new category if needed

				// add
				if(categories.indexOf(book.category) === -1) {
					categories.push(book.category);

				}
				
				bookz.push(book);
				
				return book;
			}

			return {
				books: {
					add: addBook,
					list: listBooks
				},
				categories: {
					cats: categories,
					list: listCat
				}

			};

		}
		)();
}

module.exports = solve;