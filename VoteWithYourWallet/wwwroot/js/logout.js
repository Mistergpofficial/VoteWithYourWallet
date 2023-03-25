$(document).ready(function () {
    $('#logout').on('click', function (e) {
        if (confirm("Are you sure you want to logout?"))
            window.location.href = "index.html";

        return false;
    });
});
