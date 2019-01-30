﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assistente_de_Estagio.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Jsonrequisitospreenchidos = new HashSet<Jsonrequisitospreenchidos>();
        }
        [Key]
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public DateTime? DataCriacaoUltimoDocumento { get; set; }
        public int DocumentoIdDocumento { get; set; }
        public string Prioridade { get; set; }

        public virtual Documento DocumentoIdDocumentoNavigation { get; set; }
        public virtual ICollection<Jsonrequisitospreenchidos> Jsonrequisitospreenchidos { get; set; }
    }
}
