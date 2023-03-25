$(document).ready(function () {
    // Share on Facebook
    $('.btn-facebook').click(function (e) {
        // Prevent form submission
        e.preventDefault();
        window.open('https://www.facebook.com/sharer.php?u=' + encodeURIComponent('@Url.Action("Details", "Cause", new { id = "__id__" })'.replace('__id__', causeId)), '_blank');
    });

    // Share on Twitter
    $('.btn-twitter').click(function (e) {
        // Prevent form submission
        e.preventDefault();
        window.open('https://twitter.com/share?url=' + encodeURIComponent('@Url.Action("Details", "Cause", new { id = "__id__" })'.replace('__id__', causeId)), '_blank');
    });

    // Share on LinkedIn
    $('.btn-linkedin').click(function (e) {
        // Prevent form submission
        e.preventDefault();
        window.open('https://www.linkedin.com/sharing/share-offsite/?url=' + encodeURIComponent('@Url.Action("Details", "Cause", new { id = "__id__" })'.replace('__id__', causeId)), '_blank');
    });

    // Share on Reddit
    $('.btn-reddit').click(function (e) {
        // Prevent form submission
        e.preventDefault();
        window.open('https://www.reddit.com/submit?url=' + encodeURIComponent('@Url.Action("Details", "Cause", new { id = "__id__" })'.replace('__id__', causeId)), '_blank');
    });
});
