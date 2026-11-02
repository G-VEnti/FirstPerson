using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class JetpackBehaviour : MonoBehaviour
{
    private FPSMovement FPSMovement;
    private Rigidbody rb;
    public Image currentFuelIMG;
    private bool canJetpack = true;
    public float jetpackForce;
    public float maxJPTime = 1f;
    public float JPUseTime = 1f;
    private bool canRefill = true;
    private bool isCRRunning = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FPSMovement = GetComponent<FPSMovement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (JPUseTime <= 0)
        {
            canJetpack = false;
            JPUseTime = 0;
        }        
        if (JPUseTime >= maxJPTime) JPUseTime = maxJPTime;
        if (JPUseTime > 0) canJetpack = true;

        if (FPSMovement.isGrounded)
        {
            if (!isCRRunning) StartCoroutine(JetpackRefill());
        }
        else
        {
            canRefill = false;

             if (InputSystemManager.instance.inputs.Player.Jump.IsPressed() && canJetpack)
            {
                JPUseTime -= Time.deltaTime;
                rb.AddForce(transform.up * jetpackForce);
            }
        }

        if (canRefill) JPUseTime += Time.deltaTime * 2;

        currentFuelIMG.fillAmount = JPUseTime;
    }

    IEnumerator JetpackRefill()
    {
        isCRRunning = true;

        if (JPUseTime >= maxJPTime)
        {
            isCRRunning = false;
            yield break;
        } 

        if (!canJetpack)
        {
            yield return new WaitForSeconds(0.5f);
            canRefill = true;
        }
        else canRefill = true;

        isCRRunning = false;
    }
}