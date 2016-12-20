google.charts.load('current', {
    'packages': ['corechart']
});

renderizarGraficos();

function renderizarGraficos() {
    relatorios.gerarDadosGraficoQuantidadeRecursos().then(function (response) {
        renderizarGrafico(gerarGraficoQuantidadeRecursos.bind(this, response.Dados));
    });

    relatorios.gerarDadosGraficoCustoPorFaturamento().then(function (response) {
        renderizarGrafico(gerarGraficoCustoPorFaturamento.bind(this, response.Dados));
    });
};

function gerarGraficoQuantidadeRecursos(dados) {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Topping');
    data.addColumn('number', 'Slices');
    data.addRows(dados);

    var options = {
        title: 'Gráfico da quantidade de recursos internos utilizados e não utilizados por projeto',
        legend: { position: 'bottom', maxLines: 3 }
    };

    var chart = new google.visualization.PieChart(document.getElementById('grafico-quantidade-recursos'));
    chart.draw(data, options);
}

function gerarGraficoCustoPorFaturamento(dados) {
    var cabecalho = [
          ['Tipos', 'Custo', 'Valor faturado']
    ];

    var data = google.visualization.arrayToDataTable(cabecalho.concat(dados));

    var options = {
        title: 'Gráfico de custo por faturamento \n(comparação de custo com valor faturado de projetos já encerrados)',
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

    var chart = new google.visualization.ColumnChart(document.getElementById('grafico-custo-por-faturamento'));
    chart.draw(data, options);
}

function renderizarGrafico(gerarGrafico) {
    google.charts.setOnLoadCallback(gerarGrafico);

    $(window).resize(function () {
        gerarGrafico();
    });
}