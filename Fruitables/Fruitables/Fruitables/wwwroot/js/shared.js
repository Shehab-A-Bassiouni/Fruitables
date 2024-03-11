const cart = document.getElementById("cart-btn");
data = JSON.parse(localStorage.getItem('cart'));


cart.addEventListener('click', function () {

    
    fetch('/Cart/Cart', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: myValueJSON,
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
            .then(data => {
                console.log('Value sent successfully.', data);
            })
            .catch(error => {
                console.error('Error sending value:', error);
            });
    
   
});