const phoneRegExp = /(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})\s*(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+)\s*)?$/

$(document).ready(function () {
    $(window).keydown(function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            return false;
        }
    });
});

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

function validate(el, param) {
    el = $(el)

    let isValid = false

    switch (param) {
        case 'name':
            isValid = el.val().trim().length > 2
            break;
        case 'phoneNumber':
            isValid = phoneRegExp.test(el.val().trim())
            break;
    }

    el.toggleClass('invalid', !isValid)
    el.toggleClass('valid', isValid)

    validateSendFormButton()
}

function validateSendFormButton() {
    const isValid =
        $('#full_name').attr('class').split(' ').includes('valid') &&
        $('#mobile_phone').attr('class').split(' ').includes('valid')

    $('#send-form-btn').prop('disabled', !isValid)
}