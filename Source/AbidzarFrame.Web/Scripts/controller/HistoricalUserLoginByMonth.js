var listObj = [];
var path = location.origin + "/HistoricalUserLogin/GetDataListBy/";
$.ajax({
    url: path,
    type: 'Post',
    data: { byValue: '2' },
    success: function (result) {
        console.log(result);
        var obj = result.HistoricalUserLoginResultList;
        for (var i = 0; i < obj.length; i++) {
            var singleObj = {};
            singleObj['Header'] = obj[i].Header;
            singleObj['Total'] = obj[i].Total;
            listObj.push(singleObj);
        }
        am4core.useTheme(am4themes_animated);
        var chart = am4core.create("chartdiv", am4charts.PieChart3D);

        chart.data = listObj;

        chart.innerRadius = am4core.percent(20);
        chart.depth = 90;

        chart.legend = new am4charts.Legend();
        chart.legend.position = "down";

        var series = chart.series.push(new am4charts.PieSeries3D());
        series.dataFields.value = "Total";
        series.dataFields.depthValue = "Total";
        series.dataFields.category = "Header";
    },
    error: function (jqXHR, textStatus, errorMessage) {
        console.log(errorMessage);
    }
});

