$(document).ready(function () {
    var table = $('#mygrid').DataTable();

    $('.delacc').click(function () {
        debugger;
        accid = $(this).closest('tr').prop('id');
        var id = accid.split('_')[1];
        bootbox.confirm("Are you sure you want to delete this voucher?", function (result) {
            if (result) {
                $.ajax({
                    method: 'POST',
                    url: '/Voucher/DeleteVoucher/' + id,
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

    $('#drbtn').click(function () {
        //debugger;
        var tbrow = $('.drtable tbody:first').html();
        $('.drtable tbody:first').append(tbrow);
    });

    $('#crbtn').click(function () {
        debugger;
        var tbrow = $('.crtable tbody:first').html();
        $('.crtable tbody:first').append(tbrow);
    });

    $('#subtn').click(function () {
        var trans = new Array();
        debugger;

        $('.drtable tr').each(function (i, row) {
            //debugger;
            var row = $(row);
            var acc = row.find('td:eq(0) select').val();
            var am = row.find('td:eq(1) input').val();
            var intrans = { TaccountId: parseInt( acc), Amount: parseFloat(am), Direction: 'dr' };
            trans.push(intrans);
        });

        $('.crtable tr').each(function (i, row) {
            //debugger;
            var row = $(row);
            var acc = row.find('td:eq(0) select').val();
            var am = row.find('td:eq(1) input').val();
            var intrans = { TaccountId: parseInt( acc), Amount: parseFloat(am), Direction: 'cr' };
            trans.push(intrans);
        });

        var voucherobj = {
            voucher: {
                Vouchertype: parseInt( $('#vctype').val()),
                Entrytypeid: parseInt( $('#adjust:checked').length > 0 ? 2 : 1)
            },
            transactions: trans
        };

        $.ajax({
            method: 'POST',
            url: '/Voucher/AddVoucher/',
            contentType: 'application/json charset=utf-8',
            dataType: 'text json',
            data: JSON.stringify(voucherobj),
            success: function (res) {
                location.reload();
            },
            error: function () {
                bootbox.error('An expected error occured...');
            }
        });
    });

    $('#jv').click(function () {
        $('#vctype').val(1);
        $('#exampleModalLabel').html('Journal Voucher');
    });

    $('#pv').click(function () {
        $('#vctype').val(2);
        $('#exampleModalLabel').html('Payment Voucher');
    });
    $('#rv').click(function () {
        $('#vctype').val(3);
        $('#exampleModalLabel').html('Receipt Voucher');
    });
    //$('#newvouc').click(function () {
    //    alert();
    //});
});