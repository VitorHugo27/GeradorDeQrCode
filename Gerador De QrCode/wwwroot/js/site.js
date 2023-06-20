$(document).ready(function () {
    // Quando o botão de download for clicado
    $('#btnDownload').click(function () {
        // Obter a URL da imagem do QR code
        var qrCodeUrl = $('#qrCodeImage').attr('src');

        // Extrair o nome do arquivo do URL
        var fileName = qrCodeUrl.substring(qrCodeUrl.lastIndexOf('/') + 1);

        // Criar um elemento <a> temporário
        var link = document.createElement('a');
        link.href = qrCodeUrl;
        link.download = fileName;

        // Adicionar o elemento <a> temporário à página e disparar o evento de clique
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    });
});