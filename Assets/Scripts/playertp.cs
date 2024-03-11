using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playertp : MonoBehaviour
{

    public Transform tpp;
    public Transform man;
    public Vector3 Tp1;
    public Vector3 Tp2;
    public Vector3 Tp3;
    public float FireRate = 1f;
    float NextFire = 0f;
    float TpCount = 1f;
    

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

        if (Input.GetButton("Fire2") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;

            TpCount += 1;

            if (TpCount >= 4f)
            {
                TpCount = 1f;
            }
        }

    }

    IEnumerator Teleport()
    {
        playerController.disabled = true;
        yield return new WaitForSeconds(0.2f);
        if (TpCount == 1f)
        {
            gameObject.transform.position = Tp1;
        }
        else if (TpCount == 2f)
        {
            gameObject.transform.position = Tp2;
        }
        else if (TpCount == 3f)
        {
            gameObject.transform.position = Tp3;
        }
        yield return new WaitForSeconds(1f);
        playerController.disabled = false;
    }

}
