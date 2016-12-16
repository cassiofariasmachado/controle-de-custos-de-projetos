let listagemRecursos = {};

listagemRecursos.paginaAtual = 0;
listagemRecursos.lista = $('recurso-lista');

listagemRecursos.carregarListaDeRecursos = function () {
    $.ajax({
        url: 'CarregarListaDeRecursos',
        type: 'GET',
        data: {
            pagina: listagemRecursos.paginaAtual
        }
    })
    .then(function (resultado) {
        lista.html(resultado);
        listagemRecursos.atualizarBotoesDeNavegacao();
    })
}

listagemRecursos.voltarPagina = function () {
    if (listagemRecursos.paginaAtual > 0) {
        listagemRecursos.paginaAtual--;
        listagemRecursos.carregarListaDeRecursos();
    }
}

listagemRecursos.avancarPagina = function () {
    listagemRecursos.paginaAtual++;
    listagemRecursos.carregarListaDeRecursos();
}

listagemRecursos.atualizarBotoesDeNavegacao = function () {
    listagemRecursos.$btnVoltarPagina.attr('disabled', listagemRecursos.paginaAtual === 0);

    listagemRecursos.$btnAvancarPagina.attr('disabled', ultimaPagina);
}

listagemRecursos.configurarBotoesDeNavegacao = function () {
    listagemRecursos.$btnVoltarPagina.click(listagemRecursos.voltarPagina);
    listagemRecursos.$btnAvancarPagina.click(listagemRecursos.avancarPagina);
}

listagemRecursos.iniciar = function () {
    listagemRecursos.$btnVoltarPagina = $("#btn-voltar-pagina");
    listagemRecursos.$btnAvancarPagina = $("#btn-avancar-pagina");

    listagemRecursos.configurarBotoesDeNavegacao();

    listagemRecursos.carregarListaDeRecursos();
}