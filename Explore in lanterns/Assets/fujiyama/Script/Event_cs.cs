﻿using UnityEngine;
using System.Collections;


public class Event_cs : MonoBehaviour {

    public int Type=1;//識別の数字

    SpriteRenderer MainspriteRender;
    public Sprite BoxOpen;

    public bool openflg = false;

    [SerializeField,Tooltip("乱数")]
    int range;

    int hougyouku;

    Vector3 pos;

    bool seisei = true;//生成のやつ

    [SerializeField, Tooltip("宝玉３")]
    GameObject hougyo3;

    [SerializeField, Tooltip("宝玉２")]
    GameObject hougyo2;

    [SerializeField, Tooltip("宝玉")]
    GameObject hougyo;

    GameObject yapre;

    GameObject oill;

    int yumiya = 0; //弓矢の本数 

    [SerializeField]
    int max = 0;


    int save; //ランダム保存用

    int save2;   //ランダム(宝玉)保存用


    // Use this for initialization
    void Start () {
        MainspriteRender = GetComponent<SpriteRenderer>();

        pos = transform.position;

        hougyo3 = (GameObject)Resources.Load("宝玉3");

        hougyo2 = (GameObject)Resources.Load("２宝玉");

        hougyo = (GameObject)Resources.Load("火竜");

        yapre = (GameObject)Resources.Load("ya");

        oill = (GameObject)Resources.Load("oil");


    }
	
	// Update is called once per frame


    void OnTriggerEnter2D(Collider2D other)
    {
        print("反応"); //デバッグ

        if (Type == 1 && other.tag == "a") stairs(); //階段

        if (Type == 2 && other.tag == "a") trasureChest(); //宝箱を空ける前

        if (Type == 2 && other.tag == "b"&&openflg==true) trsureChestopen(); //宝箱が開いた時

        if (Type == 3 && other.tag == "a") trap();//罠
    }


    public void stairs()
    {
        print("階段");
        ///////////////////////////
        //今村氏のメソッドを呼ぶ//
        /////////////////////////
    }


    public void trasureChest()
    {
        print("宝箱のメソッド");

        MainspriteRender.sprite = BoxOpen;

        range = Random.Range(0, 100);

        save = range;
        



        if (range <= 20) //20以下
        {
            if (seisei==true)
            {
                print("aaaaa");
               
                Instantiate(yapre);
                yapre.transform.position = new Vector3(pos.x, pos.y, 0);
                seisei = false;
            }
        }




        else if (range > 60) //6０より上
        {
            if (seisei == true)
            {
                hougyouku = Random.Range(0, 100);
                save2 = hougyouku;
                if (hougyouku <= 20) //宝玉３生成　20%
                {
                    //GameObject hougyo3 = (GameObject)Resources.Load("宝玉3");
                    Instantiate(hougyo3);
                    hougyo3.transform.position = new Vector3(pos.x, pos.y, 0);
                    seisei = false;
                }

                else if (hougyouku>=80) //宝玉２生成　20%
                {
                    //GameObject hougyo2 = (GameObject)Resources.Load("２宝玉");
                    Instantiate(hougyo2);
                    hougyo2.transform.position = new Vector3(pos.x, pos.y, 0);
                    seisei = false;

                }
                else //それ以外
                {
                    //GameObject hougyo = (GameObject)Resources.Load("宝玉");
                    Instantiate(hougyo);
                    hougyo.transform.position = new Vector3(pos.x, pos.y, 0);
                    seisei = false;

                }

            }
        }


        //if (range >= 90)  //８０以上
        else
        {
            if (seisei == true)
            {
                Instantiate(oill);
                oill.transform.position = new Vector3(pos.x, pos.y, 0);
                seisei = false;
            }
           
        }

        openflg = true;


       // gameObject.SetActive(false);
    }

   public void trsureChestopen()
    {
        if (save<=20) //矢
        {
            int yuram = Random.Range(1, 4);

            if (yumiya <= max)
            {
                yumiya = yumiya + yuram;
                
            }
            print(yumiya);

        }
        

    }

    public void trap()
    {

    }

   
    
    
        
}
