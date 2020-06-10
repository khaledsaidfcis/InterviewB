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
    if (student_no == null || student_kind == null) {
        alert("برجاء إدخال رقم القيد والتخصص");
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
                if (!response.hasOwnProperty('main_info')) {
                    $("#student-cards").append("<li class='alert alert-danger alert-dismissible fade show' role='alert'>" + response + "</li>");
                } else {
                    //if success call server method that pass JSON TO ALL Clients
                    _Server.server.sendDataToClients(response);
                }

            },
            error: function (e) {
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

    _Server.client.broadcastData = function (data) {
        console.log("Data Client", data);
        $.ajax({
            type: "POST",
            //url: "/Home/GetStudentView",
            url: $('#links').data('link2'),
            data: data,
            main_std_No: data.main_info.STD_NO,
            main_std_kind: data.main_info.STD_KIND_CODE,
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
                $.ajax({
                    url: imagePath,
                    type: 'HEAD',
                    success: function () {
                        //image is exists
                        $('#image-modal').show();
                        $('#image-modal').attr('src', imagePath);
                        $('#image-error').hide();
                    },
                    error: function () {
                        //image not exists
                        $('#image-modal').hide();
                        $('#image-error').show();
                    }
                });
            },
            error: function (e) {
                console.log("error", e);
            }
        });
    }

   
    //Make Submit by button or Perss Enter
    $("#Admin_Form_btn").on("click", function (e) {
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