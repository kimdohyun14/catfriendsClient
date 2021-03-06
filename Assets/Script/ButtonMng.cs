﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



public class ButtonMng : MonoBehaviour
{
    public MoveAndAnimation_Chunbae moveAndAnimation_Chunbae;

    public StatusManager statusMng;


    public GameObject menu_chunbae;
    public GameObject menu_setting;
    public GameObject menu_post;
    public GameObject menu_center;
    public GameObject menu_Donation;
    public GameObject center_statButton;
    public GameObject center_openButton;
    public GameObject center_donation;
    public GameObject stats_chunbae;
    public GameObject stats_center;
    public GameObject menu_bomi;

    public GameObject category_background;

    public Image default_image;
    public Sprite Nyang;
    public Sprite Animal;

    public GameObject QuestUI;
    public GameObject DailyQuest;
    public GameObject Achievement;

    public GameObject shop_package;
    public GameObject shop_draw;
    public GameObject shop_dia;
    public GameObject popup_draw;
    //가게
    public GameObject menu_StoreUpgrade;
    public GameObject menu_Store;
    public GameObject stats_Store;

    public GameObject store_statButton;
    public GameObject store_openButton;
    //가게 


    public GameObject chunbae, quest, shop, center;
    bool isStoreClicked;

    public NestedScrollManager nestedScrollMng;


    //카페 슬라이더
    public Slider slider;
    //치킨 슬라이더
    public Slider slider_chicken;
    //곱창 슬라이더
    public Slider slider_Gobchang;
    //헬스 슬라이더
    public Slider slider_Health;
    //냥냐랜드 슬라이더
    public Slider slider_Land;


    //가게 해금 전, 해금 후 이미지
    public Image[] UnActive_StoreImage;
    public Sprite[] Active_Store;
    //가게 해금 전 화살표, 해금 후 화살표 이미지
    public Image[] UnActive_ArrowImage;
    public Sprite Active_Arrow;

    //가게 해금됐을때 터치랑 안해금됐을 때 터치


    public Text[] ChunbaeButtonText;


    public Image ChunbaeLevelUpButton;
    public Sprite ChunbaeLevelUpButton_Active;
    public Sprite ChunbaeLevelUpButton_UnActive;



    //스킬버튼

    public Image ChunbaeSkillButton_1;
    public Image ChunbaeSkillButton_2;
    public Image ChunbaeSkillButton_3;
    //스킬쿨타임
    public float coolTime_1;
    public float coolTime_2;
    public float coolTime_3;


    public GameObject[] SkillTextObject;
    public Text[] SKillText;
    //스킬 지속시간
   
    public float SkillHoldingTime_1;
    public float SkillHoldingTime_2;
    public float SkillHoldingTime_3;

    float SkillChecker_1;
    float SkillChecker_2;
    float SkillChecker_3;

    public bool IsSkill2;



    void Start()
    {


    }
    
  



    void Update()
    {


        //춘배버튼의 UI상태를 계속 업데이트
        ChunBae_UI();

        //Store가 해금되어 활성화되어있는지 아닌지 그 상태에 따라 표시되는 UI를 Update문으로 계쏙 호출하고 상태를 확인하면서 보여줌
        Check_IsActiveAndShowUI();

    }


    public void Useskill_1()
    {
        if(ChunbaeSkillButton_1.fillAmount == 0)
        {
            //스킬 쿨타임 관련
            ChunbaeSkillButton_1.fillAmount = 1;
            StartCoroutine("Cooltime_1");

                 //스킬 유지시간을 받아주는 임의의 변수에 받아오기
            SkillChecker_1 = SkillHoldingTime_1;


            SkillTextObject[0].SetActive(true);
            SKillText[0].text = "스킬 1 발동중";

            //스킬 유지시간에 따른 스킬 효과 시작
            StartCoroutine("Skill_1");

           
        

        }


       

    }
    public void Useskill_2()
    {
        if (ChunbaeSkillButton_2.fillAmount == 0)
        {
            //스킬 쿨타임 관련

            ChunbaeSkillButton_2.fillAmount = 1;
            StartCoroutine("Cooltime_2");


            //스킬 유지시간을 받아주는 임의의 변수에 받아오기
            SkillChecker_2 = SkillHoldingTime_2;


            SkillTextObject[1].SetActive(true);
            SKillText[1].text = "스킬 2 발동중";


            //스킬 유지시간에 따른 스킬 효과 시작
            StartCoroutine("Skill_2");
        }
          
    


    }
    public void Useskill_3()
    {

        if (ChunbaeSkillButton_3.fillAmount == 0)
        {
            //스킬 쿨타임 관련

            ChunbaeSkillButton_3.fillAmount = 1;
            StartCoroutine("Cooltime_3");


            //스킬 유지시간을 받아주는 임의의 변수에 받아오기
            SkillChecker_3 = SkillHoldingTime_3;


            SkillTextObject[2].SetActive(true);
            SKillText[2].text = "스킬 3 발동중";
            
            //스킬 유지시간에 따른 스킬 효과 시작
            StartCoroutine("Skill_3");

        }

    }

    IEnumerator Cooltime_1()
    {
        while (ChunbaeSkillButton_1.fillAmount > 0)
        {
            ChunbaeSkillButton_1.fillAmount -= 1 * Time.smoothDeltaTime / coolTime_1;

            yield return null;

        }
    }
    IEnumerator Cooltime_2()
    {
        while (ChunbaeSkillButton_2.fillAmount > 0)
        {
            ChunbaeSkillButton_2.fillAmount -= 1 * Time.smoothDeltaTime / coolTime_2;

            yield return null;

        }
    }
    IEnumerator Cooltime_3()
    {
        while (ChunbaeSkillButton_3.fillAmount > 0)
        {
            ChunbaeSkillButton_3.fillAmount -= 1 * Time.smoothDeltaTime / coolTime_3;

            yield return null;

        }
    }




    IEnumerator Skill_1()
    {
        while (SkillChecker_1 > 0)
        {
            SkillChecker_1 -= 0.1f;
            statusMng.Touch_IncreaseMoney();
            statusMng.Touch_IncreaseMoney();


            yield return new WaitForSeconds(0.1f);

        }
        SkillTextObject[0].SetActive(false);
        StopCoroutine("Skill_1");


    }
    IEnumerator Skill_2()
    {
       
        IsSkill2 = true;
          
       yield return new WaitForSeconds(SkillHoldingTime_2);

       

        IsSkill2 = false;
        SkillTextObject[1].SetActive(false);
        StopCoroutine("Skill_2");


    }

    IEnumerator Skill_3()
    {
        SingletonMng.instance.gage_cafe = 100;
        SingletonMng.instance.gage_chicken = 100;
        SingletonMng.instance.gage_gobchang = 100;
        SingletonMng.instance.gage_health = 100;
        SingletonMng.instance.gage_land = 100;


        
        yield return new WaitForSeconds(SkillHoldingTime_3);


        SkillTextObject[2].SetActive(false);
        StopCoroutine("Skill_3");


    }







    //춘배 레벨업 버튼을 눌렀을 때
    public void LevelUpButton_Chunbae()
    {
        if(SingletonMng.instance.Money >= statusMng.LevelUpCost_Chunbae)
        {
            SingletonMng.instance.Money = SingletonMng.instance.Money - statusMng.LevelUpCost_Chunbae;
            statusMng.Level_Chunbae = statusMng.Level_Chunbae + 1;
        }
        


    }

    void ChunBae_UI()
    {
        try
        {
            // 돈이 업글비용만큼 충분히 있으면 액티브 된 이미지로 보여집니다.
            if (SingletonMng.instance.Money >= statusMng.LevelUpCost_Chunbae)
            {
                ChunbaeLevelUpButton.sprite = ChunbaeLevelUpButton_Active;
            }
            
            else if(SingletonMng.instance.Money < statusMng.LevelUpCost_Chunbae)
            {
                ChunbaeLevelUpButton.sprite = ChunbaeLevelUpButton_UnActive;
            }
            



            if (SceneManager.GetActiveScene().name == "Main")
            {
                for (int i = 0; i < ChunbaeButtonText.Length; i++)
                {
                    //춘배 레벨
                    Text ChunbaeLevel = ChunbaeButtonText[0].gameObject.GetComponent<Text>();
                    ChunbaeLevel.text = (statusMng.Level_Chunbae).ToString();

                    //터치 시 오르는 수치
                    Text Touch_profit = ChunbaeButtonText[1].gameObject.GetComponent<Text>();
                    Touch_profit.text = (statusMng.Touch_Profit).ToString();

                    //레벨업 시 드는 비용
                    Text LevelUpCost_Chunbae = ChunbaeButtonText[2].gameObject.GetComponent<Text>();
                    LevelUpCost_Chunbae.text = (statusMng.LevelUpCost_Chunbae).ToString();

                    //레벨업 시 오르는 수치
                    Text LevelUp_Effect = ChunbaeButtonText[3].gameObject.GetComponent<Text>();
                    LevelUp_Effect.text = (statusMng.LevelUp_Effect).ToString();


                }
            }

        }
        catch (NullReferenceException)
        {
           // Debug.Log(ex);
        }
      

    }

    //Store가 해금되어 활성화되어있는지 아닌지 그 상태에 따라 표시되는 UI를 Update문으로 계쏙 호출하고 상태를 확인하면서 보여줌

    void Check_IsActiveAndShowUI()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            try
            {
                if (statusMng.Cafe_Active == true)
                {
                    UnActive_StoreImage[0].sprite = Active_Store[0];
                    UnActive_ArrowImage[0].sprite = Active_Arrow;

                }
                if (statusMng.Chicken_Active == true)
                {
                    UnActive_StoreImage[1].sprite = Active_Store[1];
                    UnActive_ArrowImage[1].sprite = Active_Arrow;
                }
                if (statusMng.Gobchang_Active == true)
                {
                    UnActive_StoreImage[2].sprite = Active_Store[2];
                    UnActive_ArrowImage[2].sprite = Active_Arrow;
                }
                if (statusMng.Health_Active == true)
                {
                    UnActive_StoreImage[3].sprite = Active_Store[3];
                    UnActive_ArrowImage[3].sprite = Active_Arrow;
                }
                if (statusMng.Land_Active == true)
                {
                    UnActive_StoreImage[4].sprite = Active_Store[4];
                    UnActive_ArrowImage[4].sprite = Active_Arrow;
                }
            }
            catch(NullReferenceException)
            {
               // Debug.Log(ex);
            }



        }
    }

    // 각 가게가 활성화, 비활성화 상태일 때의 반응(비활성화면 팝업창 띄워서 해금하시겠습니까? 나오는걸로 바꿔야됌)
    public void IsStoreClicked_ActiveOrUnactive(int Num)
    {
        if(Num == 0)
        {
            if(statusMng.Cafe_Active == false)
            {
                statusMng.Cafe_Active = true;
            }
            else if(statusMng.Cafe_Active == true)
            {
                IncreaseGage();
            }
        }

        if (Num == 1)
        {
            if (statusMng.Chicken_Active == false)
            {
                statusMng.Chicken_Active = true;
            }
            else if (statusMng.Chicken_Active == true)
            {
                IncreaseGage();
            }
        }

        if (Num == 2)
        {
            if (statusMng.Gobchang_Active == false)
            {
                statusMng.Gobchang_Active = true;
            }
            else if (statusMng.Gobchang_Active == true)
            {
                IncreaseGage();
            }
        }

        if (Num == 3)
        {
            if (statusMng.Health_Active == false)
            {
                statusMng.Health_Active = true;
            }
            else if (statusMng.Health_Active == true)
            {
                IncreaseGage();
            }
        }

        if (Num == 4)
        {
            if (statusMng.Land_Active == false)
            {
                statusMng.Land_Active = true;
            }
            else if (statusMng.Land_Active == true)
            {
                IncreaseGage();
            }
        }


    }



    private void Awake()
    {
        
    }

    public void IncreaseGage()
    {

        //춘배 에니메이션 스크립트에서 트리거를 호출하여 터치할 때마다 에니메이션을 하게 만듭니다.
        moveAndAnimation_Chunbae.ToTouched_Chunbae();
        
        
        //카페 게이지 상승


        if (nestedScrollMng.targetPos >= 0 && nestedScrollMng.targetPos < 0.25)
        {
           
            if (SingletonMng.instance.isfever_cafe == false && SingletonMng.instance.gage_cafe < 100)
            {
                SingletonMng.instance.gage_cafe += 1;   //게이지 1%씩 증가
                SingletonMng.instance.isClicked_cafe = true;
                SingletonMng.instance.timer_cafe = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if(SingletonMng.instance.isfever_cafe == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }



        //치킨 게이지 상승
        if (nestedScrollMng.targetPos >= 0.25 && nestedScrollMng.targetPos < 0.5)
        {
            if (SingletonMng.instance.isfever_chicken == false && SingletonMng.instance.gage_chicken < 100)
            {
                SingletonMng.instance.gage_chicken += 1;   //게이지 1%씩 증가
                SingletonMng.instance.isClicked_chicken = true;
                SingletonMng.instance.timer_chicken = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (SingletonMng.instance.isfever_chicken == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }



        //곱창 게이지 상승
        if (nestedScrollMng.targetPos >= 0.5 && nestedScrollMng.targetPos < 0.75)
        {
            if (SingletonMng.instance.isfever_gobchang == false && SingletonMng.instance.gage_gobchang < 100)
            {
                SingletonMng.instance.gage_gobchang += 1;   //게이지 1%씩 증가
                SingletonMng.instance.isClicked_Gobchang = true;
                SingletonMng.instance.timer_Gobchang = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (SingletonMng.instance.isfever_gobchang == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }

        //헬스 게이지 상승
        if (nestedScrollMng.targetPos >= 0.75 && nestedScrollMng.targetPos < 1)
        {
            if (SingletonMng.instance.isfever_health == false && SingletonMng.instance.gage_health < 100)
            {
                SingletonMng.instance.gage_health += 1;   //게이지 1%씩 증가
                SingletonMng.instance.isClicked_Health = true;
                SingletonMng.instance.timer_Health = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (SingletonMng.instance.isfever_health == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }
        //냥냐랜드 게이지 상승
        if (nestedScrollMng.targetPos >= 1 )
        {
            if (SingletonMng.instance.isfever_land == false && SingletonMng.instance.gage_land < 100)
            {
                SingletonMng.instance.gage_land += 1;   //게이지 1%씩 증가
                SingletonMng.instance.isClicked_Land = true;
                SingletonMng.instance.timer_Land = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (SingletonMng.instance.isfever_land == true)
            {
                statusMng.Touch_IncreaseMoney();
            }

        }


    }



    public void open_ChunbaeButton()
    {
        menu_chunbae.SetActive(true);
    }
    public void open_ChunbaeStats()
    {
        stats_chunbae.SetActive(true);
    }
    public void open_Setting()
    {
        menu_setting.SetActive(true);
    }
    public void open_Post()
    {
        menu_post.SetActive(true);
    }
    public void open_CenterUpgrade()
    {
        menu_center.SetActive(true);
        center_openButton.SetActive(false);
        center_statButton.SetActive(false);
        center_donation.SetActive(false);
    }
    public void open_CenterStats()
    {
        stats_center.SetActive(true);
    }
    public void open_Donation()
    {
        menu_Donation.SetActive(true);
    }
    public void open_Bomi()
    {
        menu_bomi.SetActive(true);
    }
    public void open_QuestUI()
    {
        QuestUI.SetActive(true);
    }
    public void open_DailyQuest()
    {
        DailyQuest.SetActive(true);
        Achievement.SetActive(false);
    }
    public void open_Achievement()
    {
        DailyQuest.SetActive(false);
        Achievement.SetActive(true);
    }

    public void close_ChunbaeButton()
    {
        menu_chunbae.SetActive(false);
    }
    public void close_ChunbaeStats()
    {
        stats_chunbae.SetActive(false);
    }
    public void close_Setting()
    {
        menu_setting.SetActive(false);
    }
    public void close_Post()
    {
        menu_post.SetActive(false);
    }
    public void close_CenterUpgrade()
    {
        menu_center.SetActive(false);
        center_openButton.SetActive(true);
        center_statButton.SetActive(true);
        center_donation.SetActive(true);
    }
    public void close_CenterStats()
    {
        stats_center.SetActive(false);
    }
    public void close_Donation()
    {
        menu_Donation.SetActive(false);
    }
    public void close_Bomi()
    {
        menu_bomi.SetActive(false);
    }
    public void close_QuestUI()
    {
        QuestUI.SetActive(false);
    }

    public void shop_Package()
    {
        shop_package.SetActive(true);
        shop_draw.SetActive(false);
        shop_dia.SetActive(false);
    }
    public void shop_Draw()
    {
        shop_package.SetActive(false);
        shop_draw.SetActive(true);
        shop_dia.SetActive(false);
    }
    public void shop_Dia()
    {
        shop_package.SetActive(false);
        shop_draw.SetActive(false);
        shop_dia.SetActive(true);
    }
    public void open_popupDraw()
    {
        popup_draw.SetActive(true);
    }
    public void close_popupDraw()
    {
        popup_draw.SetActive(false);
    }


    //Arrow 버튼 비활성화때 클릭 , 활성화 때 클릭


    public void gotoCafe()
    {
        if (statusMng.Cafe_Active == true)
        {
            statusMng.TargetPos = 0;
            SceneManager.LoadScene("Cafe");

        }

        else if(statusMng.Cafe_Active == false)
        {
            statusMng.Cafe_Active = true;
        }

    }
  


    public void gotoChicken()
    {
        if (statusMng.Chicken_Active == true)
        {
            statusMng.TargetPos = 0.25f;
            SceneManager.LoadScene("Cafe");

        }

        else if (statusMng.Chicken_Active == false)
        {
            statusMng.Chicken_Active = true;
        }
    }


    public void gotoGobchang()
    {
        if (statusMng.Gobchang_Active == true)
        {
            statusMng.TargetPos = 0.5f;
            SceneManager.LoadScene("Cafe");

        }

        else if (statusMng.Gobchang_Active == false)
        {
           
            statusMng.Gobchang_Active = true;
        }
    }


    public void gotoHealth()
    {
        if (statusMng.Health_Active == true)
        {
            statusMng.TargetPos = 0.75f;
            SceneManager.LoadScene("Cafe");

        }

        else if (statusMng.Health_Active == false)
        {
            statusMng.Health_Active = true;
        }
    }


    public void gotoLand()
    {
        if (statusMng.Land_Active == true)
        {
            statusMng.TargetPos = 1f;
            SceneManager.LoadScene("Cafe");

        }

        else if (statusMng.Land_Active == false)
        {
            statusMng.Land_Active = true;
        }
    }


    //



    public void gotoMain()
    {
        if (SceneManager.GetActiveScene().name == "Cafe")
        {
            statusMng.TargetPos = nestedScrollMng.targetPos;
            SceneManager.LoadScene("Main");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }

        
    }
    public void gotoCenter()
    {
        SceneManager.LoadScene("Center");
    }
    public void gotoShop()
    {
        SceneManager.LoadScene("Shop");
    }

    //가게

    public void open_StorerUpgrade()
    {
        menu_StoreUpgrade.SetActive(true);
        store_openButton.SetActive(false);
        store_statButton.SetActive(false);
    }
    public void open_StoreStats()
    {
        stats_center.SetActive(true);
    }

    public void close_StoreUpgrade()
    {
        menu_StoreUpgrade.SetActive(false);
        store_openButton.SetActive(true);
        store_statButton.SetActive(true);
        
    }

    //센터

    public void center_NyangCategory()
    {
        default_image = category_background.GetComponent<Image>();
        default_image.sprite = Nyang;
    }
    public void center_AnimalCategory()
    {
        default_image = category_background.GetComponent<Image>();
        default_image.sprite = Animal;
    }
}


