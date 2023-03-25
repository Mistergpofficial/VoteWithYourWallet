$(document).ready(function () {
    $('#createCauseForm').submit(function (event) {
        // Prevent form submission
        event.preventDefault();

        // Get form values
        var causeName = $('#causeName').val();
        var causeDescription = $('#causeDescription').val();



        // Define validation rules
        var nameRegex = /^[a-zA-Z ]+$/;


        // Check name field
        if (!nameRegex.test(causeName)) {
            alert('Please enter a valid cause name');
            return false;
        }

        if (!nameRegex.test(causeDescription)) {
            alert('Please enter a valid cause description');
            return false;
        }


        // Form is valid, submit it
        alert('Cause created successfully!');
        window.location.href = 'member.html';
        return true;
    });
});


