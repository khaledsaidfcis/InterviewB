(function ($) {
  // Change English Numbers to Arabic Numbers
  $('body').persianNum({
    numberType: 'arabic'
  });

  //Sidebar Collpase
  $('#sidebarCollapse').on('click', function () {
    $('#sidebar').toggleClass('hide');
    $('#master').toggleClass('col-9');
    /*start navbar changes */
    $('#navbar').toggleClass('col-6 offset-3');
    $('#navbar').toggleClass('col-9');
    /*end navbar changes */
    $('.card-body').toggleClass('d-flex justify-content-center');
    // $( '#navbar' ).toggleClass( 'col-9' );
  });



    /*
    var _Server = $.connection.serverHub;

    // Create a function that the hub can call back to display messages.
    _Server.client.getAllDataFromSrever = function (std_no, std_kind) {

        $("#spinnerc").removeClass("d-none"); //Show
        let data = {
            "student_no": std_no,
            "student_kind": std_kind
        };

        $("#student-cards").empty();

        $.ajax({
            type: "POST",
            url: "/Home/GetAllData",
            data: data,
            success: function (response) {
                //alert(response);
                $("#student-cards").empty();
                
                $("#student-cards").append(response);
                $('#student-cards').persianNum({ numberType: 'arabic' }); 
                $("#spinnerc").addClass("d-none"); //hide
            },
            error: function (e) {
                alert(e);
            }
        });

        console.log(std_no + " " + std_kind);
    };


    // Start the connection.
    $.connection.hub.start().done(function () {
        $("#Admin_Form_btn").on("click", function (e) {
            e.preventDefault();
            var student_no = $("input[name=student_no]").val();
            var student_kind = $('select[name=' + "student_kind" + ']').val();
            // Call the Send method on the hub.
            _Server.server.sendStdnoToClients(student_no, student_kind);   
        });
    });

   */

    //-------------------------------------------------------------------------------//
    
    var _Server = $.connection.serverHub;
    // Create a function that the hub call in all clients 
    _Server.client.broadcastData = function (data) {
        console.log("Data Client" , data);
        $.ajax({
            type: "POST",
            url: "/Home/GetStudentView",
            //data: JSON.stringify(data),
            data: data,
            success: function (response) {
                console.log(response);
                $("#student-cards").empty();
                $("#student-cards").append(response);
                $('#student-cards').persianNum({ numberType: 'arabic' });
                $("#spinnerc").addClass("d-none"); //hide
                
            },
            error: function (e) {
                console.log("error" ,e);
            }
        });
    }



    $("#Admin_Form_btn").on("click", function (e) {
        e.preventDefault();
        //Form Values
        var student_no = $("input[name=student_no]").val();
        var student_kind = $('select[name=' + "student_kind" + ']').val();

        let data = {
            "student_no": student_no,
            "student_kind": student_kind
        };

        $("#spinnerc").removeClass("d-none"); //Show Spinner
        $("#student-cards").empty();    //Empty Cards

        //Make Ajax Request to Server
        $.ajax({
            type: "POST",
            url: "/Home/GetJsonData",
            data: data,
            success: function (response) {
                console.log(response);
                $("#spinnerc").addClass("d-none"); //hide Spinner

                //IF Error Msg Then Add To Admin Only
                if (!response.hasOwnProperty('main_info')) {
                    $("#student-cards").append("<li class='alert alert-danger alert-dismissible fade show' role='alert'>" + response + "</li>");
                } else {
                    //if success call server method that pass JSON TO ALL Clients
                    _Server.server.sendDataToClients(response);
                }
                
            },
            error: function (e) {
                console.log("error" + e );
            }
        });


    });

    









})(jQuery);

