using LudoGameEngine;

namespace LudoGameEngineTests.Mocks
{
    public class DieceMock : IDiece
    {
        public int DieceValue { get; set; }

        public int RollDiece()
        {
            return DieceValue;
        }
    }
}
