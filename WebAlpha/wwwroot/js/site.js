// wwwroot/js/site.js
$(document).ready(function () {
    // Aktivera aktuell navigeringslänk baserat på nuvarande sida
    var currentUrl = window.location.pathname;

    $('.sidebar-menu .nav-link').each(function () {
        var linkUrl = $(this).attr('href');

        if (currentUrl.startsWith(linkUrl) && linkUrl !== '/') {
            $(this).addClass('active');
        } else if (currentUrl === '/' && linkUrl === '/') {
            $(this).addClass('active');
        }
    });

    // Tooltip initialisering
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    });

    // Datum formattering
    $('.date-format').each(function () {
        var date = new Date($(this).text());
        if (!isNaN(date.getTime())) {
            $(this).text(date.toLocaleDateString());
        }
    });

    // Project status formatting
    $('.project-status').each(function () {
        var status = $(this).data('status');
        var badge = $('<span>').addClass('status-badge');

        if (status === 'Completed') {
            badge.addClass('status-completed').text('Completed');
        } else {
            badge.addClass('status-in-progress').text('In Progress');
        }

        $(this).append(badge);
    });

    // Form validation initialisering
    if ($.validator) {
        $.validator.setDefaults({
            errorElement: "div",
            errorClass: "field-validation-error",
            highlight: function (element) {
                $(element).addClass("input-validation-error");
            },
            unhighlight: function (element) {
                $(element).removeClass("input-validation-error");
            }
        });
    }
});