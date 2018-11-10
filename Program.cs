using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TickTacToe
{

    class Player
    {

        static int count = 1;

        protected int id;

        protected string name;

        protected int win = 0;

        protected int lose = 0;

        protected char Team = ' ';

        public Player()
        {
            this.id = Player.count++;
            this.name = "Player"+this.id;
        }

        public Player(string Name,char Team)
        {
            this.id = Player.count++;
            if(Name == "") this.name = "Player" + this.id;
            else this.name = Name;
            this.Team = Team;
        }

        public string GetName()
        {
            return this.name;
        }

        public char GetTeam()
        {
            return this.Team;
        }

        public int GetWinCount()
        {
            return this.win;
        }

        public int GetLoseCount()
        {
            return this.lose;
        }

        public void Won()
        {
            this.win++;
        }

        public void Lost()
        {
            this.lose++;
        }
        
    }

    class Board
    {

        protected char[,] table = new char[3, 3];

        public Board()
        {
            this.Reset();
        }

        public void Reset()
        {
            //First Row
            this.table[0, 0] = ' ';
            this.table[0, 1] = ' ';
            this.table[0, 2] = ' ';
            //Second Row
            this.table[1, 0] = ' ';
            this.table[1, 1] = ' ';
            this.table[1, 2] = ' ';
            //Third Row
            this.table[2, 0] = ' ';
            this.table[2, 1] = ' ';
            this.table[2, 2] = ' ';
        }

        public void DrawTable()
        {
            Console.WriteLine("  A B C ");
            Console.WriteLine(" #-----#");
            Console.WriteLine("1|" + this.table[0, 0] + "|" + this.table[0, 1] + "|" + this.table[0, 2] + "|");
            Console.WriteLine(" #-----#");
            Console.WriteLine("2|" + this.table[1, 0] + "|" + this.table[1, 1] + "|" + this.table[1, 2] + "|");
            Console.WriteLine(" #-----#");
            Console.WriteLine("3|" + this.table[2, 0] + "|" + this.table[2, 1] + "|" + this.table[2, 2] + "|");
            Console.WriteLine(" #-----#");
        }

        public char[,] GetTable()
        {
            return this.table;
        }

        public bool Play(string GridLocation,char Team)
        {
            switch (GridLocation)
            {
                case "A1":
                    if(this.table[0,0] == ' ')
                    {
                        this.table[0, 0] = Team;
                        return true;
                    } else
                    {
                        Console.WriteLine("Wrong, "+GridLocation+" is already taken please try again...");
                        return false;
                    }
                case "A2":
                    if (this.table[1, 0] == ' ')
                    {
                        this.table[1, 0] = Team;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, " + GridLocation + " is already taken please try again...");
                        return false;
                    }
                case "A3":
                    if (this.table[2, 0] == ' ')
                    {
                        this.table[2, 0] = Team;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, " + GridLocation + " is already taken please try again...");
                        return false;
                    }
                case "B1":
                    if (this.table[0, 1] == ' ')
                    {
                        this.table[0, 1] = Team;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, " + GridLocation + " is already taken please try again...");
                        return false;
                    }
                case "B2":
                    if (this.table[1, 1] == ' ')
                    {
                        this.table[1, 1] = Team;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, " + GridLocation + " is already taken please try again...");
                        return false;
                    }
                case "B3":
                    if (this.table[2, 1] == ' ')
                    {
                        this.table[2, 1] = Team;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, " + GridLocation + " is already taken please try again...");
                        return false;
                    }
                case "C1":
                    if (this.table[0, 2] == ' ')
                    {
                        this.table[0, 2] = Team;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, " + GridLocation + " is already taken please try again...");
                        return false;
                    }
                case "C2":
                    if (this.table[1, 2] == ' ')
                    {
                        this.table[1, 2] = Team;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, " + GridLocation + " is already taken please try again...");
                        return false;
                    }
                case "C3":
                    if (this.table[2, 2] == ' ')
                    {
                        this.table[2, 2] = Team;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, " + GridLocation + " is already taken please try again...");
                        return false;
                    }
                default:
                    Console.WriteLine("Wrong board location please try again...");
                    return false;
            }
        }

        public bool IsWin(char Team)
        {
            // A1 + B1 + C1
            if (this.table[0, 0] == Team && this.table[1, 0] == Team && this.table[2, 0] == Team) return true;
            // A2 + B2 + C2
            else if (this.table[0, 1] == Team && this.table[1, 1] == Team && this.table[2, 1] == Team) return true;
            // A3 + B3 + C3
            else if (this.table[0, 2] == Team && this.table[1, 2] == Team && this.table[2, 2] == Team) return true;
            // A1 + A2 + A3
            else if (this.table[0, 0] == Team && this.table[0, 1] == Team && this.table[0, 2] == Team) return true;
            // B1 + B2 + B3
            else if (this.table[1, 0] == Team && this.table[1, 1] == Team && this.table[1, 2] == Team) return true;
            // C1 + C2 + C3
            else if (this.table[2, 0] == Team && this.table[2, 1] == Team && this.table[2, 2] == Team) return true;
            // A1 + B2 + C3
            else if (this.table[0, 0] == Team && this.table[1, 1] == Team && this.table[2, 2] == Team) return true;
            // A3 + B2 + C1
            else if (this.table[0, 2] == Team && this.table[1, 1] == Team && this.table[2, 0] == Team) return true;
            // No success
            else return false;
        }

        public bool IsFull()
        {
            for(int i=0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this.table[i, j] == ' ') return false;
                }
            }
            return true;
        }

    }

    class Game
    {

        Board Grid;

        Random RandomPlayer = new Random(DateTime.Now.Second);

        protected Player[] Players = new Player[2];

        public Game()
        {
            Console.Title = "TicTacToe";
            this.Grid = new Board();
            this.Lobby();
            Console.Title = "TicTacToe | "+ Players[0].GetName() + " VS " + Players[1].GetName();
            this.Loop();
            this.DrawScoreboard();
            Console.ReadLine();
        }

        protected void Lobby()
        {
            this.SetPlayer1();
            this.SetPlayer2();
            Console.Clear();
        }

        protected void SetPlayer1()
        {
            Console.Write("Player 1 Name : ");
            this.Players[0] = new Player(Console.ReadLine(), 'X');
        }

        protected void SetPlayer2()
        {
            Console.Write("Player 2 Name : ");
            this.Players[1] = new Player(Console.ReadLine(), 'O');
        }

        protected void Loop()
        {
            int FirstPlayer = this.GetFirstPlayer();
            int SecondPlayer = this.GetSecondPlayer(FirstPlayer);
            Console.Clear();
            this.Grid.Reset();
            this.Grid.DrawTable();
            while (!this.Grid.IsFull() && (!this.Grid.IsWin('X') || !this.Grid.IsWin('O')))
            {
                this.PlayerTurn(this.Players[FirstPlayer]);
                Console.Clear();
                this.Grid.DrawTable();
                if (this.Grid.IsWin(this.Players[FirstPlayer].GetTeam()))
                {
                    this.Players[FirstPlayer].Won();
                    this.Players[SecondPlayer].Lost();
                    Console.WriteLine(this.Players[FirstPlayer].GetName() + " is victorious!");
                    break;
                }
                else if (this.Grid.IsFull())
                {
                    Console.WriteLine(this.Players[FirstPlayer].GetName() + " and " + this.Players[SecondPlayer].GetName() + " are tied!");
                    break;
                }
                this.PlayerTurn(this.Players[SecondPlayer]);
                Console.Clear();
                this.Grid.DrawTable();
                if (this.Grid.IsWin(this.Players[SecondPlayer].GetTeam()))
                {
                    this.Players[SecondPlayer].Won();
                    this.Players[FirstPlayer].Lost();
                    Console.WriteLine(this.Players[SecondPlayer].GetName() + " is victorious!");
                    break;
                }
                else if (this.Grid.IsFull())
                {
                    Console.WriteLine(this.Players[SecondPlayer].GetName() + " and " + this.Players[FirstPlayer].GetName() + " are tied!");
                    break;
                }
            }
            if (this.Rematch()) this.Loop();
        }

        protected bool Rematch()
        {
            Console.Write("Do you want a rematch (Y|N)? : ");
            string answer = "";
            while(answer != "Y" || answer != "N")
            {
                answer = Console.ReadLine();
                if (answer == "Y") return true;
                if (answer == "N") return false;
            }
            return false;
        }

        protected void PlayerTurn(Player PlayingPlayer)
        {
            Console.Write(PlayingPlayer.GetName() + " Select your new target : ");
            while (!this.Grid.Play(Console.ReadLine(),PlayingPlayer.GetTeam())){ /* Do nothing until it works */ }
        }

        protected void DrawScoreboard()
        {
            Console.Clear();
            Console.WriteLine("#-------------------------------------#");
            Console.WriteLine("|    Name    |    Win    |    Lose    |");
            Console.WriteLine("#-------------------------------------#");
            Console.WriteLine("|   " + this.Players[0].GetName() + "   |     " + this.Players[0].GetWinCount() + "     |     " + this.Players[0].GetLoseCount() + "     |");
            Console.WriteLine("#-------------------------------------#");
            Console.WriteLine("|   " + this.Players[1].GetName() + "   |     " + this.Players[1].GetWinCount() + "     |     " + this.Players[1].GetLoseCount() + "     |");
            Console.WriteLine("#-------------------------------------#");
        }

        protected int GetFirstPlayer()
        {
            int value = this.RandomPlayer.Next(1, 10000);
            if (value % 2 == 0) return 1;
            else return 0;
        }

        protected int GetSecondPlayer(int FirstPlayer)
        {
            if (FirstPlayer == 0) { return 1; }
            else { return 0; }
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Game MainGame = new Game();
        }
       
    }

}