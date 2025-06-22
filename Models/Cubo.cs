namespace AreaYVolumenApi.Models
{
    public class Cubo
    {
        public int Id { get; set; }  // Identificador único para cada cubo
        public double Lado { get; set; }
        public double Area { get; set; }   // Para almacenar el área calculada
        public double Volumen { get; set; } // Para almacenar el volumen calculado
    }
}
