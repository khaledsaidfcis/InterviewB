// ------------------------- Define Functions ------------------------//
function makeAjaxRequest(_type, _url, _params, successFunc, failFunc) {
    $.ajax({
        type: _type,
        url: _url,
        data: _params,
        success: successFunc,
        error: failFunc
    });
}

function submitForm(_Server) {
    //Form Values and Make them global
    var student_no = $("input[name=student_no]").val();
    var student_kind = $('select[name=' + "student_kind" + ']').val();

    // If null diplay alert
    if (student_no == null || student_kind == null || student_no == '') {
        //alert("برجاء إدخال رقم القيد والتخصص");
        swal("برجاء إدخال رقم القيد والتخصص", "", "error");
    }
    else {
        let _data = {
            "student_no": student_no,
            "student_kind": student_kind
        };

        console.log(_data);
        //Call Server Method That Refresh all Clients
        _Server.server.refreshPage();
        //MAke Ajax Request
        $.ajax({
            type: "POST",
            //url: "/Home/GetJsonData",
            url: $('#links').data('link1'),
            data: _data,
            success: function (response) {
                console.log(response);
                $("#spinnerc").addClass("d-none"); //hide Spinner
                //TODO: Make It a View 
                //IF Error Msg Then Add To Admin Only
                if (!response.hasOwnProperty('Name')) {
                    //alert("test2");
                    $("#student-cards").append("<div id='CartsDefaultValue'><li id='CartsEmptyAlert' class='alert alert-danger alert-dismissible fade show' role='alert'><h1>" + response + "</h1></li></div>");
                } else {
                    //alert("test3");
                    console.log(response);
                    $("#spinnerc").removeClass("d-none");
                    //if success call server method that pass JSON TO ALL Clients
                    _Server.server.sendDataToClients(response, null);
                }

            },
            error: function (e) {
                //alert("test4");
                console.log("error" + e);
            }
        });
    }
}


// ------------------------ jQuery --------------------------------------- //
(function ($) {

    var _Server = $.connection.serverHub;  // SignalR Server
    _Server.client.refreshPageOnClient = function () {
        $("#spinnerc").removeClass("d-none"); //Show Spinner
        $("#student-cards").empty();    //Empty Cards
        //disable imagModal
        $("#image-modal-button").addClass('disabled'); 
        $("#image-modal-button").children().removeClass('text-blinking');
    }

    _Server.client.broadcastData = function (data, notifiAdmin) {
        //console.log("Data Client", data);
        if (notifiAdmin != null && notifiAdmin != '') {
            //console.log("admin Client", data);
            var msg = "";
            if (notifiAdmin.includes("transOpinionSec")) {
                //msg = "تم تقييم المظهر العام";
                $("#transOpinionSec").removeClass("alert-danger");
                $("#transOpinionSec").addClass("alert-success"); 
                
            }
            else if (notifiAdmin.includes("user1OpinionSec")) {
                //msg = "تم تقييم المستوي الثقافي";
                $("#user1OpinionSec").removeClass("alert-danger");
                $("#user1OpinionSec").addClass("alert-success"); 
            }
            else if (notifiAdmin.includes("user2OpinionSec")) {
                //msg = "تم التقييم من قبل وزارة النقل";
                $("#user2OpinionSec").removeClass("alert-danger");
                $("#user2OpinionSec").addClass("alert-success"); 
            }
            else if (notifiAdmin.includes("user3OpinionSec")) {
                //msg = "تم التقييم من قبل هيئة تدريب القوات المسلحة";
                $("#user3OpinionSec").removeClass("alert-danger");
                $("#user3OpinionSec").addClass("alert-success"); 
            }
            else if (notifiAdmin.includes("user4OpinionSec")) {
                //msg = "تم التقييم من قبل هيئة تدريب القوات المسلحة";
                $("#user4OpinionSec").removeClass("alert-danger");
                $("#user4OpinionSec").addClass("alert-success");
            }
            else if (notifiAdmin.includes("user5OpinionSec")) {
                //msg = "تم التقييم من قبل هيئة تدريب القوات المسلحة";
                $("#user5OpinionSec").removeClass("alert-danger");
                $("#user5OpinionSec").addClass("alert-success");
            }
            else if (notifiAdmin.includes("user6OpinionSec")) {
                //msg = "تم التقييم من قبل هيئة تدريب القوات المسلحة";
                $("#user6OpinionSec").removeClass("alert-danger");
                $("#user6OpinionSec").addClass("alert-success");
            }
            //$("#adminNotification").append('<div class="alert alert-success alert-dismissible fade show">' + msg + '</div>');
        }
        else {
            $.ajax({
                type: "POST",
                //url: "/Home/GetStudentView",
                url: $('#links').data('link2'),
                data: data,
                main_std_No: data.ID,
                main_std_kind: data.Type,
                success: function (response) {
                    //console.log(response);
                    $("#student-cards").empty();
                    $("#student-cards").append(response);
                    $('#student-cards').persianNum({ numberType: 'arabic' }); //Arabic Numbers
                    $("#spinnerc").addClass("d-none"); //hide


                    //Active Student Photo Card
                    $("#image-modal-button").removeClass('disabled');
                    $("#image-modal-button").children().addClass('text-blinking');
                    //Add image path based on std_No & std_kind
                    var imagePath = null;
                    if (this.main_std_kind == 1) {
                        imagePath = "\\StudentCards\\Scn\\" + this.main_std_No + ".jpg";
                    } else {
                        imagePath = "\\StudentCards\\Gam\\" + this.main_std_No + ".jpg";

                    }
                    //Check if image is exist
                    //$.ajax({
                    //    url: imagePath,
                    //    type: 'HEAD',
                    //    success: function () {
                    //        //image is exists
                    //        $('#image-modal').show();
                    //        $('#image-modal').attr('src', imagePath);
                    //        $('#image-error').hide();
                    //    },
                    //    error: function () {
                    //        //image not exists
                    //        $('#image-modal').hide();
                    //        $('#image-error').show();
                    //    }
                    //});

                },
                error: function (e) {
                    console.log("error", e);
                }
            });
        }
    }

   
    //Make Submit by button or Perss Enter
    $("#Admin_Form_btn").on("click", function (e) {
        //alert("test1");
        e.preventDefault();
        submitForm(_Server);
    });
    
    $('#student_no').keydown(function (e) {
        //e.preventDefault();
        if (e.which == 10 || e.which == 13) {
            e.preventDefault();
            console.log('enter is pressed');
            submitForm(_Server);
            
        }
    });



    $('#letters-ul').children().on("click", function (e) {
        var letterValue = $(this).data('letter'); //Get Letter Value
        console.log($(this).data('letter'));
        
    });

    //diabled blinking after first click
    $("#image-modal-button").on("click", function (e) {
        $("#image-modal-button").children().removeClass('text-blinking');
    });


   

})(jQuery);