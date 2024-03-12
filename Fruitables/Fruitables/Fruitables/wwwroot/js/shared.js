const cart = document.getElementById("cart-btn");


cart.addEventListener('click', function () {
    try {
        $.ajax({
            type: 'POST', 
            url: '/Cart/Cart',
            data: { myValue: myValue },
            success: function (response) {
                console.log('Sent Succeefully');
            },
            error: function (error) {
                console.error('Error', error);
            }
        });
    }
    catch (e) {
        console.error('Error', e);
    }
});