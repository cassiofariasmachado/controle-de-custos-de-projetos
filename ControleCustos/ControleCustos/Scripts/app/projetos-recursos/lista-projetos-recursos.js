listaProjetosRecursos = {};

$idProjeto = $("id-projeto");

$(() => {

    listaProjetosRecursos.abrirSpinner();

    $.get('/Projeto/CarregarListaDeRecursosDoProjeto', { idProjeto: $('#id-projeto').data("id-projeto") },
        function (retorno) {
            listaProjetosRecursos.fecharSpinner();
            $("#projeto-recursos-lista").html(retorno);
        });
});

$("#botao-busca").click(function (event) {
    event.preventDefault();
    let filtro = $('#caixa-busca').val();

    listaProjetosRecursos.abrirSpinner();
    $.ajax({
        url: '/Projeto/CarregarListaDeRecursosDoProjeto',
        data: { "filtro": filtro },
        success: function (data) {
            listaProjetosRecursos.fecharSpinner();
            $("#projeto-recursos-lista").html(data);
        }
    });
});

listaProjetosRecursos.abrirSpinner = function () {
    $('#projeto-recursos-lista').addClass('hide');
    $('.spinner').removeClass('hide');
}

listaProjetosRecursos.fecharSpinner = function () {
    $('.spinner').addClass('hide');
    $('#projeto-recursos-lista').removeClass('hide');
}