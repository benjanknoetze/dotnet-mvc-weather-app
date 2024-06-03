$(document).ready(function () {
    $('#weatherForm').on('submit', function (event) {
        event.preventDefault();
        const form = $(this);
        const data = {
            location: $('#locationInput').val(),
            region: $('#regionInput').val(),
            country: $('#countryInput').val(),
            isCelsius: $('#unitToggle').val()
        };

        $('#weatherDetailsCard').addClass('hidden');
        $('#spinner').removeClass('hidden');

        $.ajax({
            type: 'POST',
            url: form.attr('action'),
            data: data,
            success: function (result) {
                $('#weatherDetails').html(result);
                $('#weatherDetailsCard').removeClass('hidden');
            },
            error: function () {
                alert('Error retrieving weather data.');
            },
            complete: function () {
                $('#spinner').addClass('hidden');
            }
        });
    });

    $('#refreshButton').on('click', function () {
        $('#weatherForm').submit();
    });

    $('#locationInput').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/api/Search',
                data: { query: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: `${item.name}, ${item.region}, ${item.country}`,
                            value: item.name,
                            region: item.region,
                            country: item.country
                        };
                    }));
                },
                error: function () {
                    console.error("Error fetching autocomplete suggestions");
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            $('#locationInput').val(`${ui.item.value}, ${ui.item.region}, ${ui.item.country}`);
            $('#regionInput').val(ui.item.region);
            $('#countryInput').val(ui.item.country);
            return false;
        }
    });

    $('#unitToggle').on('change', function () {
        const isChecked = $(this).is(':checked');
        $('#unitToggle').val(isChecked ? 'true' : 'false');
        $('#unitLabel').text(isChecked ? 'Celsius' : 'Fahrenheit');

        if (isChecked) {
            $('#tempC').removeClass('hidden');
            $('#tempF').addClass('hidden');
        } else {
            $('#tempC').addClass('hidden');
            $('#tempF').removeClass('hidden');
        }
    });
});