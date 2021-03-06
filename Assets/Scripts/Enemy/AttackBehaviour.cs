using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBehaviour: MonoBehaviour
{
    public abstract void AttackPlayer();

    public abstract void SetPlayerBehaviour(PlayerBehaviour playerBehaviour);
}
