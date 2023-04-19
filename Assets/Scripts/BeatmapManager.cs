using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using System.IO;

public class BeatmapManager : MonoBehaviour
{
    public Sprite noteSprite; //Add in inspector
    public Sprite rightLaserSprite;
    public Sprite leftLaserSprite;
    public Sprite lineSprite;
    public SpriteShape rightLaserShape;
    public SpriteShape leftLaserShape;
    public GameObject buttons;


    protected string beatmapTitle;
    protected string beatmapAuthor;
    protected string beatmapJacketPath;
    protected string difficulty;
    protected int bpm;
    protected string audioPath;
    protected int volume;

    private StreamReader beatmapInfo;
    private StreamReader beatmapLaserRight;
    private StreamReader beatmapLaserLeft;
    private string gamePath;
    private string beatmapPath;
    private int count = 0;

    //private int[][] grid; //Grid of note containing 1 beat
    private Vector3 FLPos, LPos, RPos, FRPos;
    private char[] rightLaserTab;
    private char[] leftLaserTab;
    private List<int>[] row;
    //private List<int> noteList;
    private List<char> laserList;


    [SerializeField]private GameObject note;
    //private GameObject rightLaser;
    //private GameObject leftLaser;
    private SpriteShapeController rightLaserShapeController;
    private SpriteShapeController leftLaserShapeController;
    private GameObject rightLaser, leftLaser;

    private GameObject groupLine;
    [SerializeField]private GameObject line;

   
    enum laserPos
    {
        RIGHT,
        LEFT
    }

    void Awake()
    {

        row = new List<int>[4];
        for (int i = 0; i < row.Length; i++)
        {
            row[i] = new List<int>();
        }
        initReader();

        //laserList = new List<char>();

        rightLaser = new GameObject();
        rightLaser.AddComponent<Laser>();

        leftLaser = new GameObject();
        leftLaser.AddComponent<Laser>();

        rightLaser.GetComponent<Laser>().initLaser(rightLaserShape, 16f);
        leftLaser.GetComponent<Laser>().initLaser(leftLaserShape, 16f);
        rightLaser.GetComponent<Laser>().instanciateLaser(1, 4.45f, 0f);
        leftLaser.GetComponent<Laser>().instanciateLaser(2, -4.45f, 0f);

        groupLine = new GameObject("groupLine");

        //rightLaser = new Laser();
        //rightLaser = new GameObject("rightLaser");
        //leftLaser = new GameObject("leftLaser");
    }
    // Start is called before the first frame update
    void Start()
    {
        //initReader();
        //initNote();
        //initLine();
        instanciateLine();
        //initRightLaser();
        //initLeftLaser();
        readBeatmap();
        getNote();
        instanciateNote();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Time.time >= 1)
         {
             Time.timeScale = 0;
         }*/
        //Debug.Log("Elapsed Time : " + Time.time);
    }

    void initReader()
    {
        gamePath = Application.dataPath; //Get the current project path
        beatmapPath = gamePath + "/Audio/Sports Theme-Wii.pe";
        //beatmapPath = gamePath + "/Audio/Tokyo Machine - PLAY.pe";
        //beatmapPath = gamePath + "/Audio/testMusic.pe";
        beatmapInfo = new StreamReader(beatmapPath);

        //Init laser reader
        beatmapLaserRight = new StreamReader(beatmapPath);
        beatmapLaserLeft = new StreamReader(beatmapPath);
        for (int i = 0; i < 8; i++)
        {
            beatmapLaserRight.ReadLine();
            beatmapLaserLeft.ReadLine();
        }
    }

    /*void initNote()
    {
        note.transform.position = new Vector3(100f, 0f, 100f);
        note.tag = "Note";
        note.AddComponent<SpriteRenderer>();
        note.GetComponent<SpriteRenderer>().sprite = noteSprite;
        note.GetComponent<SpriteRenderer>().color = Color.red;
        note.GetComponent<SpriteRenderer>().sortingLayerName = "Note";
        note.AddComponent<Rigidbody2D>();
        note.GetComponent<Rigidbody2D>().mass = 1;
        note.GetComponent<Rigidbody2D>().angularDrag = 0.05f;
        //note.GetComponent<Rigidbody2D>().useGravity = false;
        note.GetComponent<Rigidbody2D>().gravityScale = 0;
        note.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        note.AddComponent<BoxCollider2D>();
        note.GetComponent<BoxCollider2D>().isTrigger = true;
        note.GetComponent<BoxCollider2D>().size = new Vector3(1, 0.87f, 0);
        note.AddComponent<Note>();
        note.GetComponent<Note>().speed = 27;
        note.GetComponent<Renderer>().enabled = false;
        //Debug.Log(note.GetComponent<SpriteRenderer>().bounds.size);
    }

    void initLine()
    {
        line = new GameObject("line");
        line.transform.parent = groupLine.transform;
        line.transform.position = new Vector3(0, 0, 0);
        line.transform.localScale = new Vector3(10.5f, 0.1f, 1);
        line.AddComponent<SpriteRenderer>();
        line.GetComponent<SpriteRenderer>().sprite = lineSprite;
        line.GetComponent<SpriteRenderer>().sortingOrder = 1;
        line.AddComponent<Rigidbody2D>();
        line.GetComponent<Rigidbody2D>().gravityScale = 0;
        line.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        line.AddComponent<BoxCollider2D>();
        line.GetComponent<BoxCollider2D>().isTrigger = true;
        line.AddComponent<Note>();
        line.GetComponent<Note>().speed = 27f;
        line.GetComponent<Renderer>().enabled = false;
        line.layer = LayerMask.NameToLayer("Lines");

    }*/

    //Read level information
    void readBeatmap()
    {
        //--------------------------//
        //---Beatmap informations---//
        //--------------------------//

        string line;
        string[] tabInfo = new string[8];


        for (int i = 0; i < tabInfo.Length; i++)
        {
            line = beatmapInfo.ReadLine();
            //Debug.Log(line);
            tabInfo[i] = line;
        }
        beatmapTitle = getStringInfo(tabInfo[0]);
        beatmapAuthor = getStringInfo(tabInfo[1]);
        beatmapJacketPath = getStringInfo(tabInfo[2]);
        difficulty = getStringInfo(tabInfo[3]);
        bpm = getIntInfo(tabInfo[4]);
        audioPath = getStringInfo(tabInfo[5]);
        volume = getIntInfo(tabInfo[6]);

        //-------------------//
        //---Beatmap level---//
        //-------------------//

        //StartCoroutine(InstantiateMap());

    }

    IEnumerator InstantiateMap()
    {
        //rightLaser.GetComponent<Laser>().initLaser(rightLaserShape, 16f);
        //leftLaser.GetComponent<Laser>().initLaser(leftLaserShape, 16f);

        for (int i = 0; i < bpm; i++)
        {
            getLaser(laserPos.RIGHT);
            getLaser(laserPos.LEFT);

            instanciateNote();
            //rightLaser.GetComponent<Laser>().instanciateLaser(1, 4.45f, 25.5f);
            //leftLaser.GetComponent<Laser>().instanciateLaser(2, -4.45f, 25.5f);

            //rightLaserList.Clear();
            //leftLaserList.Clear();

            for (int j = 0; j < row.Length; j++)
            {
                row[j].Clear();
            }
            yield return new WaitForSeconds((1.5f * 32) / note.GetComponent<Note>().speed);
        }
    }
    void instanciateNote()
    {
        GameObject cloneNote;// = new GameObject();
        GameObject longNote = note;

        for (int j = 0; j < row.Length; j++)
        {
            //Debug.Log("Instanciate map ! " + row[j].Count);
            //Debug.Log(row.Length);
            //Debug.Log(System.Linq.Enumerable.ElementAt(noteList, j));
            //Debug.Log(row[j][j]);
            //float posY = 72f - 25f;
            float posY = 20; //De base c'est a 0

            for (int k = 0; k <= row[j].Count - 1; k++)
            {
                //Debug.Log(k);
                count++;
                FLPos = new Vector3(-2.7f, posY, 0);
                LPos = new Vector3(-0.9f, posY, 0);
                RPos = new Vector3(0.9f, posY, 0);
                FRPos = new Vector3(2.7f, posY, 0);
                if (k > 0)
                {
                    GameObject cloneLongNote;
                    //Debug.Log("test : " + row[j][k] + " : " + row[j][k - 1]);
                    if (row[j][k] == 1 && row[j][k] == row[j][k - 1])
                    {
                        //Debug.Log(note.GetComponent<Renderer>().bounds.size.y);
                        //Debug.Log("Long scale");
                        note.tag = "longNote";
                        note.transform.localScale = new Vector3(note.transform.localScale.x, note.transform.localScale.y + 1.73f, note.transform.localScale.z);
                        //note.transform.localScale = new Vector3(note.transform.localScale.x, note.transform.localScale.y + 1, note.transform.localScale.z);
                    }
                    else
                    {
                        if (row[j][k] == 1)
                        {
                            switch (j)
                            {
                                case 0:
                                    cloneNote = Instantiate(note, FLPos, Quaternion.Euler(0, 0, 0));
                                    cloneNote.tag = "FLNote";
                                    break;
                                case 1:
                                    cloneNote = Instantiate(note, LPos, Quaternion.Euler(0, 0, 0));
                                    cloneNote.tag = "LNote";
                                    break;
                                case 2:
                                    cloneNote = Instantiate(note, RPos, Quaternion.Euler(0, 0, 0));
                                    cloneNote.tag = "RNote";
                                    break;
                                case 3:
                                    cloneNote = Instantiate(note, FRPos, Quaternion.Euler(0, 0, 0));
                                    cloneNote.tag = "FRNote";
                                    break;
                            }
                            
                            longNote.transform.localScale = new Vector3(note.transform.localScale.x, 1, note.transform.localScale.z);
                        }
                    }
                }
                else
                {
                    if (row[j][k] == 1)
                    {
                        switch (j)
                        {
                            case 0:
                                Instantiate(note, FLPos, Quaternion.Euler(0, 0, 0));
                                break;
                            case 1:
                                Instantiate(note, LPos, Quaternion.Euler(0, 0, 0));
                                break;
                            case 2:
                                Instantiate(note, RPos, Quaternion.Euler(0, 0, 0));
                                break;
                            case 3:
                                Instantiate(note, FRPos, Quaternion.Euler(0, 0, 0));
                                break;
                        }
                    }
                }
                //Debug.Log(row[j][k]);
                /*if (j == 0 && row[j][k] == 1)
                {
                    cloneNote = Instantiate(note, FLPos, Quaternion.Euler(0, 0, 0));
                    row[j].RemoveAt(k);
                }
                else if (j == 1 && row[j][k] == 1)
                {
                    cloneNote = Instantiate(note, LPos, Quaternion.Euler(0, 0, 0));
                    row[j].RemoveAt(k);
                }
                else if (j == 2 && row[j][k] == 1)
                {
                    cloneNote = Instantiate(note, RPos, Quaternion.Euler(0, 0, 0));
                    row[j].RemoveAt(k);
                }
                else if (j == 3 && row[j][k] == 1)
                {
                    cloneNote = Instantiate(note, FRPos, Quaternion.Euler(0, 0, 0));
                    row[j].RemoveAt(k);
                }
                else
                {
                    cloneNote = null;
                }
                Destroy(cloneNote, 5.0f);*/
                posY = posY + 1.5f;
            }
            //debugGrid();
        }
    }


    void instanciateLine()
    {
        GameObject cloneLine;
        for (int i = 0; i < 384; i++)
        {
            cloneLine = Instantiate(line, new Vector3(0, 24 * i, 0), Quaternion.Euler(0, 0, 0));
            cloneLine.transform.parent = groupLine.transform;
        }
    }

    string getStringInfo(string str)
    {
        return str.Substring(str.LastIndexOf('=') + 1);
    }

    int getIntInfo(string str)
    {
        return System.Int32.Parse(str.Substring(str.LastIndexOf('=') + 1));
    }

    //Allow to print a beat grid
    /*void debugGrid()
    {
        string result = "";

        for (int i = 0; i < grid.Length; i++)
        {
            result += "{";
            for (int j = 0; j < grid[i].Length; j++)
            {
                result += grid[i][j];
                if (j != grid[i].Length - 1)
                {
                    result += ", ";
                }
            }
            result += "}\n";
        }
    }*/

    void getNote()
    {
        string line;

        //row = new List<int>[4];
        //noteList = new List<char>();

        //Debug.Log(grid.Length);
        //Debug.Log(grid[0].Length);

        for (int i = 0; i < 5000; i++)
        {
            if (beatmapInfo != null)
            {
                //Debug.Log(i);

                line = beatmapInfo.ReadLine();
                if (line != "--" && line != null)
                {
                    row[0].Add(line.Substring(0, 1)[0] - '0');
                    row[1].Add(line.Substring(1, 2)[0] - '0');
                    row[2].Add(line.Substring(2, 3)[0] - '0');
                    row[3].Add(line.Substring(3, 4)[0] - '0');
                }
                else if (line == null)
                {
                    beatmapInfo.Close();
                    beatmapInfo = null;
                }
                else
                {
                    i = i - 1;
                }
            }
        }
        //Debug.Log("TEST : " + grid[0][32]);
    }

    /*void getNote()
    {
        string line;

        grid = new int[4][];
        for (int i = 0; i < 4; i++)
        {
            grid[i] = new int[16];
        }

        //Debug.Log(grid.Length);
        //Debug.Log(grid[0].Length);

        for (int i = 0; i < grid[0].Length; i++)
        {
            if (beatmapInfo != null)
            {
                line = beatmapInfo.ReadLine();
                if (line != "--" && line != null)
                {
                    grid[0][i] = line.Substring(0, 1)[0] - '0';
                    grid[1][i] = line.Substring(1, 2)[0] - '0';
                    grid[2][i] = line.Substring(2, 3)[0] - '0';
                    grid[3][i] = line.Substring(3, 4)[0] - '0';
                }
                else if (line == null)
                {
                    beatmapInfo.Close();
                    beatmapInfo = null;
                }
                else
                {
                    i = i - 1;
                }
            }
        }
    }*/

    void getLaser(laserPos pos)
    {


        /*if (beatmapLaser != null)
        {

           
                while (beatmapLaser.ReadLine() != null )
                {
                    string line = beatmapLaser.ReadLine();
                    if (line.Substring(line.Length - 2)[0] != '0' && line != "--")
                    {
                        leftLaserList.Add(line.Substring(line.Length - 2)[0]);
                    }
                    else
                    {
                        break;
                    }
                }

                while (line.Substring(line.Length - 1)[0] != '0')
                {
                    rightLaserList.Add(line.Substring(line.Length - 1)[0]);
                }
            }
            else if (line == null)
            {
                beatmapLaser.Close();
                beatmapLaser = null;
            }


            /*for (int i = 0; i < 32; i++)
            {
                string line = beatmapLaser.ReadLine();
                if (line != "--" && line != null)
                {
                    leftLaserList.Add(line.Substring(line.Length - 2)[0]);
                    rightLaserList.Add(line.Substring(line.Length - 1)[0]);
                    //Debug.Log("Laser : " + line.Substring(line.Length - 1)[0]);
                }
                else if (line == null)
                {
                    beatmapLaser.Close();
                    beatmapLaser = null;
                    break;
                }
                else
                {
                    i = i - 1;
                }
            }
        }*/
    }
}
