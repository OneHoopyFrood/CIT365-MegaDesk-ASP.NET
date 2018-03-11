using System;

namespace MegaDesk
{
    public class Desk
    {
        public enum DeskMaterial
        {
            Pine, Laminate, Veneer, Oak, Rosewood
        }

        private int _width;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value <= 96 && value >= 24)
                {
                    _width = value;
                }
                else
                    throw new Exception("Unacceptable width value.");
            }
        }
        private int _depth;
        public int Depth
        {
            get
            {
                return _depth;
            }
            set
            {
                if (value <= 48 && value >= 12)
                {
                    _depth = value;
                }
                else
                    throw new Exception("Unacceptable depth value.");
            }
        }
        private int _numDrawers;
        public int NumDrawers
        {
            get
            {
                return _numDrawers;
            }
            set
            {
                if (value <= 7 && value >= 0)
                {
                    _numDrawers = value;
                }
                else
                    throw new Exception("Unacceptable numDrawers value.");
            }
        }
        public DeskMaterial Material { get; set; }

        public Desk(int width, int depth, int numDrawers, DeskMaterial material)
        {
            this.Width = width;
            this.Depth = depth;
            this.NumDrawers = numDrawers;
            this.Material = material;
        }

        public int GetSurfaceArea()
        {
            return Width * Depth;
        }
    }
}
