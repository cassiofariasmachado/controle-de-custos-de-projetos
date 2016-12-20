$(() => {
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
});

$("#botao-busca").click(function (event) {
    event.preventDefault();
    let filtro = $('#caixa-busca').val();

    $.ajax({
        url: '/Projeto/ListaProjetosFiltrada',
        data: { "filtro": filtro },
        success: function (data) {
            $("#projetos-lista").html(data);
        }
    });
});