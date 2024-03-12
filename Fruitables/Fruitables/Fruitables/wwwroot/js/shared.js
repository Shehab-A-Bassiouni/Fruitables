
jQuery(".cart-btn").on("click",function () {

         
    let data = localStorage.getItem('cart');
    jQuery.noConflict();
    jQuery.ajax({

        type: 'POST',
        url: '/Cart/Cart',
        data: data,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            prompt("Success");
        },
        error: function (error) {
            prompt("Error");
        }
    });
});
    






