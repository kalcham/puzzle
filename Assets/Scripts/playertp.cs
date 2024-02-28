using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playertp : MonoBehaviour
{

    public Transform tpp;
    public Transform man;

    playermovementscript playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<playermovementscript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            StartCoroutine(Teleport());
        }
     
    }

    IEnumerator Teleport()
    {
        playerController.disabled = true;
        yield return new WaitForSeconds(0.01f);
        gameObject.transform.position = new Vector3(90f, 0f, 0f);
        yield return new WaitForSeconds(1f);
        playerController.disabled = false;
    }
}
