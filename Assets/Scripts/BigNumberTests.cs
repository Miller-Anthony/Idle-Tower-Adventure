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
