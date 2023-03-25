$(document).ready(function () {
    $('#myForm').submit(function (event) {
        // Prevent form submission
        event.preventDefault();

        // Get form values
        var email = $('#email').val();
        var password = $('#password').val();

        // Define validation rules
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        // Get form values
        var password = $('#password').val();

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


        // Form is valid, submit it
        alert('Login is successful!');
        window.location.href = "member.html";
        return true;
    });
});

