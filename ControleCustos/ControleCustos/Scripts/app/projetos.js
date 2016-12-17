var projetos = {};

projetos.carregarListaDeProjetos = function () {
    $.ajax({
        url: '/Projeto/ListaProjetosFiltrada',
        type: 'GET'
    })
    .then(function (resultado) {
        $('#projetos-lista').html(resultado);
    })
    .fail(function (erro) {
        console.error(erro);
    });
}

projetos.iniciar = function () {
    projetos.carregarListaDeProjetos();
}