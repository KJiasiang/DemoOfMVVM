using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{

    enum CharaterType
    {
        NONE,
        PLAYER,
        ENEMY
    }
    enum MoveDirection
    {
        UP, DOWN, RIGHT, LEFT
    }

    class Player : Character
    {
        public Player()
        {
            ImgSource = "Resources/runner_128px_1168248_easyicon.net.png";
            Type = CharaterType.PLAYER;
        }
        public Player(int id, int x, int y) : this()
        {
            ID = id;
            X = x;
            Y = y;
        }
        public Player(Character newPlayer) : this()
        {
            ID = newPlayer.ID;
            X = newPlayer.X;
            Y = newPlayer.Y;
        }
    }

    class Enemy : Character
    {
        public Enemy()
        {
            ImgSource = "Resources/monsters_84.562248995984px_1195660_easyicon.net.png";
            Type = CharaterType.ENEMY;
        }
        public Enemy(int id, int x, int y) : this()
        {
            ID = id;
            X = x;
            Y = y;
        }
        public Enemy(Character newEnemy) : this()
        {
            ID = newEnemy.ID;
            X = newEnemy.X;
            Y = newEnemy.Y;
        }
    }

    class Character
    {
        public int ID { get; set; }
        public string ImgSource { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public CharaterType Type { get; set; }
        public Character() : this(CharaterType.NONE, "", 0, 0)
        { }
        public Character(CharaterType type, string source, int x, int y)
        {
            Type = type;
            ImgSource = source;
            X = x;
            Y = y;
        }


        public Character Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.DOWN:
                    return MoveDown();
                case MoveDirection.LEFT:
                    return MoveLeft();
                case MoveDirection.RIGHT:
                    return MoveRight();
                case MoveDirection.UP:
                    return MoveUp();
                default:
                    throw new Exception("Unknown Direction");
            }
        }

        public Character MoveRight()
        {
            Character result = Copy();
            result.X++;
            if (result.X > 8)
                result.X = 8;
            return result;
        }

        public Character MoveLeft()
        {
            Character result = Copy();
            result.X--;
            if (result.X < 0)
                result.X = 0;
            return result;
        }

        public Character MoveUp()
        {
            Character result = Copy();
            result.Y--;
            if (result.Y < 0)
                result.Y = 0;
            return result;
        }

        public Character MoveDown()
        {
            Character result = Copy();
            result.Y++;
            if (result.Y > 8)
                result.Y = 8;
            return result;
        }

        public Character Dash(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.DOWN:
                    return DashDown();
                case MoveDirection.LEFT:
                    return DashLeft();
                case MoveDirection.RIGHT:
                    return DashRight();
                case MoveDirection.UP:
                    return DashUp();
                default:
                    throw new Exception("Unknown Direction");
            }
        }

        public Character DashRight()
        {
            Character result = Copy();
            result.X = 8;
            return result;
        }

        public Character DashLeft()
        {
            Character result = Copy();
            result.X = 0;
            return result;
        }

        public Character DashUp()
        {
            Character result = Copy();
            result.Y = 0;
            return result;
        }

        public Character DashDown()
        {
            Character result = Copy();
            result.Y = 8;
            return result;
        }

        private Character Copy()
        {
            return new Character(Type, ImgSource, X, Y);
        }

        public bool CompareXYIsSame(Character character)
        {
            if (character.X == X && character.Y == Y)
                return true;
            return false;
        }
    }
}
