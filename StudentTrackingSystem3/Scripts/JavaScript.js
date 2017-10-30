$(document).ready(function () {

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


    //Form 1 - Qualifying Exam passed fields show/display based on value
    $('#Qualifier2ResultId').closest('.col-md-3').css('display', 'none');
    $('#DateOfQualification').closest('.col-md-4').css('display', 'none');

    $("#QualifierResultId").change(function () {
        $('#Qualifier2ResultId').closest('.col-md-3').css('display', 'none');
        $('#DateOfQualification').closest('.col-md-4').css('display', 'none');

        $('#QualifierResultId option:selected').each(function () {
            if ($(this).val() == 46) {
                $('#DateOfQualification').closest('.col-md-4').css('display', 'block');
            } else if ($(this).val() == 47) {
                $('#Qualifier2ResultId').closest('.col-md-3').css('display', 'block');
                $('#DateOfQualification').closest('.col-md-4').css('display', 'none');
            } else {
                $('#Qualifier2ResultId').closest('.col-md-3').css('display', 'none');
                $('#DateOfQualification').closest('.col-md-4').css('display', 'none');
            }
        });

    });

    $("#Qualifier2ResultId").change(function () {
        if ($(this).val() == 46) {
            $('#DateOfQualification').closest('.col-md-4').css('display', 'block');
        } else {
            $('#DateOfQualification').closest('.col-md-4').css('display', 'none');
        }
    });


    //Display Thesis or Dissertation based on selection
    $('.thesis').closest('span').css('display', 'none');
    $('.dissertation').closest('span').css('display', 'none');

    $("#CommitteeTypeID").change(function () {
        $('.thesis').closest('span').css('display', 'none');
        $('.dissertation').closest('span').css('display', 'none');
        $('#CommitteeTypeID option:selected').each(function () {
            if ($(this).val() == 53) {
                $('.thesis').closest('span').css('display', 'block');
                $('.committeetype').closest('span').css('display', 'none');
            } else if ($(this).val() == 54){
                $('.dissertation').closest('span').css('display', 'block');
                $('.committeetype').closest('span').css('display', 'none');
            } else {
                $('.thesis').closest('span').css('display', 'none');
                $('.dissertation').closest('span').css('display', 'none');
                $('.committeetype').closest('span').css('display', 'block');
            }

        });
    });

    //Display Comprehensive Exam or Proposal Presentation based on selection
    $('.comprehensiveexam').closest('span').css('display', 'none');
    $('.proposalpresentation').closest('span').css('display', 'none');

    $("#Form2TypeId").change(function () {
        $('.comprehensiveexam').closest('span').css('display', 'none');
        $('.proposalpresentation').closest('span').css('display', 'none');
        $('#Form2TypeId option:selected').each(function () {
            if ($(this).val() == 48) {
                $('.comprehensiveexam').closest('span').css('display', 'block');
                $('.form2type').closest('span').css('display', 'none');
            } else if ($(this).val() == 49) {
                $('.proposalpresentation').closest('span').css('display', 'block');
                $('.form2type').closest('span').css('display', 'none');
            } else {
                $('.comprehensiveexam').closest('span').css('display', 'none');
                $('.proposalpresentation').closest('span').css('display', 'none');
                $('.form2type').closest('span').css('display', 'block');
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

