function updateQuantity(itemID, op) {
    var data = {
        ItemID: itemID.toString(),
        Op: op
    };

    jQuery.ajax({
        url: "/Cart/QuantityChange",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (response) {
            jQuery(`#quantityTag_${itemID.toString()}`).val(`${response.NewQuantity.toString()}`);
            jQuery(`#totalPriceTagAfter_${itemID.toString()}`).text(`${response.NewTotal.toString()} \u00A3`);
        },
      
    });
}
