using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RifleShot : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform shotPoint;

    public AudioClip shotSound;
    public AudioClip pushMagazineSound;

    public XRSocketInteractor magazineSocket;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPushMagazineSound() {
        GetComponent<AudioSource>().PlayOneShot(pushMagazineSound);
    }

    public void Shot() {

        if(magazineSocket.interactablesSelected.Count != 0) {
            if(((MonoBehaviour)magazineSocket.interactablesSelected[0]).GetComponent<BulletMagazine>().GetBullet()) {
                GetComponent<AudioSource>().PlayOneShot(shotSound);
                Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
            }
        }

    }
}
