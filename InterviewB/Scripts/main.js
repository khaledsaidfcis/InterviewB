(function ($) {
  // Change English Numbers to Arabic Numbers
  $('body').persianNum({
    numberType: 'arabic'
  });

  //Sidebar Collpase
  $('#sidebarCollapse').on('click', function () {
    $('#sidebar').toggleClass('hide');
      $('#master').toggleClass('col-9');
      $('.card-body').toggleClass('d-flex justify-content-center');

    // $( '#navbar' ).toggleClass( 'col-9' );
  });




    //Admin_Form AJAX
    $("#Admin_Form_btn").on("click", function (e) {
        e.preventDefault();
        var student_no   = $("input[name=student_no]").val();
        var student_kind = $('select[name=' + "student_kind" + ']').val();

        alert($("input[name=student_no]").val());
        alert($('select[name=' + "student_kind" + ']').val());

        //$("#spinnerc").toggleClass("d-none");
      
        var data = $("#Admin_Form").serialize();

        $.ajax({
            type: "POST",
            url: "/Home/getAllData",
            data: data,
            success: function (response) {
                alert(response);
                $("#student-cards").empty();
                $("#student-cards").append(response);
            },
            error: function (e) {
                alert(e);
            }
        });

        
    });

})(jQuery);

