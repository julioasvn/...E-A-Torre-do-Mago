using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public GameController   _GameController;

    public GameObject       HeroAtackPrefab;
    public GameObject       hitBoxPrefab;

    private Rigidbody2D     playerRB;

    private Animator        playerAnimator;

    public float            velocidade = 2.5f;

    private bool            IsLookLeft;
    public bool             IsAtack;
    public Transform        mao;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        
        _GameController.playerTransform = this.transform;

        transform.position = new Vector3(0, -3.7f, 0);

    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");        

        Moviment();

        if (Input.GetButtonDown("Fire1") && IsAtack == false)
        {
            IsAtack = true; 
            _GameController.playSFX(_GameController.sfxAtack, 0.5f);
            playerAnimator.SetTrigger("atack");
        }
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {            
            Instantiate(HeroAtackPrefab, transform.position, Quaternion.identity);             
        }

        if (IsAtack == true)
        {
            h = 0;
            v = 0;
        }

        playerAnimator.SetInteger("h", (int) h);
        playerAnimator.SetInteger("v", (int) v);
        playerAnimator.SetBool("IsAtack", IsAtack);

    }

    private void Flip()
    {
        IsLookLeft = !IsLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    private void Moviment()
    {
        float EntradaHorizontal = Input.GetAxis("Horizontal");
        
        if (EntradaHorizontal > 0 && IsLookLeft) 
        {
            Flip();
        } 
        else if (EntradaHorizontal < 0 && !IsLookLeft) 
        {
            Flip();
        }

        float EntradaVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * velocidade * EntradaHorizontal);
        transform.Translate(Vector3.up * Time.deltaTime * velocidade * EntradaVertical);

        if (transform.position.y > 3.7f)
        {
            transform.position = new Vector3(transform.position.x, 3.7f, 0);
        }
        else if (transform.position.y < -3.7f)
        {
            transform.position = new Vector3(transform.position.x, -3.7f, 0);
        }

        if (transform.position.x > 7.7f)
        {
            transform.position = new Vector3(7.7f, transform.position.y, 0);
        }
        else if (transform.position.x < -7.7f)
        {
            transform.position = new Vector3(-7.7f, transform.position.y, 0);
        }
    }
    
    void OnEndAtack() 
    {
        IsAtack = false;
    }

    void hitBoxAtack()
    {
        GameObject HitBoxTemp = Instantiate(hitBoxPrefab, mao.position, transform.localRotation);
        Destroy(HitBoxTemp, 0.2f);
    }
}