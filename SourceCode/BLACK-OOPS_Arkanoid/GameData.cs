namespace BLACK_OOPS_Arkanoid
{
    public static class GameData
    {
        // Variables necesarias para la funcionalidad del juego
        public static bool gameStarted = false;
        public static int lifes = 3, score = 0;
        
        // Inicializacion de variables
        public static void InitializeGame()
        {
            gameStarted = false;
            lifes = 3;
            score = 0;
        }
    }
}