// Get the current page pathname
const pathname = window.location.pathname;



$(document).ready(function () {
    $('#myForm').submit(function (event) {
        // Prevent form submission
        event.preventDefault();

        // Get form values
        var reason = $('#Reason').val();

        // Define validation rules
        var nameRegex = /^[a-zA-Z ]+$/;

        // Check reason field
        if (!nameRegex.test(reason)) {
            alert('Please enter a valid reason');
            return false;
        }


        // Form is valid, submit it
        alert('Petition has been signed successfully!');
        window.location.href = filename;
        return true;
    });
});