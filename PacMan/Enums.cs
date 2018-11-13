public enum Gamestate { Start, Game, End};

public enum enumTile
{
    Empty,
    OnlyWalls,
    DeadLeft,
    Deadtop,
    TurnTopRight,
    DeadRight,
    WallTopBottom,
    TurnTopLeft,
    WallBottom,
    DeadBottom,
    TurnRightBottom,
    WallRightLeft,
    WallLeft,
    TurnLeftBottom,
    WallTop,
    WallRight,
    NoWall,
    EndPoint1,
    EndPoint2,
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
