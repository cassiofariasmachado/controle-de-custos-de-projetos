let listagemRecursos = {};

listagemRecursos.paginaAtual = 1;
listagemRecursos.urlRecursosCompartilhados = 'CarregarListaDeRecursosCompartilhados';
listagemRecursos.urlServicos = 'CarregarListaDeServicos';
listagemRecursos.urlPatrimonios = 'CarregarListaDePatrimonios';
listagemRecursos.urlEditarRecurso = 'EditarRecurso';
listagemRecursos.$lista = $('#recurso-lista');
listagemRecursos.$selectPatrimonio = $('#patrimonio');
listagemRecursos.$selectCompartilhado = $('#compartilhado');
listagemRecursos.$selectServico = $('#servico');
listagemRecursos.$botaoVoltar;
listagemRecursos.$botaoAvancar;

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
        listagemRecursos.carregarListaDeRecursos();
    }
};

listagemRecursos.avancarPagina = function () {
    listagemRecursos.paginaAtual++;
    listagemRecursos.carregarListaDeRecursos();
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
    });
    listagemRecursos.$selectPatrimonio.click(function () {
        listagemRecursos.iniciarLista(listagemRecursos.urlPatrimonios);
    });
    listagemRecursos.$selectServico.click(function () {
        listagemRecursos.iniciarLista(listagemRecursos.urlServicos);
    });
};

listagemRecursos.editar = function (id) {
    $('#exampleModal').on('show.bs.modal', function (event) {
        let button = $(event.relatedTarget)
        let recipient = button.data('whatever');
        let idModal = $('#id-modal');
        idModal.text(id);
        let modal = $(this);
        modal.find('.modal-title').text('New message to ' + recipient);
        modal.find('.modal-body input').val(recipient);
    })
}


listagemRecursos.iniciar = function () {
    listagemRecursos.iniciarEscutaDoSelect();
};