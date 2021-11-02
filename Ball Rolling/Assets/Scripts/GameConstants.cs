using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants
{
    #region Game System constant
    public const float GRAVITY_VALUE = 9.81f;
    #endregion

    #region Player constant
    public const int PLAYER_VERTICAL_LOOK_LOWER_BOUND = -50;
    public const int PLAYER_VERTICAL_LOOK_UPPER_BOUND = 50;

    public const int PLAYER_RAY_LENGTH = 1000;
    public const int PLAYER_THROW_STRENGTH = 1000;
    #endregion

    #region Enemy constant
    public const float ENEMY_FOV_DISTANCE = 2000;
    public const float ENEMY_FOV_ANGLE = 60;
    public const int ENEMY_RAY_LENGTH = 1000;
    public const float ENEMY_PATROL_RADIUS = 50;
    public const float ENEMY_ATTACK_DISTANCE = 30;
    #endregion
}
