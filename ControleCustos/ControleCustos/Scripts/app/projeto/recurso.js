let recurso = {};

recurso.paginaAtual = 1;
recurso.urlRecursosCompartilhados = '/Projeto/CarregarListaDeRecursosCompartilhados';
recurso.urlServicos = '/Projeto/CarregarListaDeServicos';
recurso.urlPatrimonios = '/Projeto/CarregarListaDePatrimonios';
recurso.urlCarregarModal = '/Projeto/CarregarModal';
recurso.$lista = $('#recurso-lista');
recurso.$recursoModal = $('#recurso-modal');
recurso.$selectPatrimonio = $('#patrimonio');
recurso.$selectCompartilhado = $('#compartilhado');
recurso.$selectServico = $('#servico');
recurso.$botaoFormModal;
recurso.$mensagem = $('#mensagem');
recurso.$botaoVoltar;
recurso.$botaoAvancar;
recurso.urlDeContexto;
recurso.modal;
recurso.formModal;
recurso.idProjeto;

recurso.carregarListaDeRecursos = function (url) {
    $.get(url, { pagina: recurso.paginaAtual },
            function (resultado) {
                recurso.$lista.html(resultado);
                recurso.configurarBotoesDeNavegacao();
                recurso.atualizarBotoesDeNavegacao();
            });
};

recurso.voltarPagina = function () {
    if (recurso.paginaAtual > 0) {
        recurso.paginaAtual--;
        recurso.carregarListaDeRecursos(recurso.urlDeContexto);
    }
};

recurso.avancarPagina = function () {
    recurso.paginaAtual++;
    recurso.carregarListaDeRecursos(recurso.urlDeContexto);
};

recurso.atualizarBotoesDeNavegacao = function () {
    recurso.$botaoVoltar.prop('disabled', recurso.paginaAtual === 1);
    var ultimaPagina = !!$('#tabela').data("ultima-pagina");
    recurso.$botaoAvancar.attr('disabled', ultimaPagina);
};

recurso.configurarBotoesDeNavegacao = function () {
    recurso.$botaoVoltar = $('#voltar');
    recurso.$botaoAvancar = $('#avancar');
    recurso.$botaoVoltar.click(function () {
        recurso.voltarPagina();
    });
    recurso.$botaoAvancar.click(function () {
        recurso.avancarPagina();
    });
};

recurso.iniciarEscutaDoSelect = function () {
    recurso.$selectCompartilhado.click(function () {
        recurso.carregarListaDeRecursos(recurso.urlRecursosCompartilhados);
        recurso.urlDeContexto = recurso.urlRecursosCompartilhados;
    });
    recurso.$selectPatrimonio.click(function () {
        recurso.carregarListaDeRecursos(recurso.urlPatrimonios);
        recurso.urlDeContexto = recurso.urlPatrimonios;
    });
    recurso.$selectServico.click(function () {
        recurso.carregarListaDeRecursos(recurso.urlServicos);
        recurso.urlDeContexto = recurso.urlServicos;
    });
};

recurso.escutarBotaoEnviarFormModal = function () {
    recurso.$botaoFormModal = $("#botao-form-modal");
    recurso.$botaoFormModal.click(function (evento) {
        evento.preventDefault();
        $.post('/Projeto/SalvarModalRecurso', recurso.formModal.serialize(), function (dados) {
            recurso.carregarListaDeRecursos(recurso.urlDeContexto);
            recurso.modal.modal('toggle');
            recurso.mensagem(dados);
        });
    });
};

recurso.mensagem = function (mensagem) {
    recurso.$mensagem.html(mensagem);
    recurso.$mensagem.css('display', 'block');
    setTimeout(function () { recurso.$mensagem.css('display', 'none'); }, 5000);
};

recurso.adicionarRecurso = function (idRecurso) {
    recurso.idProjeto = $('#id-projeto');
    let idProjeto = recurso.idProjeto.data("id-projeto");
    $.get(recurso.urlCarregarModal, { idRecurso: idRecurso, idProjeto: idProjeto }, function (resultado) {
        recurso.$recursoModal.html(resultado);
        recurso.modal = $('#modal');
        recurso.modal.modal();
        recurso.formModal = $('#form-modal');
        recurso.escutarBotaoEnviarFormModal();
    });
};

recurso.iniciar = function () {
    recurso.iniciarEscutaDoSelect();
};
