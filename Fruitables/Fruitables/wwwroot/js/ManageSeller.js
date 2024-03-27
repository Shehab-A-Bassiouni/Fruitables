var elementObj = document.getElementById("Seller-link");
elementObj.addEventListener('click', function loadPartialView() {
    $.ajax({
        url: '/ManageSeller/GetAll',
        type: 'GET',
        success: function (response) {
            $('#mainContainer').html(response);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
})

//Edit Seller

  
$(document).ready(function () {
    $('#submitBtn').click(function (e) { // Capture the click event of the submit button
        e.preventDefault(); // Prevent default form submission

        var formData = $('#SellerEditForm').serialize(); // Serialize form data
        var id; // Make sure you set the id value here

        // Check if id is available
        if (id) {
            $.ajax({
                url: '/ManageSeller/Edit/' + id, // Update the URL to your controller action
                type: 'POST', // Use 'PUT' method for updating resource
                data: formData, // Send serialized form data
                success: function (response) {
                    // Handle success response (if any)
                    console.log(response);
                    // You can redirect or show a success message here
                },
                error: function (xhr, status, error) {
                    // Handle error response
                    console.error(xhr.responseText);
                    // You can display an error message here
                }
            });
        }
    });
});

//Details

function GetSellerDetails(Seller_Id) {

    $.ajax({
        url: 'ManageSeller/Details',
        type: 'GET',
        data: {
            id: Seller_Id
        },
        success: function (response) {
            // Render products dynamically
            $('#mainContainer').html(response);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            // Handle errors
        }
    });
}
   

   