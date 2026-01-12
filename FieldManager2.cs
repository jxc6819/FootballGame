using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class FieldManager2 : MonoBehaviour
{
    [SerializeField] private InputActionReference GripActionReference;
    public PathCreation.PathCreator pathCreator;
    public TrajectoryPredictor traj;
    public PlayerFollow D1playerfollow;
    public PlayerFollow D2playerfollow;
    public PlayerFollow D3playerfollow;
    public PlayerFollow D4playerfollow;
    public PlayerFollow MLB1playerfollow;
    public PlayerFollow MLB2playerfollow;
    public PlayerFollow Safetyplayerfollow;
    public PlayerFollow DL1playerfollow;
    public PlayerFollow DL2playerfollow;
    public PlayerFollow DL3playerfollow;
    public PlayerFollow DL4playerfollow;
    public SnappingTEMP STcs;
    
    public GripButton GripButton;
    Vector3 HitPoint;


    public bool Punt;
    public bool GoingForIt;
    public bool TurnoverOnDowns;
    public bool Incomplete;
    public bool Interception;
    public bool D1_Int;
    public bool D2_Int;
    public bool D3_Int;
    public bool D4_Int;
    public bool _D1Int;
    public bool _D2Int;
    public bool _D3Int;
    public bool _D4Int;
    public GameObject Ground;
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
    public bool SnapLocked;

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

    public GameObject Ball;


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
    public PlayerFollow R1PlayerFollow;
    public PlayerFollow R2PlayerFollow;
    public PlayerFollow R3PlayerFollow;
    public PlayerFollow R4PlayerFollow;


    public GameObject R1Route;
    public GameObject R2Route;
    public GameObject R3Route;
    public GameObject R4Route;

    Animator R1anim;
    Animator R2anim;
    Animator R3anim;
    Animator R4anim;
    Animator OL1anim;
    Animator OL2anim;
    Animator OL3anim;
    Animator OL4anim;
    Animator OL5anim;


    Vector3 Losy;
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

    public Rigidbody BallRigidBody;
    public bool BallCalibration = false;
    public GameObject RRT; // (Receiver Rotation Template)

    public bool TMWcheck = true;
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
    public bool D1Out;
    public bool D2Out;
    public bool D3Out;
    public bool D4Out;
    public bool D1OutCheck;
    public bool D2OutCheck;
    public bool D3OutCheck;
    public bool D4OutCheck;
    public bool hasTackled;
    public bool Scrambling;
    public bool Touchdown;
    public GameObject PrePlayLinemanTemplate;
    public GameObject PostPlayLinemanTemplate;
    public bool RouteCalibration;
    public GameObject Hand;
    public GameObject FDM; //First Down Marker
    public bool BallisThrown;
    public bool R1Locked;
    public bool R2Locked;
    public bool R3Locked;
    public bool R4Locked;
    bool CheckMTBPos;
    bool StopCheckingMTB;

    Vector3 FDMPos;
    public GameObject LOS;
    Vector3 LOSPos;
    public bool PrePlay;
    public int Down;
    public bool Sacked;
    public GameObject MTB; //Move To Ball
    public GameObject MTE; //Move to EndZone
    public GameObject FDUI; //Fourth Down UI
    public GameObject P6Pos; //Pick Six Pos
    Vector3 FDUIPos;


    public PathCreation.Examples.PathFollower R1Path;
    public PathCreation.Examples.PathFollower R2Path;
    public PathCreation.Examples.PathFollower R3Path;
    public PathCreation.Examples.PathFollower R4Path;

    public GripButton GB;

    public int PlayerScore;
    public int OpponentScore;
    public bool TimerOn;
    public bool TimerOff = true;


    //¦¦¦¦¦¦+¦¦¦¦¦¦¦+¦¦¦¦¦¦¦+¦¦¦+¦¦¦+¦¦¦¦+¦¦¦¦¦¦¦+¦  ¦¦¦¦¦¦¦+¦¦¦¦¦¦¦¦+¦¦+¦¦¦¦¦+¦¦¦¦¦¦¦+¦¦¦¦¦¦¦+
    //¦¦+--¦¦+¦¦+--¦¦+¦¦+--¦¦+¦¦¦¦¦¦¦+¦¦¦¦¦¦+----+¦  ¦¦+----++--¦¦+--+¦¦¦¦¦¦¦¦¦¦¦+----+¦¦+----+
    //¦¦¦¦¦¦-+¦¦¦¦¦¦¦¦¦¦¦¦¦¦++¦¦¦¦¦+¦¦+¦¦¦¦¦¦¦¦¦¦+¦  +¦¦¦¦¦+¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦+¦¦¦¦¦¦¦+¦¦
    //¦¦+--¦¦+¦¦¦¦¦¦¦¦¦¦+--¦¦+¦¦¦¦¦¦+¦¦¦¦¦¦¦¦¦¦+¦¦+  ¦+---¦¦+¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦+--+¦¦¦¦+--+¦¦
    //¦¦¦¦¦¦-++¦¦¦¦¦++¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦+¦¦¦¦+¦¦¦¦¦¦++  ¦¦¦¦¦¦++¦¦¦¦¦¦¦¦¦+¦¦¦¦¦¦++¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦
    //+-----+¦¦+----+¦+-+¦¦+-++-++-+¦¦+--+¦+-----+¦  +-----+¦¦¦¦+-+¦¦¦¦+-----+¦+-+¦¦¦¦¦+-+¦¦¦¦¦

    public void Start()
    {
        R1PlayerFollow = Receiver1.GetComponent<PlayerFollow>();
        R2PlayerFollow = Receiver2.GetComponent<PlayerFollow>();
        R3PlayerFollow = Receiver3.GetComponent<PlayerFollow>();
        R4PlayerFollow = Receiver4.GetComponent<PlayerFollow>();



        BallRigidBody = GetComponent<Rigidbody>();
        D1playerfollow = Defender1.GetComponent<PlayerFollow>();
        D2playerfollow = Defender2.GetComponent<PlayerFollow>();
        D3playerfollow = Defender3.GetComponent<PlayerFollow>();
        D4playerfollow = Defender4.GetComponent<PlayerFollow>();
        MLB1playerfollow = MLB1.GetComponent<PlayerFollow>();
        MLB2playerfollow = MLB2.GetComponent<PlayerFollow>();
        Safetyplayerfollow = Safety.GetComponent<PlayerFollow>();
        DL1playerfollow = DL1.GetComponent<PlayerFollow>();
        DL2playerfollow = DL2.GetComponent<PlayerFollow>();
        DL3playerfollow = DL3.GetComponent<PlayerFollow>();
        DL4playerfollow = DL4.GetComponent<PlayerFollow>();


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

        OL1anim = OL1.GetComponent<Animator>();
        OL2anim = OL2.GetComponent<Animator>();
        OL3anim = OL3.GetComponent<Animator>();
        OL4anim = OL4.GetComponent<Animator>();
        OL5anim = OL5.GetComponent<Animator>();

        

        //ye

        FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
        FDM.transform.position = FDMPos;

        Down = 1;

        currentTime = startingTime;
        Quarter = 1;
    }

    IEnumerator RouteMoving()
    {
        yield return new WaitForSeconds(1);
    }
    public void OnCollisionEnter(Collision col)
    {


        //¦¦¦¦¦¦¦+¦¦+¦¦¦¦¦¦¦+¦¦+¦¦¦¦¦¦¦¦¦¦¦+¦  ¦¦¦¦¦¦¦+¦¦¦¦¦¦¦¦+¦¦+¦¦¦¦¦+¦¦¦¦¦¦¦+¦¦¦¦¦¦¦+
        //¦¦+----+¦¦¦¦¦+----+¦¦¦¦¦¦¦¦¦¦+--¦¦+  ¦¦+----++--¦¦+--+¦¦¦¦¦¦¦¦¦¦¦+----+¦¦+----+
        //¦¦¦¦¦+¦¦¦¦¦¦¦¦¦¦+¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦  +¦¦¦¦¦+¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦+¦¦¦¦¦¦¦+¦¦
        //¦¦+--+¦¦¦¦¦¦¦+--+¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦  ¦+---¦¦+¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦+--+¦¦¦¦+--+¦¦
        //¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦+¦¦¦¦¦¦¦+¦¦¦¦¦¦++  ¦¦¦¦¦¦++¦¦¦¦¦¦¦¦¦+¦¦¦¦¦¦++¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦¦
        //+-+¦¦¦¦¦+-++------++------++-----+¦  +-----+¦¦¦¦+-+¦¦¦¦+-----+¦+-+¦¦¦¦¦+-+¦¦¦¦¦


        //if (col.gameObject == Receiver1)
        //{
        //    //R1hasCaught = true;
        //   // Debug.Log("Contact_R1");

        //    rend.enabled = false;
        //}

        //if (col.gameObject == Receiver2)
        //{
        //    R2hasCaught = true;
        //   // Debug.Log("Contact_R2");
        //    rend.enabled = false;
        //}
        //if (col.gameObject == Receiver3)
        //{
        //    R3hasCaught = true;
        //   // Debug.Log("Contact_R3");
        //    rend.enabled = false;
        //}
        //if (col.gameObject == Receiver4)
        //{
        //   // Debug.Log("Contact_R4");
        //    R4hasCaught = true;
        //    rend.enabled = false;
        //}

        //Vector3 Throwdist = Ball.transform.position - Hand.transform.position;
        //if (PrePlay == false && col.gameObject == Ground && (!R1hasCaught && !R2hasCaught && !R3hasCaught && !R4hasCaught) && Math.Abs(Throwdist.magnitude) >= 1) 
        //{
        //   // Debug.Log("Incomplete");
        //   // Incomplete = true;

        //}
        //if (col.gameObject == Defender1)
        //{
        //    if (UnityEngine.Random.Range(1, 100) <= 70)
        //    {
        //        D1_Int = true;
                
        //    }
        //}
        //if (col.gameObject == Defender2)
        //{
        //    if (UnityEngine.Random.Range(1, 100) <= 70)
        //    {
        //        D2_Int = true;
                
        //    }
        //}
        //if (col.gameObject == Defender3)
        //{
        //    if (UnityEngine.Random.Range(1, 100) <= 70)
        //    {
        //        D3_Int = true;
               
        //    }
        //}
        //if (col.gameObject == Defender4)
        //{
        //    if (UnityEngine.Random.Range(1, 100) <= 70)
        //    {
        //        D4_Int = true;
                
        //    }
        //}




    }

    public bool TestSimming;
    private void Update()
    {
        if (R1Out || R2Out || R3Out || R4Out)
        {
            //  Debug.Log("Out");
        }
        if (hasTackled || Sacked)
        {
            Debug.Log("Tackled");
        }
        if (Down == 4)
        {

            FDUI.SetActive(true);
            FDUIPos = new Vector3(QB.transform.position.x, QB.transform.position.y + 1, QB.transform.position.z + 2.5f);
            FDUI.transform.position = FDUIPos;
            SnapLocked = true;


        }

        if (Vector3.Distance(Hand.transform.position, Ball.transform.position) > 1)
        {
            BallisThrown = true;

        }

        if (GoingForIt && Down > 4)
        {
            TurnoverOnDowns = true;
            GoingForIt = false;
        }

        if (TurnoverOnDowns || Interception)
        {
            Simming();
            Debug.Log(OpponentScore + " - " + PlayerScore);
            Down = 1; Interception = false; TurnoverOnDowns = false;
            FDUI.SetActive(false);
        }

        if (Punt)
        {
            PuntSimming();
            Debug.Log(OpponentScore + " - " + PlayerScore);
            Down = 1; Punt = false;
            FDUI.SetActive(false);

        }

        if (currentTime <= 0)
        {
            QuarterEnd = true;

        }

        if (QuarterEnd)
        {
            currentTime = startingTime;
            Quarter = Quarter + 1;
            QuarterEnd = false;
        }
        if (Quarter > 4)
        {
            GameOver = true;
        }

        if (TimerOn)
        {
            Timer();
        }


        if (TimerOff)
        {
            TimerOn = false;
        }
        else
        {
            TimerOn = true;
        }
        if (PrePlay == false)
        {
            TimerOff = false;
        }

        if (R1Out || R2Out || R3Out || R4Out)
        {
            TimerOff = true;
        }

        if (Quarter == 2 && TMWcheck && currentTime <= 120)
        {
            TimerOff = true;
            TMWcheck = false;
        }
        if (Quarter == 3)
        {
            TMWcheck = true;
        }
        if (Quarter == 4 && TMWcheck && currentTime <= 120)
        {
            TimerOff = true;
            TMWcheck = false;
        }





        if (R2hasCaught == true)
        {
            R1Path.enabled = false;
            R2Path.enabled = false;
            R3Path.enabled = false;
            R4Path.enabled = false;
            R1PlayerFollow.enabled = true;
            R2PlayerFollow.enabled = true;
            R3PlayerFollow.enabled = true;
            R4PlayerFollow.enabled = true;
            R1PlayerFollow.StreakPlayer = Defender1.transform;
            R2PlayerFollow.StreakPlayer = MTE.transform;
            R3PlayerFollow.StreakPlayer = Defender3.transform;
            R4PlayerFollow.StreakPlayer = Defender4.transform;

            D1playerfollow.StreakPlayer = Receiver2.transform;
            D2playerfollow.StreakPlayer = Receiver2.transform;
            D3playerfollow.StreakPlayer = Receiver2.transform;
            D4playerfollow.StreakPlayer = Receiver2.transform;

            DL1playerfollow.StreakPlayer = Receiver2.transform;
            DL2playerfollow.StreakPlayer = Receiver2.transform;
            DL3playerfollow.StreakPlayer = Receiver2.transform;
            DL4playerfollow.StreakPlayer = Receiver2.transform;

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

            DL1playerfollow.StreakPlayer = Receiver3.transform;
            DL2playerfollow.StreakPlayer = Receiver3.transform;
            DL3playerfollow.StreakPlayer = Receiver3.transform;
            DL4playerfollow.StreakPlayer = Receiver3.transform;

            MLB1playerfollow.enabled = true;
            MLB2playerfollow.enabled = true;
            Safetyplayerfollow.enabled = true;

            MLB1playerfollow.StreakPlayer = Receiver3.transform;
            MLB2playerfollow.StreakPlayer = Receiver3.transform;
            Safetyplayerfollow.StreakPlayer = Receiver3.transform;

            R1Path.enabled = false;
            R2Path.enabled = false;
            R3Path.enabled = false;
            R4Path.enabled = false;
            R1PlayerFollow.enabled = true;
            R2PlayerFollow.enabled = true;
            R3PlayerFollow.enabled = true;
            R4PlayerFollow.enabled = true;
            R1PlayerFollow.StreakPlayer = Defender1.transform;
            R2PlayerFollow.StreakPlayer = Defender2.transform;
            R3PlayerFollow.StreakPlayer = MTE.transform;
            R4PlayerFollow.StreakPlayer = Defender4.transform;

        }
        else if (R4hasCaught == true)
        {
            R1Path.enabled = false;
            R2Path.enabled = false;
            R3Path.enabled = false;
            R4Path.enabled = false;
            R1PlayerFollow.enabled = true;
            R2PlayerFollow.enabled = true;
            R3PlayerFollow.enabled = true;
            R4PlayerFollow.enabled = true;
            R1PlayerFollow.StreakPlayer = Defender1.transform;
            R2PlayerFollow.StreakPlayer = Defender2.transform;
            R3PlayerFollow.StreakPlayer = Defender3.transform;
            R4PlayerFollow.StreakPlayer = MTE.transform;


            D1playerfollow.StreakPlayer = Receiver4.transform;
            D2playerfollow.StreakPlayer = Receiver4.transform;
            D3playerfollow.StreakPlayer = Receiver4.transform;
            D4playerfollow.StreakPlayer = Receiver4.transform;

            DL1playerfollow.StreakPlayer = Receiver4.transform;
            DL2playerfollow.StreakPlayer = Receiver4.transform;
            DL3playerfollow.StreakPlayer = Receiver4.transform;
            DL4playerfollow.StreakPlayer = Receiver4.transform;

            MLB1playerfollow.enabled = true;
            MLB2playerfollow.enabled = true;
            Safetyplayerfollow.enabled = true;

            MLB1playerfollow.StreakPlayer = Receiver4.transform;
            MLB2playerfollow.StreakPlayer = Receiver4.transform;
            Safetyplayerfollow.StreakPlayer = Receiver4.transform;
        }
        else if (R1hasCaught == true)
        {
            R1Path.enabled = false;
            R2Path.enabled = false;
            R3Path.enabled = false;
            R4Path.enabled = false;
            R1PlayerFollow.enabled = true;
            R2PlayerFollow.enabled = true;
            R3PlayerFollow.enabled = true;
            R4PlayerFollow.enabled = true;
            R1PlayerFollow.StreakPlayer = MTE.transform;
            R2PlayerFollow.StreakPlayer = Defender2.transform;
            R3PlayerFollow.StreakPlayer = Defender3.transform;
            R4PlayerFollow.StreakPlayer = Defender4.transform;


            D1playerfollow.StreakPlayer = Receiver1.transform;
            D2playerfollow.StreakPlayer = Receiver1.transform;
            D3playerfollow.StreakPlayer = Receiver1.transform;
            D4playerfollow.StreakPlayer = Receiver1.transform;

            DL1playerfollow.StreakPlayer = Receiver1.transform;
            DL2playerfollow.StreakPlayer = Receiver1.transform;
            DL3playerfollow.StreakPlayer = Receiver1.transform;
            DL4playerfollow.StreakPlayer = Receiver1.transform;

            MLB1playerfollow.enabled = true;
            MLB2playerfollow.enabled = true;
            Safetyplayerfollow.enabled = true;

            MLB1playerfollow.StreakPlayer = Receiver1.transform;
            MLB2playerfollow.StreakPlayer = Receiver1.transform;
            Safetyplayerfollow.StreakPlayer = Receiver1.transform;


        }
        //else if (QB.transform.position.z - LOS.transform.position.z >= 0.1)
        //{
        //    Scrambling = true;
        //    D1playerfollow.StreakPlayer = QB.transform;
        //    D2playerfollow.StreakPlayer = QB.transform;
        //    D3playerfollow.StreakPlayer = QB.transform;
        //    D4playerfollow.StreakPlayer = QB.transform;

        //    DL1playerfollow.StreakPlayer = QB.transform;
        //    DL2playerfollow.StreakPlayer = QB.transform;
        //    DL3playerfollow.StreakPlayer = QB.transform;
        //    DL4playerfollow.StreakPlayer = QB.transform;

        //    MLB1playerfollow.enabled = true;
        //    MLB2playerfollow.enabled = true;
        //    Safetyplayerfollow.enabled = true;

        //    MLB1playerfollow.StreakPlayer = QB.transform;
        //    MLB2playerfollow.StreakPlayer = QB.transform;
        //    Safetyplayerfollow.StreakPlayer = QB.transform;
        //}
        else
        {
            D1playerfollow.StreakPlayer = Receiver1.transform;
            D2playerfollow.StreakPlayer = Receiver2.transform;
            D3playerfollow.StreakPlayer = Receiver3.transform;
            D4playerfollow.StreakPlayer = Receiver4.transform;
            MLB1playerfollow.enabled = false;
            MLB2playerfollow.enabled = false;
            Safetyplayerfollow.enabled = false;
            DL1playerfollow.StreakPlayer = QB.transform;
            DL2playerfollow.StreakPlayer = QB.transform;
            DL3playerfollow.StreakPlayer = QB.transform;
            DL4playerfollow.StreakPlayer = QB.transform;


            MLB1playerfollow.StreakPlayer = null;
            MLB2playerfollow.StreakPlayer = null;
            Safetyplayerfollow.StreakPlayer = null;

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
                Debug.Log("Receiver tackled");
                hasTackled = true;
                LOSPos = new Vector3(0, -0.49f, Receiver1.transform.position.z);
                LOS.transform.position = LOSPos;
             
                R1hasCaught = false;
                PrePlay = true;
            }

            if (Receiver1.transform.position.z > 236.229 && Receiver1.transform.position.z < 245.34)
            {
                Touchdown = true;
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
                Debug.Log("Receiver tackled");
                hasTackled = true;
                LOSPos = new Vector3(0, -0.49f, Receiver2.transform.position.z);
                LOS.transform.position = LOSPos;
                R2hasCaught = false;
                PrePlay = true;
            }
            if (Receiver2.transform.position.z > 236.229 && Receiver2.transform.position.z < 245.34)
            {
                Touchdown = true;
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
                Debug.Log("Receiver tackled");
                hasTackled = true;
                LOSPos = new Vector3(0, -0.49f, Receiver3.transform.position.z);
                LOS.transform.position = LOSPos;
                R3hasCaught = false;
                PrePlay = true;
            }

            if (Receiver3.transform.position.z > 236.229 && Receiver3.transform.position.z < 245.34)
            {
                Touchdown = true;
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
                Debug.Log("Receiver tackled");
                hasTackled = true;
                LOSPos = new Vector3(0, -0.49f, Receiver4.transform.position.z);
                LOS.transform.position = LOSPos;
                R4hasCaught = false;
                PrePlay = true;
            }

            if (Receiver4.transform.position.z > 236.229 && Receiver4.transform.position.z < 245.34)
            {
                Touchdown = true;
            }
        }







        //if ((R1hasCaught == false && R2hasCaught == false && R3hasCaught == false && R4hasCaught == false) && (Vector3.Distance(QB.transform.position, Defender1.transform.position) <= 2 || Vector3.Distance(QB.transform.position, Defender2.transform.position) <= 2) || Vector3.Distance(QB.transform.position, Defender3.transform.position) <= 2 || Vector3.Distance(QB.transform.position, Defender4.transform.position) <= 2 || Vector3.Distance(QB.transform.position, MLB1.transform.position) <= 2 || Vector3.Distance(QB.transform.position, MLB2.transform.position) <= 2 || Vector3.Distance(QB.transform.position, Safety.transform.position) <= 2 || Vector3.Distance(QB.transform.position, DL1.transform.position) <= 2 || Vector3.Distance(QB.transform.position, DL2.transform.position) <= 2 || Vector3.Distance(QB.transform.position, DL3.transform.position) <= 2 || Vector3.Distance(QB.transform.position, DL4.transform.position) <= 2)
        //{
        //    Debug.Log("Receiver tackled");
        //    PrePlay = true;
        //    Sacked = true;
        //    hasTackled = true;
        //    LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, QB.transform.position.z);
        //    LOS.transform.position = LOSPos;
        //    Debug.Log("Sacked");


        //}


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
        if (Receiver4.transform.position.x >= 24.375 || Receiver4.transform.position.x <= -24.375)
        {
            R4Out = true;
        }




        if (R1OutCheck == false && R1hasCaught == true && R1Out == false)
        {

            R1OutCheck = true;
        }
        if (R1OutCheck == true && R1Out == true)
        {

            Debug.Log("Out of bounds (Receiver)");
            hasTackled = true;
            LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Receiver1.transform.position.z);
            LOS.transform.position = LOSPos;
            PrePlay = true;
        }
        if (R1OutCheck == false && R1hasCaught == true && R1Out == true)
        {
            Debug.Log("Out of bounds (Receiver)");
            hasTackled = true;
            PrePlay = true;
        }


        if (R2OutCheck == false && R2hasCaught == true && R2Out == false)
        {

            R2OutCheck = true;
        }
        if (R2OutCheck == true && R2Out == true)
        {
            Debug.Log("Out of bounds (Receiver)");
            hasTackled = true;
            LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Receiver2.transform.position.z);
            LOS.transform.position = LOSPos;
            PrePlay = true;
        }
        if (R2OutCheck == false && R2hasCaught == true && R2Out == true)
        {
            Debug.Log("Out of bounds (Receiver)");
            hasTackled = true;
            PrePlay = true;
        }


        if (R3OutCheck == false && R3hasCaught == true && R3Out == false)
        {

            R3OutCheck = true;
        }
        if (R3OutCheck == true && R3Out == true)
        {
            Debug.Log("Out of bounds (Receiver)");
            hasTackled = true;
            LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Receiver3.transform.position.z);
            LOS.transform.position = LOSPos;
            PrePlay = true;
        }
        if (R3OutCheck == false && R3hasCaught == true && R3Out == true)
        {
            Debug.Log("Out of bounds (Receiver)");
            hasTackled = true;
            PrePlay = true;
        }


        if (R4OutCheck == false && R4hasCaught == true && R4Out == false)
        {

            R4OutCheck = true;
        }
        if (R4OutCheck == true && R4Out == true)
        {
            Debug.Log("Out of bounds (Receiver)");
            hasTackled = true;
            LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Receiver4.transform.position.z);
            LOS.transform.position = LOSPos;
            PrePlay = true;
        }
        if (R4OutCheck == false && R4hasCaught == true && R4Out == true)
        {
            Debug.Log("Out of bounds (Receiver)");
            hasTackled = true;
            PrePlay = true;
        }






        if (Defender1.transform.position.x >= 24.375 || Defender1.transform.position.x <= -24.375)
        {
            D1Out = true;
        }
        if (Defender2.transform.position.x >= 24.375 || Defender2.transform.position.x <= -24.375)
        {
            D2Out = true;
        }
        if (Defender3.transform.position.x >= 24.375 || Defender3.transform.position.x <= -24.375)
        {
            D3Out = true;
        }
        if (Defender4.transform.position.x >= 24.375 || Defender4.transform.position.x <= -24.375)
        {
            D4Out = true;
        }

        if (D1OutCheck == false && _D1Int == true && D1Out == false)
        {

            D1OutCheck = true;
        }
        if (D2OutCheck == false && _D2Int == true && D2Out == false)
        {

            D2OutCheck = true;
        }
        if (D3OutCheck == false && _D3Int == true && D3Out == false)
        {

            D3OutCheck = true;
        }
        if (D4OutCheck == false && _D4Int == true && D4Out == false)
        {

            D4OutCheck = true;
        }


        if (D1OutCheck == true && D1Out == true)
        {
            D1_Int = true;
        }
        if (D1OutCheck == false && _D1Int == true && D1Out == true)
        {
            Incomplete = true;
            Down = Down + 1;
            PrePlay = true;
        }

        if (D2OutCheck == true && D2Out == true)
        {
            D2_Int = true;
        }
        if (D2OutCheck == false && _D2Int == true && D2Out == true)
        {
            Incomplete = true;
            Down = Down + 1;
            PrePlay = true;
        }

        if (D3OutCheck == true && D3Out == true)
        {
            D3_Int = true;
        }
        if (D3OutCheck == false && _D3Int == true && D3Out == true)
        {
            Incomplete = true;
            Down = Down + 1;
            PrePlay = true;
        }

        if (D4OutCheck == true && D4Out == true)
        {
            D1_Int = true;
        }
        if (D4OutCheck == false && _D4Int == true && D4Out == true)
        {
            Incomplete = true;
            Down = Down + 1;
            PrePlay = true;
        }



        if (QB.transform.position.z - LOS.transform.position.z >= 0.1 && BallisThrown == false)
        {
            Scrambling = true;
            D1playerfollow.StreakPlayer = QB.transform;
            D2playerfollow.StreakPlayer = QB.transform;
            D3playerfollow.StreakPlayer = QB.transform;
            D4playerfollow.StreakPlayer = QB.transform;

            DL1playerfollow.StreakPlayer = QB.transform;
            DL2playerfollow.StreakPlayer = QB.transform;
            DL3playerfollow.StreakPlayer = QB.transform;
            DL4playerfollow.StreakPlayer = QB.transform;

            MLB1playerfollow.enabled = true;
            MLB2playerfollow.enabled = true;
            Safetyplayerfollow.enabled = true;

            MLB1playerfollow.StreakPlayer = QB.transform;
            MLB2playerfollow.StreakPlayer = QB.transform;
            Safetyplayerfollow.StreakPlayer = QB.transform;
            Debug.Log("Scrambling");
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


        if (Scrambling && QB.transform.position.z > 236.229 && QB.transform.position.z < 245.34)
        {
            Touchdown = true;
        }
        if (QB.transform.position.x >= 24.375 || QB.transform.position.x <= -24.375)
        {
            LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, QB.transform.position.z);
            LOS.transform.position = LOSPos;
            PrePlay = true;
        }

        Vector3 Throwdist = Ball.transform.position - Hand.transform.position;



        if (PrePlay == false && Ball.transform.position.y < 0.07 && (!R1hasCaught && !R2hasCaught && !R3hasCaught && !R4hasCaught && !D1_Int && !D2_Int && !D3_Int && !D4_Int) && BallisThrown == true)
        {
            Incomplete = true;
            //Debug.Log("Incomplete");
            Down = Down + 1;
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
            Debug.Log("Line 968");
            Down = Down + 1;
        }

        //if (Down >= 4)
        //{
        //    TurnoverOnDowns = true;
        //    LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, 167.45f);
        //    Down = 1;
        //}

        if (Touchdown)
        {
            LOSPos = new Vector3(0, -0.49f, 167.45f);
            LOS.transform.position = LOSPos;
            FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
            FDM.transform.position = FDMPos;
            PlayerScore = PlayerScore + 7;
            PrePlay = true;
        }


        if (PrePlay == false && BallisThrown == true && R1hasCaught == false && R2hasCaught == false && R3hasCaught == false && R4hasCaught == false && Interception == false)
        {
            float R1DistanceFromBall;
            float R2DistanceFromBall;
            float R3DistanceFromBall;
            float R4DistanceFromBall;

            




            traj.enabled = true;

            HitPoint = new Vector3(traj.hitInfo3D.point.x, 0, traj.hitInfo3D.point.z);

            MTB.transform.position = HitPoint;
            //   Debug.Log("MTB " + MTB.transform.position);

            

            //  Debug.Log("R1 " + R1DistanceFromBall); Debug.Log("R2 " + R2DistanceFromBall); Debug.Log("R3 " + R3DistanceFromBall); Debug.Log("R4 " + R4DistanceFromBall);

            if (MTB.transform.position.z == 0)
            {
                CheckMTBPos = false;

            }
            else
            {
                CheckMTBPos = true;
            }

            R1DistanceFromBall = Vector3.Distance(Receiver1.transform.position, MTB.transform.position);
            R2DistanceFromBall = Vector3.Distance(Receiver2.transform.position, MTB.transform.position);
            R3DistanceFromBall = Vector3.Distance(Receiver3.transform.position, MTB.transform.position);
            R4DistanceFromBall = Vector3.Distance(Receiver4.transform.position, MTB.transform.position);

            if (R1DistanceFromBall < R2DistanceFromBall && R1DistanceFromBall < R3DistanceFromBall && R1DistanceFromBall < R4DistanceFromBall && CheckMTBPos == true)
            {
               // Debug.Log("R1");
               // Debug.Log("MTB1 " + MTB.transform.position);
               // Debug.Log("R1 " + R1DistanceFromBall); Debug.Log("R2 " + R2DistanceFromBall); Debug.Log("R3 " + R3DistanceFromBall); Debug.Log("R4 " + R4DistanceFromBall);
                R1Locked = true;
                R2Locked = false;
                R3Locked = false;
                R4Locked = false;
               
            }
             if (R2DistanceFromBall < R1DistanceFromBall && R2DistanceFromBall < R3DistanceFromBall && R2DistanceFromBall < R4DistanceFromBall && CheckMTBPos == true)
            {
             //   Debug.Log("R2");
               // Debug.Log("MTB2 " + MTB.transform.position);
               // Debug.Log("R1 " + R1DistanceFromBall); Debug.Log("R2 " + R2DistanceFromBall); Debug.Log("R3 " + R3DistanceFromBall); Debug.Log("R4 " + R4DistanceFromBall);
                R2Locked = true;
                R1Locked = false;
                R3Locked = false;
                R4Locked = false;
              
            }
             if (R3DistanceFromBall < R1DistanceFromBall && R3DistanceFromBall < R2DistanceFromBall && R3DistanceFromBall < R4DistanceFromBall && CheckMTBPos == true)
            {
               // Debug.Log("R3");
             //   Debug.Log("MTB3 " + MTB.transform.position);
              //  Debug.Log("R1 " + R1DistanceFromBall); Debug.Log("R2 " + R2DistanceFromBall); Debug.Log("R3 " + R3DistanceFromBall); Debug.Log("R4 " + R4DistanceFromBall);
                R3Locked = true;
                R1Locked = false;
                R2Locked = false;
                R4Locked = false;
                
            }
           if (R4DistanceFromBall < R1DistanceFromBall && R4DistanceFromBall < R2DistanceFromBall && R4DistanceFromBall < R3DistanceFromBall && CheckMTBPos == true)
            {
               // Debug.Log("R4");
               // Debug.Log("MTB4 " + MTB.transform.position);
              //  Debug.Log("R1 " + R1DistanceFromBall); Debug.Log("R2 " + R2DistanceFromBall); Debug.Log("R3 " + R3DistanceFromBall); Debug.Log("R4 " + R4DistanceFromBall);
                R4Locked = true;
                R1Locked = false;
                R2Locked = false;
                R3Locked = false;
                
            }

           if(R1Locked)
            {
                R1Path.enabled = false;
                R1PlayerFollow.enabled = true;
                R1PlayerFollow.StreakPlayer = MTB.transform;
            }
           if(R2Locked)
            {
                R2Path.enabled = false;
                R2PlayerFollow.enabled = true;
                R2PlayerFollow.StreakPlayer = MTB.transform;
            }
           if(R3Locked)
            {
                R3Path.enabled = false;
                R3PlayerFollow.enabled = true;
                R3PlayerFollow.StreakPlayer = MTB.transform;
            }
            if (R4Locked)
            {
                R4Path.enabled = false;
                R4PlayerFollow.enabled = true;
                R4PlayerFollow.StreakPlayer = MTB.transform;
            }

         

           



           


        }
        else if (PrePlay == false)
        {
            R1Path.enabled = true;
            R2Path.enabled = true;
            R3Path.enabled = true;
            R4Path.enabled = true;
        }

        if (Incomplete)
        {
            Debug.Log("Incomplete");
            hasTackled = true;
            PrePlay = true;
        }

        if (D1_Int)
        {
            D1playerfollow.StreakPlayer = P6Pos.transform;

            R1PlayerFollow.StreakPlayer = D1playerfollow.transform;
            R2PlayerFollow.StreakPlayer = D1playerfollow.transform;
            R3PlayerFollow.StreakPlayer = D1playerfollow.transform;
            R4PlayerFollow.StreakPlayer = D1playerfollow.transform;

            D2playerfollow.StreakPlayer = Receiver2.transform;
            D3playerfollow.StreakPlayer = Receiver3.transform;
            D4playerfollow.StreakPlayer = Receiver4.transform;
            DL1playerfollow.StreakPlayer = OL1.transform;
            DL2playerfollow.StreakPlayer = OL2.transform;
            DL3playerfollow.StreakPlayer = OL3.transform;
            DL4playerfollow.StreakPlayer = OL4.transform;
            MLB1playerfollow.StreakPlayer = OL5.transform;
            MLB2playerfollow.StreakPlayer = QB.transform;
            Safetyplayerfollow.StreakPlayer = Defender1.transform;

            Vector3 r1dist = Receiver1.transform.position - Defender1.transform.position;
            Vector3 r2dist = Receiver2.transform.position - Defender1.transform.position;
            Vector3 r4dist = Receiver4.transform.position - Defender1.transform.position;
            Vector3 r3dist = Receiver3.transform.position - Defender1.transform.position;
            Vector3 QBdist = QB.transform.position - Defender1.transform.position;

            if (r1dist.magnitude < 1.5 || r2dist.magnitude < 1.5 || r3dist.magnitude < 1.5 || r4dist.magnitude < 1.5 || QBdist.magnitude < 1.5)
            {
                LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Defender1.transform.position.z);
                LOS.transform.position = LOSPos;
                Interception = true;
                LOSPos = new Vector3(0, -0.49f, 167.45f);
                LOS.transform.position = LOSPos;
                FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
                FDM.transform.position = FDMPos;

                PrePlay = true;
                TimerOff = true;
            }
            if(Defender1.transform.position.z < 144.832)
            {
                OpponentScore = OpponentScore + 7;
                LOSPos = new Vector3(0, -0.49f, 167.45f);
                LOS.transform.position = LOSPos;
                FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
                FDM.transform.position = FDMPos;
                PrePlay = true;
                TimerOff = true;

            }
        //    Interception = false;
            //D1_Int = false;
                
        }
        if (D2_Int)
        {
            D2playerfollow.StreakPlayer = P6Pos.transform;

            R1PlayerFollow.StreakPlayer = D2playerfollow.transform;
            R2PlayerFollow.StreakPlayer = D2playerfollow.transform;
            R3PlayerFollow.StreakPlayer = D2playerfollow.transform;
            R4PlayerFollow.StreakPlayer = D2playerfollow.transform;

            D1playerfollow.StreakPlayer = Receiver1.transform;
            D3playerfollow.StreakPlayer = Receiver3.transform;
            D4playerfollow.StreakPlayer = Receiver4.transform;
            DL1playerfollow.StreakPlayer = OL1.transform;
            DL2playerfollow.StreakPlayer = OL2.transform;
            DL3playerfollow.StreakPlayer = OL3.transform;
            DL4playerfollow.StreakPlayer = OL4.transform;
            MLB1playerfollow.StreakPlayer = OL5.transform;
            MLB2playerfollow.StreakPlayer = QB.transform;
            Safetyplayerfollow.StreakPlayer = Defender2.transform;

            Vector3 r1dist = Receiver1.transform.position - Defender2.transform.position;
            Vector3 r2dist = Receiver2.transform.position - Defender2.transform.position;
            Vector3 r4dist = Receiver4.transform.position - Defender2.transform.position;
            Vector3 r3dist = Receiver3.transform.position - Defender2.transform.position;
            Vector3 QBdist = QB.transform.position - Defender2.transform.position;

            if (r1dist.magnitude < 1.5 || r2dist.magnitude < 1.5 || r3dist.magnitude < 1.5 || r4dist.magnitude < 1.5 || QBdist.magnitude < 1.5)
            {
                LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Defender2.transform.position.z);
                LOS.transform.position = LOSPos;
                Interception = true;
                LOSPos = new Vector3(0, -0.49f, 167.45f);
                LOS.transform.position = LOSPos;
                FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
                FDM.transform.position = FDMPos;
                PrePlay = true;
                TimerOff = true;
            }
            if (Defender2.transform.position.z < 144.832)
            {
                OpponentScore = OpponentScore + 7;
                LOSPos = new Vector3(0, -0.49f, 167.45f);
                LOS.transform.position = LOSPos;
                FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
                FDM.transform.position = FDMPos;
                PrePlay = true;
                TimerOff = true;

            }
            //    Interception = false;
            //D1_Int = false;

        }
        if (D3_Int)
        {
            D3playerfollow.StreakPlayer = P6Pos.transform;

            R1PlayerFollow.StreakPlayer = D3playerfollow.transform;
            R2PlayerFollow.StreakPlayer = D3playerfollow.transform;
            R3PlayerFollow.StreakPlayer = D3playerfollow.transform;
            R4PlayerFollow.StreakPlayer = D3playerfollow.transform;

            D1playerfollow.StreakPlayer = Receiver1.transform;
            D2playerfollow.StreakPlayer = Receiver2.transform;
            D4playerfollow.StreakPlayer = Receiver4.transform;
            DL1playerfollow.StreakPlayer = OL1.transform;
            DL2playerfollow.StreakPlayer = OL2.transform;
            DL3playerfollow.StreakPlayer = OL3.transform;
            DL4playerfollow.StreakPlayer = OL4.transform;
            MLB1playerfollow.StreakPlayer = OL5.transform;
            MLB2playerfollow.StreakPlayer = QB.transform;
            Safetyplayerfollow.StreakPlayer = Defender3.transform;

            Vector3 r1dist = Receiver1.transform.position - Defender3.transform.position;
            Vector3 r2dist = Receiver2.transform.position - Defender3.transform.position;
            Vector3 r4dist = Receiver4.transform.position - Defender3.transform.position;
            Vector3 r3dist = Receiver3.transform.position - Defender3.transform.position;
            Vector3 QBdist = QB.transform.position - Defender3.transform.position;

            if (r1dist.magnitude < 1.5 || r2dist.magnitude < 1.5 || r3dist.magnitude < 1.5 || r4dist.magnitude < 1.5 || QBdist.magnitude < 1.5)
            {
                LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Defender3.transform.position.z);
                LOS.transform.position = LOSPos;
                Interception = true;
                LOSPos = new Vector3(0, -0.49f, 167.45f);
                LOS.transform.position = LOSPos;
                FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
                FDM.transform.position = FDMPos;
                PrePlay = true;
                TimerOff = true;
            }
            if (Defender3.transform.position.z < 144.832)
            {
                OpponentScore = OpponentScore + 7;
                LOSPos = new Vector3(0, -0.49f, 167.45f);
                LOS.transform.position = LOSPos;
                FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
                FDM.transform.position = FDMPos;
                PrePlay = true;
                TimerOff = true;

            }
            //    Interception = false;
            //D1_Int = false;

        }
        if (D4_Int)
        {
            D4playerfollow.StreakPlayer = P6Pos.transform;

            R1PlayerFollow.StreakPlayer = D4playerfollow.transform;
            R2PlayerFollow.StreakPlayer = D4playerfollow.transform;
            R3PlayerFollow.StreakPlayer = D4playerfollow.transform;
            R4PlayerFollow.StreakPlayer = D4playerfollow.transform;

            D1playerfollow.StreakPlayer = Receiver1.transform;
            D2playerfollow.StreakPlayer = Receiver2.transform;
            D3playerfollow.StreakPlayer = Receiver3.transform;
            DL1playerfollow.StreakPlayer = OL1.transform;
            DL2playerfollow.StreakPlayer = OL2.transform;
            DL3playerfollow.StreakPlayer = OL3.transform;
            DL4playerfollow.StreakPlayer = OL4.transform;
            MLB1playerfollow.StreakPlayer = OL5.transform;
            MLB2playerfollow.StreakPlayer = QB.transform;
            Safetyplayerfollow.StreakPlayer = Defender4.transform;

            Vector3 r1dist = Receiver1.transform.position - Defender4.transform.position;
            Vector3 r2dist = Receiver2.transform.position - Defender4.transform.position;
            Vector3 r4dist = Receiver4.transform.position - Defender4.transform.position;
            Vector3 r3dist = Receiver3.transform.position - Defender4.transform.position;
            Vector3 QBdist = QB.transform.position - Defender4.transform.position;

            if (r1dist.magnitude < 1.5 || r2dist.magnitude < 1.5 || r3dist.magnitude < 1.5 || r4dist.magnitude < 1.5 || QBdist.magnitude < 1.5)
            {
                LOSPos = new Vector3(LOS.transform.position.x, LOS.transform.position.y, Defender4.transform.position.z);
                LOS.transform.position = LOSPos;
                Interception = true;
                LOSPos = new Vector3(0, -0.49f, 167.45f);
                LOS.transform.position = LOSPos;
                FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
                FDM.transform.position = FDMPos;
                PrePlay = true;
                TimerOff = true;
                Debug.Log("Defender tackled");
            }
            if (Defender4.transform.position.z < 144.832)
            {
                OpponentScore = OpponentScore + 7;
                LOSPos = new Vector3(0, -0.49f, 167.45f);
                LOS.transform.position = LOSPos;
                FDMPos = new Vector3(FDM.transform.position.x, FDM.transform.position.y, LOS.transform.position.z + 9.146f);
                FDM.transform.position = FDMPos;
                PrePlay = true;
                TimerOff = true;
                Debug.Log("Pick Six");
            }
            //    Interception = false;
            //D1_Int = false;

        }

        if (PrePlay == true)
        {
            R1Path.enabled = true;
            R2Path.enabled = true;
            R3Path.enabled = true;
            R4Path.enabled = true;
            traj.enabled = false;
            R1PlayerFollow.enabled = false;
            R2PlayerFollow.enabled = false;
            R3PlayerFollow.enabled = false;
            R4PlayerFollow.enabled = false;


            R1anim.SetBool("Running", false);
            R2anim.SetBool("Running", false);
            R3anim.SetBool("Running", false);
            R4anim.SetBool("Running", false);

            D1anim.SetBool("Running", false);
            D2anim.SetBool("Running", false);
            D3anim.SetBool("Running", false);
            D4anim.SetBool("Running", false);
            MLB1anim.SetBool("Running", false);
            MLB2anim.SetBool("Running", false);
            Safetyanim.SetBool("Running", false);

            R1anim.SetBool("Idle", true);
            R2anim.SetBool("Idle", true);
            R3anim.SetBool("Idle", true);
            R4anim.SetBool("Idle", true);

            D1anim.SetBool("Idle", true);
            D2anim.SetBool("Idle", true);
            D3anim.SetBool("Idle", true);
            D4anim.SetBool("Idle", true);
            MLB1anim.SetBool("Idle", true);
            MLB2anim.SetBool("Idle", true);
            Safetyanim.SetBool("Idle", true);

            DL1anim.SetBool("Running", false);
            DL1anim.SetBool("Idle", true);
            DL2anim.SetBool("Running", false);
            DL2anim.SetBool("Idle", true);
            DL3anim.SetBool("Running", false);
            DL3anim.SetBool("Idle", true);
            DL4anim.SetBool("Running", false);
            DL4anim.SetBool("Idle", true);




            //OL1anim.speed = 0;
            //OL2anim.speed = 0;
            //OL3anim.speed = 0;
            //OL4anim.speed = 0;
            //OL5anim.speed = 0;





            R1hasCaught = false;
            R2hasCaught = false;
            R3hasCaught = false;
            R4hasCaught = false;
            hasTackled = false;
            Sacked = false;
            OL1Pos = new Vector3(2.7f, 0, LOS.transform.position.z - 1);
            OL2Pos = new Vector3(1.49f, 0, LOS.transform.position.z - 1);
            OL3Pos = new Vector3(0.2825f, 0, LOS.transform.position.z - 0.5f);
            OL4Pos = new Vector3(-1, 0, LOS.transform.position.z - 1);
            OL5Pos = new Vector3(-1.98f, 0, LOS.transform.position.z - 1);
            R1Pos = new Vector3(16.64f, 0, LOS.transform.position.z - 1.3f);
            R2Pos = new Vector3(9.83f, 0, LOS.transform.position.z - 1.3f);
            R3Pos = new Vector3(-7.76f, 0, LOS.transform.position.z - 1.3f);
            R4Pos = new Vector3(-15.41f, 0, LOS.transform.position.z - 1.3f);
            QBPos = new Vector3(-0.97f, 0, LOS.transform.position.z - 4.5f);
            RBPos = new Vector3(2.33f, 0, LOS.transform.position.z - 4.65f);

            DL1Pos = new Vector3(-1.65f, 0, LOS.transform.position.z + 0.5f);
            DL2Pos = new Vector3(-0.65f, 0, LOS.transform.position.z + 0.5f);
            DL3Pos = new Vector3(0.65f, 0, LOS.transform.position.z + 0.5f);
            DL4Pos = new Vector3(2.18f, 0, LOS.transform.position.z + 0.5f);
            D1Pos = new Vector3(16.52f, 0, LOS.transform.position.z + 2.5f);
            D2Pos = new Vector3(9.6f, 0, LOS.transform.position.z + 2.5f);
            D3Pos = new Vector3(-8.37f, 0, LOS.transform.position.z + 2.5f);
            D4Pos = new Vector3(-16.17f, 0, LOS.transform.position.z + 2.5f);
            MLB1Pos = new Vector3(-1.82f, 0, LOS.transform.position.z + 3.5f);
            MLB2Pos = new Vector3(1.49f, 0, LOS.transform.position.z + 3.5f);
            SafetyPos = new Vector3(0.16f, 0, LOS.transform.position.z + 10);





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


            R1PlayerFollow.enabled = false;
            R2PlayerFollow.enabled = false;
            R3PlayerFollow.enabled = false;
            R4PlayerFollow.enabled = false;
            //   BallRigidBody.freezeRotation = true;

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

            //R1PlayerFollow.StreakPlayer = MTB.transform;
            //R2PlayerFollow.StreakPlayer = MTB.transform;
            //R3PlayerFollow.StreakPlayer = MTB.transform;
            //R4PlayerFollow.StreakPlayer = MTB.transform;

            R1OutCheck = false;
            R2OutCheck = false;
            R3OutCheck = false;
            R4OutCheck = false;
            R1Out = false;
            R2Out = false;
            R3Out = false;
            R4Out = false;
            D1Out = false;
            D2Out = false;
            D3Out = false;
            D4Out = false;
            D1OutCheck = false;
            D2OutCheck = false;
            D3OutCheck = false;
            D4OutCheck = false;
            RouteCalibration = false;
            Scrambling = false;
            Touchdown = false;
            Incomplete = false;
            
            BallisThrown = false;
            CheckMTBPos = false;

            D1_Int = false;
            D2_Int = false;
            D3_Int = false;
            D4_Int = false;
            Interception = false;
            R1PlayerFollow.StreakPlayer = null;
            R2PlayerFollow.StreakPlayer = null;
            R3PlayerFollow.StreakPlayer = null;
            R4PlayerFollow.StreakPlayer = null;

            R1Locked = false;
            R2Locked = false;
            R3Locked = false;
            R4Locked = false;

            STcs.Caught = false;
            

          


            //
        }
        
        else
        {

          //  BallRigidBody.freezeRotation = false;
            R1anim.SetBool("Running", true);
            R2anim.SetBool("Running", true);
            R3anim.SetBool("Running", true);
            R4anim.SetBool("Running", true);

            D1anim.SetBool("Running", true);
            D2anim.SetBool("Running", true);
            D3anim.SetBool("Running", true);
            D4anim.SetBool("Running", true);
            R1anim.SetBool("Idle", false);
            R2anim.SetBool("Idle", false);
            R3anim.SetBool("Idle", false);
            R4anim.SetBool("Idle", false);

            D1anim.SetBool("Idle", false);
            D2anim.SetBool("Idle", false);
            D3anim.SetBool("Idle", false);
            D4anim.SetBool("Idle", false);
            MLB1anim.SetBool("Idle", false);
            MLB2anim.SetBool("Idle", false);
            Safetyanim.SetBool("Idle", false);
            DL1anim.SetBool("Idle", false);
            DL1anim.SetBool("Running", true);
            DL2anim.SetBool("Idle", false);
            DL2anim.SetBool("Running", true);
            DL3anim.SetBool("Idle", false);
            DL3anim.SetBool("Running", true);
            DL4anim.SetBool("Idle", false);
            DL4anim.SetBool("Running", true);

            DL1.transform.localScale = PostPlayLinemanTemplate.transform.localScale;
            DL2.transform.localScale = PostPlayLinemanTemplate.transform.localScale;
            DL3.transform.localScale = PostPlayLinemanTemplate.transform.localScale;
            DL4.transform.localScale = PostPlayLinemanTemplate.transform.localScale;

            //R1Path.enabled = true;
            //R2Path.enabled = true;
            //R3Path.enabled = true;
            //R4Path.enabled = true;

            if (RouteCalibration == false)
            {
                transform.position = pathCreator.path.GetPoint(0);
                R1Path.distanceTravelled = 0;
                R2Path.distanceTravelled = 0;
                R3Path.distanceTravelled = 0;
                R4Path.distanceTravelled = 0;

                new WaitForSeconds(0.1f);
                R1hasCaught = false;
                RouteCalibration = true;

            }
            

            //MLB1anim.SetBool("Running", true);
            //MLB2anim.SetBool("Running"e, true);
            //////Safetyanim.SetBool("Running", true);;




        }

    }




















   

//Simming



    void Simming()
    {

        //35-50 yard line
        if(LOS.transform.position.z <= 190.493 && LOS.transform.position.z >= 176.768)
        {
            Debug.Log("The player is between the 35 yard line and the 50 yard line. The opponent now has a 70% chance of scoring, with up to 3 minutes taken off the clock");
            //70% chance of scoring, Up to 3 minutes taken off the clock.

            if(UnityEngine.Random.Range(1, 100) <= 70)
            {
                if(UnityEngine.Random.Range(1, 100) <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if(UnityEngine.Random.Range(1,100) > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }


            currentTime = currentTime - UnityEngine.Random.Range(30, 180);


        }

        //15-35 yard line
        if(LOS.transform.position.z <= 176.768 && LOS.transform.position.z >= 158.468)
        {
            Debug.Log("The player is between the 15 yard line and the 35 yard line. The opponent now has a 90% chance of scoring, with up to 2 minutes taken off the clock");
            //90% chance of scoring, up to 2 minutes taken off the clock
         
            if (UnityEngine.Random.Range(1, 100) <= 90)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(15, 120);

        }

        //10-15 yard line
        if(LOS.transform.position.z <= 158.468 && LOS.transform.position.z >= 153.893)
        {
            Debug.Log("The player is between the 10 and 15 yard line. The opponent now has a 95% chance of scoring, with up to 1:30 minutes taken off the clock");
            //95% chance of scoring, up to 1:30 taken off the clock

            if (UnityEngine.Random.Range(1, 100) <= 95)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(15, 90);
        }

        //10 yard line - Endzone
        if(LOS.transform.position.z <= 153.893 && LOS.transform.position.z >= 144.832)
        {
            Debug.Log("The player is between the Endzone and 10 yard line. The opponent now has a 99% chance of scoring, with up to 1 minute taken off the clock");

            if (UnityEngine.Random.Range(1, 100) <= 99)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(15, 60);
        }




        //50-65 yard line
        if(LOS.transform.position.z <= 204.218 && LOS.transform.position.z >= 190.493)
        {
            Debug.Log("The player is between the 50 and 65 yard line. The opponent now has a 40% chance of scoring, with up to 3 minutes taken off the clock");

            if (UnityEngine.Random.Range(1, 100) <= 40)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(30, 180);
        }

        //65-85 yard line
        if(LOS.transform.position.z <= 222.518 && LOS.transform.position.z >= 204.218)
        {
            Debug.Log("The player is between the 65 and 85 yard line. The opponent now has a 30% chance of scoring, with up to 4 minutes taken off the clock");

            if (UnityEngine.Random.Range(1, 100) <= 30)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(30, 240);
        }

        //85-90 yard line 
        if(LOS.transform.position.z <= 227.093 && LOS.transform.position.z >= 222.518)
        {
            Debug.Log("The player is between the 85 and 90 yard line. The opponent now has a 15% chance of scoring, with up to 4:30 minutes taken off the clock");

            if (UnityEngine.Random.Range(1, 100) <= 15)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(30, 270);
        }

        //90 yard line - Endzone
        if(LOS.transform.position.z <= 236.229 && LOS.transform.position.z >= 227.093)
        {
            Debug.Log("The player is between the Endzone and the 90 yard line. The opponent now has a 5% chance of scoring, with up to 5 minutes taken off the clock");

            if (UnityEngine.Random.Range(1, 100) <= 5)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(15, 300);
        }



        LOSPos = new Vector3(0, -0.49f, 167.45f);
        LOS.transform.position = LOSPos;
        PrePlay = true;

        TimerOff = true;

    }

    float RandomNumber;

    void PuntSimming()
    {
        //Endzone - 10
        if (LOS.transform.position.z <= 153.893 && LOS.transform.position.z >= 144.832)
        {
            Debug.Log("The player is punting between the endzone and the 10 yard line. The opponent has a 55% chance of scoring, with up to 3 minutes taken off the clock");
            if(UnityEngine.Random.Range(1, 100) <= 55)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(30, 180);
        }

        //10-20
        if(LOS.transform.position.z <= 163.043 && LOS.transform.position.z >= 153.893)
        {
            Debug.Log("The player is punting between the 10 and 20 yard line. The opponent has a 45% chance of scoring, with up to 3 minutes taken off the clock");
            if (UnityEngine.Random.Range(1, 100) <= 45)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }
            currentTime = currentTime - UnityEngine.Random.Range(15, 180);
        }

            //20-30
        if(LOS.transform.position.z <= 172.193 && LOS.transform.position.z >= 163.043)
        {
            Debug.Log("The player is punting between the 20 and 30 yard line. The opponent has a 35% chance of scoring, with up to 3:30 minutes taken off the clock");
            if (UnityEngine.Random.Range(1, 100) <= 35)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }
            currentTime = currentTime - UnityEngine.Random.Range(15, 210);
        }

            //30-40
        if(LOS.transform.position.z <= 181.343 && LOS.transform.position.z >= 172.193)
        {
            Debug.Log("The player is punting between the 30 and 40 yard line. The opponent has a 25% chance of scoring, with up to 4 minutes taken off the clock");
            if (UnityEngine.Random.Range(1, 100) <= 25)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(30, 240);
        }

            //40-50
        if(LOS.transform.position.z <= 190.493 && LOS.transform.position.z >= 181.343)
        {
            Debug.Log("The player is punting between the 40 and 50 yard line. The opponent has a 15% chance of scoring, with up to 4 minutes taken off the clock");
            if (UnityEngine.Random.Range(1, 100) <= 15)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(30, 240);
        }

            //50-60
        if(LOS.transform.position.z <= 199.643 && LOS.transform.position.z >= 190.493)
        {
            Debug.Log("The player is punting between the 50 and 60 yard line. The opponent has a 15% chance of scoring, with up to 4 minutes taken off the clock");
            if (UnityEngine.Random.Range(1, 100) <= 15)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }
            currentTime = currentTime - UnityEngine.Random.Range(30, 240);
        }

            //60+
        if(LOS.transform.position.z > 199.643)
        {
            Debug.Log("The player is punting past the 60 yard line. The opponent has a 10% chance of scoring, with up to 4:30 minutes taken off the clock");
            if (UnityEngine.Random.Range(1, 100) <= 10)
            {
                RandomNumber = UnityEngine.Random.Range(1, 100);

                if (RandomNumber <= 70)
                {
                    OpponentScore = OpponentScore + 7;
                }
                if (RandomNumber > 70)
                {
                    OpponentScore = OpponentScore + 3;
                }
            }

            currentTime = currentTime - UnityEngine.Random.Range(30, 270);
        }


        LOSPos = new Vector3(0, -0.49f, 167.45f);
        LOS.transform.position = LOSPos;
        PrePlay = true;

        TimerOff = true;
    }












    public void ActivatePunt()
    {
        Punt = true;
        SnapLocked = false;
    }

    public void ActivateGoForIt()
    {
        GoingForIt = true;
        FDUI.SetActive(false);
        SnapLocked = false;
    }

    float currentTime;
    float startingTime = 300;
    string seconds;
    int Minutes;
    void Timer()
    {
     //   Debug.Log("Quarter " + Quarter + "  --  "  + Minutes + ":" + seconds);

       
        currentTime -= 1 * Time.deltaTime;

        Minutes = TimeSpan.FromSeconds(currentTime).Minutes;
        seconds = TimeSpan.FromSeconds(currentTime).Seconds.ToString("0");

        if(seconds == "9")
        {
            seconds = "09";
        }
        if (seconds == "8")
        {
            seconds = "08";
        }

        if (seconds == "7")
        {
            seconds = "07";
        }

        if (seconds == "6")
        {
            seconds = "06";
        }

        if (seconds == "5")
        {
            seconds = "05";
        }
        if (seconds == "4")
        {
            seconds = "04";
        }
        if (seconds == "3")
        {
            seconds = "03";
        }
        if (seconds == "2")
        {
            seconds = "02";
        }

        if (seconds == "1")
        {
            seconds = "01";
        }

        if (seconds == "0")
        {
            seconds = "00";
        }



        







    }

    public bool QuarterEnd;
    public int Quarter = 1;
    public bool GameOver;
    

}

