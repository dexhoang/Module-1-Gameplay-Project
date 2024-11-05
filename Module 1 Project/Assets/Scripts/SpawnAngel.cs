using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAngel : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public Vector3 spawnPosition;
    public Text spawnMessage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
            ShowMessage();
        }
    }

    private void ShowMessage()
    {
        spawnMessage.text = "AN ANGEL HAS FALLEN";
        StartCoroutine(ClearMessage(2f));
    }

    private IEnumerator ClearMessage(float delay)
    {
        yield return new WaitForSeconds (delay);
        spawnMessage.text = "";
    }
}
