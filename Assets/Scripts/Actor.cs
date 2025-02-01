using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    private Color color;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();

        GetComponentInChildren<SkinnedMeshRenderer>().material.color = color;
    }

    public void UpdateAnimation(string stateName) 
    {
        animator.Play(stateName);
    }

    public void Die(int orderInStack) 
    {
        gameObject.layer = 6;

        var col = gameObject.AddComponent<SphereCollider>();

        col.radius = 0.3f;

        col.center = new Vector3(0, 0, -1);

        var rb = gameObject.AddComponent<Rigidbody>();

        rb.useGravity = true;

        rb.AddForce(-50 * orderInStack * transform.forward, ForceMode.Impulse);

        UpdateAnimation("Fall");
    }
}
