
function payMethodRadio(value) {
    var paymentMethod = "";

    if (value == "Cod")
        paymentMethod = "Cod"

    else
        paymentMethod = "Card"

    jQuery("#payMethod").val(paymentMethod.toString());
}

