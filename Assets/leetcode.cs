using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leetcode : MonoBehaviour
{

    string[] strs = new string[] {"flower", "flow", "flight"};
    string prefix; 

    // Start is called before the first frame update
    void Start()
    {
        prefix = strs[0];

        Debug.Log(strs[1].IndexOf(prefix));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int RomanToInt(string s)
    {

        int returnNumber = 0;
        string chars ="";
        

        for (int i = 0; i <= s.Length - 1; i++)
        {
            Debug.Log(i + " : " + chars);


            
            if (s.Length >= 2 && i < s.Length - 1)
            {
                chars = s.Substring(i, 2);


                if (chars == "IV")
                {
                    returnNumber += 4;
                    i++;
                    continue;
                }
                else if (chars == "IX")
                {
                    returnNumber += 9;
                    i++;
                    continue;
                }
                else if (chars == "XL")
                {
                    returnNumber += 40;
                    i++;
                    continue;
                }
                else if (chars == "XC")
                {
                    returnNumber += 90;
                    i++;
                    continue;
                }
                else if (chars == "CD")
                {
                    returnNumber += 400;
                    i++;
                    continue;
                }
                else if (chars == "CM")
                {
                    returnNumber += 900;
                    i++;
                    continue;
                }
            }


            chars = s.Substring(i, 1);



            if (chars == "I")
            {
                returnNumber += 1;

            }
            else if (chars == "V")
            {
                returnNumber += 5;

            }
            else if (chars == "X")
            {
                returnNumber += 10;

            }
            else if (chars == "L")
            {
                returnNumber += 50;

            }
            else if (chars == "C")
            {
                returnNumber += 100;

            }
            else if (chars == "D")
            {
                returnNumber += 500;

            }
            else if (chars == "M")
            {
                returnNumber += 1000;

            }


        }

        return returnNumber;
    }
}
