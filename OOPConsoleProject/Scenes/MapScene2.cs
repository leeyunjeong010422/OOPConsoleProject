﻿using OOPConsoleProject.Players;

namespace OOPConsoleProject.Scenes
{
    public class MapScene2 : MapSceneBase
    {
        public MapScene2(Game game, Player player) : base(game, player) { }

        protected override void InitializeMaze()
        {
            maze = new char[,]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', '#', '#', '#', '#', ' ', '#', '#', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', '#', '#', '#', ' ', '#', '#', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', '#', '#', '#', ' ', '#'},
                {'#', '#', ' ', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', '#', ' ', '#', ' ', ' ', ' ', ' ', '#', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#'}
            };
        }

        protected override void InitializeMonsters()
        {
            monsters = new List<(int x, int y)>
            {
                (3, 3), (7, 5), (10, 3), (16, 5), (25, 2)
            };
        }

        protected override void InitializeGoal()
        {
            goal = new List<(int x, int y)>
            {
                (38, 6)
            };
        }

        protected override void InitializePotion()
        {
            potion = new List<(int x, int y)>
            {
                (11, 3), (21,1)
            };
        }

        protected override void CheckForGoal()
        {
            foreach (var goal in goal)
            {
                if (playerX == goal.x && playerY == goal.y)
                {
                    game.ChangeScene(SceneType.Map3);
                    break;
                }
            }
        }

        protected override void MapName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<선도지방>");
            Console.ResetColor();
        }

        public override void Exit()
        {

        }
    }
}