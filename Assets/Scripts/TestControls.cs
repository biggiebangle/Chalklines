using UnityEngine;
using System.Collections;

public class TestControls : MonoBehaviour
{

    Sprite gradient;
    Animator animator;

    public float delayBeforeLoading = 1f;

    private float timeElapsed;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
           animator.SetTrigger("AnimateIn");
        }
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //bool fire = Input.GetButtonDown("Fire1");

        //animator.SetFloat("Forward", v);
        //animator.SetFloat("Strafe", h);
        //animator.SetBool("Fire", fire);
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.CompareTag("Enemy"))
    //    {
    //        animator.SetTrigger("Die");
    //    }
    //}
}
