

function AddedCard() {
   

        const liveToast = new bootstrap.Toast(document.getElementById('liveToast'));
        try {
            liveToast.show();
        }
        catch (e) {
            prompt(e)
        }

    
}


jQuery(document).ready(function () {
    const alertList = document.querySelectorAll('.alert')
    const alerts = [...alertList].map(element => new bootstrap.Alert(element))
    alerts[0].alert();
});





