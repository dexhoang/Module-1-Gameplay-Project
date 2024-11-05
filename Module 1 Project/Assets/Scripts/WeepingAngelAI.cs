using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    private bool isDisplayingMessage = false;

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
        }
        else
        {
            dangerMessage.gameObject.SetActive(false);
        }
    }

    private IEnumerator DisplayDanger()
    {
        isDisplayingMessage = true;
        dangerMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        dangerMessage.gameObject.SetActive(false);
        isDisplayingMessage = false;
    }
}
