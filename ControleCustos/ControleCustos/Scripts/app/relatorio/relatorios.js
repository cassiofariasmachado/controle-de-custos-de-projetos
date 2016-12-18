class Relatorios {

    gerarDadosGraficoMenorCusto() {
        return $.get("/relatorio/gerarGraficoMenorCusto");
    }

    gerarDadosGraficoMaiorCusto() {
        return $.get("/relatorio/gerarGraficoMaiorCusto");
    }
}