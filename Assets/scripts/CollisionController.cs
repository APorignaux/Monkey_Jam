using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    

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

    
}
