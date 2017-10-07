$(document).ready(function () {

    //Stops the program and posts and error message if at least one race hasn been entered.  
    //Without this error message, the program crashes since no races have been entered.
    $('.createOrEditPost').on('click', function (e) {
        var checkedBoxes = $(':checkbox:checked');
        var checked = $(':checkbox:checked').length;
        if (checked < 1) {
            alert('You must select at least one race.  If no races known, please select "Other" and type "Unknown" in the [Race Other] box.');
            e.preventDefault();
        } else {
            alert('Your entry has been saved.');
        }
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