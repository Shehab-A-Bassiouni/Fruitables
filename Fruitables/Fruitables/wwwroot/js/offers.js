var elementObj = document.getElementById("offers-link");
$('#offers-link').click(function loadPartialView() {
    $.ajax({
        url: '/DashboardOffer/Index',
        type: 'GET',
        success: function (response) {
            console.log(response);
            $('#mainContainer').html(response);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
})

function deleteDetails(OfferId) {
    $.ajax({
        url: '/DashboardOffer/Delete',
        type: 'POST',
        data: { id: OfferId },
        success: function (response) {
            $('#mainContainer').html(response);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
}

function getofferDetails(OfferId) {
    $.ajax({
        url: '/DashboardOffer/Details',
        type: 'GET',
        data: { id: OfferId },
        success: function (response) {
            $('#mainContainer').html(response);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
}

$('#editoffer').click(function () {
    $('#inputsDiv input').each(function () {

        $(this).prop('readOnly', false);
        $(this).css('border-color', '#050E1E');


    });
    $('#editoffer').prop('hidden', true);
    $('#saveoffer').prop('hidden', false);

});

$('#saveoffer').click(function () {
    $('#inputsDiv input').each(function () {

        $(this).prop('readOnly', true);
        $(this).css('border-color', '#99B4E2');


    });
    $('#editoffer').prop('hidden', false);
    $('#saveoffer').prop('hidden', true);

    let offerid = $('#offerID').val();
    let expirDate = $('#offerexpire').val();
    let discount = $('#offerdiscount').val();
    let description = $('#offerdescription').val();


    $.ajax({
        url: '/DashboardOffer/Edit',
        type: 'POST',
        data: {
            OfferId: offerid,
            Description: description,
            Discount: discount,
            ExpireDate: expirDate
        },
        success: function (response) {
            $('#mainContainer').html(response);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
});



$('#createOffer').click(function () {

    /*let offerid = $('#offerID').val();*/
    let expirDate = $('#offerexpire').val();
    let discount = $('#offerdiscount').val();
    let description = $('#offerdescription').val();


    $.ajax({
        url: '/DashboardOffer/Create',
        type: 'POST',
        data: {

            Description: description,
            Discount: discount,
            ExpireDate: expirDate
        },
        success: function (response) {
            $('#mainContainer').html(response);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
});


$('#newoffer').click(function loadPartialView() {
    $.ajax({
        url: '/DashboardOffer/Create',
        type: 'GET',
        success: function (response) {
            $('#mainContainer').html(response);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
})