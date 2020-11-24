using System;
using System.Collections.Generic;
using System.Text;

namespace Reto10.Models
{
    public class MassiveTransport
    {
        public string Fecha { get; set; }
        public string Ciudad { get; set; }
        public string Sistema { get; set; }
        public string Pasajeros_dia { get; set; }
        public string Pasajeros_d_a_t_pico_laboral { get; set; }
        public string Pasajeros_d_a_s_bado { get; set; }
        public string Pasajeros_d_a_festivo { get; set; }
        public string D_asemana { get; set; }
    }
}
