using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Animator anim;
    private static readonly int Jump = Animator.StringToHash("Jump");

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Bounds boundsScript = player.GetComponent<Bounds>();

        anim.SetBool(Jump, boundsScript.justJump);
    }
}
