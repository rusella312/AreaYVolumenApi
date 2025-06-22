namespace AreaYVolumenApi.Models
{
    public class Cilindro
    {
        public int Id { get; set; }  // Identificador único para cada cilindro
        public double Radio { get; set; }
        public double Altura { get; set; }
        public double Area { get; set; }   // Para almacenar el área calculada
        public double Volumen { get; set; } // Para almacenar el volumen calculado
    }
}
