using System.Drawing;

namespace ReproductorMusical
{
    internal class ParticulaVisual
    {
        public float X               { get; set; }
        public float Y               { get; set; }
        public float VX              { get; set; }
        public float VY              { get; set; }
        public float Tamano          { get; set; }
        public float Alfa            { get; set; }
        public float Rotacion        { get; set; }
        public float VelRotacion     { get; set; }
        public float TimerAnillo     { get; set; }
        public float IntervaloAnillo { get; set; }
        public Color ColorBase       { get; set; }

        public ParticulaVisual(float x, float y, float vx, float vy,
            float tamano, Color colorBase, float velRotacion, float intervaloAnillo)
        {
            X = x; Y = y;
            VX = vx; VY = vy;
            Tamano = tamano;
            ColorBase = colorBase;
            Alfa = 1f;
            Rotacion = 0f;
            VelRotacion = velRotacion;
            IntervaloAnillo = intervaloAnillo;
            TimerAnillo = intervaloAnillo;
        }
    }
}
