var jsonRequester = function () {

    // da jivee doncho
	function send(method, url, options) {
		options = options || {};

		var headers = options.headers || {},
			data = options.data || undefined;

		var promise = new Promise(function (resolve, reject) {
			$.ajax({
				url: url,
				method: method,
				contentType: 'application/json',
				headers: headers,
				data: data,
				success: function (response) {
					resolve(response);
				},
				error: function (error) {
					reject(error);
				}
			});

		});

		return promise;
	}

	function post(url, options) {
	    console.log(url, options);
		return send('POST', url, options);
	}

	function put(url, options) {
		return send('PUT', url, options);
	}

	function get(url, options) {
		return send('GET', url, options);
	}

	function del(url, options) {
		return send('DELETE', url, options);
	}

	return {
		post: post,
		put: put,
		del: del,
		get: get
	};

} ();