
    var liveToastBtn = document.getElementById('liveToastBtn');
    var liveToast = new bootstrap.Toast(document.getElementById('liveToast'));

    liveToastBtn.addEventListener('click', function () {
        liveToast.show();
    });

