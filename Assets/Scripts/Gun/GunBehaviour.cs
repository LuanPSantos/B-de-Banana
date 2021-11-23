using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{

    public BulletBehaviour bullet;
    public Transform barrel;

    public void Fire(float direction)
    {
        if(direction != 0)
        {
            bullet.horizontalDirection = direction;
        }
        
        Instantiate(bullet, barrel.position, Quaternion.identity);
    }
}
