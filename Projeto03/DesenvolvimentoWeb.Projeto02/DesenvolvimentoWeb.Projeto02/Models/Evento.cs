using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public double Preco { get; set; }

        public byte[] Foto { get; set; }
        public string MimeType { get; set; }

        public ICollection<Participante> Participantes { get; set; }
    }
}
