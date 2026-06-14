using System;
using System.Drawing;

namespace ReproductorMusical
{
    internal class AnilloOnda
    {
        public float CX        { get; private set; }
        public float CY        { get; private set; }
        public float RadioMax  { get; private set; }
        public Color ColorBase { get; private set; }
        public float Radio     { get; set; }
        public float Alfa      { get; set; }

        public AnilloOnda(float cx, float cy, float radioMax, Color colorBase)
        {
            CX = cx; CY = cy;
            Radio = 0f;
            RadioMax = Math.Max(1f, radioMax);
            Alfa = 1f;
            ColorBase = colorBase;
        }
    }
}
