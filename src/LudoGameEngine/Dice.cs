using System;

namespace LudoGameEngine
{
    public class Dice : IDice
    {
        private static int lastDiceValue;
        public static int LastDiceValue { get { return lastDiceValue; } }

        public int RollDice()
        {
            Random random = new Random();
            lastDiceValue = random.Next(1, 7);
            return lastDiceValue;
        }
    }
}