var relatorios = {}

relatorios.gerarDadosGraficoMenorCusto = function () {
    return $.get("/relatorio/gerarGraficoMenorCusto");
}

relatorios.gerarDadosGraficoMaiorCusto = function () {
    return $.get("/relatorio/gerarGraficoMaiorCusto");
}