(function () {

    var responseContainer = $('#zemi-toq-json'),
        requestTypes =
        {
            put: true,
            del: true,
            post: true,
            get: true
        },
        urlBase = 'http://localhost:2583/api/',
        checkedRadioQueryString = '[name="pesho"]:checked',
        requestBodyContainerId = '#imam-edno-malko-json';

    $.ready = function (event) {

        $(requestBodyContainerId).html(localStorage.getItem('request-json') || '');

        var checkedButtonId = localStorage.getItem('checked-id');

        if (checkedButtonId) {
            $('#' + checkedButtonId).prop('checked', true);
        }
            
    };

    function jsonRequest(event) {

        var action = event.target.id;

        if (requestTypes[action]) {

            var controllerName = $(checkedRadioQueryString).val(),
                requestBody = $(requestBodyContainerId).val();

            localStorage.setItem('request-json', requestBody);
            localStorage.setItem('checked-id', $(checkedRadioQueryString).prop('id'));

            jsonRequester[action](urlBase + controllerName, { data: requestBody })
                                    .then(function (result) {
                                        $('#zemi-toq-json').html(JSON.stringify(result));
                                    },
                                    function (error) {
                                        $('#zemi-toq-json').html(JSON.stringify(error));
                                    });
        }

    }

    $('#request-menu').on('click', jsonRequest);

}());