// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $.ajaxSetup({ cache: false });

    $(".viewDialog").on("click", function (e) {
        e.preventDefault();
        let mode = ($(this).attr("data_dialog_title"));

        var buttons = {};

        //Add save button only for create/edit dialogs
        if (mode === "Create" || mode == "Edit") {
            buttons['Save'] = function () {
                let form = $('#contactForm')[0];
                let formData = new FormData(form);
                let url = "Contact/" + mode;
                $.ajax({
                    url: url,
                    type: "POST",
                    data: formData,
                    processData: false,
                    contentType: false,
                    cache: false,
                    success: function (result) {
                        $("#dialogContent").html(result);
                        window.location = "/Contact"
                    }
                });
            }
        }

        $("<div id='dialogContent'></div>")
            .addClass("dialog")
            .appendTo("body")
            .dialog({
                title: $(this).attr("data_dialog_title"),
                close: function () { window.location = "/Contact" },
                modal: true,
                open: function () {
                    //IE need to set format for datepicker
                    $("#datepicker").datepicker({ dateFormat: 'dd.MM.yyyy' });
                },
                buttons: buttons
            })
            .load(this.href);
    });
});
