lista = {}

$(() => {

    lista.abrirSpinner();

    $.ajax({
        url: '/Projeto/ListaProjetosFiltrada',
        type: 'GET'
    })

    .then(function (resultado) {
        lista.fecharSpinner();
        $('#projetos-lista').html(resultado);
    })
    .fail(function (erro) {
        console.error(erro);
    });
});

$("#botao-busca").click(function (event) {
    event.preventDefault();
    let filtro = $('#caixa-busca').val();

    lista.abrirSpinner();
    $.ajax({
        url: '/Projeto/ListaProjetosFiltrada',
        data: { "filtro": filtro },
        success: function (data) {
            lista.fecharSpinner();
            $("#projetos-lista").html(data);
        }
    });
});

lista.abrirSpinner = function () {
    $('#projetos-lista').addClass('hide');
    $('.spinner').removeClass('hide');
}

lista.fecharSpinner = function () {
    $('.spinner').addClass('hide');
    $('#projetos-lista').removeClass('hide');
}