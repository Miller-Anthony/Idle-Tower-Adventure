using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNumberTests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Beginning Tests");

        BigNumber a = new BigNumber(123456);
        BigNumber b = new BigNumber(23456);
        Debug.Log(a.ToString());
        Debug.Log(b.ToString());
        BigNumber c = a + b;
        if(c != new BigNumber(146912))
        {
            Debug.Log("BigNumber Failed, 123456 + 23456 != 146912");
            Debug.Log(c.ToString());
        }
        c = a - b;
        if(c != new BigNumber(100000))
        {
            Debug.Log("BigNumber Failed, 123456 - 23456 != 100000");
            Debug.Log(c.ToString());
        }
        BigNumber d = new BigNumber(105);
        BigNumber e = new BigNumber(99);
        c = d - e;
        if (c != new BigNumber(6))
        {
            Debug.Log("BigNumber Failed, 105 - 99 = 6");
            Debug.Log(c.ToString());
        }
        c = e - d;
        if (c != new BigNumber(0))
        {
            Debug.Log("BigNumber Failed, Underflow Value");
            Debug.Log(c.ToString());
        }
        BigNumber f = new BigNumber(10000000000000000000);
        c = f - e;
        if (c != new BigNumber(9999999999999999901))
        {
            Debug.Log("BigNumber Failed, 10000000000000000000 - 99 != 9999999999999999901");
            Debug.Log(c.ToString());
        }
        c = new BigNumber(50);
        c += e;
        if (c != new BigNumber(149))
        {
            Debug.Log("BigNumber Failed, var(50) += 99 != 149");
            Debug.Log(c.ToString());
        }
        c = a * b;
        if(c != new BigNumber(2895783936))
        {
            Debug.Log("BigNumber Failed, 123456 * 23456 != 2895783936");
            Debug.Log(c.ToString());
        }
        ulong g = 0;
        ulong h = 0;
        for(int i = 0; i < 1000; ++i)
        {
            ulong answer = g * h;
            BigNumber gb = new BigNumber(g);
            BigNumber hb = new BigNumber(h);
            BigNumber answerb = gb * hb;
            if (answerb != new BigNumber(answer))
            {
                Debug.Log("Multiplication Test Failed");
            }

            g += (ulong)(Random.Range(0, 100));
            h += (ulong)(Random.Range(0, 100));
        }
        BigNumber l = new BigNumber(993);
        BigNumber m = new BigNumber(11);

        Debug.Log("993 / 11 = ");
        Debug.Log((l / m).ToString());

        Debug.Log("993 % 11 = ");
        Debug.Log((l % m).ToString());

        BigNumber aa = new BigNumber(10);
        BigNumber cc = aa * 0.3;
        Debug.Log("10 * 0.3 = ");
        Debug.Log((cc).ToString());
        BigNumber bb = new BigNumber(17);
        Debug.Log("17 * 0.7 = ");
        Debug.Log((bb * 0.7).ToString());

        /*BigNumber d = new BigNumber(1, 0);
        int comparator = 1;

        for(int i = 0; i < 100; ++i)
        {
            d *= 10;
            comparator *= 10;
            if(d != new BigNumber(comparator, 0))
            {
                Debug.Log("Test Failed: ");

                Debug.Log(d.ToString());

                Debug.Log(comparator.ToString());
            }
        }*/

        Debug.Log("All Tests Completed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
