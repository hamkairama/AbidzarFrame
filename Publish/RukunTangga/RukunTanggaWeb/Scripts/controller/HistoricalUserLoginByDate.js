var listObj = [];
var path = location.origin + "/HistoricalUserLogin/GetDataListBy/";
$.ajax({
    url: path,
    type: 'Post',
    data: { byValue: '1' },
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
        var chart = am4core.create("chartdiv", am4charts.XYChart3D);

        chart.data = listObj;
        var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
        categoryAxis.renderer.grid.template.location = 0;
        categoryAxis.dataFields.category = "Header";
        categoryAxis.renderer.minGridDistance = 60;
        categoryAxis.renderer.grid.template.disabled = true;
        categoryAxis.renderer.baseGrid.disabled = true;
        categoryAxis.renderer.labels.template.dy = 20;

        var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.renderer.grid.template.disabled = true;
        valueAxis.renderer.baseGrid.disabled = true;
        valueAxis.renderer.labels.template.disabled = true;
        valueAxis.renderer.minWidth = 0;

        var series = chart.series.push(new am4charts.ConeSeries());
        series.dataFields.categoryX = "Header";
        series.dataFields.valueY = "Total";
        series.columns.template.tooltipText = "{valueY.value}";
        series.columns.template.tooltipY = 0;
        series.columns.template.strokeOpacity = 1;

        // as by default columns of the same series are of the same color, we add adapter which takes colors from chart.colors color set
        series.columns.template.adapter.add("fill", function (fill, target) {
            return chart.colors.getIndex(target.dataItem.index);
        });

        series.columns.template.adapter.add("stroke", function (stroke, target) {
            return chart.colors.getIndex(target.dataItem.index);
        });
    },
    error: function (jqXHR, textStatus, errorMessage) {
        console.log(errorMessage);
    }
});




