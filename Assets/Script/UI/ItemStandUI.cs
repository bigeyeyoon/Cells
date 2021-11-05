using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemStandUI : MonoBehaviour
{

    public TMP_Text Username;
    public TMP_Text Address;
    public GameObject ScrollContents;
    public GameObject ItemPreviewPrefab;

    public Cam_Move CamMove;

    public ItemStandData data;
    GameObject Player;
    private float m_fDist = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        CamMove = GameObject.Find("Main Camera").GetComponent<Cam_Move>();

        //for (int i = 0; i<data.items.Count; i++)
        //{
            

        //}
    }

    // Update is called once per frame
    void Update()
    {
        print(CamMove.position);
        print(transform.position);
        transform.rotation = Quaternion.LookRotation(transform.position - CamMove.position, Vector3.up);

        print("itemstand");

        print((Vector3.Distance(Player.transform.position, transform.position)));
        if (Vector3.Distance(Player.transform.position, transform.position) < m_fDist)
        {
            print("in");
            PushUIManager.Show<QueryItemListPush>();
        }

        else PushUIManager.Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide() { gameObject.SetActive(false); }

}
