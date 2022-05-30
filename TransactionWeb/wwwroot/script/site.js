function ShowListView() {
    $('#ListView').show();
    $('#DetailView').hide();
    $('#CreateView').hide();
}

function ShowDetailView() {
    $('#DetailView').show();
    $('#ListView').hide();
    $('#CreateView').hide();
}

function ShowCreateView() {
    $('#ListView').hide();
    $('#DetailView').hide();
    $('#CreateView').show();
}

function StopPropagation(event) {
    event.stopPropagation();
}

$('a:first').click(function (event) { event.stopPropagation(); });

function countDown() {
    $('#timer').html(--i);

    if (i == 1) {
        $('#loadingBar').hide(1000);
    }

    if (i == 0) {
        location.href = './';
    }
}

function MainLayoutLoaded() {
    $('#blazor-host-ui').hide();
    clearInterval(interval);
}
function DisableButton() {
    var fewSeconds = 120;
    //$('#btnDeploy').click(function () {
        // Ajax request
    var btn = $('#btnDeploy');
        btn.prop('disabled', true);
        setTimeout(function () {
            btn.prop('disabled', false);
        }, fewSeconds * 1000);
    //});
}

function NavigateTo(virtualPath) {
    location.href = virtualPath;
}

function DownloadAnalyticsReport(filename, content) {
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = "data:application/octet-stream;base64," + content;
    a.download = filename;
    a.target = "_self";
    a.click();
    document.body.removeChild(a);
}

function PreviewPdf(content) {
    var atobData = atob(content);
    var num = new Array(atobData.length);
    for (var i = 0; i < atobData.length; i++) {
        num[i] = atobData.charCodeAt(i);
    }
    var pdfData = new Uint8Array(num);
    var blob = new Blob([pdfData], { type: 'application/pdf;base64' });
    var url = URL.createObjectURL(blob);
    window.open(url);
    URL.revokeObjectURL(url)
}