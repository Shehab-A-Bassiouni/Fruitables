let Chartsarr = [];
$(document).ready(function () {
    var today = new Date();
    $('#nextYear').hide();
    $('#nextYear2').hide();

    drawChart(today.getFullYear());

    console.log(Chartsarr);

    DrawBestSellingProducts(today.getFullYear());
    DrawBestSellers(today.getFullYear())

});

$('#nextYear').click(function () {
    var today = new Date();
    var yearSpan = document.getElementById("yearSpan");
    var year = yearSpan.textContent;
    var newYear = parseInt(year) + 1;
    if (newYear >= today.getFullYear()) {
        $('#nextYear').hide();
    }
    drawChart(newYear);
});
$('#nextYear2').click(function () {
    var today = new Date();
    var yearSpan = document.getElementById("yearSpan2");
    var year = yearSpan.textContent;
    var newYear = parseInt(year) + 1;
    if (newYear >= today.getFullYear()) {
        $('#nextYear2').hide();
    }
    DrawBestSellingProducts(newYear);
});

$('#nextYear3').click(function () {
    var today = new Date();
    var yearSpan = document.getElementById("yearSpan3");
    var year = yearSpan.textContent;
    var newYear = parseInt(year) + 1;
    if (newYear >= today.getFullYear()) {
        $('#nextYear3').hide();
    }
    DrawBestSellers(newYear);
});

$('#prevYear').click(function () {

    var today = new Date();
    var yearSpan = document.getElementById("yearSpan");
    var year = yearSpan.textContent;
    var newYear = parseInt(year) - 1;
    if (newYear < today.getFullYear()) {
        $('#nextYear').show();
    }
    drawChart(newYear);


});

$('#prevYear2').click(function () {

    var today = new Date();
    var yearSpan = document.getElementById("yearSpan2");
    var year = yearSpan.textContent;
    var newYear = parseInt(year) - 1
    if (newYear < today.getFullYear()) {

        $('#nextYear2').show();
    }
    DrawBestSellingProducts(newYear);


});

$('#prevYear3').click(function () {

    var today = new Date();
    var yearSpan = document.getElementById("yearSpan3");
    var year = yearSpan.textContent;
    var newYear = parseInt(year) - 1
    if (newYear < today.getFullYear()) {

        $('#nextYear3').show();
    }
    DrawBestSellers(newYear);


});

function drawChart(newYear) {
    $('#yearSpan').html(newYear);

    $.ajax({
        url: `/Dashboard/GetMonthSalesData`,
        type: 'GET',
        data: {
            year: newYear
        },

        success: function (data) {
            console.log(data)
            if (Chartsarr.length > 0) {
                Chartsarr[0].destroy();
                Chartsarr.pop();
            }

            let firstcahrtData = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

            for (var i of data) {
                console.log(i)
                firstcahrtData[i.Month - 1] = i.TotalSales
            }
            console.log(firstcahrtData)
            var ctx2 = document.getElementById("chart-line").getContext("2d");


            var gradientStroke1 = ctx2.createLinearGradient(0, 230, 0, 50);

            gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');
            gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');
            gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)'); //purple colors

            var gradientStroke2 = ctx2.createLinearGradient(0, 230, 0, 50);

            gradientStroke2.addColorStop(1, 'rgba(20,23,39,0.2)');
            gradientStroke2.addColorStop(0.2, 'rgba(72,72,176,0.0)');
            gradientStroke2.addColorStop(0, 'rgba(20,23,39,0)'); //purple colors

            var newchart = new Chart(ctx2, {
                type: "line",
                data: {
                    labels: ["Jan", "Feb", "March", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                    datasets: [{
                        label: "Sales Per Month",
                        tension: 0.4,
                        borderWidth: 0,
                        pointRadius: 1,
                        borderColor: "#cb0c9f",
                        borderWidth: 3,
                        backgroundColor: gradientStroke1,
                        fill: true,
                        data: firstcahrtData,
                        maxBarThickness: 6

                    },
                    {
                        label: "",
                        tension: 0.4,
                        borderWidth: 0,
                        pointRadius: 0,
                        borderColor: "#3A416F",
                        borderWidth: 3,
                        backgroundColor: gradientStroke2,
                        fill: true,
                        data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                        maxBarThickness: 6
                    },
                    ],
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            display: false,
                        }
                    },
                    interaction: {
                        intersect: false,
                        mode: 'index',
                    },
                    scales: {
                        y: {
                            grid: {
                                drawBorder: false,
                                display: true,
                                drawOnChartArea: true,
                                drawTicks: false,
                                borderDash: [5, 5]
                            },
                            ticks: {
                                display: true,
                                padding: 10,
                                color: '#b2b9bf',
                                font: {
                                    size: 11,
                                    family: "Open Sans",
                                    style: 'normal',
                                    lineHeight: 2
                                },
                            }
                        },
                        x: {
                            grid: {
                                drawBorder: false,
                                display: false,
                                drawOnChartArea: false,
                                drawTicks: false,
                                borderDash: [5, 5]
                            },
                            ticks: {
                                display: true,
                                color: '#b2b9bf',
                                padding: 20,
                                font: {
                                    size: 11,
                                    family: "Open Sans",
                                    style: 'normal',
                                    lineHeight: 2
                                },
                            }
                        },
                    },
                },
            });

            Chartsarr.push(newchart)

        },
        error: function (error) {
            console.log(error);
        }
    });

}

function DrawBestSellingProducts(year) {
    $('#yearSpan2').html(year);
    $.ajax({
        url: `/Dashboard/bestSelling`,
        type: 'GET',
        data: {
            year: year
        },

        success: function (data) {
            console.log(data)
            $('#bestsellingdiv').html(data)

        },
        error: function (error) {
            console.log(error);
        }
    });
}




function DrawBestSellers(year) {
    $('#yearSpan2').html(year);
    $.ajax({
        url: `/Dashboard/bestSellers`,
        type: 'GET',
        data: {
            year: year
        },

        success: function (data) {
            console.log(data)
            $('#bestsellersdiv').html(data)

        },
        error: function (error) {
            console.log(error);
        }
    });
}
