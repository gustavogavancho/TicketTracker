function saveAsFile(filename, bytesBase64, mimeType) {
    let link = document.createElement('a');
    link.download = filename;
    link.href = "data:" + mimeType + ";base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};

function saveAsZip(filename, data) {
    const blob = base64ToBlob(data);
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = filename;
    link.click();
}

function base64ToBlob(base64) {
    const byteCharacters = atob(base64);
    const byteArrays = [];
    for (let offset = 0; offset < byteCharacters.length; offset += 512) {
        const slice = byteCharacters.slice(offset, offset + 512);
        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }
    return new Blob(byteArrays, { type: 'application/zip' });
}

window.scrollUtils = {
    scrollToTop: function () {
        window.scrollTo(0, 0);
    }
};