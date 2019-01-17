using System;

namespace LudoGameEngine
{
    public class Diece : IDiece
    {
        public int RollDiece()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }
    }
}
