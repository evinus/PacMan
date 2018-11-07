public enum Gamestate { Start, Game, End};

public enum enumTile
{
    Empty,
    OnlyWalls,
    DeadLeft,
    Deadtop,
    TurnTopLeft,
    DeadRight,
    WallTopBottom,
    TurnTopRight,
    WallBottom,
    DeadBottom,
    TurnRightBottom,
    WallRightLeft,
    WallLeft,
    TurnLeftBottom,
    WallTop,
    WallRight,
    NoWall,
    Ghost1,
    Ghost2,
    Ghost3,
    Ghost4,
    Food
};

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    Stop
};
