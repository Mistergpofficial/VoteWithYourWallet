$(document).ready(function () {
    $(".delete-btn").click(function () {
        if (confirm("Are you sure you want to delete this cause?")) {
            $(this).closest("tr").remove();
        }
    });
});


