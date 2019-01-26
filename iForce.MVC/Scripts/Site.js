$(document).ready(function () {
    $('#createNew').click(function () {
        var url = $('#userAddModal').data('url');

        $.get(url, function (data) {
            $('#userAddContainer').html(data);
            $('#userAddModal').modal('show');
        });
    });
});
function editUser(id) {
    var url = $('#userEditModal').data('url');
    url += "/" + id;
    $.get(url, function (data) {
        $('#userEditContainer').html(data);
        $('#userEditModal').modal('show');
    });
}

function deleteUser(id) {
    var url = $('#userDeleteModal').data('url');
    url += "/" + id;
    $.get(url, function (data) {
        $('#userDeleteContainer').html(data);
        $('#userDeleteModal').modal('show');
    });
}
function PagerClick(index, sortBy) {
    document.getElementById("hfCurrentPageIndex").value = index;
    debugger;

    if (sortBy) {
        document.getElementById("hfSortBy").value = sortBy;

        if (document.getElementById("hfSortOrder").value == "ASC") {
            document.getElementById("hfSortOrder").value = "DESC";
        } else {
            document.getElementById("hfSortOrder").value = "ASC";
        }

    }
    
    document.forms[0].submit();
}