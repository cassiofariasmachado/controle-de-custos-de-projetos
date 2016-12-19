google.charts.load('current', {
    'packages': ['corechart']
});

renderizarGraficos();

function renderizarGraficos() {
    relatorios.gerarDadosGraficoMenorCusto().then(function (response) {
        renderizarGrafico(gerarGraficoMenorCusto.bind(this, response.Dados));
    });

    relatorios.gerarDadosGraficoMaiorCusto().then(function (response) {
        renderizarGrafico(gerarGraficoMaiorCusto.bind(this, response.Dados));
    });
};

function gerarGraficoMenorCusto(dados) {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Topping');
    data.addColumn('number', 'Slices');
    data.addRows(dados);

    var options = {
        title: 'Gráfico de menor custo \n(percentual da diferença entre custo e faturamento previsto de projetos em andamento)',
        legend: { position: 'bottom', maxLines: 3 }
    };

    var chart = new google.visualization.PieChart(document.getElementById('grafico-menor-custo'));
    chart.draw(data, options);
}

function gerarGraficoMaiorCusto(dados) {
    var cabecalho = [
          ['Tipos', 'Custo', 'Valor faturado']
    ];

    var data = google.visualization.arrayToDataTable(cabecalho.concat(dados));

    var options = {
        title: 'Gráfico de maior custo \n(comparação de custo com valor faturado de projetos já encerrados)',
        isStacked: true,
        legend: { position: 'bottom', maxLines: 3 },
        colors: ['#516D7C', '#F99100'],
        bar: { groupWidth: '75%' },
        hAxis: {
            title: 'Projeto'
        },
        vAxis: {
            title: 'Valor faturado e custo (em reais)',
            format: 'R$ '
        }
    };

    var chart = new google.visualization.ColumnChart(document.getElementById('grafico-maior-custo'));
    chart.draw(data, options);
}

function renderizarGrafico(gerarGrafico) {
    google.charts.setOnLoadCallback(gerarGrafico);

    $(window).resize(function () {
        gerarGrafico();
    });
}