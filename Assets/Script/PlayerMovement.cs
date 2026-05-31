using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject objectToEnable;

    private Animator animator;
    private bool movimentoAtivo = true;

    void Start()
    {
        animator = GetComponent<Animator>();

        objectToEnable.SetActive(false);
    }

    void Update()
    {
        if (!movimentoAtivo)
            return;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0f, z).normalized;

        transform.position += move * speed * Time.deltaTime;

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        animator.SetBool("IsRuning", move.magnitude > 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            movimentoAtivo = false;

            animator.enabled = false;

            objectToEnable.SetActive(true);
        }
    }
}