using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public static float x;
    public static float z;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = this.gameObject.transform.position.x;
        z = this.gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        x = this.gameObject.transform.position.x;
        z = this.gameObject.transform.position.z;
    }

    private void OnCollisionEnter(Collision collision) {
        string str = collision.gameObject.name;
        if (getSameCount(str, "Cylinder") >= 5)
            UI.is_end = true;
    }

    private int getSameCount(string str1, string str2) {
        int len = str1.Length > str2.Length ? str2.Length : str1.Length;
        int count = 0;
        for(int i = 0; i < len; ++i) {
            if (str1[i] == str2[i]) ++count;
            else return count;
        }
        return count;
    }
}
