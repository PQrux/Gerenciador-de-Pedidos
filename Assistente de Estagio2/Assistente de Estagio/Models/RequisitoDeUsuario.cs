using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assistente_de_Estagio.Models
{
    public partial class Requisitodeusuario
    {
        public int? UsuarioIdUsuario { get; set; }
        public byte? OrdemRequisito { get; set; }
        public int RequisitosIdRequisito { get; set; }
        [Key]
        public int IdRequisitoDeUsuario { get; set; }
    }
}
