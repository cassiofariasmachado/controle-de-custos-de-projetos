class Grafico {

    constructor() {
        this.registrarBinds();
        this.renderizarGraficos();
    }

    registrarBinds() {
        this.relatorios = new Relatorios();
    }

    renderizarGraficos() {
        this.relatorios.gerarDadosGraficoMenorCusto().then(response => {
            this.rederizarGrafico(this.gerarGraficoMenorCusto.bind(this, response.Dados));
        });

        this.relatorios.gerarDadosGraficoMaiorCusto().then(response => {
            this.rederizarGrafico(this.gerarGraficoMaiorCusto.bind(this, response.Dados));
        });
    }

    gerarGraficoMenorCusto(dados) {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Topping');
        data.addColumn('number', 'Slices');
        data.addRows(dados);

        var options = {
            title: 'Gráfico de menor custo (percentual da diferença entre custo e faturamento previsto de projetos em andamento)',
            legend: { position: 'bottom', maxLines: 3 }
        };

        var chart = new google.visualization.PieChart(document.getElementById('grafico-menor-custo'));
        chart.draw(data, options);
    }

    gerarGraficoMaiorCusto(dados) {
        var cabecalho = [
              ['Tipos', 'Custo', 'Valor faturado']
        ];

        var data = google.visualization.arrayToDataTable(cabecalho.concat(dados));

        var options = {
            title: 'Gráfico de maior custo (comparação de custo com valor faturado de projetos já encerrados)',
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

    rederizarGrafico(gerarGrafico) {
        google.charts.load('current', {
            'packages': ['corechart']
        });

        google.charts.setOnLoadCallback(gerarGrafico);

        $(window).resize(function () {
            gerarGrafico();
        });
    }

}