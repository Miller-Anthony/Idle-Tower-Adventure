using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberManager : MonoBehaviour
{
    public enum numbers
    {
        hundred,
        thousand,
        million,
        billion,
        trillion,
        quadrillion,
        a,
        b,
        c,
        d,
        e,
        f,
        g,
        h,
        i,
        j,
        k,
        l,
        m,
        n,
        o,
        p,
        q,
        r,
        s,
        t,
        u,
        v,
        w,
        x,
        y,
        z,
        aa,
        ab
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetModefier(int num)
    {
        switch (num)
        {
            case (int)numbers.hundred:
                return "";
            case (int)numbers.thousand:
                return "K";
            case (int)numbers.million:
                return "M";
            case (int)numbers.billion:
                return "B";
            case (int)numbers.trillion:
                return "T";
            case (int)numbers.quadrillion:
                return "Q";
            case (int)numbers.a:
                return "a";
            case (int)numbers.b:
                return "b";
            case (int)numbers.c:
                return "c";
            case (int)numbers.d:
                return "d";
            case (int)numbers.e:
                return "e";
            case (int)numbers.f:
                return "f";
            case (int)numbers.g:
                return "g";
            case (int)numbers.h:
                return "h";
            case (int)numbers.i:
                return "i";
            case (int)numbers.j:
                return "j";
            case (int)numbers.k:
                return "k";
            case (int)numbers.l:
                return "l";
            case (int)numbers.m:
                return "m";
            case (int)numbers.n:
                return "n";
            case (int)numbers.o:
                return "o";
            case (int)numbers.p:
                return "p";
            case (int)numbers.q:
                return "q";
            case (int)numbers.r:
                return "r";
            case (int)numbers.s:
                return "s";
            case (int)numbers.t:
                return "t";
            case (int)numbers.u:
                return "u";
            case (int)numbers.v:
                return "v";
            case (int)numbers.w:
                return "w";
            case (int)numbers.x:
                return "x";
            case (int)numbers.y:
                return "y";
            case (int)numbers.z:
                return "z";
            case (int)numbers.aa:
                return "aa";
            case (int)numbers.ab:
                return "ab";
            default:
                return "";
        }
    }
}
