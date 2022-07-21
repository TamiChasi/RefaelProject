
$(document).ready(function () {

    const uri = 'ViewDevices';

    $("#showAllBtn").click(function () {
        $.getJSON(uri)
            .done(function (data) {
                $("#result").empty();
                $.each(data, function (key, item) {
                    $("#result").append('<li>' + JSON.stringify(item) + '</li>');
                });
            });
    });

    $("#showSortedRangeBtn").click(function () {
        $.getJSON(uri)
            .done(function (data) {
                data.sort((a, b) => (a.range.meters > b.range.meters) ? 1 : -1);
                $("#result").empty();
                $.each(data, function (key, item) {
                    $("#result").append('<li>' + JSON.stringify(item) + '</li>');
                });
            });
    });

    $("#showMaxMinBtn").click(function () {
        var minField = $("#showMaxMin")[0].valueAsNumber;
        if (!minField) {
            alert("Empty Input. Fill it, and try again");
            return;
        }
        var tmpUri = uri + '/minField?minField=' + minField;
        $.getJSON(tmpUri)
            .done(function (data) {
                $("#result").empty();
                $.each(data, function (key, item) {
                    $("#result").append('<li>' + JSON.stringify(item) + '</li>');
                });
            });
    });

    $("#showByTypeBtn").click(function () {
        var type = $("#showByType")[0].value;
        if (!type) {
            alert("Empty Input. Fill it, and try again");
            return;
        }
        var tmpUri = uri + '/type?type=' + type;
        $.getJSON(tmpUri)
            .done(function (data) {
                $("#result").empty();
                $.each(data, function (key, item) {
                    $("#result").append('<li>' + JSON.stringify(item) + '</li>');
                });
            });
    });

    $("#deleteBtn").click(function () {
        var id = $("#devideIdDelete")[0].valueAsNumber;
        if (!id) {
            alert("Empty Input. Fill it, and try again");
            return;
        }
        $.ajax({
            url: uri + '?id=' + id,
            type: 'DELETE',
            success: function (result) {
                $("#showAllBtn").click();
            }
        });
    });

    $("#addDevice").click(function () {
        var TypeName = $("#type")[0].value;
        var meters = $("#mataers")[0].valueAsNumber;
        var aerialLine = $("#aerialLine")[0].valueAsNumber;
        var degrees = $("#degrees")[0].valueAsNumber;
        var engle = $("#angle")[0].valueAsNumber;

        if (!TypeName || !meters || !aerialLine || !degrees || !engle) {
            alert("Empty Input. Fill it, and try again");
            return;
        }

        var data = {
            Range: { AerialLine: aerialLine, Meters: meters },
            Type: TypeName,
            FieldOfView: { engle: engle, Degrees: degrees  }
        }

        $.ajax({
            url: uri,
            data: JSON.stringify(data),
            type: 'POST',
            contentType: "application/json",

            success: function (result) {
                $("#showAllBtn").click();
            }
        });
    });
})
