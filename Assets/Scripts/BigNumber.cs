using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNumber
{
    private decimal number;
    private int modifier;
    [SerializeField] NumberManager numManager;

    public BigNumber(decimal num, int mod = 0)
    {
        while(num > 999)
        {
            num = num / 1000;
            mod++;
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
            while (num1.modifier > num2.modifier)
            {
                num1.number = num1.number / 1000;
                num1.modifier++;
            }
        }

        return new BigNumber(num1.number + num2.number, num2.modifier);
    }

    public static BigNumber operator -(BigNumber num1, BigNumber num2)
    {
        return num1;
    }

    public override string ToString()
    {
        string num = number.ToString("#.000");
        num = num + numManager.GetModefier(modifier);
        return num;
    }
}
