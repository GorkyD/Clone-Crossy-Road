using UnityEngine;

public class Bounds : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private AudioSource audioSource;
    
    private Animator anim;
    private bool isJumping;

    private void Update()
    {
        anim = gameObject.GetComponent<Animator>();
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            anim.SetTrigger("Jump");
            isJumping = true;
            float xDifference = 0;
            if (transform.position.y % 1 != 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;
            }
            Move(new Vector3(-xDifference,0,1),new Vector3(0f,0f,0f));

        }
        else if (Input.GetKeyDown(KeyCode.A) && !isJumping)
        {
            Move(new Vector3(-1,0,0),new Vector3(0f,-90f,0f));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isJumping)
        {
            Move(new Vector3(1,0,0),new Vector3(0f,90f,0f));
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isJumping)
        {
            Move(new Vector3(0,0,-1),new Vector3(0f,180f,0f));
        }

    }

    private void Move(Vector3 difference,Vector3 angle)
    {
        anim.SetTrigger("Jump");
        isJumping = true;
        transform.position = (transform.position + difference);
        transform.rotation = Quaternion.Euler(angle);
        audioSource.Play();
        terrainGenerator.SpawnTerrain(false,transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<MovingObject>() != null)
        {
            if (collision.collider.GetComponent<MovingObject>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }
    }
    
    public void FinishJump()
    {
        isJumping = false;
    }
}


