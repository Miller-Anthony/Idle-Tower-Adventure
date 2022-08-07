using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNumber
{
    private double number;
    private int modifier;


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

    public BigNumber(double num, int mod = 0)
    {
        if (num < 0)
        {
            num = 0;
            mod = 0;
        }

        while(num >= 1000)
        {
            num = num / 1000;
            mod++;
        }

        while(num < 1 && num > 0 && mod > 0)
        {
            num = num * 1000;
            mod--;
        }



        number = num;
        modifier = mod;
    }

    public static BigNumber operator +(BigNumber num)
    {
        return num;
    }

    public static BigNumber operator +(BigNumber num1, BigNumber num2)
    {
        
        if(num1.modifier > num2.modifier)
        { 
            while (num1.modifier > num2.modifier)
            {
                num2.number = num2.number / 1000;
                num2.modifier++;
            }
        }
        else if (num1.modifier < num2.modifier)
        {
            while (num1.modifier < num2.modifier)
            {
                num1.number = num1.number / 1000;
                num1.modifier++;
            }
        }

        return new BigNumber(num1.number + num2.number, num2.modifier);
    }

    public static BigNumber operator -(BigNumber num1, BigNumber num2)
    {
        if (num1.modifier > num2.modifier)
        {
            while (num1.modifier > num2.modifier)
            {
                num2.number = num2.number / 1000;
                num2.modifier++;
            }
        }
        else if (num1.modifier < num2.modifier)
        {
            while (num1.modifier < num2.modifier)
            {
                num1.number = num1.number / 1000;
                num1.modifier++;
            }
        }

        return new BigNumber(num1.number - num2.number, num2.modifier);
    }

    public static BigNumber operator *(BigNumber num1, BigNumber num2)
    {
        return new BigNumber(num1.number * num2.number, num1.modifier + num2.modifier);
    }

    public static float operator /(BigNumber num1, BigNumber num2)
    {
        if (num1.modifier > num2.modifier)
        {
            while (num1.modifier > num2.modifier)
            {
                num2.number = num2.number / 1000;
                num2.modifier++;
            }
        }
        else if (num1.modifier < num2.modifier)
        {
            while (num1.modifier < num2.modifier)
            {
                num1.number = num1.number / 1000;
                num1.modifier++;
            }
        }

        return (float)(num1.number / num2.number);
    }

    //multiplies BigNumber by another BigNumber representing a percentage
    public static BigNumber operator %(BigNumber num1, BigNumber num2)
    {
        //this is wrong as it does not take the modefier of the percentage big number into account
        return new BigNumber(num1.number * ((num2.number / 100) + 1), num1.modifier);
    }

    //multiplies BigNumber by another BigNumber representing a percentage
    public static float operator %(float num1, BigNumber num2)
    {
        //this is wrong as it does not take the modefier of the percentage big number into account
        return num1 * ((float)num2.number / 100 + 1);
    }

    //multiplies BigNumber by another BigNumber representing a percentage
    public static double operator %(double num1, BigNumber num2)
    {
        //this is wrong as it does not take the modefier of the percentage big number into account
        return num1 * (num2.number / 100 + 1);
    }

    //multiplies BigNumber by another BigNumber representing a percentage
    public static int operator %(int num1, BigNumber num2)
    {
        //this is wrong as it does not take the modefier of the percentage big number into account
        return (int)(num1 * (num2.number / 100) + 1);
    }

    public static bool operator <(BigNumber num1, BigNumber num2)
    {
        
        if(num1.modifier < num2.modifier)
        {
            return true;
        }
        else if(num1.modifier > num2.modifier)
        {
            return false;
        }

        if(num1.number < num2.number)
        {
            return true;
        }
        else if(num1.number > num2.number)
        {
            return false;
        }    

        return false;
    }

    public static bool operator >(BigNumber num1, BigNumber num2)
    { 
        if (num1.modifier > num2.modifier)
        {
            return true;
        }
        else if (num1.modifier < num2.modifier)
        {
            return false;
        }

        if (num1.number > num2.number)
        {
            return true;
        }
        else if (num1.number < num2.number)
        {
            return false;
        }

        return false;
    }

    public static bool operator <=(BigNumber num1, BigNumber num2)
    {

        if (num1.modifier < num2.modifier)
        {
            return true;
        }
        else if (num1.modifier > num2.modifier)
        {
            return false;
        }

        if (num1.number < num2.number)
        {
            return true;
        }
        else if (num1.number > num2.number)
        {
            return false;
        }

        return true;
    }

    //Compare 2 big numbers to if one is bigger than the other
    public static bool operator >=(BigNumber num1, BigNumber num2)
    {
        if (num1.modifier > num2.modifier)
        {
            return true;
        }
        else if (num1.modifier < num2.modifier)
        {
            return false;
        }

        if (num1.number > num2.number)
        {
            return true;
        }
        else if (num1.number < num2.number)
        {
            return false;
        }

        return true;
    }

    //when an int is added to a BigNumber
    public static BigNumber operator +(BigNumber num1, int num2)
    {
        return num1 + new BigNumber(num2);
    }

    //when an int is added to a BigNumber
    public static BigNumber operator +(int num1, BigNumber num2)
    {
        return num2 + new BigNumber(num1);
    }

    //when a BigNumber is multiplied by an int
    public static BigNumber operator *(BigNumber num1, int num2)
    {
        return new BigNumber(num1.number * num2, num1.modifier);
    }

    //when a BigNumber is multiplied by an int
    public static BigNumber operator *(int num1, BigNumber num2)
    {
        return new BigNumber(num1 * num2.number, num2.modifier);
    }

    //when a BigNumber is multiplied by a float
    public static BigNumber operator *(BigNumber num1, float num2)
    {
        return new BigNumber(num1.number * num2, num1.modifier);
    }

    //when a BigNumber is compared to an int
    public static bool operator >(BigNumber num1, int num2)
    {
        return num1 > new BigNumber(num2);
    }

    //when a BigNumber is compared to an int
    public static bool operator <(BigNumber num1, int num2)
    {
        return num1 < new BigNumber(num2);
    }

    //when a BigNumber is compared to an int
    public static bool operator >=(BigNumber num1, int num2)
    {
        return num1 >= new BigNumber(num2);
    }

    //when a BigNumber is compared to an int
    public static bool operator <=(BigNumber num1, int num2)
    {
        return num1 <= new BigNumber(num2);
    }

    //returns the BigNumber as an int as best as possible (cant do numbers above the int cap)
    public int ToInt()
    {
        double temp = number;

        for(int i = 0; i < modifier; i++)
        {
            temp /= 1000;
        }
        return (int)temp;
    }

    //returns a string formatted for UI display purposes
    public override string ToString()
    {
        string num = number.ToString("#.###");
        num = num + GetModefier(modifier);
        return num;
    }

    //returns a modified string for game saving purposes
    public string SaveString()
    {
        return number + "\n" + modifier;
    }

    //gets the apropriate number place value for UI string display 
    private string GetModefier(int num)
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
