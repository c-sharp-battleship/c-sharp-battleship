/// <summary>
/// Implementation of project-wide status codes.
/// </summary>
namespace Battleship
{
    public enum AttackStatus
    {
        NOT_ATTACKED,
        ATTACKED_NOT_HIT,
        ATTACKED_HIT
    }

    public enum ApplicationStatus
    {
        START_GAME,
        PLAYER_1_TURN,
        PLAYER_2_TURN,
        END_GAME
    }
}