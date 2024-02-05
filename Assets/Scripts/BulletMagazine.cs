using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BulletMagazine : MonoBehaviour {
    int bulletCount = 16;

    void Start()
    {
        GameManager.instance.releaseMagazine.performed += ReleaseMagazine;
    }

    public bool GetBullet() {
        if(bulletCount > 0) {
            bulletCount--;
            return true;
        }
        return false;
    }

    public void Lock(SelectEnterEventArgs args) {
        if (((MonoBehaviour)args.interactorObject).CompareTag("RifleMagazineSocket")) {
            GetComponent<Collider>().enabled = false;
        }
    }

    private void ReleaseMagazine(InputAction.CallbackContext context) {
        if (!GetComponent<Collider>().enabled) {
            GetComponent<Collider>().enabled = true;
            RifleShot.instance.PlayReleaseManazineSound();
        }
    }
}
