using AreaYVolumenApi.Models; // Agrega esta línea

namespace AreaYVolumenApi.Services
{
    public class AreaYVolumenService
    {
        public double CalcularAreaCilindro(Cilindro cilindro)
        {
            return 2 * Math.PI * cilindro.Radio * (cilindro.Radio + cilindro.Altura);
        }

        public double CalcularVolumenCilindro(Cilindro cilindro)
        {
            return Math.PI * Math.Pow(cilindro.Radio, 2) * cilindro.Altura;
        }

        public double CalcularAreaCubo(Cubo cubo)
        {
            return 6 * Math.Pow(cubo.Lado, 2);
        }

        public double CalcularVolumenCubo(Cubo cubo)
        {
            return Math.Pow(cubo.Lado, 3);
        }
    }
}