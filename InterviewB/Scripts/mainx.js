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

function submitForm() {
    console.log('sumbit');
    //Form Values
    var student_no = $("input[name=student_no]").val();
    var student_kind = $('select[name=' + "student_kind" + ']').val();
    //TODO : If null diplay alert
    let _data = {
        "student_no": student_no,
        "student_kind": student_kind
    };

    console.log(_data);
}


// ------------------------ jQuery --------------------------------------- //
(function ($) {

    //Make Submit by button or Perss Enter
    $("#Admin_Form_btn").on("click", function (e) {
        e.preventDefault();
        submitForm();
       
        //TODO:  Call Server Method That Refresh all Clients
        //_Server.server.refreshPage();
    });
    
    $('body').keydown(function (e) {
        //e.preventDefault();
        if (e.which == 10 || e.which == 13) {
            e.preventDefault();
            submitForm();
            console.log('enter is pressed');
        }

    });
    



})(jQuery);