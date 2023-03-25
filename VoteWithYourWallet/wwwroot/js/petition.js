// Get the current page pathname
const pathname = window.location.pathname;

// Get the last part of the pathname (which should be the filename)
const filename = pathname.split('/').pop();

// Check if the filename ends with ".html"
if (filename.endsWith('.html')) {
    // If it does, display it in the console
    console.log(filename);
} else {
    // If it doesn't, display an error message
    console.error('Current page is not an HTML file');
}

$(document).ready(function () {
    $('#myForm').submit(function (event) {
        // Prevent form submission
        event.preventDefault();

        // Get form values
        var full_name = $('#full_name').val();
        var email = $('#email').val();
        var reason = $('#reason').val();

        // Define validation rules
        var nameRegex = /^[a-zA-Z ]+$/;
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;


        // Check name field
        if (!nameRegex.test(full_name)) {
            alert('Please enter a valid full name');
            return false;
        }

        // Check email field
        if (!emailRegex.test(email)) {
            alert('Please enter a valid email address');
            return false;
        }

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