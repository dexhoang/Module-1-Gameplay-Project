using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//code for player detection ai given by Omogonix - https://youtu.be/_e57zSZSOS8?si=jHGpMCsrJpD5911Z 

public class WeepingAngelAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;
    public Camera playerCam;
    public float aiSpeed;
    public float dangerDistance = 10f;
    public Text dangerMessage;
    private Coroutine messageCoroutine;
    public string sceneName;

    private void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCam);

        if (GeometryUtility.TestPlanesAABB(planes, this.gameObject.GetComponent<Renderer>().bounds))
        {
            ai.speed = 0;
            ai.SetDestination(transform.position);
        }
        else
        {
            ai.speed = aiSpeed;
            ai.destination = player.position;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= dangerDistance)
        {
            dangerMessage.gameObject.SetActive(true);

            if (messageCoroutine != null)
            {
                StopCoroutine(messageCoroutine);
                messageCoroutine = null;
            }
        }
        else
        {
            if (dangerMessage.gameObject.activeSelf && messageCoroutine == null)
            {
                messageCoroutine = StartCoroutine(HideMessage());
            }
        }
    }

    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(2f);
        dangerMessage.gameObject.SetActive(false);
        messageCoroutine = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hello");
            SceneManager.LoadScene(sceneName);
        }
    }
}
