$(document).ready( function () {

    const data = localStorage.getItem('cart');

    $("#cart-btn").click(function () {



        $.ajax({
            type: 'POST',
            url: '/Cart/Cart',
            dataType: "json",
            traditional:true,
            contentType: 'application/json',
            data: { data: data },
            success: function (response) {
                prompt("Success");
            },
            error: function (error) {
                prompt("Error");
            }
        });
    });

});




