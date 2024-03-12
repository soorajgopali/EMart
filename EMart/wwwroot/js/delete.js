function confirmDelete(deletedId) {
    if (deletedId) {
        swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!',
        }).then((result) => {
            if (result.isConfirmed) {
                var categoryId = deletedId;
                let ajaxreq = $.ajax({
                    url: '/Category/Delete',
                    type: 'POST',
                    data: { id: deletedId },
                    datatype: 'json'
                });

                ajaxreq.done(function (data) {
                    if (data.success) {
                        Swal.fire(data.message).then(() => {
                            window.location.href = '/Category/Index';
                        });
                    } else {
                        Swal.fire(data.message);
                    }
                });

                ajaxReq.fail(function (jqXHR, textStatus, errorThrown) {
                    alert('Error : ' + jqXHR.responseText);
                });
            }
        });
    }
}
