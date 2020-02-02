using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public char controller;             //Floating point variable to store the player's movement speed.

    private Animator animator;
    private AudioSource source;
    // private bool playingWalkingSound;

    private bool stunned;
    private float inputX, inputY;
    private Vector3 movement = new Vector3(0, 0, 0);
    private Vector3 facingDirection = new Vector3(0, 1, 0);

    private SpriteRenderer itemCarregadoSpriteRenderer;
    private ItemScript.ItemType currentItem = ItemScript.ItemType.None;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        itemCarregadoSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stunned) {
            Move();
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.Normalize(movement) * speed * Time.deltaTime);
    }

    private void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal" + controller);
        inputY = Input.GetAxisRaw("Vertical" + controller);

        movement = Vector3.zero;

        animator.SetFloat("SpeedX", 0);
        animator.SetFloat("SpeedY", 0);
            
        if (inputX != 0 || inputY != 0)
        {
            animator.SetBool("Walking", true);
            //if (!playingWalkingSound)
            //{
            //    playingWalkingSound = true;
            //    source.Play();
            //}
            
            if (inputX > 0 || inputX < 0)
            {
                animator.SetFloat("LastMoveX", inputX);
                animator.SetFloat("SpeedX", inputX);
                facingDirection = new Vector3(inputX, 0, 0);
                movement.x = inputX;
            }
            else {
                animator.SetFloat("LastMoveX", 0f);
            }
            
        
            if (inputY > 0 || inputY < 0)
            {
                animator.SetFloat("LastMoveY", inputY);
                animator.SetFloat("SpeedY", inputY);
                facingDirection = new Vector3(0, inputY, 0);
                movement.y = inputY;
            }
            else {
                animator.SetFloat("LastMoveY", 0f);
            }
           
        }
        else
        {
            animator.SetBool("Walking", false);
            //source.Stop();
            // playingWalkingSound = false;
        }

        if (Input.GetButtonDown("Interact" + controller))
        {
            if(currentItem != ItemScript.ItemType.None)
            {
                var item = Resources.Load<GameObject>("Prefabs/ItemLancado");
                var itemLancadoScript = Instantiate(
                        item,
                        transform.position + facingDirection * 0.5f,
                        Quaternion.identity
                    ).GetComponent<ItemLancado>();
                itemLancadoScript.Throw(currentItem, facingDirection);
                currentItem = ItemScript.ItemType.None;
                itemCarregadoSpriteRenderer.sprite = null;
            }
        }

    }

    public bool IsMoving()
    {
        return inputX != 0 || inputY != 0;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        switch(collider.gameObject.tag)
        {
            case "Item":
                var itemScript = collider.gameObject.GetComponent<ItemScript>();
                currentItem = itemScript.itemType;
                itemCarregadoSpriteRenderer.sprite = GameManager.Instance.sprites[(int)currentItem];
                GameObject.Destroy(collider.gameObject);
                break;
            case "ItemLancado":
                StartCoroutine(Stun());
                break;
        }
    }

    private IEnumerator Stun()
    {
        stunned = true;
        movement = Vector3.zero;
        animator.SetBool("Stunned", stunned);

        yield return new WaitForSeconds(3.0f);

        stunned = false;
        animator.SetBool("Stunned", stunned);
    }

}
