using System;

namespace TicTacToeLib
{

    public class TicTacToe
    {
        public const char NONE = ' ';
        public const char CROSS = 'X';
        public const char CIRCLE = 'O';
        public const int SIZE = 3;

        public static char StartNewGame(int size, out char[,] grid)
        {
            // PROF : À COMPLÉTER. Les deux lignes suivantes sont erronnées, mais permettent la compilation.
            // ATTENTION : le programme va tout de même planter immédiatement. Il devrait toutefois se lancer une fois que cette fonction (StartNewGame) sera complète.
            // Vous devrez alors compléter les autres fonctions pour que le programme est le fonctionnement attendu.
            grid = null;

            return NONE;
        }

        public static char PutMarkAt(int row, int column, char[,] grid, char currentPlayer)
        {
            // PROF : À COMPLÉTER. La ligne suivante est erronnée, mais permet la compilation.
            
            // PROF : n'oubliez pas -> cette fonction retourne le joueur suivant.
            // - Si currentPlayer est CIRCLE, on devrait retourner CROSS
            // - Si currentPlayer est CROSS, on devrait retourner CIRCLE
            // Cette fonction comporte donc deux parties : 
            // 1. Placer la bonne marque à la position demandée
            // 2. Déterminer le prochain joueur selon le joueur courant (vous allez devoir trouver un moyen de faire l'inversion) et retourner le signe du prochain joueur.
            return NONE;
        }

        public static char FindWinner(char[,] grid)
        {
            // PROF : À COMPLÉTER. La ligne suivante est erronnée, mais permet la compilation.
            return NONE;
        }

        public static bool IsGameADraw(char[,] grid)
        {
            // PROF : À COMPLÉTER. La ligne suivante est erronnée, mais permet la compilation.
            return false;
        }
    }
}