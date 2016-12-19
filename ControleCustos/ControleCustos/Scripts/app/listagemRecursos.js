let listagemRecursos = {};

listagemRecursos.paginaAtual = 1;
listagemRecursos.urlRecursosCompartilhados = 'CarregarListaDeRecursosCompartilhados';
listagemRecursos.urlServicos = 'CarregarListaDeServicos';
listagemRecursos.urlPatrimonios = 'CarregarListaDePatrimonios';
listagemRecursos.urlCarregarModal = 'CarregarModal';
listagemRecursos.$lista = $('#recurso-lista');
listagemRecursos.$recursoModal = $('#recurso-modal');
listagemRecursos.$selectPatrimonio = $('#patrimonio');
listagemRecursos.$selectCompartilhado = $('#compartilhado');
listagemRecursos.$selectServico = $('#servico');
listagemRecursos.$botaoVoltar;
listagemRecursos.$botaoAvancar;
listagemRecursos.urlDeContexto;

listagemRecursos.carregarListaDeRecursos = function (url) {
    $.get(url, { pagina: listagemRecursos.paginaAtual },
            function (resultado) {
                listagemRecursos.$lista.html(resultado);
                listagemRecursos.configurarBotoesDeNavegacao();
                listagemRecursos.atualizarBotoesDeNavegacao();
            });
};

listagemRecursos.voltarPagina = function () {
    if (listagemRecursos.paginaAtual > 0) {
        listagemRecursos.paginaAtual--;
        listagemRecursos.carregarListaDeRecursos(listagemRecursos.urlDeContexto);
    }
};

listagemRecursos.avancarPagina = function () {
    listagemRecursos.paginaAtual++;
    listagemRecursos.carregarListaDeRecursos(listagemRecursos.urlDeContexto);
};

listagemRecursos.atualizarBotoesDeNavegacao = function () {
    listagemRecursos.$botaoVoltar.prop('disabled', listagemRecursos.paginaAtual === 1);
    var ultimaPagina = !!$('#tabela').data("ultima-pagina");
    listagemRecursos.$botaoAvancar.attr('disabled', ultimaPagina);
};

listagemRecursos.configurarBotoesDeNavegacao = function () {
    listagemRecursos.$botaoVoltar = $('#voltar');
    listagemRecursos.$botaoAvancar = $('#avancar');
    listagemRecursos.$botaoVoltar.click(function () {
        listagemRecursos.voltarPagina();
    });
    listagemRecursos.$botaoAvancar.click(function () {
        listagemRecursos.avancarPagina();
    });
};

listagemRecursos.iniciarLista = function (url) {
    listagemRecursos.carregarListaDeRecursos(url);
};

listagemRecursos.iniciarEscutaDoSelect = function () {
    listagemRecursos.$selectCompartilhado.click(function () {
        listagemRecursos.iniciarLista(listagemRecursos.urlRecursosCompartilhados);
        listagemRecursos.urlDeContexto = listagemRecursos.urlRecursosCompartilhados;
    });
    listagemRecursos.$selectPatrimonio.click(function () {
        listagemRecursos.iniciarLista(listagemRecursos.urlPatrimonios);
        listagemRecursos.urlDeContexto = listagemRecursos.urlPatrimonios;
    });
    listagemRecursos.$selectServico.click(function () {
        listagemRecursos.iniciarLista(listagemRecursos.urlServicos);
        listagemRecursos.urlDeContexto = listagemRecursos.urlServicos;
    });
};

listagemRecursos.adicionarRecurso = function (id) {
    $.get(listagemRecursos.urlCarregarModal, { id: id }, function (resultado) {
        listagemRecursos.$recursoModal.html(resultado)
        $('#modal').modal();
    });
}

listagemRecursos.iniciar = function () {
    listagemRecursos.iniciarEscutaDoSelect();
};