function GetItems(url, target)
{
    target.text("");

    $.ajax({
        url: url,
        dataType: "json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Basic " + btoa($("input#user").val() + ":" + $("input#pass").val()));
        }
    }).done(function (data) {
        BuildTable(data, target);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        target.text(textStatus + " - " + errorThrown);
    });
}

function GoToItem(item, target)
{
    GetItems(item.href, target);
}

function BuildFileRow(item)
{
    var result = $("<tr/>");

    result.append(BuildTD(item.name));

    result.append(BuildTD(item.size));

    return result;
}

function BuildTD(value)
{
    var result = $("<td/>");
    result.append(value);
    return result;
}

function BuildFolderRow(item, target)
{
    var result = $("<tr/>");

    result.append(BuildTD(item.name));
    
    var goButton = $("<input type='button'/>");
    goButton.val(">>");
    goButton.click(function () { GoToItem(item, target); });

    result.append(BuildTD(goButton));

    return result;
}

function BuildTable(items, target)
{
    var table = $("<table/>");
    
    $.each(items, function (index, item) {
        if (item.mime == "inode/directory" || item.mime == "inode/shortcut")
            table.append(BuildFolderRow(item, target));
        else
            table.append(BuildFileRow(item));
    });

    target.html(table);
};

$(function () {
    var _urlPreffix = "https://";
    var _urlSuffix = ".scm.azurewebsites.net/api/vfs/";
    var resultDiv = $("div#result");

    $("input#go").click(function () {
        var url = _urlPreffix + $("input#webSite").val() + _urlSuffix;

        GetItems(url, resultDiv);
    });

});