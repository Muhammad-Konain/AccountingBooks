$(document).ready(function () {
    var table = $('#mygrid').DataTable();

    $('.fillform').click(function () {
        var row = $(this).closest('tr');
        var acctitle = row.find('td:eq(0)').text();
        var acctype = row.find('td:eq(1)').text();
        var accid = row.prop('id');

        var id = accid.split('_')[1];
        $('#Id').val(id);

        $('#Title').val(acctitle);
        var value = $('#AccountType option').filter(function () { return $(this).text() == acctype; }).val();
        $('#AccountType').val(value);
    });

    $('.delacc').click(function () {
        accid = $(this).closest('tr').prop('id');
        var id = accid.split('_')[1];
        bootbox.confirm("Are you sure you want to delete this account?", function (result) {
            if (result) {
                var i = 'TAccounts/DeleteAccount/' + id;
                $.ajax({
                    method: 'POST',
                    url: '/TAccounts/DeleteAccount/' + id,
                    contentType: 'application/json charset=utf-8',
                    dataType: 'text json',
                    success: function (res) {
                        table.row($('#' + accid)).remove().draw();
                    },
                    error: function () {
                        bootbox.error('An expected error occured...');
                    }
                });
            }
        })
    });
    $('#cls').click(function () {
        $('#Id').val(0);

        $('#Title').val('');
 
        $('#AccountType').val(1);
    });
});