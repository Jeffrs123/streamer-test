//using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;

namespace Streamer.Domain
{
    public class Evento
    {        //[Key]
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime DateEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}


//public enum ProjectStatus { get; set; }
//public string Course { get; set; }
//public Course CursO { get; set; }
//public int CourseId { get; set; }