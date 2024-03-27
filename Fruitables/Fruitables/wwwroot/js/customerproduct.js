
let rangeObj = document.getElementById("rangeInput");
console.log(rangeObj);

rangeObj.addEventListener('change', function () {

    let seachKey = document.getElementById("searchinput").value;
    var rangeValue = parseInt(rangeObj.value);
    let categppp = $('input[name="categoryRadio"]:checked').val();

    let sellerID = document.getElementById("sellerIDinput").value;


    $.ajax({
        url: '/Product/Productfilter',
        type: 'GET',
        data: {
            pName: seachKey,
            categID: categppp,
            sellerID: sellerID,
            filterPrice: rangeValue,
            pageNumber: 1,

        },
        success: function (response) {
            $('#largeproductDiv').html(response); // Replace the content of the body with the response
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });


    //var rangeValue = parseInt(rangeObj.value);




    //fetch(`/Product/Product?maxPrice=${rangeValue}`, {
    //    method: "GET",
    //    headers: { "Content-Type": "application/json" }
    //}).then(function (response) {
    //    window.location.href = response.url

    //}).catch(function (err) {
    //    console.log(err); 
    //});


});

//function onclickCategory(c) {
//     return getRequestwithoptions(1)
//}


function oncchangeInputs() {
    let seachKey = document.getElementById("searchinput").value;
    var rangeValue = parseInt(rangeObj.value);
    let categppp = $('input[name="categoryRadio"]:checked').val();

    let sellerID = document.getElementById("sellerIDinput").value;


    $.ajax({
        url: '/Product/Productfilter',
        type: 'GET',
        data: {
            pName: seachKey,
            categID: categppp,
            sellerID: sellerID,
            filterPrice: rangeValue,
            pageNumber: 1,

        },
        success: function (response) {
            $('#largeproductDiv').html(response); // Replace the content of the body with the response
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });

}

$('#searchbutton').click(function () {
    let seachKey = document.getElementById("searchinput").value;
    var rangeValue = parseInt(rangeObj.value);
    let categppp = $('input[name="categoryRadio"]:checked').val();

    let sellerID = document.getElementById("sellerIDinput").value;


    $.ajax({
        url: '/Product/Productfilter',
        type: 'GET',
        data: {
            pName: seachKey,
            categID: categppp,
            sellerID: sellerID,
            filterPrice: rangeValue,
            pageNumber: 1,

        },
        success: function (response) {
            $('#largeproductDiv').html(response); // Replace the content of the body with the response
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
});


function onclickPagination(pageNumber) {

    let seachKey = document.getElementById("searchinput").value;
    var rangeValue = parseInt(rangeObj.value);
    let categppp = $('input[name="categoryRadio"]:checked').val();

    let sellerID = document.getElementById("sellerIDinput").value;


    $.ajax({
        url: '/Product/Productfilter',
        type: 'GET',
        data: {
            pName: seachKey,
            categID: categppp,
            sellerID: sellerID,
            filterPrice: rangeValue,
            pageNumber: pageNumber,

        },
        success: function (response) {
            $('#productDiv').html(response); // Replace the content of the body with the response
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });

}