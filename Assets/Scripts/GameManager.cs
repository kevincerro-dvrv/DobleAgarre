using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject targetPrefab;
    public GameObject player;

    private int targetCount;
    private float score;
    private float timeBonus;
    private float elapsedTime;
    private float standardTime = 20f;

    void Awake() {
        instance = this;
    }

    public InputAction deployTargets;
    public InputAction releaseMagazine;

    // Start is called before the first frame update
    void Start() {
        DeployTargets(); 
        deployTargets.Enable();
        deployTargets.performed += DT;

        releaseMagazine.Enable(); 
    }

    // Update is called once per frame
    void Update() {
        if(targetCount > 0) {
            elapsedTime += Time.deltaTime;
        }
    }

    private void DT(InputAction.CallbackContext context) {
        DeployTargets();
    }


    private void DeployTargets() {
        //Non permitimos unha nova remesa ata que a anterior foi completamente eliminada
        if(targetCount > 0) {
            return;
        }
        for(int i=0; i<10; i++) {
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 1, Random.Range(-10f, 10f));
            while(Vector3.Distance(spawnPosition, player.transform.position) < 5) {
                spawnPosition.x = Random.Range(-10f, 10f);
                spawnPosition.z = Random.Range(-10f, 10f);
            }
            Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        }
        targetCount += 10;
    }

    public void TargetDestroyed() {
        targetCount--;
        if(targetCount == 0) {
            timeBonus = Mathf.Clamp(standardTime  - elapsedTime, 0, standardTime);
        }

    }

    public void TargetHit(Transform destroyedTarget) {
        score += Mathf.Round(Vector3.Distance(destroyedTarget.position, player.transform.position));
        Debug.Log($"{score}");
    }
}
