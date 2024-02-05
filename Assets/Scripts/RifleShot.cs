using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RifleShot : MonoBehaviour {
    public static RifleShot instance;

    public GameObject bulletPrefab;
    public Transform shotPoint;

    public AudioClip shotSound;
    public AudioClip pushMagazineSound;
    public AudioClip releaseMagazineSound;

    public XRSocketInteractor magazineSocket;

    private bool magazineIsReleased = true;

    public ParticleSystem[] smokeParticleSystem;

    void Awake() {
        instance = this;
    }

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
        magazineIsReleased = false;
    }

    public void PlayReleaseManazineSound() {
        GetComponent<AudioSource>().PlayOneShot(releaseMagazineSound);
        magazineIsReleased = true;
    }

    public void Shot() {

        if (magazineIsReleased) {
            return;
        }

        if(magazineSocket.interactablesSelected.Count != 0) {
            if(((MonoBehaviour)magazineSocket.interactablesSelected[0]).GetComponent<BulletMagazine>().GetBullet()) {
                GetComponent<AudioSource>().PlayOneShot(shotSound);
                Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

                foreach (ParticleSystem ps in smokeParticleSystem) {
                    ps.Play();
                }
            }
        }

    }
}
