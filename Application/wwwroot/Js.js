
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

    


    function _displayItems(data) {
        const tBody = document.getElementById('todos');
        tBody.innerHTML = '';

        _displayCount(data.length);

        const button = document.createElement('button');

        data.forEach(item => {
            let isCompleteCheckbox = document.createElement('input');
            isCompleteCheckbox.type = 'checkbox';
            isCompleteCheckbox.disabled = true;
            isCompleteCheckbox.checked = item.isComplete;

            let editButton = button.cloneNode(false);
            editButton.innerText = 'Edit';
            editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

            let deleteButton = button.cloneNode(false);
            deleteButton.innerText = 'Delete';
            deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

            let tr = tBody.insertRow();

            let td1 = tr.insertCell(0);
            td1.appendChild(isCompleteCheckbox);

            let td2 = tr.insertCell(1);
            let textNode = document.createTextNode(item.name);
            td2.appendChild(textNode);

            let td3 = tr.insertCell(2);
            td3.appendChild(editButton);

            let td4 = tr.insertCell(3);
            td4.appendChild(deleteButton);
        });

        todos = data;
    }
})
