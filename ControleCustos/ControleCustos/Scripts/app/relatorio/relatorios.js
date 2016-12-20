var relatorios = {}

relatorios.gerarDadosGraficoQuantidadeRecursos = function () {
    return $.get("/relatorio/gerarDadosGraficoQuantidadeRecursos");
}

relatorios.gerarDadosGraficoCustoPorFaturamento = function () {
    return $.get("/relatorio/gerarDadosGraficoCustoPorFaturamento");
}