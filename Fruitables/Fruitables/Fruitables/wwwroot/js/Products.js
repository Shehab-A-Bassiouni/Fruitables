
const liveToastBtn = document.getElementById('liveToastBtn');
const liveToast = new bootstrap.Toast(document.getElementById('liveToast'));

liveToastBtn.addEventListener('click', function () {
    try {

        let cart = JSON.parse(localStorage.getItem('cart')) || [];
        cart.push(String(liveToastBtn.getAttribute('value')));
        localStorage.setItem('cart', JSON.stringify(cart));
        liveToast.show();
    }
    catch (e) {
        console.error('Error', e);
    }
    });



