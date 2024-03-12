
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    let ajaxreq = $.ajax({
        url: '/Category/GetList',
        type: 'GET',
        dataType: 'json'
    });
    ajaxreq.done(function (data) {
        console.log(data);
        if (data.success) {
            $("#tb_category").empty();
            if (data.data != null && data.data.length > 0) {
                let htmlDom = '';
                for (let i = 0; i < data.data.length; i++) {

                    htmlDom = '<tr>';
                    htmlDom += '<td>' + data.data[i].id + '</td>';
                    htmlDom += '<td>' + data.data[i].name + '</td>';
                    htmlDom += '<td>' + data.data[i].displayOrder + '</td>';
                    htmlDom += '<td>';
                    htmlDom += '<button type="button" class="btn btn-sm btn-primary" title="Edit" data-options=' + JSON.stringify(data.data[i]) + ' onclick="editCategory(this)"><i class="fas fa-edit"></i></button>';
                    htmlDom += '<button type="button" class="btn btn-sm btn-danger" title="Delete" onclick="deleteCategory(' + data.data[i].id + ')"><i class="fas fa-trash-alt"></i></button>';
                    htmlDom += '<td>';
                    htmlDom += '<tr>';

                    $("#td_category").append(htmlDom);

                }
            }
            else {
                alert(data.message);
            }
        }
    });
    ajaxreq.fail(function (xhr, status, error) {
        console.error('Error occurred:', error);
    });
}


function editCategory(ctx) {

    var abc = $(ctx).data('options');
    console.log(abc);


}