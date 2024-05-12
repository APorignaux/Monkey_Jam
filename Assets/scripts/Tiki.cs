using System;
using UnityEngine;

public class Tiki : Personnage
{
    //Points qui definissent la patrouille du tiki
    public GameObject Point_A;
    public GameObject Point_B;

    protected Transform currentPoint;

    public override void Mouvement(bool state) { }
}

