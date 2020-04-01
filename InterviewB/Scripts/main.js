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
    //Admin_Form AJAX
    $("#Admin_Form_btn").on("click", function (e) {
        e.preventDefault();
        var student_no   = $("input[name=student_no]").val();
        var student_kind = $('select[name=' + "student_kind" + ']').val();

        

        //alert($("input[name=student_no]").val());
        //alert($('select[name=' + "student_kind" + ']').val());

        //$("#spinnerc").toggleClass("d-none");
      
        var data = $("#Admin_Form").serialize();
        console.log(data);
        $.ajax({
            type: "POST",
            url: "/Home/getAllData",
            data: data,
            success: function (response) {
                //alert(response);
                $("#student-cards").empty();
                $("#student-cards").append(response);
            },
            error: function (e) {
                alert(e);
            }
        });

        
    });
    */






    var _Server = $.connection.serverHub;

    // Create a function that the hub can call back to display messages.
    _Server.client.getAllDataFromSrever = function (std_no, std_kind) {

        $("#spinnerc").removeClass("d-none"); //Show
        let data = {
            "student_no": std_no,
            "student_kind": std_kind
        };

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

   













})(jQuery);

