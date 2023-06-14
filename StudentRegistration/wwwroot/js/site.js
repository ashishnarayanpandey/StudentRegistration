$(function () {
    var PaceholerElement = $('#PlaceHolderHere');
    debugger
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');

        $.get(url).done(function (data) {
           
            PaceholerElement.html(data);
            var CId = PaceholerElement.find('.hdnCId').val();
            var SId = PaceholerElement.find('.hdnSId').val();
            var DId = PaceholerElement.find('.hdnDId').val();

            GetCountry(CId);
            Getstate(CId, SId);
            Getcity(SId, DId);
            PaceholerElement.find('.modal').modal('show');
        })
    })
})
$(document).ready(function () {

    $('#C1').change(function () {
        debugger;
        $('#S2').attr('disabled', false);
        var id = $(this).val();
        Getstate(id);
    });
    $('#S2').change(function () {
        $('#D3').attr('disabled', false);
        var id = $(this).val();
        Getcity(id);
    });

})

function GetCountry(CId) {

    $.ajax({
        url: "/Stud/GetCountry",
        success: function (result) {
            $('#C1').empty();
            $('#C1').append('<option value=' + 0 + ' >' + '--------Select country-------' + '</option >');
            $.each(result, function (i, data) {
                if (CId == data.cId) {
                    $('#C1').append('<option value=' + data.cId + ' selected >' + data.cName + '</option >');
                }
                else {
                    $('#C1').append('<option value=' + data.cId + '>' + data.cName + '</option >');
                }

            });
        }
    });
}
function Getstate(CId, SId) {
    debugger;
    $.ajax({
        url: '/Stud/GetState?id=' + CId,
        success: function (result) {
            $('#S2').empty();
            $('#S2').append('<option value=' + 0 + ' >' + '--------Select State-------' + '</option >');
            $.each(result, function (i, data) {
                debugger;
                if (SId == data.sId) {

                    $('#S2').append('<option value=' + data.sId + ' selected >' + data.sName + '</option >');
                }
                else {

                    $('#S2').append('<option value=' + data.sId + ' >' + data.sName + '</option >');
                }
            });
        }
    });
}

function Getcity(SId, DId) {
    debugger;
    $.ajax({
        url: '/Stud/GetCity?id=' + SId,
        success: function (result) {
            $('#D3').empty();
            $('#D3').append('<option value=' + 0 + ' >' + '--------Select city-------' + '</option >');
            $.each(result, function (i, data) {
                debugger;
                if (DId == data.dId) {

                    $('#D3').append('<option value=' + data.dId + ' selected >' + data.dName + '</option >');
                }
                else {

                    $('#D3').append('<option value=' + data.dId + ' >' + data.dName + '</option >');
                }
            });
        }
    });
}

/*------------------Refreshpage--------------------------------------------*/
function refreshPage() {
    window.location.reload();
} 
/*----------------------------------------------------*/

