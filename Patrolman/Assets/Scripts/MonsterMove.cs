using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private float speed = 3.0f;
    private float mtime = 3.0f;

    private float x, z;
    private Vector3 vec;
    private bool is_run = true;

    private bool is_chase = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vec = this.gameObject.transform.position;
        mtime += Time.deltaTime;
        if (getDistance(Judge.x, Judge.z, vec.x, vec.z) < 30) {
            is_chase = true;
            mtime = 3.0f;
            speed = 11.0f;
            float theta = Mathf.Atan(Mathf.Abs(vec.z - Judge.z) / Mathf.Abs(vec.x - Judge.x));
            if (vec.x < Judge.x) {
                this.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime * Mathf.Cos(theta));
            } else {
                this.gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime * Mathf.Cos(theta));
            }
            if (vec.z < Judge.z) {
                this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime * Mathf.Sin(theta));
            } else {
                this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime * Mathf.Sin(theta));
            }
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            return;
        }else if(mtime >= 3) {
            if (is_chase) {
                is_chase = false;
                if(!UI.is_end)
                    UI.score += 1;
            }
            speed = 3.0f;
            mtime -= 3;
            float ori_x = vec.x, ori_z = vec.z;
            float x_min = vec.x - 20;
            float x_max = vec.x + 20;
            float z_min = vec.z - 20;
            float z_max = vec.z + 20;
            x = Random.Range(x_min, x_max);
            while(Mathf.Abs(x - ori_x) < 10) {
                x = Random.Range(x_min, x_max);
            }
            z = Random.Range(z_min, z_max);
            while (Mathf.Abs(z - ori_z) < 10) {
                z = Random.Range(z_min, z_max);
            }
        }
        if(x < vec.x) {
            this.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        } else {
            this.gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(z < vec.z) {
            this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        } else {
            this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    private void OnCollisionEnter(Collision collision) {
        
    }

    float getDistance(float x1, float y1, float x2, float y2) {
        return Mathf.Sqrt(Mathf.Pow(Mathf.Abs(x1 - x2), 2) + Mathf.Pow(Mathf.Abs(y1 - y2), 2));
    }
}
