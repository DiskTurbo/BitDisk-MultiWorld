using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using JSAM;

public class Rupee : MonoBehaviour
{
    public float spinRate = 3f;
    [SerializeField] GameObject headRupee;
    [SerializeField] Text counter;
    public static float rupeeCount;
    private void Awake()
    {
        rupeeCount = 0f;
        counter.text = "000";
    }
    void FixedUpdate()
    {
        this.transform.Rotate(0f, (spinRate), 0f, Space.Self);
        if (rupeeCount == 10f)
        {
            SceneManager.LoadScene("End");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "JohnLemon")
        {
            headRupee.SetActive(true);
            Invoke("HideRupee", 0.75f);
            JSAM.AudioManager.PlaySound(Sounds.Rupee);
            rupeeCount++;
            Destroy(this.GetComponentInChildren<MeshFilter>());
            Destroy(this.GetComponent<Collider>());
            counter.text = "00" + rupeeCount.ToString();
        }
    }

    void HideRupee()
    {
        headRupee.SetActive(false);
        Destroy(this.gameObject);
    }

}
