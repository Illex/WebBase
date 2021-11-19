function callGetSchedule() {
    $.ajax({
        type: 'POST',
        url: '/SlotsController/GetSchedule/',
        data: { a: 'data1', b: 'data2' }
    }).done(function (data) { alert("got message back") });
}


