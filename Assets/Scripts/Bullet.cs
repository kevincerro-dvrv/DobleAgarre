using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float shotForce = 1000f;
    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody>().AddForce(transform.forward * shotForce, ForceMode.Impulse);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
