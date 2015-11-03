if (!library)
    var library = {};

library.json = {
    replacer: function (match, pIndent, pKey, pVal, pEnd) {
        var key = '<span class=json-key>';
        var val = '<span class=json-value>';
        var str = '<span class=json-string>';
        var r = pIndent || '';
        if (pKey)
            r = r + key + pKey.replace(/[": ]/g, '') + '</span>: ';
        if (pVal)
            r = r + (pVal[0] == '"' ? str : val) + pVal + '</span>';
        return r + (pEnd || '');
    },
    prettyPrint: function (obj) {
        var jsonLine = /^( *)("[\w]+": )?("[^"]*"|[\w.+-]*)?([,[{])?$/mg;
        return JSON.stringify(obj, null, 3)
          .replace(/&/g, '&amp;').replace(/\\"/g, '&quot;')
          .replace(/</g, '&lt;').replace(/>/g, '&gt;')
          .replace(jsonLine, library.json.replacer);
    }
};

$(function () {

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true
    });

    if ($('#IsError').val() == 'true') {
        scrollToElement('.prettyprint', 1000);
    }

    $('#CountryId').change(function () {
        $.get($(this).attr('data-url'), {
            countryID: $(this).val()
        }, function (data) {

            $("#StateId").empty()
              .append('<option selected="selected" value="">Select State</option>');

            $.each(data, function (index, item) {
                $("#StateId").append('<option value="' + item.Id + '">' + item.ShortTitle + '</option>');
            });
        });
    })


    /* Fill the state select list based on country */
    $('#SectorId').change(function () {

        $.get($(this).attr('data-url'), {
            parentSectorID: $(this).val()
        },
          function (data) {
              $("#SubSectorId").empty()
                .append('<option selected="selected"  value="">Select Sub-Sector</option>');

              $.each(data, function (index, item) {
                  $("#SubSectorId").append('<option value="' + item.Id + '">' + item.Name + '</option>')
              })
          }
        )
    })


})

function scrollToElement(selector, time, verticalOffset) {
    time = typeof (time) != 'undefined' ? time : 1000;
    verticalOffset = typeof (verticalOffset) != 'undefined' ? verticalOffset : 0;
    element = $(selector);
    offset = element.offset();
    offsetTop = offset.top + verticalOffset;
    $('html, body').animate({
        scrollTop: offsetTop
    }, time);
}