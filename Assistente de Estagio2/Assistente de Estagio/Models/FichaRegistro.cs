using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assistente_de_Estagio.Models
{
    public partial class Ficharegistro
    {
        [Key]
        public int IdFichaRegistro { get; set; }
        public string Identificador { get; set; }
        public string Classe { get; set; }
        public DateTime Data { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string Atividades { get; set; }
        public float CargaHoraria { get; set; }
        public int IdUsuario { get; set; }
        public int UsuarioIdUsuario { get; set; }
    }
}
