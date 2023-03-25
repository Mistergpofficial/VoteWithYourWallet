$(document).ready(function () {
    $('#myForm').submit(function (event) {
        // Prevent form submission
        event.preventDefault();

        // Get form values
        var firstName = $('#firstName').val();
        var lastName = $('#lastName').val();
        var username = $('#username').val();
        var email = $('#email').val();
        var password = $('#password').val();
        var confirmPassword = $('#confirmPassword').val();

        // Define validation rules
        var nameRegex = /^[a-zA-Z ]+$/;
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        // Get form values
        var password = $('#password').val();
        var confirmPassword = $('#confirmPassword').val();

        // Check name field
        if (!nameRegex.test(firstName)) {
            alert('Please enter a valid first name');
            return false;
        }

        if (!nameRegex.test(lastName)) {
            alert('Please enter a valid last name');
            return false;
        }

        if (!nameRegex.test(username)) {
            alert('Please enter a valid username');
            return false;
        }

        // Check email field
        if (!emailRegex.test(email)) {
            alert('Please enter a valid email address');
            return false;
        }

        // Define validation rules
        var passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;

        // Check password field
        if (!passwordRegex.test(password)) {
            alert('Password must contain at least 8 characters, including at least one letter and one number.');
            return false;
        }

        // Check confirm password field
        if (password !== confirmPassword) {
            alert('Passwords do not match.');
            return false;
        }

        // Form is valid, submit it
        alert('User created successfully!');
        window.location.href = "login.html";
        return true;
    });
});

