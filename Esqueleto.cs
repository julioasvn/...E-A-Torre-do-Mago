using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Esqueleto : MonoBehaviour
{
    public GameController   _GameController;
    public Transform        playerTransform;
    public Transform        xEsqueleto;


    private float           _speed = 1.0f;
    private bool            IsLookLeft;
        
    void Start()
    {
        transform.position = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-2.5f, 3.5f), 0);
    }
    
    void Update()
    {
        

        xEsqueleto = transform.position.x;
        xPlayer = playerTransform.position.x;

        if(xEsqueleto > xPlayer) 
        {
            xEsqueleto--;

        }else if (xEsqueleto < xPlayer) 
        {
            xEsqueleto++;
        }

        transform.Translate(new Vector3(xEsqueleto, transform.position.y, transform.position.z));

        if (transform.position.x > 7.7f)
        {
            transform.position = new Vector3(7.7f, transform.position.y, 0);
            _speed = _speed * -1;
        }
        else if (transform.position.x < -7.7f)
        {
            transform.position = new Vector3(-7.7f, transform.position.y, 0);
            _speed = _speed * -1;
        }
        

        //float EntradaHorizontal = Input.GetAxis("Horizontal");

        if (_speed > 0 && IsLookLeft)
        {
            Flip();
        }
        else if (_speed < 0 && !IsLookLeft)
        {
            Flip();
        }
    }

    private void Flip()
    {
        IsLookLeft = !IsLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    public void footStep()
    {
        _GameController.playSFX(_GameController.sfxStep[Random.Range(0, _GameController.sfxStep.Length)], 0.2f);
    }
}

