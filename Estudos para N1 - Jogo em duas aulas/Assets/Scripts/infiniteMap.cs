using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infiniteMap : MonoBehaviour
{
    public GameObject pipeSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("invisible_wall"))
            Instantiate(pipeSection, new Vector3(2f, 1f, -8f), Quaternion.identity);
    }
}
