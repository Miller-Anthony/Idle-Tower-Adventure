using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BigNumber
{
    List<byte> digit;


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

    public int CountDigits()
    {
        int subtract_from = 0;
        for(int i = digit.Count - 1; i >= 0; --i)
        {
            if (digit[i] != 0)
                break;
            ++subtract_from;
        }
        return digit.Count - subtract_from;
    }

    // lots of references, remain undeprecated
    public BigNumber(double num, int mod = 0)
    {
        /*if (num <= 0)
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
        }*/
        digit = new List<byte>();
        while (mod > 0)
        {
            num = num * 1000;
            mod--;
        }

        while (num > 9)
        {
            digit.Add((byte)(num % 10));
            num /= 10;
        }
        if (num != 0)
            digit.Add((byte)num);
    }

    public BigNumber(ulong num)
    {
        digit = new List<byte>();
        while (num > 9)
        {
            digit.Add((byte)(num % 10));
            num /= 10;
        }
        if (num != 0)
            digit.Add((byte)num);
    }

    public static BigNumber operator +(BigNumber num)
    {
        return num;
    }

    public static BigNumber operator +(BigNumber num1, BigNumber num2)
    {
        int max = Math.Max(num1.CountDigits(), num2.CountDigits());
        int min = Math.Min(num1.CountDigits(), num2.CountDigits());

        BigNumber toReturn = new BigNumber(0);
        byte carry = 0;
        int continued = 0;

        for (int i = 0; i < min; ++i)
        {
            byte total = (byte)(num1.digit[i] + num2.digit[i] + carry);
            if (total > 9)
            {
                total -= 10;
                carry = 1;
            }
            else
            {
                carry = 0;
            }
            toReturn.digit.Add(total);
            continued = i + 1;
        }
        for(int i = continued; i < max; ++i)
        {
            if(num1 > num2)
            {
                if(num1.digit[i] + carry > 9)
                {
                    toReturn.digit.Add(0);
                }
                else
                {
                    toReturn.digit.Add((byte)(num1.digit[i] + carry));
                    carry = 0;
                }
            }
            else
            {
                if (num2.digit[i] + carry > 9)
                {
                    toReturn.digit.Add(0);
                }
                else
                {
                    toReturn.digit.Add((byte)(num2.digit[i] + carry));
                    carry = 0;
                }
            }
        }
        if (carry > 0)
            toReturn.digit.Add(carry);

        return toReturn;
    }

    public static BigNumber operator -(BigNumber num1, BigNumber num2) // 30 - 22 = 18?
    {
        if(num2.CountDigits() > num1.CountDigits())
        {
            return new BigNumber(0);
        }

        BigNumber toReturn = new BigNumber(0);
        byte carry = 0;
        int continued = 0;

        for (int i = 0; i < num2.CountDigits(); ++i)
        {
            if (num1.digit[i] == 0 && carry != 0)
            {
                toReturn.digit.Add((byte)(9 - num2.digit[i]));
                carry = 1;
            }
            else if (num2.digit[i] > (num1.digit[i] - carry))
            {
                toReturn.digit.Add((byte)(num1.digit[i] + 10 - (num2.digit[i] + carry)));
                carry = 1;
            }
            else
            {
                toReturn.digit.Add((byte)(num1.digit[i] - (num2.digit[i] + carry)));
                carry = 0;
            }
            continued = i + 1;
        }
        for(int i = continued; i < num1.CountDigits(); ++i)
        {
            if(num1.digit[i] == 0 && carry != 0)
            {
                toReturn.digit.Add(9);
                carry = 1;
            }
            else if(carry != 0)
            {
                toReturn.digit.Add((byte)(num1.digit[i] - carry));
                carry = 0;
            }
            else
                toReturn.digit.Add(num1.digit[i]);
        }
        if (carry != 0)
            return new BigNumber(0);
        return toReturn;
    }

    public static BigNumber operator *(BigNumber num1, BigNumber num2)
    {
        BigNumber toReturn = new BigNumber(0);
        for(int i = 0; i < num1.CountDigits(); ++i)
        {
            for(int j = 0; j < num2.CountDigits(); ++j)
            {
                toReturn += new BigNumber(num1.digit[i] * num2.digit[j] * Math.Pow(10, (i + j)));
            }
        }
        return toReturn;
    }

    public static BigNumber operator *(BigNumber num1, double num2)
    {
        BigNumber toReturn = new BigNumber(0);

        int digits = 1;
        // code here - WIP
        if(num2 > 10)
        {
            digits = (int)(Math.Log10(num2));
        }
        for (int i = 0; i < num1.CountDigits(); ++i)
        {
            for (int j = 0; j < digits; ++j)
            {
                int current = (int)(num2) / (int)(Math.Pow(10, j)) % 10;
                toReturn += new BigNumber(num1.digit[i] * current * Math.Pow(10, (i + j)));
            }
        }
        num2 %= 1.0;
        int counter = 0;
        while(num2 < 1.0 && num2 > 0.0)
        {
            num2 *= 10;
            ++counter;
            toReturn += BigDivision((num1 * new BigNumber(num2 % 10)), new BigNumber(Math.Pow(10, counter)));
        }

        return toReturn;
    }


    // Precision: 15 decimal places
    public static double operator /(BigNumber num1, BigNumber num2) // fractional method
    {
        BigNumber num1_clone = num1;
        double total = 0;
        while (num1_clone > num2)
        {
            double iter = 1;
            BigNumber val = num2;
            while (val * new BigNumber(10) < num1_clone)
            {
                val *= new BigNumber(10);
                iter *= 10;
            }
            BigNumber val_clone = val;
            double iter_clone = iter;
            while (val + val_clone < num1_clone)
            {
                val += val_clone;
                iter += iter_clone;
            }
            num1_clone -= val;
            total += iter;
        }

        for(int i = 1; i <= 15; ++i)
        {
            if (num1_clone == new BigNumber(0))
                break;
            num1_clone *= new BigNumber(10);
            BigNumber val = num2;
            BigNumber val_clone = val;
            double iter = 1;
            double iter_clone = iter;
            while (val + val_clone < num1_clone)
            {
                val += val_clone;
                iter += iter_clone;
            }
            num1_clone -= val;
            total += iter * Math.Pow(10, -i);
        }

        return total;
    }


    public static BigNumber BigDivision(BigNumber num1, BigNumber num2) // groups method
    {
        BigNumber num1_clone = num1;
        BigNumber total = new BigNumber(0);
        while (num1_clone > num2)
        {
            BigNumber iter = new BigNumber(1);
            BigNumber val = num2;
            while (val * new BigNumber(10) < num1_clone)
            {
                val *= new BigNumber(10);
                iter *= new BigNumber(10);
            }
            BigNumber val_clone = val;
            BigNumber iter_clone = iter;
            while (val + val_clone < num1_clone)
            {
                val += val_clone;
                iter += iter_clone;
            }
            num1_clone -= val;
            total += iter;
        }
        if (num1_clone == num2)
            total = total + new BigNumber(1);
        return total;
    }

    //multiplies BigNumber by another BigNumber representing a percentage

    //THIS IS NOT A MODULO OPERATION (see below function)
    public static BigNumber operator %(BigNumber num1, BigNumber num2)
    {
        return BigDivision(num1 * num2, new BigNumber(100));
    }
    public static float operator %(float num1, BigNumber num2)
    {
        return (float)((num2 * num1) / new BigNumber(100));
    }
    public static double operator %(double num1, BigNumber num2)
    {
        return (num2 * num1) / new BigNumber(100);
    }
    public static BigNumber operator %(int num1, BigNumber num2)
    {
        return BigDivision(new BigNumber(num1) * num2, new BigNumber(100));
    }

    public static BigNumber modulo(BigNumber num1, BigNumber num2)
    {
        if (num2 == new BigNumber(0))
            return num1;

        BigNumber num1_clone = num1;
        while (num1_clone > num2)
        {
            BigNumber val = num2;
            while (val * new BigNumber(10) < num1_clone)
            {
                val *= new BigNumber(10);
            }
            BigNumber val_clone = val;
            while (val + val_clone < num1_clone)
            {
                val += val_clone;
            }
            num1_clone -= val;
        }
        return num1_clone;
    }

    public static bool operator <(BigNumber num1, BigNumber num2)
    {
        if (num1.CountDigits() < num2.CountDigits())
            return true;
        else if (num1.CountDigits() > num2.CountDigits())
            return false;
        else
        {
            for(int i = num1.CountDigits() - 1; i >= 0; --i)
            {
                if (num1.digit[i] < num2.digit[i])
                    return true;
                else if (num1.digit[i] > num2.digit[i])
                    return false;
            }
        }
        return false;
    }

    public static bool operator >(BigNumber num1, BigNumber num2)
    {
        return num2 < num1;
    }

    public static bool operator <=(BigNumber num1, BigNumber num2)
    {
        if (num1.CountDigits() < num2.CountDigits())
            return true;
        else if (num1.CountDigits() > num2.CountDigits())
            return false;
        else
        {
            for (int i = num1.CountDigits() - 1; i >= 0; --i)
            {
                if (num1.digit[i] < num2.digit[i])
                    return true;
                else if (num1.digit[i] < num2.digit[i])
                    return false;
            }
        }
        return true;
    }

    //Compare 2 big numbers to if one is bigger than the other
    public static bool operator >=(BigNumber num1, BigNumber num2)
    {
        return num2 <= num1;
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
        //return new BigNumber(num1.number * num2, num1.modifier);
        return new BigNumber(0);
    }

    //when a BigNumber is multiplied by an int
    public static BigNumber operator *(int num1, BigNumber num2)
    {
        //return new BigNumber(num1 * num2.number, num2.modifier);
        return new BigNumber(0);
    }

    //when a BigNumber is multiplied by a float
    public static BigNumber operator *(BigNumber num1, float num2)
    {
        //return new BigNumber(num1.number * num2, num1.modifier);
        return new BigNumber(0);
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

    public static bool operator !=(BigNumber num1, BigNumber num2)
    {
        return !(num1 == num2);
    }

    public static bool operator ==(BigNumber num1, BigNumber num2)
    {
        if (num1.CountDigits() != num2.CountDigits())
            return false;
        for(int i = 0; i < num1.CountDigits(); ++i)
        {
            if (num1.digit[i] != num2.digit[i])
                return false;
        }
        return true;
    }

    //returns a string formatted for UI display purposes
    public override string ToString()
    {
        /*string num = number.ToString("#.###");
        num = num + GetModefier(modifier);
        return num;*/
        if(CountDigits() == 0)
            return "0";

        if (CountDigits() < 10)
        {
            string num = "";
            for (int i = CountDigits() - 1; i >= 0; --i)
                num += digit[i].ToString();
            return num;
        }
        else
        {
            string num = digit[CountDigits() - 1].ToString();
            num += ".";
            for (int i = 1; i < 4; ++i)
                num += digit[CountDigits() - (1 + i)].ToString();
            num += " * 10^";
            num += (CountDigits() - 1).ToString();
            return num;
        }
    }

    //returns a modified string for game saving purposes
    public string SaveString()
    {
        string num = "";
        for(int i = CountDigits() - 1; i >= 0; --i)
        {
            num += digit[i].ToString();
        }
        return num;
        //return number + "\n" + modifier;
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
