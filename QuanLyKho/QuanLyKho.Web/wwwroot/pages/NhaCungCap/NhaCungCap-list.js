
$(document).ready(function () {
    var datatable = $('#datatable').dataTable({
        "searching": false,
        "iDisplayLength": 10,
        "ordering": false,
        "lengthChange": false,
        "bServerSide": true,
        "processing": true,
        "paging": true,
        "sAjaxSource": "/NhaCungCap/List",
        "info": true,
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            aoData.push(
                { "name": "returnformat", "value": "plain" },
                { "name": "TenNhaCungCap", "value": $('input[name="TenNhaCungCap"]').val() },
                { "name": "DiaChi", "value": $('input[name="DiaChi"]').val() },
                { "name": "SoDienThoai", "value": $('input[name="SoDienThoai"]').val() },
                { "name": "Email", "value": $('input[name="Email"]').val() },
                { "name": "NguoiDaiDien", "value": $('input[name="NguoiDaiDien"]').val() }
            );
            $.ajax({
                "dataType": 'json',
                "type": "GET",
                "url": sSource,
                "data": aoData,
                "success": function (data) {
                    if (data.IsSucceeded == true) {
                        fnCallback(data);
                    }
                    else {
                        toastr.error(data.UserMessage);
                    }
                }
            });
        },
        aoColumns:
            [
                {
                    mDataProp: "TenNhaCungCap"
                },
                {
                    mDataProp: "DiaChi"
                },
                {
                    mDataProp: "SoDienThoai"
                },
                {
                    mDataProp: "Email"
                },
                {
                    mDataProp: "NguoiDaiDien"
                },
                {
                    "sDefaultContent": "",
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        var buttons = "";
                        buttons += '<a href="/NhaCungCap/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Cập nhật</a>&nbsp;'
                        buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> Xóa</a>'
                        return buttons;
                    }
                }
            ]
    });

    $("#btnFilter").click(function () {
        datatable.fnFilter();
    });

    $("#btnClear").click(function () {
        $('div.dataTable-search-form').clearForm();
        datatable.fnFilter();
    });


    $('.enter-keyup').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            datatable.fnFilter();
        }
    });

});



function deleteRow(row, id) {

    $.ajax({
        url: '/NhaCungCap/Delete/' + id,
        type: "POST",
        async: false,
        success: function (data) {
            if (data.IsSucceeded) {
                var aPos = $('#datatable').dataTable().fnGetPosition(row);
                $('#datatable').dataTable().fnDeleteRow(aPos);
                toastr.success(data.UserMessage);
            }
            else {
                toastr.error(data.UserMessage);
            }
        }
    });
}

