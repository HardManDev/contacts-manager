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

function validateName() {
    const nameInput = $('#full_name')
    const isValid = nameInput.val().trim().length > 2

    nameInput.toggleClass('invalid', !isValid)
    validateSendFormButton()
}

function validatePhoneNumber() {
    const phoneInput = $('#mobile_phone')
    const isValid = phoneRegExp.test(phoneInput.val().trim())

    phoneInput.toggleClass('invalid', !isValid)
    validateSendFormButton()
}

function validateSendFormButton() {
    const isValid =
        $('#full_name').attr('class').split(' ').includes('invalid') ||
        $('#mobile_phone').attr('class').split(' ').includes('invalid');

    $('#send-form-btn').toggleClass('disabled', isValid);
}