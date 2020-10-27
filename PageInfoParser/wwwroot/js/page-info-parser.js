$(document).ready(function () {
    $("#infoParser").click(function () {
        var pageList = $("#pagesList").val();
        var urlList = pageList.split('\n');
        removeHiddenAttr();

        $.when($(urlList).each(function(index, value) {
            $.ajax({
                type: "POST",
                url: "home/pageInfoUpload",
                data: { pageUrl: value },
                dataType: "text",
                success: function(data) {
                    $('#infoPreloader').hide();
                    addTableElement(data, value);
                    $('#infoPreloader').show();
                },
                error: onError
            });
        }));
    });

    $(document).ajaxStop(function () {
        $('#infoPreloader').hide();
    });

    function removeHiddenAttr() {
        $('#results').removeAttr('hidden');
        $('#infoPreloader').removeAttr('hidden');
    }

    function addTableElement(data, value) {
        var pageInfo = JSON.parse(data);
        $("#pageResults").append("<tr><td>" + pageInfo["title"] + " => " + value + "</td><td>" + pageInfo["statusCode"] + "</td></tr>");
    }

    function onError(data) {
        console.log(data);
    }
});