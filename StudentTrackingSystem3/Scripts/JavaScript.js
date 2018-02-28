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
                alert("There are errors in submission. Please view below for details.");
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
            alert("There are errors in submission. Please view below for details.");
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
    $('.dateOfQualificationPassed1').hide();
    $('.dateOfQualificationFailed1').hide();
    $('#DateOfQualification').closest('.col-md-4').css('display', 'none');
    $('#Qualifier2ResultId').closest('.col-md-4').css('display', 'none');
    $('#DateOfQualification2').closest('.col-md-4').css('display', 'none');

    $('#QualifierResultId option:selected').each(function () {
        if ($(this).val() == 46) {
            $('#DateOfQualification').closest('.col-md-4').css('display', 'block');
            $('.dateOfQualificationPassed1').show();
            $('.dateOfQualificationFailed1').hide();
        } else if ($(this).val() == 47) {
            $('#DateOfQualification').closest('.col-md-4').css('display', 'block');
            $('.dateOfQualificationFailed1').show();
            $('.dateOfQualificationPassed1').hide();
            $('#Qualifier2ResultId').closest('.col-md-4').css('display', 'block');
            $('#DateOfQualification2').closest('.col-md-4').css('display', 'block');

            $('#Qualifier2ResultId option:selected').each(function () {
                if ($(this).val() == 46) {
                    $('.dateOfQualificationPassed2').show();
                    $('.dateOfQualificationFailed2').hide();
                } else if ($(this).val() == 47) {
                    $('.dateOfQualificationPassed2').hide();
                    $('.dateOfQualificationFailed2').show();
                } else {
                    $('.dateOfQualificationPassed2').hide();
                    $('.dateOfQualificationFailed2').hide();
                }

            });

        } else {
            $('.dateOfQualificationPassed1').hide();
            $('.dateOfQualificationFailed1').hide();
            $('#DateOfQualification').closest('.col-md-4').css('display', 'none');
            $('#Qualifier2ResultId').closest('.col-md-4').css('display', 'none');
            $('#DateOfQualification2').closest('.col-md-4').css('display', 'none');
        }
    });

    $("#QualifierResultId").change(function () {
        $('.dateOfQualificationPassed1').hide();
        $('.dateOfQualificationFailed1').hide();
        $('#DateOfQualification').closest('.col-md-4').css('display', 'none');
        $('#Qualifier2ResultId').closest('.col-md-4').css('display', 'none');
        $('#DateOfQualification2').closest('.col-md-4').css('display', 'none');
       

        $('#QualifierResultId option:selected').each(function () {
            if ($(this).val() == 46) {
                $('#DateOfQualification').closest('.col-md-4').css('display', 'block');
                $('.dateOfQualificationPassed1').show();
                $('.dateOfQualificationFailed1').hide();
            } else if ($(this).val() == 47) {
                $('#DateOfQualification').closest('.col-md-4').css('display', 'block');
                $('.dateOfQualificationFailed1').show();
                $('.dateOfQualificationPassed1').hide();
                $('#Qualifier2ResultId').closest('.col-md-4').css('display', 'block');
            } else {
                $('#DateOfQualification').closest('.col-md-4').css('display', 'none');
                $('#Qualifier2ResultId').closest('.col-md-4').css('display', 'none');
                $('#DateOfQualification2').closest('.col-md-4').css('display', 'none');
            }
        });

    });

    $("#Qualifier2ResultId").change(function () {
        $('.dateOfQualificationPassed2').hide();
        $('.dateOfQualificationFailed2').hide();

        if ($(this).val() == 46) {
            $('#DateOfQualification2').closest('.col-md-4').css('display', 'block');
            $('.dateOfQualificationPassed2').show();
            $('.dateOfQualificationFailed2').hide();
        } else if ($(this).val() == 47) {
            $('#DateOfQualification2').closest('.col-md-4').css('display', 'block');
            $('.dateOfQualificationPassed2').hide();
            $('.dateOfQualificationFailed2').show();
        } else {
            $('#DateOfQualification2').closest('.col-md-4').css('display', 'none');
            $('.dateOfQualificationPassed2').hide();
            $('.dateOfQualificationFailed2').hide();
        }
    });


    //Form 2 - Comprehensive Exam passed fields show/display based on value
    $('.dateOfCompExamPassed1').hide();
    $('.dateOfCompExamFailed1').hide();
    $('#DateOfCompExam').closest('.col-md-4').css('display', 'none');
    $('#CompExam2ResultId').closest('.col-md-4').css('display', 'none');
    $('#DateOfCompExam2').closest('.col-md-4').css('display', 'none');

    $('#CompExamResultId option:selected').each(function () {
        if ($(this).val() == 46) {
            $('#DateOfCompExam').closest('.col-md-4').css('display', 'block');
            $('.dateOfCompExamPassed1').show();
            $('.dateOfCompExamFailed1').hide();
        } else if ($(this).val() == 47) {
            $('#DateOfCompExam').closest('.col-md-4').css('display', 'block');
            $('.dateOfCompExamFailed1').show();
            $('.dateOfCompExamPassed1').hide();
            $('#CompExam2ResultId').closest('.col-md-4').css('display', 'block');
            $('#DateOfCompExam2').closest('.col-md-4').css('display', 'block');

            $('#CompExam2ResultId option:selected').each(function () {
                if ($(this).val() == 46) {
                    $('.dateOfCompExamPassed2').show();
                    $('.dateOfCompExamFailed2').hide();
                } else if ($(this).val() == 47) {
                    $('.dateOfCompExamPassed2').hide();
                    $('.dateOfCompExamFailed2').show();
                } else {
                    $('.dateOfCompExamPassed2').hide();
                    $('.dateOfCompExamFailed2').hide();
                }

            });

        } else {
            $('.dateOfCompExamPassed1').hide();
            $('.dateOfCompExamFailed1').hide();
            $('#DateOfCompExam').closest('.col-md-4').css('display', 'none');
            $('#CompExam2ResultId').closest('.col-md-4').css('display', 'none');
            $('#DateOfCompExam2').closest('.col-md-4').css('display', 'none');
        }
    });

    $("#CompExamResultId").change(function () {
        $('.dateOfCompExamPassed1').hide();
        $('.dateOfCompExamFailed1').hide();
        $('#DateOfCompExam').closest('.col-md-4').css('display', 'none');
        $('#CompExam2ResultId').closest('.col-md-4').css('display', 'none');
        $('#DateOfCompExam2').closest('.col-md-4').css('display', 'none');


        $('#CompExamResultId option:selected').each(function () {
            if ($(this).val() == 46) {
                $('#DateOfCompExam').closest('.col-md-4').css('display', 'block');
                $('.dateOfCompExamPassed1').show();
                $('.dateOfCompExamFailed1').hide();
            } else if ($(this).val() == 47) {
                $('#DateOfCompExam').closest('.col-md-4').css('display', 'block');
                $('.dateOfCompExamFailed1').show();
                $('.dateOfCompExamPassed1').hide();
                $('#CompExam2ResultId').closest('.col-md-4').css('display', 'block');
            } else {
                $('#DateOfCompExam').closest('.col-md-4').css('display', 'none');
                $('#CompExam2ResultId').closest('.col-md-4').css('display', 'none');
                $('#DateOfCompExam2').closest('.col-md-4').css('display', 'none');
            }
        });

    });

    $("#CompExam2ResultId").change(function () {
        $('.dateOfCompExamPassed2').hide();
        $('.dateOfCompExamFailed2').hide();

        if ($(this).val() == 46) {
            $('#DateOfCompExam2').closest('.col-md-4').css('display', 'block');
            $('.dateOfCompExamPassed2').show();
            $('.dateOfCompExamFailed2').hide();
        } else if ($(this).val() == 47) {
            $('#DateOfCompExam2').closest('.col-md-4').css('display', 'block');
            $('.dateOfCompExamPassed2').hide();
            $('.dateOfCompExamFailed2').show();
        } else {
            $('#DateOfCompExam2').closest('.col-md-4').css('display', 'none');
            $('.dateOfCompExamPassed2').hide();
            $('.dateOfCompExamFailed2').hide();
        }
    });

    //Form 3 - (MS Plan B only) Final Exam passed fields show/display based on value
    $('.dateOfFinalExamPassed1').hide();
    $('.dateOfFinalExamFailed1').hide();
    $('#DateOfFinalExam').closest('.col-md-4').css('display', 'none');
    $('#FinalExam2ResultId').closest('.col-md-4').css('display', 'none');
    $('#DateOfFinalExam2').closest('.col-md-4').css('display', 'none');

    $('#FinalExamResultId option:selected').each(function () {
        if ($(this).val() == 46) {
            $('#DateOfFinalExam').closest('.col-md-4').css('display', 'block');
            $('.dateOfFinalExamPassed1').show();
            $('.dateOfFinalExamFailed1').hide();
        } else if ($(this).val() == 47) {
            $('#DateOfFinalExam').closest('.col-md-4').css('display', 'block');
            $('.dateOfFinalExamFailed1').show();
            $('.dateOfFinalExamPassed1').hide();
            $('#FinalExam2ResultId').closest('.col-md-4').css('display', 'block');
            $('#DateOfFinalExam2').closest('.col-md-4').css('display', 'block');

            $('#FinalExam2ResultId option:selected').each(function () {
                if ($(this).val() == 46) {
                    $('.dateOfFinalExamPassed2').show();
                    $('.dateOfFinalExamFailed2').hide();
                } else if ($(this).val() == 47) {
                    $('.dateOfFinalExamPassed2').hide();
                    $('.dateOfFinalExamFailed2').show();
                } else {
                    $('.dateOfFinalExamPassed2').hide();
                    $('.dateOfFinalExamFailed2').hide();
                }

            });

        } else {
            $('.dateOfFinalExamPassed1').hide();
            $('.dateOfFinalExamFailed1').hide();
            $('#DateOfFinalExam').closest('.col-md-4').css('display', 'none');
            $('#FinalExam2ResultId').closest('.col-md-4').css('display', 'none');
            $('#DateOfFinalExam2').closest('.col-md-4').css('display', 'none');
        }
    });

    $("#FinalExamResultId").change(function () {
        $('.dateOfFinalExamPassed1').hide();
        $('.dateOfFinalExamFailed1').hide();
        $('#DateOfFinalExam').closest('.col-md-4').css('display', 'none');
        $('#FinalExam2ResultId').closest('.col-md-4').css('display', 'none');
        $('#DateOfFinalExam2').closest('.col-md-4').css('display', 'none');


        $('#FinalExamResultId option:selected').each(function () {
            if ($(this).val() == 46) {
                $('#DateOfFinalExam').closest('.col-md-4').css('display', 'block');
                $('.dateOfFinalExamPassed1').show();
                $('.dateOfFinalExamFailed1').hide();
            } else if ($(this).val() == 47) {
                $('#DateOfFinalExam').closest('.col-md-4').css('display', 'block');
                $('.dateOfFinalExamFailed1').show();
                $('.dateOfFinalExamPassed1').hide();
                $('#FinalExam2ResultId').closest('.col-md-4').css('display', 'block');
            } else {
                $('#DateOfFinalExam').closest('.col-md-4').css('display', 'none');
                $('#FinalExam2ResultId').closest('.col-md-4').css('display', 'none');
                $('#DateOfFinalExam2').closest('.col-md-4').css('display', 'none');
            }
        });

    });

    $("#FinalExam2ResultId").change(function () {
        $('.dateOfFinalExamPassed2').hide();
        $('.dateOfFinalExamFailed2').hide();

        if ($(this).val() == 46) {
            $('#DateOfFinalExam2').closest('.col-md-4').css('display', 'block');
            $('.dateOfFinalExamPassed2').show();
            $('.dateOfFinalExamFailed2').hide();
        } else if ($(this).val() == 47) {
            $('#DateOfFinalExam2').closest('.col-md-4').css('display', 'block');
            $('.dateOfFinalExamPassed2').hide();
            $('.dateOfFinalExamFailed2').show();
        } else {
            $('#DateOfFinalExam2').closest('.col-md-4').css('display', 'none');
            $('.dateOfFinalExamPassed2').hide();
            $('.dateOfFinalExamFailed2').hide();
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


    //Adds tooltip functionality
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });


    //If menuNav exists (or current home page), shows leftSide navigation 
    //if ($('.menuNav').length != 0 || $('#formerStudent').length != 0 || $('#currentStudent').length != 0) {
    //    $('.leftSide').show(); $('#rightSide').addClass('rightSide');
    //}
    if ($('.menuNav').length == 0 && $('#formerStudent').length == 0 && $('#currentStudent').length == 0) {
        $('.leftSide').hide(); $('#rightSide').removeClass('rightSide');
    }

    //Add select picker functionality to make student list searchable
    $('.selectpicker').selectpicker(
        {
            liveSearch: true,
            showSubtext: true
        }
    );

    //Hide or show report based on button click


    //Display Report on button click

    if ($("input[name='ReportType']:checked").val()) {
        $('.reportSection').show();
    } else {
        $('.reportSection').hide();
    }

    // Hide or show report parameters based on selected Report Type

    $('#ListOfStudents').closest('.form-group').hide();
    $('#CurrentFormer').closest('.form-group').hide();
    $('#FromDateParam').closest('.form-group').hide();
    $('#ToDateParam').closest('.form-group').hide();

    $("input:radio[name='ReportType']:checked").each(function () {
        if ($(this).val() == 'Background' || $(this).val() == 'Requirements')
        {
            $('#ListOfStudents').closest('.form-group').show();
            $('#CurrentFormer').closest('.form-group').show();
            $('#FromDateParam').closest('.form-group').show();
            $('#ToDateParam').closest('.form-group').show();
        }
        else if ($(this).val() == 'Coursework'
                || $(this).val() == 'Performance' 
              //  || $(this).val() == 'Requirements' 
                || $(this).val() == 'PostGraduation')
        {
            $('#ListOfStudents').closest('.form-group').show();
        }
        else
        {
            $('#ListOfStudents').closest('.form-group').hide();
            $('#CurrentFormer').closest('.form-group').hide();
            $('#FromDateParam').closest('.form-group').hide();
            $('#ToDateParam').closest('.form-group').hide();
        }

    });

    
    $("input:radio[name='ReportType']").change(function () {

        $('#ListOfStudents').closest('.form-group').hide();
        $('#CurrentFormer').closest('.form-group').hide();
        $('#FromDateParam').closest('.form-group').hide();
        $('#ToDateParam').closest('.form-group').hide();

        if ($(this).val() == 'Background' || $(this).val() == 'Requirements') {
            $('#ListOfStudents').closest('.form-group').show();
            $('#CurrentFormer').closest('.form-group').show();
            $('#FromDateParam').closest('.form-group').show();
            $('#ToDateParam').closest('.form-group').show();
        }
        else if ($(this).val() == 'Coursework'
                || $(this).val() == 'Performance'
                //|| $(this).val() == 'Requirements'
                || $(this).val() == 'PostGraduation') {
            $('#ListOfStudents').closest('.form-group').show();
        }
        else {
            $('#ListOfStudents').closest('.form-group').hide();
            $('#CurrentFormer').closest('.form-group').hide();
            $('#FromDateParam').closest('.form-group').hide();
            $('#ToDateParam').closest('.form-group').hide();
        }

    });
    
    // Prompts users to select a type of report before proceeding
    $("#GetReport").mouseup(function (e) {
        if (!$("input[name='ReportType']:checked").val()) {
            alert('Please select a report type to obtain a report.');
            e.preventDefault();
        }
        $("input:radio[name='ReportType']:checked").each(function () {
            if ($(this).val() == 'PostGraduation' && ($('#ListOfStudents').val() == ''
                                                      || $('#ListOfStudents').val() == null)) {
                e.preventDefault();
                e.stopPropagation();
                alert('WARNING: Due to the amount of information provided, all students can NOT be'
                       + ' loaded.  Please select a student.');
                
            }
        });

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


