function openModal({url, modalSelector, data}) {
    const modal = $(modalSelector)

    $.ajax({
        method: 'GET',
        url: url,
        data: data,
        success: (res) => {
            modal.html(res)

            M.Modal.init(modal)
            M.Modal.getInstance(modal).open()
            M.updateTextFields();
        },
        error: (res) => {
            alert(res.errorText)
        }
    })
}

function openDatepicker({datepickerSelector}) {
    const datepicker = $(datepickerSelector)

    M.Datepicker.init(datepicker, {
        yearRange: [1900, new Date(Date.now()).getFullYear()],
        format: 'mmmm dd, yyyy',
        maxDate: new Date(Date.now())
    })
    M.Datepicker.getInstance(datepicker).open()
}