﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assistente_de_Estagio.Models
{
    public partial class Documento
    {
        public Documento()
        {
            Curso = new HashSet<Curso>();
            Jsonrequisitospreenchidos = new HashSet<Jsonrequisitospreenchidos>();
            Usuario = new HashSet<Usuario>();
        }
        [Key]
        public int IdDocumento { get; set; }
        public int CursoIdCurso { get; set; }
        public string TituloDocumento { get; set; }
        public string DescricaoDocumento { get; set; }
        public string RequisitoDocumento { get; set; }
        public string PreenchimentoDocumento { get; set; }
        public int PosicaoDocumento { get; set; }
        public string AutorDocumento { get; set; }
        public string CaminhoDocumento { get; set; }
        public string TiposRequisitos { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
        public virtual ICollection<Jsonrequisitospreenchidos> Jsonrequisitospreenchidos { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
