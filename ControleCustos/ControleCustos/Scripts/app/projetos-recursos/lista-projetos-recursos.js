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

$("#select-tipo").change(function (event) {
  event.preventDefault();
  let filtro = $('#select-tipo').val();
  listaProjetosRecursos.abrirSpinner();

  switch (filtro) {
    case "patrimonio":
      listaProjetosRecursos.buscarPatrimonios();
      break;
    case "compartilhado":
      listaProjetosRecursos.buscarCompartilhados();
      break;
    case "servico":
      listaProjetosRecursos.buscarServicos();
      break;
    default:
      listaProjetosRecursos.buscarTodos();
      break;
  }
});

listaProjetosRecursos.buscarTodos = function () {
  $.get('/Projeto/CarregarListaDeRecursosDoProjeto', { idProjeto: $('#id-projeto').data("id-projeto") },
      function (retorno) {
        listaProjetosRecursos.fecharSpinner();
        $("#projeto-recursos-lista").html(retorno);
      });
};

listaProjetosRecursos.buscarPatrimonios = function () {
  $.get('/Projeto/CarregarListaDePatrimoniosDoProjeto', { idProjeto: $('#id-projeto').data("id-projeto") },
      function (retorno) {
        listaProjetosRecursos.fecharSpinner();
        $("#projeto-recursos-lista").html(retorno);
      });
};

listaProjetosRecursos.buscarCompartilhados = function () {
  $.get('/Projeto/CarregarListaDeCompartilhadosDoProjeto', { idProjeto: $('#id-projeto').data("id-projeto") },
      function (retorno) {
        listaProjetosRecursos.fecharSpinner();
        $("#projeto-recursos-lista").html(retorno);
      });
};

listaProjetosRecursos.buscarServicos = function () {
  $.get('/Projeto/CarregarListaDeServicosDoProjeto', { idProjeto: $('#id-projeto').data("id-projeto") },
      function (retorno) {
        listaProjetosRecursos.fecharSpinner();
        $("#projeto-recursos-lista").html(retorno);
      });
};

listaProjetosRecursos.abrirSpinner = function () {
  $('#projeto-recursos-lista').addClass('hide');
  $('.spinner').removeClass('hide');
}

listaProjetosRecursos.fecharSpinner = function () {
  $('.spinner').addClass('hide');
  $('#projeto-recursos-lista').removeClass('hide');
}