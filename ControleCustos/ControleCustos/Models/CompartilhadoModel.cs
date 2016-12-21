using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class CompartilhadoModel : RecursoModel
    {
        public string EnderecoIp { get; private set; }

        public bool BaseDeDados { get; private set; }

        public decimal EspacoEmDisco { get; private set; }

        public int Processadores { get; private set; }

        public decimal Memoria { get; private set; }

        public bool BackupDiario { get; private set; }

        public bool BackupIncremental { get; private set; }

        public TipoRecurso TipoRecurso { get; private set; }

        public CompartilhadoModel(Compartilhado compartilhado)
            : base(compartilhado)
        {
            this.EnderecoIp = compartilhado.EnderecoIp;
            this.BaseDeDados = compartilhado.BaseDeDados;
            this.EspacoEmDisco = compartilhado.EspacoEmDisco;
            this.Processadores = compartilhado.Processadores;
            this.Memoria = compartilhado.Memoria;
            this.BackupDiario = compartilhado.BackupDiario;
            this.BackupIncremental = compartilhado.BackupIncremental;
            this.TipoRecurso = compartilhado.TipoRecurso;
        }
    }
}