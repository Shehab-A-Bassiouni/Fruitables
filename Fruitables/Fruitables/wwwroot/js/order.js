var elementObj = document.getElementById("order-link");

$('#order-link').click(function loadPartialView() {
    $.ajax({
        url: '/DashboardOrder/Index',
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


function changeshippingState(orderId) {


    var newShippingState = $('#newShippingState').prop('checked');

    $.ajax({
        url: $('#updateShippingForm').attr('action'),
        type: 'POST',
        data: { orderId: orderId, newShippingState: newShippingState },
        success: function (response) {
            // Handle success
            alert('Shipping state updated successfully');
            // Reload the table content
            $('#mainContainer').load('/DashboardOrder/Index');
        },
        error: function (xhr, status, error) {
            // Handle error
            console.error(error);
        }
    });
}