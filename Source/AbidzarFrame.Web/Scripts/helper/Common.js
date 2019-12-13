$(document).ready(function () {
    setTimeout(function () {
        if (typeof dataTable !== 'undefined') {
            if (dataTable != null) {
                var table = $("table[id]").DataTable();
                var buttons = new $.fn.dataTable.Buttons(table, {
                    buttons: [
                        //'colvis',
                        {
                            extend: 'print',
                            exportOptions: {
                                columns: ':not(:contains(Edit)):not(:contains(Delete)):not(:contains(Detail))'
                            }
                        },
                        {
                            extend: 'csvHtml5',
                            exportOptions: {
                                orthogonal: 'export',
                                columns: ':not(:contains(Edit)):not(:contains(Delete)):not(:contains(Detail))'
                            }
                        },
                        {
                            extend: 'copyHtml5',
                            exportOptions: {
                                orthogonal: 'export',
                                //columns: ':visible'
                                columns: ':not(:contains(Edit)):not(:contains(Delete)):not(:contains(Detail))'
                            }
                        },
                        {
                            extend: 'excelHtml5',
                            exportOptions: {
                                orthogonal: 'export',
                                //columns: ':visible',
                                columns: ':not(:contains(Edit)):not(:contains(Delete)):not(:contains(Detail))'
                            }
                        },
                        {
                            extend: 'pdfHtml5',
                            text: 'Export PDF',
                            exportOptions: {
                                orthogonal: 'export',
                                //columns: ':visible',
                                columns: ':not(:contains(Edit)):not(:contains(Delete)):not(:contains(Detail))'
                            }
                            //orientation: 'landscape',
                            //pageSize: 'LEGAL',
                            //customize: function (doc) {
                            //    doc.styles['td:nth-child(1)'] = {
                            //        width: '500px',
                            //        'max-width': '500px'
                            //    }
                            //}
                        }
                    ]
                });
            }
        }

    });

    $(".datatable-action-print").click(function () {
        dataTable.buttons('.buttons-print').trigger();
    });

    $(".datatable-action-pdf").click(function () {
        dataTable.buttons('.buttons-pdf').trigger();
    });

    $(".datatable-action-excel").click(function () {
        dataTable.buttons('.buttons-excel').trigger();
    });

    $(".datatable-action-csv").click(function () {
        dataTable.buttons('.buttons-csv').trigger();
    });

    $(".reload").click(function () {
        if (typeof dataTable !== 'undefined') {
            if (dataTable != null) {
                dataTable.ajax.reload();
                //console.log('refresh grid');
            }
        }
    });

    function doUpdateForm(url) {
        $('div#AbidzarFrameModalFormContent').children().each(function (e) {
            var nodeName = this.nodeName.toLowerCase();
            if (nodeName == "form") {
                if ($(this).valid()) {
                    $.ajax({
                        async: true,
                        url: url,
                        type: 'post',
                        dataType: 'json',
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({
                            model: $(this).serializeObject()
                        }),
                        success: function (ret) {
                            if (ret.Msg != null && ret.Msg != "") {
                                if (typeof dataTable !== 'undefined') {
                                    if (dataTable != null) {
                                        //console.log('refresh');
                                        dataTable.ajax.reload();
                                    }
                                }
                                alertSuccess(ret.Msg);
                                $('#AbidzarFrameModalFormEdit').modal('hide');
                            } else if (!ret.success) {
                                console.log(ret.errors);
                                $.each(ret.errors, function (index, value) {
                                    // Error message
                                    var validationMessageElement = $('span[data-valmsg-for="' + index + '"]');
                                    validationMessageElement.removeClass('field-validation-valid');
                                    validationMessageElement.addClass('field-validation-error');
                                    validationMessageElement.text(value[0]);
                                });
                            }
                            else {
                                var msg = ret ? $.parseJSON(ret) : null; alertError(msg.ErrorMessage);
                            }

                        },
                        error: function (jqXHR, exception) {
                            // dicomment karna error json udah dicover di fungsi ajaxError
                            //var msg = ret ? $.parseJSON(ret) : null;
                            //alertError(msg.ErrorMessage);
                            if (typeof dataTable !== 'undefined') {
                                if (dataTable != null) {
                                    dataTable.ajax.reload();
                                }
                            }
                        }
                    });
                }
            }
        });
    }

    function getErrorMessage(jqXHR, exception) {
        var msg = '';
        if (jqXHR.status === 0) {
            msg = 'Not connect.\n Verify Network.';
        }
        else if (jqXHR.status == 404) {
            msg = 'Requested page not found. [404]';
        }
        else if (jqXHR.status == 500) {
            msg = 'Internal Server Error [500].';
        }
        else if (exception === 'parsererror') {
            msg = 'Requested JSON parse failed.';
        }
        else if (exception === 'timeout') {
            msg = 'Time out error.';
        }
        else if (exception === 'abort') {
            msg = 'Ajax request aborted.';
        }
        else {
            msg = 'Uncaught Error.\n' + jqXHR.responseText.ErrorMessage;
        }
        $('#post').html(msg);
    }

    $('#AbidzarFrameModalFormEdit').on('show.bs.modal', function (e) {
        if (e.target.id == 'AbidzarFrameModalFormEdit') {
            var data = $(e.relatedTarget).data();
            $.ajax({
                async: true,
                type: "POST",
                url: data.url,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    id: data.itemId
                }),
                datatype: "application/json",
                success: function (ret) {
                    $('#AbidzarFrameModalFormContent').html(ret);
                },
                error: function () {
                    $(this).modal('hide');
                    alertError("Failed to open form, please try again");
                }
            }).done(function (ret) {
                markRequired();
            });

            $('.description', this).text(data.itemDescription);
            $('#btnSaveForm', this).data('urlAction', data.urlAction);
        }
    });

    $('#AbidzarFrameModalFormEdit').on('click', '#btnSaveForm', function (e) {
        var $modalDiv = $(e.delegateTarget);
        var url = $(this).data('urlAction');
        doUpdateForm(url);
    });

    $('#confirm-delete').on('show.bs.modal', function (e) {
        var data = $(e.relatedTarget).data();
        //$('.description', this).text(data.itemDescription);
        $('#btnContinueDelete', this).data('itemId', data.itemId);
        $('#btnContinueDelete', this).data('url', data.url);
    });

    $('#confirm-delete').on('click', '#btnContinueDelete', function (e) {
        var $modalDiv = $(e.delegateTarget);
        var id = $(this).data('itemId');
        var url = $(this).data('url');
        $.ajax({
            async: true,
            url: url,
            type: 'post',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                id: id
            }),
            success: function (ret) {


                $modalDiv.modal('hide');
                if (typeof dataTable !== 'undefined') {
                    if (dataTable != null) {
                        dataTable.ajax.reload();
                    }
                }
                alertSuccess(ret.Msg);
            },
            error: function (ret) {
                //var msg = ret ? $.parseJSON(ret) : null; alertError(msg.ErrorMessage);
                if (typeof dataTable !== 'undefined') {
                    if (dataTable != null) {
                        dataTable.ajax.reload();
                    }
                }
            }
        });
    });

    $('#confirm-polling-pemilu').on('show.bs.modal', function (e) {
        var data = $(e.relatedTarget).data();
        //$('.description', this).text(data.itemDescription);
        $('#btnContinuePollingPemilu', this).data('itemId', data.itemId);
        $('#btnContinuePollingPemilu', this).data('url', data.url);
    });

    $('#confirm-polling-pemilu').on('click', '#btnContinuePollingPemilu', function (e) {
        var $modalDiv = $(e.delegateTarget);
        var id = $(this).data('itemId');
        var url = $(this).data('url');
        $.ajax({
            async: true,
            url: url,
            type: 'post',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                id: id
            }),
            success: function (ret) {


                $modalDiv.modal('hide');
                if (typeof dataTable !== 'undefined') {
                    if (dataTable != null) {
                        dataTable.ajax.reload();
                    }
                }
                alertSuccess(ret.Msg);
            },
            error: function (ret) {
                //var msg = ret ? $.parseJSON(ret) : null; alertError(msg.ErrorMessage);
                if (typeof dataTable !== 'undefined') {
                    if (dataTable != null) {
                        dataTable.ajax.reload();
                    }
                }
            }
        });
    });

    function doUpdateFormWithFile(url) {
        var fileSelected = document.getElementById("fileSelected");
        var files = fileSelected.files;
        var formData = new FormData();
        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            if (!file.type.match('image.*')) {
                continue;
            }
            formData.append("file", file);
            //formData.append('photos[]', file, file.name);
        }

        //call controller save data by hamka
        $.ajax({
            type: "POST",
            url: location.origin + '/DataFile/SaveDataFile/',
            contentType: false,
            processData: false,
            data: formData,
            success: function (ret) {
                $('div#AbidzarFrameModalFormContentWithFile').children().each(function (e) {
                    var nodeName = this.nodeName.toLowerCase();
                    if (nodeName == "form") {
                        if ($(this).valid()) {
                            $.ajax({
                                async: true,
                                url: url,
                                type: 'post',
                                dataType: 'json',
                                contentType: 'application/json; charset=utf-8',
                                processData: false,
                                //contentType: false,
                                data: JSON.stringify({
                                    model: $(this).serializeObject(),
                                }),
                                success: function (ret) {
                                    if (ret.Msg != null && ret.Msg != "") {
                                        if (typeof dataTable !== 'undefined') {
                                            if (dataTable != null) {
                                                //console.log('refresh');
                                                dataTable.ajax.reload();
                                            }
                                        }
                                        alertSuccess(ret.Msg);
                                        $('#AbidzarFrameModalFormEditWithFile').modal('hide');
                                        Refresh();
                                    } else if (!ret.success) {
                                        console.log(ret.errors);
                                        $.each(ret.errors, function (index, value) {
                                            // Error message
                                            var validationMessageElement = $('span[data-valmsg-for="' + index + '"]');
                                            validationMessageElement.removeClass('field-validation-valid');
                                            validationMessageElement.addClass('field-validation-error');
                                            validationMessageElement.text(value[0]);
                                        });
                                    }
                                    else {
                                        var msg = ret ? $.parseJSON(ret) : null; alertError(msg.ErrorMessage);
                                    }
                                },
                                error: function (jqXHR, exception) {
                                    // dicomment karna error json udah dicover di fungsi ajaxError
                                    //var msg = ret ? $.parseJSON(ret) : null;
                                    //alertError(msg.ErrorMessage);
                                    if (typeof dataTable !== 'undefined') {
                                        if (dataTable != null) {
                                            dataTable.ajax.reload();
                                        }
                                    }
                                }
                            });
                        }
                    }
                });

            }
        });

    }

    $('#AbidzarFrameModalFormEditWithFile').on('show.bs.modal', function (e) {
        if (e.target.id == 'AbidzarFrameModalFormEditWithFile') {
            var data = $(e.relatedTarget).data();
            $.ajax({
                async: true,
                type: "POST",
                url: data.url,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    id: data.itemId
                }),
                datatype: "application/json",
                success: function (ret) {
                    $('#AbidzarFrameModalFormContentWithFile').html(ret);
                },
                error: function () {
                    $(this).modal('hide');
                    alertError("Failed to open form, please try again");
                }
            }).done(function (ret) {
                markRequired();
            });

            $('.description', this).text(data.itemDescription);
            $('#btnSaveFormWithFile', this).data('urlAction', data.urlAction);
        }
    });

    $('#AbidzarFrameModalFormEditWithFile').on('click', '#btnSaveFormWithFile', function (e) {
        var $modalDiv = $(e.delegateTarget);
        var url = $(this).data('urlAction');
        doUpdateFormWithFile(url);
    });

    $('#AbidzarFrameModalFormEditGrafik').on('show.bs.modal', function (e) {
        if (e.target.id == 'AbidzarFrameModalFormEditGrafik') {
            var data = $(e.relatedTarget).data();
            $.ajax({
                async: true,
                type: "POST",
                url: data.url,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    id: data.itemId
                }),
                datatype: "application/json",
                success: function (ret) {
                    $('#AbidzarFrameModalFormContentGrafik').html(ret);
                },
                error: function () {
                    $(this).modal('hide');
                    alertError("Failed to open form, please try again");
                }
            }).done(function (ret) {
                markRequired();
            });

            $('.description', this).text(data.itemDescription);
            $('#btnSaveForm', this).data('urlAction', data.urlAction);
        }
    });

    function doUpdateFormWithRefresh(url) {
        $('div#AbidzarFrameModalFormContentWithRefresh').children().each(function (e) {
            var nodeName = this.nodeName.toLowerCase();
            if (nodeName == "form") {
                if ($(this).valid()) {
                    $.ajax({
                        async: true,
                        url: url,
                        type: 'post',
                        dataType: 'json',
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({
                            model: $(this).serializeObject()
                        }),
                        success: function (ret) {
                            if (ret.Msg != null && ret.Msg != "") {
                                if (typeof dataTable !== 'undefined') {
                                    if (dataTable != null) {
                                        //console.log('refresh');
                                        dataTable.ajax.reload();
                                    }
                                }
                                alertSuccess(ret.Msg);
                                $('#AbidzarFrameModalFormWithRefresh').modal('hide');
                                Refresh();
                            } else if (!ret.success) {
                                console.log(ret.errors);
                                $.each(ret.errors, function (index, value) {
                                    // Error message
                                    var validationMessageElement = $('span[data-valmsg-for="' + index + '"]');
                                    validationMessageElement.removeClass('field-validation-valid');
                                    validationMessageElement.addClass('field-validation-error');
                                    validationMessageElement.text(value[0]);
                                });
                            }
                            else {
                                var msg = ret ? $.parseJSON(ret) : null; alertError(msg.ErrorMessage);
                            }

                        },
                        error: function (jqXHR, exception) {
                            // dicomment karna error json udah dicover di fungsi ajaxError
                            //var msg = ret ? $.parseJSON(ret) : null;
                            //alertError(msg.ErrorMessage);
                            if (typeof dataTable !== 'undefined') {
                                if (dataTable != null) {
                                    dataTable.ajax.reload();
                                }
                            }
                        }
                    });
                }
            }
        });
    }

    $('#AbidzarFrameModalFormWithRefresh').on('show.bs.modal', function (e) {
        if (e.target.id == 'AbidzarFrameModalFormWithRefresh') {
            var data = $(e.relatedTarget).data();
            $.ajax({
                async: true,
                type: "POST",
                url: data.url,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    id: data.itemId
                }),
                datatype: "application/json",
                success: function (ret) {
                    $('#AbidzarFrameModalFormContentWithRefresh').html(ret);
                },
                error: function () {
                    $(this).modal('hide');
                    alertError("Failed to open form, please try again");
                }
            }).done(function (ret) {
                markRequired();
            });

            $('.description', this).text(data.itemDescription);
            $('#btnSaveForm', this).data('urlAction', data.urlAction);
        }
    });

    $('#AbidzarFrameModalFormWithRefresh').on('click', '#btnSaveForm', function (e) {
        var $modalDiv = $(e.delegateTarget);
        var url = $(this).data('urlAction');
        doUpdateFormWithRefresh(url);
    });

    $('#confirm-delete-refresh').on('show.bs.modal', function (e) {
        var data = $(e.relatedTarget).data();
        //$('.description', this).text(data.itemDescription);
        $('#btnContinueDeleteRefresh', this).data('itemId', data.itemId);
        $('#btnContinueDeleteRefresh', this).data('url', data.url);
    });

    $('#confirm-delete-refresh').on('click', '#btnContinueDeleteRefresh', function (e) {
        var $modalDiv = $(e.delegateTarget);
        var id = $(this).data('itemId');
        var url = $(this).data('url');
        $.ajax({
            async: true,
            url: url,
            type: 'post',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                id: id
            }),
            success: function (ret) {
                $modalDiv.modal('hide');
                if (typeof dataTable !== 'undefined') {
                    if (dataTable != null) {
                        dataTable.ajax.reload();
                    }
                }
                alertSuccess(ret.Msg);
                Refresh();
            },
            error: function (ret) {
                //var msg = ret ? $.parseJSON(ret) : null; alertError(msg.ErrorMessage);
                if (typeof dataTable !== 'undefined') {
                    if (dataTable != null) {
                        dataTable.ajax.reload();
                    }
                }
            }
        });
    });

    $('#AbidzarFrameModalFormView').on('show.bs.modal', function (e) {
        if (e.target.id == 'AbidzarFrameModalFormView') {
            var data = $(e.relatedTarget).data();
            $.ajax({
                async: true,
                type: "POST",
                url: data.url,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    id: data.itemId
                }),
                datatype: "application/json",
                success: function (ret) {
                    $('#AbidzarFrameModalFormContentView').html(ret);
                },
                error: function () {
                    $(this).modal('hide');
                    alertError("Failed to open form, please try again");
                }
            }).done(function (ret) {
                markRequired();
            });

            $('.description', this).text(data.itemDescription);
        }
    });


});

function Refresh() {
    window.location.reload(true);
}

function markRequired() {
    //('input[type=text]').each(function () {
    $('input, textarea, select').each(function () {
        var req = $(this).attr('data-val-required');
        var req2 = $(this).attr('aria-required');
        if (undefined != req || undefined != req2) {
            var label = $('label[for="' + $(this).attr('id') + '"]');

            if (label.length > 0) {
                label = label.first();
            }

            var text = label.text().replace('*', '').trim();
            if (text.length > 0) {
                label.html(text + '<span style="color:red" id="mdtMark"> *</span>');
            } else {
                if ($('#mdtMark').length > 0) {
                    $('#mdtMark').remove();
                }
            }
        }
    });
}

function markRequiredWrapper(div) {
    //('input[type=text]').each(function () {
    $(div + ' input,textarea,select').each(function () {
        var req = $(this).attr('data-val-required');

        if (undefined != req) {
            var label = $('label[for="' + $(this).attr('id') + '"]');

            if (label.length > 0) {
                label = label.first();
            }

            var text = label.text().replace('*', '').trim();
            if (text.length > 0) {
                label.html(text + '<span style="color:red"> *</span>');
            }
        }
    });
}

function toastrOptions() {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "positionClass": "toast-top-right",
        "onclick": function () { null },
        "showDuration": "5000",
        "hideDuration": "1000",
        "timeOut": "10000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

function alertSuccess(msg) {
    toastrOptions();
    toastr.success(msg);
}

function alertError(msg) {
    toastrOptions();
    toastr.error(msg);
}

function alertWarning(msg) {
    toastrOptions();
    toastr.warning(msg);
}

//[Tyo] function for getting serialize form
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

function getFormattedDate(date) {
    var tahun = date.getFullYear();

    var bulan = (1 + date.getMonth()).toString();
    bulan = bulan.length > 1 ? bulan : '0' + bulan;

    var hari = date.getDate().toString();
    hari = hari.length > 1 ? hari : '0' + hari;

    return hari + '-' + bulan + '-' + tahun;
}

function convertToCurrency(nStr) {
    if (nStr == null) {
        nStr = '0.00'
    }
    else {
        nStr += '';
    }

    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
    // return x1;
}

function getFormattedMonthYear(date) {
    var tahun = date.getFullYear();

    var bulan = (1 + date.getMonth()).toString();
    bulan = bulan.length > 1 ? bulan : '0' + bulan;

    var hari = date.getDate().toString();
    hari = hari.length > 1 ? hari : '0' + hari;

    return bulan + '-' + tahun;
}

function getFormattedDateTime(date) {
    var jam = date.getHours().toString();
    jam = jam.length > 1 ? jam : '0' + jam;

    var menit = date.getMinutes().toString();
    menit = menit.length > 1 ? menit : '0' + menit;

    var detik = date.getSeconds().toString();
    detik = detik.length > 1 ? detik : '0' + detik;

    return getFormattedDate(date) + ' ' + jam + ":" + menit + ":" + detik;
}


$(function () {
    try {
        $.validator.addMethod('date',
            function (value, element) {
                if (this.optional(element)) {
                    return true;
                }
                var ok = true;
                try {
                    ok = moment(value, "dd-mm-yyyy", true).isValid();
                } catch (err) {
                    ok = false;
                }
                return ok;
            });
    } catch (e) {
        alertError(e.message);
    }
});

function disabledAllFieldWrapper(div) {
    $(div).find('fieldset').each(function (e) {
        $(this).prop('disabled', true);
        $(this).find('[id$=_ButtonLookup]').addClass('disabled');
        $(this).find('[id$=_ButtonLookupClear]').addClass('disabled');
        $(this).find('[type="submit"]').remove();
        $(this).find('.btn-submit').remove();
    });

    $(div + ' input').each(function () {
        $(this).prop('disabled', true);
    });
}

function readOnlyAllFieldWrapper(div) {
    $(div).find('fieldset').each(function (e) {
        $(this).prop('readonly', true);
        $(this).find('[id$=_ButtonLookup]').addClass('disabled');
        $(this).find('[id$=_ButtonLookupClear]').addClass('disabled');
        $(this).find('[type="submit"]').remove();
        $(this).find('.btn-submit').remove();
        $(this).find('[type="button"]').remove();
    });

    $(div + ' input,textarea,select').each(function () {
        $(this).prop('readonly', true);
    });
}

function enabledAllFieldWrapper(div) {
    $(div).find('fieldset').each(function (e) {
        $(this).prop('disabled', false);
        $(this).find('[id$=_ButtonLookup]').removeClass('disabled');
        $(this).find('[id$=_ButtonLookupClear]').removeClass('disabled');
    });

    $(div + ' input,textarea,select').each(function () {
        $(this).prop('disabled', false);
    });
}

//Hide Loading Overlay
function hideLoading() {
    $(".bg_load").fadeOut("slow");
    $(".wrapper").fadeOut("slow");
}

//Show Loading Overlay
function showLoading() {
    $(".bg_load").fadeIn("slow");
    $(".wrapper").fadeIn("slow");
}

$(document).ajaxStart(function () {
    showLoading();
}).ajaxComplete(function () {
    hideLoading();
}).ajaxStop(function () {
    hideLoading();
    //}).ajaxSuccess(function () {
    //    hideLoading();
}).ajaxError(function (e, jqxhr, settings, exception) {
    e.stopPropagation();
    if (jqxhr != null) {
        console.log(jqxhr);
        $.each(jqxhr.responseJSON.ErrorMessages, function (key, value) {
            //$('input[name=' + key + ']').after('<span class="error">' + value + '</span>');
            if (key != null && key != "") {
                var validationMessageElement = $('span[data-valmsg-for="' + key + '"]');
                validationMessageElement.removeClass('field-validation-valid');
                validationMessageElement.addClass('field-validation-error');
                validationMessageElement.text(value[0]);
            } else {
                alertError(jqxhr.responseJSON.ErrorMessage);
            }
        });
    }
    hideLoading();
});

$.ajaxPrefilter(function (options, original_Options, jqXHR) {
    options.async = true;
});


