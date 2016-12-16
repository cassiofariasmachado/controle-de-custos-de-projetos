﻿using ControleCustos.Dominio.Interface;
using System;
using System.Configuration;

namespace ControleCustos.Servicos
{
    public class ServicoDeConfiguracao : IServicoDeConfiguracao
    {
        public int QuantidadeDeRecursosPorPagina
        {
            get
            {
                int quantidadeDeRecursosPorPagina = Convert.ToInt32(ConfigurationManager.AppSettings["QuantidadeDeRecursosPorPagina"]);
                return quantidadeDeRecursosPorPagina;
            }
        }
    }
}