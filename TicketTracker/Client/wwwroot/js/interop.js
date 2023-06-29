window.saveAsFile = function (filename, bytesBase64, mimeType) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:" + mimeType + ";base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};