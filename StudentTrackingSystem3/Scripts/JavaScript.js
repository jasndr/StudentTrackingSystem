﻿$(document).ready(function () {

    //Stops the program and posts and error message if at least one race hasn been entered.  
    //Without this error message, the program crashes since no races have been entered.
    $('.createOrEditPost').mouseup(function (e) {
        var checkedBoxes = $(':checkbox:checked');
        var checked = $(':checkbox:checked').length;
        if (checked < 1) {
            alert('You must select at least one race.  If no races known, please select "Other" and type "Unknown" in the [Race Other] box.');
            e.preventDefault();
        } else {
            var form = $('.createOrEditPost').closest('form');
            if (!form) {
                alert("You have not submitted a valid form.");
            } else if (!form.valid()) {
                alert("There are erors in submission. Please view below for details.");
            } else {
                setTimeout(function () {
                    alert('Your entry has been saved.');
                }, 100);
            }
        }
    });

    //Stops from posting if there are errors in submission; otherwise, it will be saved into the database.
    $('.createOrEditPost2').mouseup(function (e) {
        var form = $('.createOrEditPost2').closest('form');
        if (!form) {
            alert("You have not submitted a valid form.");
        }
        else if (!form.valid()) {
            alert("There are erors in submission. Please view below for details.");
        } else {
            setTimeout(function () {
                alert('Your entry has been saved.');
            }, 100);
        }
    });

    //Status box will show depending on which category has been selected

    $('#PublicationStatsID').closest('.form-group').css('display', 'none');
    $('#AbstractStatsID').closest('.form-group').css('display', 'none');
    $('#ProposalStatsID').closest('.form-group').css('display', 'none');
    $('#TeachingStatsID').closest('.form-group').css('display', 'none');

    $("#CategoryID option:selected").each(function () {
        if ($(this).val() == 42) {
            $('#PublicationStatsID').closest('.form-group').css('display', 'block');
        } else if ($(this).val() == 43) {
            $('#AbstractStatsID').closest('.form-group').css('display', 'block');
        } else if ($(this).val() == 44) {
            $('#ProposalStatsID').closest('.form-group').css('display', 'block');
        } else if ($(this).val() == 45) {
            $('#TeachingStatsID').closest('.form-group').css('display', 'block');
        }

    });

    $("#CategoryID").change(function () {
        // hide all optional elements
        $('#PublicationStatsID').closest('.form-group').css('display', 'none');
        $('#AbstractStatsID').closest('.form-group').css('display', 'none');
        $('#ProposalStatsID').closest('.form-group').css('display', 'none');
        $('#TeachingStatsID').closest('.form-group').css('display', 'none');

        $("#CategoryID option:selected").each(function () {
            if ($(this).val() == 42) {
                $('#PublicationStatsID').closest('.form-group').css('display', 'block');
            } else if ($(this).val() == 43) {
                $('#AbstractStatsID').closest('.form-group').css('display', 'block');
            } else if ($(this).val() == 44) {
                $('#ProposalStatsID').closest('.form-group').css('display', 'block');
            } else if ($(this).val() == 45) {
                $('#TeachingStatsID').closest('.form-group').css('display', 'block');
            }

        });
    });


    //Hide other "Other Race" checkbox is "other" is unchecked
    var checkedOther = $(":checkbox[value=13]");
    var raceOtherField = $(".raceOther");
    if (!checkedOther.is(':checked')) {
        raceOtherField.hide();
    }
    //raceOtherField.hide();
    checkedOther.on('click', function () {
        if ($(this).is(':checked')) {
            raceOtherField.show();
        } else {
            raceOtherField.hide();
        }

    });


});

//Automatically put parentheses and dash for phone number fields
$(window).load(function () {
    var phones = [{ "mask": "(###) ###-####" }, { "mask": "(###) ###-##############" }];
    $('.phoneNum').inputmask({
        mask: phones,
        greedy: false,
        definitions: { '#': { validator: "[0-9]", cardinality: 1 } }
    });
});

//Adds tabs functionality
//$("#TabSet1").tabs();

