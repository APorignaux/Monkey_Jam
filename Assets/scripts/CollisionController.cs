using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private float _pushingForce; //SerializeField sert à ajuster la valeur dynamiquement dans Unity 
    public float PushingForce
    {
        get => this._pushingForce;
        set => this._pushingForce = value;
    }

    private Rigidbody2D _body; //variable qui contient le corps du joueur (objet à manipuler)
    public Rigidbody2D Body
    {
        get => this._body;
        set => this._body = value;
    }

    private Animator _animator;
    public void Awake() //methdode qui est appellé à chaque fois que le script est chargé (point d'entré)
    {
        //references 
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
    }

    //private bool _isDamaged;
    //public bool IsDamaged
    //{
    //    get => this._isDamaged;
    //    set => this._isDamaged = value;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tiki"))
        {
            Debug.Log("enter");
            _animator.SetBool("isDamaged", true);

            if(Body.velocity.x < 0) 
            _body.velocity = new Vector2(-10, Body.velocity.y);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tiki"))
        { 
            Debug.Log("stay");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tiki"))
        {
            Debug.Log("exit");
            _animator.SetBool("isDamaged", false);
        }
    }
}
