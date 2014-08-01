function giveadmin(id) {
    var req = $.ajax({ url: '/site/giveadmin?u=' + id + "&act=giveadmin", dataType: "text" });
    req.done(function (data) {
        if (data != "OK") {
            alert("Unknown error!");
            window.location.reload();
        }
    });
}

function revokeadmin(id) {
    var req = $.ajax({ url: '/site/giveadmin?u=' + id + "&act=revokeadmin", dataType: "text" });
    req.done(function (data) {
        if (data != "OK") {
            alert("Unknown error!");
            window.location.reload();
        }
    });
}

function lock(id) {
    var req = $.ajax({ url: '/site/lockuser?u=' + id + "&act=lock", dataType: "text" });
    req.done(function(data) {
        if (data == "OK") {
            $("#row" + id).removeClass("success");
            $("#row" + id).addClass("danger");
        } else {
            alert("Unknown error!");
            window.location.reload();
        }
    });
}

function unlock(id) {
    var req = $.ajax({ url: '/site/lockuser?u=' + id + "&act=unlock", dataType: "text" });
    req.done(function (data) {
        if (data == "OK") {
            $("#row" + id).removeClass("danger");
            $("#row" + id).addClass("success");
        } else {
            alert("Unknown error!");
            window.location.reload();
        }
    });
}

function deletesite(id) {
    if (confirm("Are you sure?")) {
        var req = $.ajax({ url: '/site/delsite?id=' + id, dataType: "text" });
        req.done(function (data) {
            if (data == "OK") {
                window.location.reload();
            } else {
                $('#tab').html("Unknown error!");
            }
        });
    }
}

function togglesite(id) {
    var req = $.ajax({ url: '/site/togglesite?id=' + id, dataType: "text" });
    
    req.done(function (data) {
        if (data == "OK") {
            if ($("#row" + id).hasClass("success")) {
                $("#row" + id).removeClass("success");
                $("#row" + id).addClass("danger");
            } else {
                $("#row" + id).removeClass("danger");
                $("#row" + id).addClass("success");
            }
        } else {
            alert("Unknown Error");
        }
    });
}

function changepagesize(pagesizenew) {
    $('#pagesize').html(pagesizenew);

    var pagesize = $.cookie('isepam_stats_pagesize');
    if (pagesizenew != pagesize) {
        $.cookie('isepam_stats_pagesize', pagesizenew, { expires: 365 });
        window.location.reload();
    }
}

function loadScript(src, callbackfn) {
    var newScript = document.createElement("script");
    newScript.type = "text/javascript";
    newScript.setAttribute("async", "true");
    newScript.setAttribute("src", src);

    if (newScript.readyState) {
        newScript.onreadystatechange = function () {
            if (/loaded|complete/.test(newScript.readyState)) callbackfn();
        };
    } else {
        newScript.addEventListener("load", callbackfn, false);
    }
    document.documentElement.firstChild.appendChild(newScript);
}

function changePageState(a, b, c, d) {
    var history = window.History;
    if (!history.enabled) {
        return false;
    }
    history.replaceState(a, b, c, d);
    return false;
}

function errorShow(id) {
    if (id != '') {
        $.get('/stat/errordetail?id=' + id, function (data) {
            loadScript("/scripts/Prettify/run_prettify.js");
            $('#errordetailcontainer').html(data);
            $('#iderror').val("");
            $('#iderror').focus();
        });
        changePageState(null, document.title, "" + id);
    }
    return false;
}