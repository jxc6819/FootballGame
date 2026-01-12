using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class FieldManager : MonoBehaviour
{
    public PathCreation.PathCreator pathCreator;
    public PlayerFollow D1playerfollow;
    public PlayerFollow D2playerfollow;
    public PlayerFollow D3playerfollow;
    public PlayerFollow D4playerfollow;
    public PlayerFollow MLB1playerfollow;
    public PlayerFollow MLB2playerfollow;
    public PlayerFollow Safetyplayerfollow;
    public Renderer rend;


    public GameObject Defender1;
    public GameObject Defender2;
    public GameObject Defender3;
    public GameObject Defender4;
    public GameObject MLB1;
    public GameObject MLB2;
    public GameObject Safety;
    public GameObject DL1;
    public GameObject DL2;
    public GameObject DL3;
    public GameObject DL4;

    Animator D1anim;
    Animator D2anim;
    Animator D3anim;
    Animator D4anim;
    Animator MLB1anim;
    Animator MLB2anim;
    Animator Safetyanim;
    Animator DL1anim;
    Animator DL2anim;
    Animator DL3anim;
    Animator DL4anim;

    Vector3 D1Pos;
    Vector3 D2Pos;
    Vector3 D3Pos;
    Vector3 D4Pos;
    Vector3 MLB1Pos;
    Vector3 MLB2Pos;
    Vector3 SafetyPos;
    Vector3 DL1Pos;
    Vector3 DL2Pos;
    Vector3 DL3Pos;
    Vector3 DL4Pos;



    public GameObject Receiver1;
    public GameObject Receiver2;
    public GameObject Receiver3;
    public GameObject Receiver4;
    public GameObject RB;
    public GameObject QB;
    public GameObject OL1;
    public GameObject OL2;
    public GameObject OL3;
    public GameObject OL4;
    public GameObject OL5;

    public GameObject R1Route;
    public GameObject R2Route;
    public GameObject R3Route;
    public GameObject R4Route;

    Animator R1anim;
    Animator R2anim;
    Animator R3anim;
    Animator R4anim;

    Vector3 OL1Pos;
    Vector3 OL2Pos;
    Vector3 OL3Pos;
    Vector3 OL4Pos;
    Vector3 OL5Pos;
    Vector3 R1Pos;
    Vector3 R2Pos;
    Vector3 R3Pos;
    Vector3 R4Pos;
    Vector3 RBPos;
    Vector3 QBPos;

    public GameObject RRT; // (Receiver Rotation Template)

    public bool isRunning;
    public GameObject Football;
    public bool R1hasCaught;
    public bool R2hasCaught;
    public bool R3hasCaught;
    public bool R4hasCaught;
    public bool RBhasCaught;
    public bool R1Out;
    public bool R2Out;
    public bool R3Out;
    public bool R4Out;
    public bool R1OutCheck = false;
    public bool R2OutCheck = false;
    public bool R3OutCheck = false;
    public bool R4OutCheck = false;
    public bool hasTackled;
    public GameObject PrePlayLinemanTemplate;
    public GameObject PostPlayLinemanTemplate;
    public bool RouteCalibration;

    public GameObject FDM; //First Down Marker
    Vector3 FDMPos;
    public GameObject LOS;
    Vector3 LOSPos;
    public bool PrePlay;
    public int Down;
    public bool Sacked;

    public PathCreation.Examples.PathFollower R1Path;
    public PathCreation.Examples.PathFollower R2Path;
    public PathCreation.Examples.PathFollower R3Path;
    public PathCreation.Examples.PathFollower R4Path;




    public void Start()
    {

       
        D1playerfollow = Defender1.GetComponent<PlayerFollow>();
        D2playerfollow = Defender2.GetComponent<PlayerFollow>();
        D3playerfollow = Defender3.GetComponent<PlayerFollow>();
        D4playerfollow = Defender4.GetComponent<PlayerFollow>();
        MLB1playerfollow = MLB1.GetComponent<PlayerFollow>();
        MLB2playerfollow = MLB2.GetComponent<PlayerFollow>();
        Safetyplayerfollow = Safety.GetComponent<PlayerFollow>();

        R1Path = Receiver1.GetComponent<PathCreation.Examples.PathFollower>();
        R2Path = Receiver2.GetComponent<PathCreation.Examples.PathFollower>();
        R3Path = Receiver3.GetComponent<PathCreation.Examples.PathFollower>();
        R4Path = Receiver4.GetComponent<PathCreation.Examples.PathFollower>();


        PrePlay = true;


        D1anim = Defender1.GetComponent<Animator>();
        D2anim = Defender2.GetComponent<Animator>();
        D3anim = Defender3.GetComponent<Animator>();
        D4anim = Defender4.GetComponent<Animator>();
        MLB1anim = MLB1.GetComponent<Animator>();
        MLB2anim = MLB2.GetComponent<Animator>();
        Safetyanim = Safety.GetComponent<Animator>();
        DL1anim = DL1.GetComponent<Animator>();
        DL2anim = DL2.GetComponent<Animator>();
        DL3anim = DL3.GetComponent<Animator>();
        DL4anim = DL4.GetComponent<Animator>();

        R1anim = Receiver1.GetComponent<Animator>();
        R2anim = Receiver2.GetComponent<Animator>();
        R3anim = Receiver3.GetComponent<Animator>();
        R4anim = Receiver4.GetComponent<Animator>();

        rend = GetComponent<Renderer>();

        //ye

        FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
        FDM.transform.position = FDMPos;

        Down = 1;
    }

    IEnumerator RouteMoving()
    {
        yield return new WaitForSeconds(1);
    }
    public void OnCollisionEnter(Collision col)
    {



        if (col.gameObject == Receiver1)
        {
            R1hasCaught = true;


            rend.enabled = false;
        }

        if (col.gameObject == Receiver2)
        {
            R2hasCaught = true;

            rend.enabled = false;
        }
        if (col.gameObject == Receiver3)
        {
            R3hasCaught = true;

            rend.enabled = false;
        }
        if (col.gameObject == Receiver4)
        {
            R4hasCaught = true;
            rend.enabled = false;
        }




    }

    private void Update()
    {







        if (R2hasCaught == true)
        {
            D1playerfollow.StreakPlayer = Receiver2.transform;
            D2playerfollow.StreakPlayer = Receiver2.transform;
            D3playerfollow.StreakPlayer = Receiver2.transform;
            D4playerfollow.StreakPlayer = Receiver2.transform;

            MLB1playerfollow.enabled = true;
            MLB2playerfollow.enabled = true;
            Safetyplayerfollow.enabled = true;

            MLB1playerfollow.StreakPlayer = Receiver2.transform;
            MLB2playerfollow.StreakPlayer = Receiver2.transform;
            Safetyplayerfollow.StreakPlayer = Receiver2.transform;
        }
        else if (R3hasCaught == true)
        {
            D1playerfollow.StreakPlayer = Receiver3.transform;
            D2playerfollow.StreakPlayer = Receiver3.transform;
            D3playerfollow.StreakPlayer = Receiver3.transform;
            D4playerfollow.StreakPlayer = Receiver3.transform;

            MLB1playerfollow.enabled = true;
            MLB2playerfollow.enabled = true;
            Safetyplayerfollow.enabled = true;

            MLB1playerfollow.StreakPlayer = Receiver3.transform;
            MLB2playerfollow.StreakPlayer = Receiver3.transform;
            Safetyplayerfollow.StreakPlayer = Receiver3.transform;
        }
        else if (R4hasCaught == true)
        {
            D1playerfollow.StreakPlayer = Receiver4.transform;
            D2playerfollow.StreakPlayer = Receiver4.transform;
            D3playerfollow.StreakPlayer = Receiver4.transform;
            D4playerfollow.StreakPlayer = Receiver4.transform;

            MLB1playerfollow.enabled = true;
            MLB2playerfollow.enabled = true;
            Safetyplayerfollow.enabled = true;

            MLB1playerfollow.StreakPlayer = Receiver4.transform;
            MLB2playerfollow.StreakPlayer = Receiver4.transform;
            Safetyplayerfollow.StreakPlayer = Receiver4.transform;
        }
        else if (R1hasCaught == true)
        {
            D1playerfollow.StreakPlayer = Receiver1.transform;
            D2playerfollow.StreakPlayer = Receiver1.transform;
            D3playerfollow.StreakPlayer = Receiver1.transform;
            D4playerfollow.StreakPlayer = Receiver1.transform;

            MLB1playerfollow.enabled = true;
            MLB2playerfollow.enabled = true;
            Safetyplayerfollow.enabled = true;

            MLB1playerfollow.StreakPlayer = Receiver1.transform;
            MLB2playerfollow.StreakPlayer = Receiver1.transform;
            Safetyplayerfollow.StreakPlayer = Receiver1.transform;


        }
        else
        {
            D1playerfollow.StreakPlayer = Receiver1.transform;
            D2playerfollow.StreakPlayer = Receiver2.transform;
            D3playerfollow.StreakPlayer = Receiver3.transform;
            D4playerfollow.StreakPlayer = Receiver4.transform;
            MLB1playerfollow.enabled = false;
            MLB2playerfollow.enabled = false;
            Safetyplayerfollow.enabled = false;
        }





        if (R1hasCaught)
        {
            Vector3 d1dist = Receiver1.transform.position - Defender1.transform.position;
            Vector3 d2dist = Receiver1.transform.position - Defender2.transform.position;
            Vector3 d3dist = Receiver1.transform.position - Defender3.transform.position;
            Vector3 d4dist = Receiver1.transform.position - Defender4.transform.position;
            Vector3 DL1dist = Receiver1.transform.position - DL1.transform.position;
            Vector3 DL2dist = Receiver1.transform.position - DL2.transform.position;
            Vector3 DL3dist = Receiver1.transform.position - DL3.transform.position;
            Vector3 DL4dist = Receiver1.transform.position - DL4.transform.position;
            Vector3 MLB1dist = Receiver1.transform.position - MLB1.transform.position;
            Vector3 MLB2dist = Receiver1.transform.position - MLB2.transform.position;
            Vector3 Safetydist = Receiver1.transform.position - Safety.transform.position;

            if (d1dist.magnitude < 1.5 || d2dist.magnitude < 1.5 || d3dist.magnitude < 1.5 || d4dist.magnitude < 1.5 || DL1dist.magnitude < 1.5 || DL2dist.magnitude < 1.5 || DL3dist.magnitude < 1.5 || DL4dist.magnitude < 1.5 || MLB1dist.magnitude < 1.5 || MLB2dist.magnitude < 1.5 || Safetydist.magnitude < 1.5)
            {
                hasTackled = true;
                LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Receiver1.transform.position.z);
                LOS.transform.position = LOSPos;
                R1hasCaught = false;
                PrePlay = true;
            }

        }
        if (R2hasCaught)
        {
            Vector3 d1dist = Receiver2.transform.position - Defender1.transform.position;
            Vector3 d2dist = Receiver2.transform.position - Defender2.transform.position;
            Vector3 d3dist = Receiver2.transform.position - Defender3.transform.position;
            Vector3 d4dist = Receiver2.transform.position - Defender4.transform.position;
            Vector3 DL1dist = Receiver2.transform.position - DL1.transform.position;
            Vector3 DL2dist = Receiver2.transform.position - DL2.transform.position;
            Vector3 DL3dist = Receiver2.transform.position - DL3.transform.position;
            Vector3 DL4dist = Receiver2.transform.position - DL4.transform.position;
            Vector3 MLB1dist = Receiver2.transform.position - MLB1.transform.position;
            Vector3 MLB2dist = Receiver2.transform.position - MLB2.transform.position;
            Vector3 Safetydist = Receiver2.transform.position - Safety.transform.position;

            if (d1dist.magnitude < 1.5 || d2dist.magnitude < 1.5 || d3dist.magnitude < 1.5 || d4dist.magnitude < 1.5 || DL1dist.magnitude < 1.5 || DL2dist.magnitude < 1.5 || DL3dist.magnitude < 1.5 || DL4dist.magnitude < 1.5 || MLB1dist.magnitude < 1.5 || MLB2dist.magnitude < 1.5 || Safetydist.magnitude < 1.5)
            {
                hasTackled = true;
                LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Receiver2.transform.position.z);
                LOS.transform.position = LOSPos;
                R2hasCaught = false;
                PrePlay = true;
            }

        }
        if (R3hasCaught)
        {
            Vector3 d1dist = Receiver3.transform.position - Defender1.transform.position;
            Vector3 d2dist = Receiver3.transform.position - Defender2.transform.position;
            Vector3 d3dist = Receiver3.transform.position - Defender3.transform.position;
            Vector3 d4dist = Receiver3.transform.position - Defender4.transform.position;
            Vector3 DL1dist = Receiver3.transform.position - DL1.transform.position;
            Vector3 DL2dist = Receiver3.transform.position - DL2.transform.position;
            Vector3 DL3dist = Receiver3.transform.position - DL3.transform.position;
            Vector3 DL4dist = Receiver3.transform.position - DL4.transform.position;
            Vector3 MLB1dist = Receiver3.transform.position - MLB1.transform.position;
            Vector3 MLB2dist = Receiver3.transform.position - MLB2.transform.position;
            Vector3 Safetydist = Receiver3.transform.position - Safety.transform.position;

            if (d1dist.magnitude < 1.5 || d2dist.magnitude < 1.5 || d3dist.magnitude < 1.5 || d4dist.magnitude < 1.5 || DL1dist.magnitude < 1.5 || DL2dist.magnitude < 1.5 || DL3dist.magnitude < 1.5 || DL4dist.magnitude < 1.5 || MLB1dist.magnitude < 1.5 || MLB2dist.magnitude < 1.5 || Safetydist.magnitude < 1.5)
            {
                hasTackled = true;
                LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Receiver3.transform.position.z);
                LOS.transform.position = LOSPos;
                R3hasCaught = false;
                PrePlay = true;
            }

        }

        if (R4hasCaught)
        {
            Vector3 d1dist = Receiver4.transform.position - Defender1.transform.position;
            Vector3 d2dist = Receiver4.transform.position - Defender2.transform.position;
            Vector3 d3dist = Receiver4.transform.position - Defender3.transform.position;
            Vector3 d4dist = Receiver4.transform.position - Defender4.transform.position;
            Vector3 DL1dist = Receiver4.transform.position - DL1.transform.position;
            Vector3 DL2dist = Receiver4.transform.position - DL2.transform.position;
            Vector3 DL3dist = Receiver4.transform.position - DL3.transform.position;
            Vector3 DL4dist = Receiver4.transform.position - DL4.transform.position;
            Vector3 MLB1dist = Receiver4.transform.position - MLB1.transform.position;
            Vector3 MLB2dist = Receiver4.transform.position - MLB2.transform.position;
            Vector3 Safetydist = Receiver4.transform.position - Safety.transform.position;

            if (d1dist.magnitude < 1.5 || d2dist.magnitude < 1.5 || d3dist.magnitude < 1.5 || d4dist.magnitude < 1.5 || DL1dist.magnitude < 1.5 || DL2dist.magnitude < 1.5 || DL3dist.magnitude < 1.5 || DL4dist.magnitude < 1.5 || MLB1dist.magnitude < 1.5 || MLB2dist.magnitude < 1.5 || Safetydist.magnitude < 1.5)
            {
                hasTackled = true;
                LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Receiver4.transform.position.z);
                LOS.transform.position = LOSPos;
                R4hasCaught = false;
                PrePlay = true;
            }

        }







        if ((R1hasCaught == false && R2hasCaught == false && R3hasCaught == false && R4hasCaught == false) && (Vector3.Distance(QB.transform.position, Defender1.transform.position) <= 2 || Vector3.Distance(QB.transform.position, Defender2.transform.position) <= 2) || Vector3.Distance(QB.transform.position, Defender3.transform.position) <= 2 || Vector3.Distance(QB.transform.position, Defender4.transform.position) <= 2 || Vector3.Distance(QB.transform.position, MLB1.transform.position) <= 2 || Vector3.Distance(QB.transform.position, MLB2.transform.position) <= 2 || Vector3.Distance(QB.transform.position, Safety.transform.position) <= 2 || Vector3.Distance(QB.transform.position, DL1.transform.position) <= 2 || Vector3.Distance(QB.transform.position, DL2.transform.position) <= 2 || Vector3.Distance(QB.transform.position, DL3.transform.position) <= 2 || Vector3.Distance(QB.transform.position, DL4.transform.position) <= 2)
        {
            PrePlay = true;
            Sacked = true;
            hasTackled = true;
            LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, QB.transform.position.z);
            LOS.transform.position = LOSPos;


        }


        if (Receiver1.transform.position.x >= 24.375 || Receiver1.transform.position.x <= -24.375)
        {
            R1Out = true;
        }
        if (Receiver2.transform.position.x >= 24.375 || Receiver2.transform.position.x <= -24.375)
        {
            R2Out = true;
        }
        if (Receiver3.transform.position.x >= 24.375 || Receiver3.transform.position.x <= -24.375)
        {
            R3Out = true;
        }
        if (Receiver4.transform.position.x >= 24.375 || Receiver4.transform.position.x <= -27.375)
        {
            R4Out = true;
        }




        if (R1OutCheck == false && R1hasCaught == true && R1Out == false)
        {

            R1OutCheck = true;
        }
        if (R1OutCheck == true && R1Out == true)
        {
            hasTackled = true;
            LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Receiver1.transform.position.z);
            LOS.transform.position = LOSPos;
            PrePlay = true;
        }
        if (R1OutCheck == false && R1hasCaught == true && R1Out == true)
        {
            hasTackled = true;
            PrePlay = true;
        }










        if (LOS.transform.position.z - FDM.transform.position.z >= 0)
        {

            FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
            FDM.transform.position = FDMPos;
            Down = 1;

        }
        else
        {
            FDM.transform.position = FDM.transform.position;
        }


        if (hasTackled == true || Sacked == true)
        {
            Down = Down + 1;
        }

        if (PrePlay == true)
        {
            Debug.Log("HI");
            //R1anim.SetBool("Running", false);
            //R2anim.SetBool("Running", false);
            //R3anim.SetBool("Running", false);
            //R4anim.SetBool("Running", false);

            //D1anim.SetBool("Running", false);
            //D2anim.SetBool("Running", false);
            //D3anim.SetBool("Running", false);
            //D4anim.SetBool("Running", false);
            //MLB1anim.SetBool("Running", false);
            //MLB2anim.SetBool("Running", false);
            //Safetyanim.SetBool("Running", false);

            //R1anim.SetBool("Idle", true);
            //R2anim.SetBool("Idle", true);
            //R3anim.SetBool("Idle", true);
            //R4anim.SetBool("Idle", true);

            //D1anim.SetBool("Idle", true);
            //D2anim.SetBool("Idle", true);
            //D3anim.SetBool("Idle", true);
            //D4anim.SetBool("Idle", true);
            //MLB1anim.SetBool("Idle", true);
            //MLB2anim.SetBool("Idle", true);
            //Safetyanim.SetBool("Idle", true);
            //DL1anim.SetBool("Idle", true);
            //DL1anim.SetBool("Running", false);
            //DL2anim.SetBool("Idle", true);
            //DL2anim.SetBool("Running", false);
            //DL3anim.SetBool("Idle", true);
            //DL3anim.SetBool("Running", false);
            //DL4anim.SetBool("Idle", true);
            //DL4anim.SetBool("Running", false);





            R1hasCaught = false;
            R2hasCaught = false;
            R3hasCaught = false;
            R4hasCaught = false;
            hasTackled = false;
            Sacked = false;
            OL1Pos = new Vector3(-3.67f, 0.62f, LOS.transform.position.z - 1);
            OL2Pos = new Vector3(-1.74f, 0.62f, LOS.transform.position.z - 1);
            OL3Pos = new Vector3(0.27f, 0.62f, LOS.transform.position.z - 0.5f);
            OL4Pos = new Vector3(2.17f, 0.62f, LOS.transform.position.z - 1);
            OL5Pos = new Vector3(4.14f, 0.62f, LOS.transform.position.z - 1);
            R1Pos = new Vector3(16.64f, 0f, LOS.transform.position.z - 1.3f);
            R2Pos = new Vector3(9.83f, 0, LOS.transform.position.z - 1.3f);
            R3Pos = new Vector3(-7.76f, 0, LOS.transform.position.z - 1.3f);
            R4Pos = new Vector3(-15.41f, 0, LOS.transform.position.z - 1.3f);
            QBPos = new Vector3(-0.97f, 0, LOS.transform.position.z - 7.5f);
            RBPos = new Vector3(2.33f, 0, LOS.transform.position.z - 7.8f);

            DL1Pos = new Vector3(3.25f, 0.62f, LOS.transform.position.z + 1.5f);
            DL2Pos = new Vector3(1.2f, 0.62f, LOS.transform.position.z + 1.5f);
            DL3Pos = new Vector3(-1.07f, 0.62f, LOS.transform.position.z + 1.5f);
            DL4Pos = new Vector3(-3.14f, 0.62f, LOS.transform.position.z + 1.5f);
            D1Pos = new Vector3(16.52f, 0, LOS.transform.position.z + 5);
            D2Pos = new Vector3(9.6f, 0, LOS.transform.position.z + 5);
            D3Pos = new Vector3(-8.37f, 0, LOS.transform.position.z + 5);
            D4Pos = new Vector3(-16.17f, 0, LOS.transform.position.z + 5);
            MLB1Pos = new Vector3(-1.82f, 0, LOS.transform.position.z + 6.5f);
            MLB2Pos = new Vector3(1.49f, 0, LOS.transform.position.z + 6.5f);
            SafetyPos = new Vector3(0.16f, 0, LOS.transform.position.z + 17);





            OL1.transform.position = OL1Pos;
            OL2.transform.position = OL2Pos;
            OL3.transform.position = OL3Pos;
            OL4.transform.position = OL4Pos;
            OL5.transform.position = OL5Pos;
            Receiver1.transform.position = R1Pos;
            Receiver2.transform.position = R2Pos;
            Receiver3.transform.position = R3Pos;
            Receiver4.transform.position = R4Pos;
            Receiver1.transform.rotation = RRT.transform.rotation;
            Receiver2.transform.rotation = RRT.transform.rotation;
            Receiver3.transform.rotation = RRT.transform.rotation;
            Receiver4.transform.rotation = RRT.transform.rotation;
            RB.transform.position = RBPos;
            QB.transform.position = QBPos;

            Defender1.transform.position = D1Pos;
            Defender2.transform.position = D2Pos;
            Defender3.transform.position = D3Pos;
            Defender4.transform.position = D4Pos;
            MLB1.transform.position = MLB1Pos;
            MLB2.transform.position = MLB2Pos;
            Safety.transform.position = SafetyPos;
            DL1.transform.position = DL1Pos;
            DL2.transform.position = DL2Pos;
            DL3.transform.position = DL3Pos;
            DL4.transform.position = DL4Pos;
            DL1.transform.localScale = PrePlayLinemanTemplate.transform.localScale;
            DL2.transform.localScale = PrePlayLinemanTemplate.transform.localScale;
            DL3.transform.localScale = PrePlayLinemanTemplate.transform.localScale;
            DL4.transform.localScale = PrePlayLinemanTemplate.transform.localScale;



            R1Path.enabled = false;
            R2Path.enabled = false;
            R3Path.enabled = false;
            R4Path.enabled = false;

            //Receiver1.SetActive(false); //e
            //new WaitForSeconds(1);
            //Receiver1.SetActive(true);


            R1Route.transform.position = R1Pos;
            R2Route.transform.position = R2Pos;
            R3Route.transform.position = R3Pos;
            R4Route.transform.position = R4Pos;


            R1OutCheck = false;
            R2OutCheck = false;
            R3OutCheck = false;
            R4OutCheck = false;
            R1Out = false;
            R2Out = false;
            R3Out = false;
            R4Out = false;
            RouteCalibration = false;
        }

        else
        {


            //R1anim.SetBool("Running", true);
            //R2anim.SetBool("Running", true);
            //R3anim.SetBool("Running", true);
            //R4anim.SetBool("Running", true);

            //D1anim.SetBool("Running", true);
            //D2anim.SetBool("Running", true);
            //D3anim.SetBool("Running", true);
            //D4anim.SetBool("Running", true);
            //R1anim.SetBool("Idle", false);
            //R2anim.SetBool("Idle", false);
            //R3anim.SetBool("Idle", false);
            //R4anim.SetBool("Idle", false);

            //D1anim.SetBool("Idle", false);
            //D2anim.SetBool("Idle", false);
            //D3anim.SetBool("Idle", false);
            //D4anim.SetBool("Idle", false);
            //MLB1anim.SetBool("Idle", false);
            //MLB2anim.SetBool("Idle", false);
            //Safetyanim.SetBool("Idle", false);
            //DL1anim.SetBool("Idle", false);
            //DL1anim.SetBool("Running", true);
            //DL2anim.SetBool("Idle", false);
            //DL2anim.SetBool("Running", true);
            //DL3anim.SetBool("Idle", false);
            //DL3anim.SetBool("Running", true);
            //DL4anim.SetBool("Idle", false);
            //DL4anim.SetBool("Running", true);

            DL1.transform.localScale = PostPlayLinemanTemplate.transform.localScale;
            DL2.transform.localScale = PostPlayLinemanTemplate.transform.localScale;
            DL3.transform.localScale = PostPlayLinemanTemplate.transform.localScale;
            DL4.transform.localScale = PostPlayLinemanTemplate.transform.localScale;

            R1Path.enabled = true;
            R2Path.enabled = true;
            R3Path.enabled = true;
            R4Path.enabled = true;

            if (RouteCalibration == false)
            {
                transform.position = pathCreator.path.GetPoint(0);
                R1Path.distanceTravelled = 0;
                R2Path.distanceTravelled = 0;
                R3Path.distanceTravelled = 0;
                R4Path.distanceTravelled = 0;

                new WaitForSeconds(0.1f);
                RouteCalibration = true;

            }


            //MLB1anim.SetBool("Running", true);
            //MLB2anim.SetBool("Running"e, true);
            //////Safetyanim.SetBool("Running", true);;




        }


    }


}
