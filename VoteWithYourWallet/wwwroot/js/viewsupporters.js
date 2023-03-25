$(document).ready(function () {
    $.getJSON("users.json", function (data) {
        $.each(data, function (key, value) {
            $("#userList").append("<li>" + value.name + "</li>");
        });
    });
});
