namespace LudoGameEngine
{
    public class Piece
    {
        public int PieceId { get; set; }
        public PieceGameState State { get; set; }
        public int Position { get; set; }
        public PlayerColor PieceColor {get; set;}

        public int UpdatePosition(int n)
        {
            if(this.Position == 0 && n == 6)
            {
                this.State = PieceGameState.InGame;
            }
            return this.Position += n;
        }
    }
}