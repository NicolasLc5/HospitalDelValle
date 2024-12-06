﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_del_Valle.Models
{
    public class Cita
    {
        [Key]
        public int CitaID { get; set; }

        [Required]
        [ForeignKey(nameof(Paciente))]
        public int PacienteID { get; set; }

        [InverseProperty(nameof(Usuario.CitasComoPaciente))]
        public Usuario Paciente { get; set; }

        [Required]
        [ForeignKey(nameof(Medico))]
        public int MedicoID { get; set; }

        [InverseProperty(nameof(Usuario.CitasComoMedico))]
        public Usuario Medico { get; set; }

        [Required]
        public DateTime FechaCita { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }

        public string Observaciones { get; set; }
    }
}
