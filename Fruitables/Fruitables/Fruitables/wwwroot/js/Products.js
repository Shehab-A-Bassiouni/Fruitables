
   
        jQuery("#liveToastBtn").on("click",function () {
            
            const liveToast = new bootstrap.Toast(document.getElementById('liveToast'));
            let cart = JSON.parse(localStorage.getItem('cart')) || [];
            cart.push(String(jQuery("#liveToastBtn").attr("value")));
                localStorage.setItem('cart', JSON.stringify(cart));
                liveToast.show();
        });


    
    





