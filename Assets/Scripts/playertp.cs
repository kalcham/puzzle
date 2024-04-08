using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class playertp : MonoBehaviour
{

    public Transform tpp;
    public Transform man;
    public Vector3 Tp1;
    public Vector3 Tp2;
    public Vector3 Tp3;
    public float FireRate = 1f;
    float NextFire = 0f;
    float NextFire2 = 0f;
    float TpCount = 1f;
    public TMP_Text TpIndicator;
    public bool teleporting;
    playermovementscript playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<playermovementscript>();
        TpIndicator.SetText("Current Time: Present");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            teleporting = true;
            StartCoroutine(Teleport());
            
        }

        if (Input.GetButtonDown("Fire2") && Time.time > NextFire2)
        {
            NextFire2 = Time.time + FireRate;

            TpCount += 1;

            if (TpCount >= 4f)
            {
                TpCount = 1f;
            }
            if (TpCount == 1f)
            {
                TpIndicator.SetText("Current Time: Present");
            }
            if (TpCount == 2f)
            {
                TpIndicator.SetText("Current Time: Future");
            }
            if (TpCount == 3f)
            {
                TpIndicator.SetText("Current Time: Past");
            }
        }
    }
    IEnumerator Teleport()
    {
        
        if (TpCount == 1f)
        {
            gameObject.transform.position = Tp1;
        }
        if (TpCount == 2f)
        {
            gameObject.transform.position = Tp2;
        }
        if (TpCount == 3f)
        {
            gameObject.transform.position = Tp3;
        }
        yield return new WaitForSeconds(0.1f);
        teleporting = false;

    }

}
