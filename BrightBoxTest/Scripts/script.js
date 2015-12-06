$(function () {
    $('.date-ru-input').datetimepicker({
        isRTL: false,
        format: 'DD.MM.YYYY HH:mm',
        autoclose: true,
        language: 'ru'
    });

    $('.date-ru-input').removeAttr("data-val-date");

    switchDisabled();
        
    $('#StatusKey').change(switchDisabled)

});

function switchDisabled() {
    if ($('#StatusKey').val() == 'AvailableWorkPlaned') {
        $('.date-ru-input').removeAttr('disabled');
    } else {
        $('.date-ru-input').attr('disabled', 'disabled');
    }
}