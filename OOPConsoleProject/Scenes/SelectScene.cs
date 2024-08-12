﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OOPConsoleProject.Players;

namespace OOPConsoleProject.Scenes
{
    public class SelectScene : Scene
    {
        public enum State { Name, Job, PoketMonsterSelection, Confirm }
        private State curState;
        private Job currentJob;

        private string input;
        private string nameInput;

        public SelectScene(Game game) : base(game)
        {

        }

        public override void Enter()
        {
            curState = State.Name;
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            if (curState == State.Name)
            {
                Console.Write("캐릭터의 이름을 입력하세요 : ");
            }
            else if (curState == State.Job)
            {
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("1. 한지우");
                Console.WriteLine("2. 최이슬");
                Console.WriteLine("3. 웅이");
                Console.WriteLine("4. 봄이");
                Console.Write("입력해주세요: ");
            }
            else if (curState == State.PoketMonsterSelection)
            {
                DisplayPoketMonsters(currentJob);
                Console.Write("포켓몬 번호 입력: ");
            }

            else if (curState == State.Confirm)
            {
                Console.WriteLine("===================");
                Console.WriteLine($"이름 : {game.Player.Name}");
                Console.WriteLine($"직업 : {game.Player.Job}");
                //Console.WriteLine($"포켓몬 : {}");
                Console.WriteLine($"체력 : {game.Player.MaxHP}");
                Console.WriteLine($"공격 : {game.Player.Attack}");
                Console.WriteLine($"방어 : {game.Player.Defense}");
                Console.WriteLine($"소지금 : {game.Player.Gold}");
                Console.WriteLine("===================");
                Console.WriteLine();
                Console.Write("이대로 플레이 하시겠습니까? [네(y) | 아니오(n)]: ");
            }
        }

        public override void Update()
        {
            if (curState == State.Name)
            {
                if (input == string.Empty)
                    return;

                nameInput = input;
                curState = State.Job;
            }
            else if (curState == State.Job)
            {
                if (int.TryParse(input, out int jobIndex) && Enum.IsDefined(typeof(Job), jobIndex))
                {
                    currentJob = (Job)jobIndex;
                    switch (currentJob)
                    {
                        case Job.HanJiu:
                            game.Player = new HanJiu(nameInput);
                            break;
                        case Job.ChoeIseul:
                            game.Player = new ChoeIseul(nameInput);
                            break;
                        case Job.UNG:
                            game.Player = new UNG(nameInput);
                            break;
                        case Job.BOM:
                            game.Player = new BOM(nameInput);
                            break;
                    }
                    curState = State.PoketMonsterSelection;
                }
            }
            else if(curState == State.PoketMonsterSelection)
            {
                curState = State.Confirm;
            }

            else if (curState == State.Confirm)
            {
                switch (input)
                {
                    case "Y":
                    case "y":
                    case "네":
                        game.ChangeScene(SceneType.Map);
                        break;
                    case "N":
                    case "n":
                    case "아니오":
                        curState = State.Name;
                        break;
                    default:
                        break;
                }
            }
        }

        private void DisplayPoketMonsters(Job job)
        {
            Console.WriteLine($"<선택한 직업[{game.Player.Job}]에 따른 포켓몬 목록>");
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (job)
            {
                case Job.HanJiu:
                    foreach (var monster in Enum.GetValues(typeof(JiuPoketMonster)))
                    {
                        Console.WriteLine(monster);
                    }
                    break;
                case Job.ChoeIseul:
                    foreach (var monster in Enum.GetValues(typeof(IseulPoketMonster)))
                    {
                        Console.WriteLine(monster);
                    }
                    break;
                case Job.UNG:
                    foreach (var monster in Enum.GetValues(typeof(UngPoketMonster)))
                    {
                        Console.WriteLine(monster);
                    }
                    break;
                case Job.BOM:
                    foreach (var monster in Enum.GetValues(typeof(BomPoketMonster)))
                    {
                        Console.WriteLine(monster);
                    }
                    break;
                    
            }
            Console.ResetColor();
        }
    }
}