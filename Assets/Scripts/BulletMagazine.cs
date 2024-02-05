using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMagazine : MonoBehaviour {
    int bulletCount = 16;

    public bool GetBullet() {
        if(bulletCount > 0) {
            bulletCount--;
            return true;
        }
        return false;
    }
}
