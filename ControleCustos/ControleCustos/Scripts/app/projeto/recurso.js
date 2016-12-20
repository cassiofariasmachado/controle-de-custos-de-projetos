let recurso = {};

recurso.paginaAtual = 1;
recurso.urlRecursosCompartilhados = '/Projeto/CarregarListaDeRecursosCompartilhados';
recurso.urlServicos = '/Projeto/CarregarListaDeServicos';
recurso.urlPatrimonios = '/Projeto/CarregarListaDePatrimonios';
recurso.urlCarregarModal = '/Projeto/CarregarModal';
recurso.urlCarregarListaDeRecursosDoProjeto = '/Projeto/CarregarListaDeRecursosDoProjeto';
recurso.$lista = $('#recurso-lista');
recurso.$listaRecursoDoPojeto = $('#recurso-lista-projeto');
recurso.$nomeRecurso = $('#nome-recurso');
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
recurso.idProjeto = $('#id-projeto').data("id-projeto");
recurso.$alertaModal;

recurso.carregarListaDeRecursos = function (url) {
  $.get(url, { pagina: recurso.paginaAtual },
          function (resultado) {
            recurso.$lista.html(resultado);
            recurso.configurarBotoesDeNavegacao();
            recurso.atualizarBotoesDeNavegacao();
            recurso.atualizarNomeRecurso();
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
  $("#select-tipo").change(function (event) {
    event.preventDefault();
    let $recursoSelecionado = $('#select-tipo').val();

    switch ($recursoSelecionado) {
      case 'compartilhado':
        recurso.carregarListaDeRecursos(recurso.urlRecursosCompartilhados);
        recurso.urlDeContexto = recurso.urlRecursosCompartilhados;
        break;
      case 'patrimonio':
        recurso.carregarListaDeRecursos(recurso.urlPatrimonios);
        recurso.urlDeContexto = recurso.urlPatrimonios;
        break;
      case 'servico':
        recurso.carregarListaDeRecursos(recurso.urlServicos);
        recurso.urlDeContexto = recurso.urlServicos;
        break;
    }
  })
};

recurso.escutarBotaoEnviarFormModal = function () {
  recurso.$botaoFormModal = $("#botao-form-modal");
  recurso.$botaoFormModal.click(function (evento) {
    evento.preventDefault();
    $.post('/Projeto/SalvarModalRecurso', recurso.formModal.serialize(), function (dados) {
      recurso.carregarListaDeRecursos(recurso.urlDeContexto);
      recurso.modal.modal('toggle');
      recurso.carregarListaDeRecursosDoProjeto();
      recurso.mensagem(dados);
    }).fail(function (erro) {
      recurso.alertaModal.css('display', 'block');
      recurso.alertaModal.html("Ocorreu um erro!");
      console.log(erro);
    });
  });
};

recurso.mensagem = function (mensagem) {
  recurso.$mensagem.html(mensagem);
  recurso.$mensagem.css('display', 'block');
  setTimeout(function () { recurso.$mensagem.css('display', 'none'); }, 5000);
};

recurso.adicionarRecurso = function (idRecurso) {
  $.get(recurso.urlCarregarModal, { idRecurso: idRecurso, idProjeto: recurso.idProjeto }, function (resultado) {
    recurso.$recursoModal.html(resultado);
    recurso.modal = $('#modal');
    recurso.modal.modal();
    recurso.formModal = $('#form-modal');
    recurso.escutarBotaoEnviarFormModal();
    recurso.alertaModal = $('#alerta-modal');
  });
};

recurso.atualizarNomeRecurso = function () {
  if (recurso.urlDeContexto === recurso.urlPatrimonios) {
    recurso.$nomeRecurso.html("Patrimônio");
  } else if (recurso.urlDeContexto === recurso.urlServicos) {
    recurso.$nomeRecurso.html("Serviço");
  } else if (recurso.urlDeContexto === recurso.urlRecursosCompartilhados) {
    recurso.$nomeRecurso.html("Compartilhado");
  }
};

recurso.carregarListaDeRecursosDoProjeto = function () {
  $.get(recurso.urlCarregarListaDeRecursosDoProjeto, { idProjeto: recurso.idProjeto },
      function (retorno) {
        recurso.$listaRecursoDoPojeto.html(retorno);
      });
}

recurso.iniciar = function () {
  recurso.iniciarEscutaDoSelect();
  recurso.carregarListaDeRecursos(recurso.urlPatrimonios);
  recurso.urlDeContexto = recurso.urlPatrimonios;
  recurso.carregarListaDeRecursosDoProjeto();
};
