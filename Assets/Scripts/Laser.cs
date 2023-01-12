using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.U2D;

public class Laser : MonoBehaviour
{
    private GameObject container;
    private GameObject laser;
    private SpriteShape laserSpriteShape;
    private SpriteShapeController laserShapeController;
    private List<char> laserList;
    private string gamePath;
    private StreamReader beatmapLaser;
    private string beatmapPath;

    //public SpriteShape laserShape;
    //Sprite laserSprite;
    private void Awake()
    {
        //container = new GameObject("laserContainer");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void initLaser(SpriteShape laserShape, float speed = 27f)
    {
        laser = new GameObject("laser");
        laserSpriteShape = laserShape;
        laser.layer = LayerMask.NameToLayer("Lines");

        laser.transform.position = new Vector3(1000f, 0f, 1000f);
        laser.AddComponent<SpriteShapeRenderer>();
        laser.GetComponent<SpriteShapeRenderer>().sortingOrder = 1;
        laser.AddComponent<SpriteShapeController>();
        laser.GetComponent<SpriteShapeController>().spriteShape = laserSpriteShape;
        laserShapeController = laser.GetComponent<SpriteShapeController>();
        /*laser.AddComponent<Rigidbody>();
        laser.GetComponent<Rigidbody>().mass = 1;
        laser.GetComponent<Rigidbody>().angularDrag = 0.05f;
        laser.GetComponent<Rigidbody>().useGravity = false;*/

        //laser.AddComponent<BoxCollider>();
        //laser.GetComponent<BoxCollider>().size = new Vector3(1, 1f, 0);
        laser.AddComponent<Rigidbody2D>();
        laser.GetComponent<Rigidbody2D>().mass = 1;
        laser.GetComponent<Rigidbody2D>().angularDrag = 0.05f;
        laser.GetComponent<Rigidbody2D>().gravityScale = 0f;
        laser.AddComponent<Note>();
        laser.GetComponent<Note>().speed = speed;
        laser.AddComponent<EdgeCollider2D>();
        laser.GetComponent<EdgeCollider2D>().edgeRadius = 0.20f;
        laser.GetComponent<EdgeCollider2D>().isTrigger = true;
        //laser.transform.IsChildOf(container.transform);
        //laser.transform.parent = container.transform;
        //Debug.Log(tab[0]);

        gamePath = Application.dataPath; //Get the current project path
        beatmapPath = gamePath + "/Audio/Sports Theme-Wii.pe";
        beatmapLaser = new StreamReader(beatmapPath);
        for (int i = 0; i < 9; i++)
        {
            beatmapLaser.ReadLine();
        }
    }


    public void instanciateLaser(int nLaser, float spawnPosX, float spawnPosY, int renderQuality = 16)
    {
        int count = 0;
        string line = beatmapLaser.ReadLine();
        //laserList = list;


        float y = spawnPosY;
        float RLPosX = 0f; //Right Laser position x
        float RLPosY = 0f; //Right Laser position y

        laserShapeController.splineDetail = renderQuality; //High quality
        laserShapeController.enableTangents = true;
        Vector3 laserPos = new Vector3(spawnPosX, spawnPosY, 0);

        laserShapeController.spline.Clear(); //Erase last laser point

        Spline spline;
        spline = laserShapeController.spline;
        spline.isOpenEnded = true;

        for (int i = 0; i < 1000; i++)
        {
            laserShapeController.spline.Clear();
            laserShapeController.splineDetail = renderQuality; //High quality
            laserShapeController.enableTangents = true;
            do
            {
                count++;
                if (count % 8 == 0)
                {
                    line = beatmapLaser.ReadLine();
                }
                line = beatmapLaser.ReadLine();
                spline.InsertPointAt(spline.GetPointCount(), new Vector3(RLPosX, RLPosY, 0));
                //Debug.Log(spline.GetPointCount());
                spline.SetTangentMode(spline.GetPointCount() - 1, ShapeTangentMode.Continuous);
                spline.SetHeight(spline.GetPointCount() - 1, 1.0f);
                if (line.Substring(line.Length - nLaser)[0] == '3') // Turn right
                {
                    RLPosX++;
                    RLPosY += 1.5f;
                }
                else if (line.Substring(line.Length - nLaser)[0] == '1') // straight ahead
                {
                    RLPosY += 1.5f;
                }
                else if (line.Substring(line.Length - nLaser)[0] == '2') // Turn left
                {
                    RLPosX--;
                    RLPosY += 1.5f;
                }
                else if (line.Substring(line.Length - nLaser)[0] == '4') // Go to the right end
                {
                    RLPosX = -9;
                }
                else if (line.Substring(line.Length - nLaser)[0] == '5') // Go to the right end
                {
                    RLPosX = 0;
                }
                else if (line.Substring(line.Length - nLaser)[0] == '0')
                {
                    laserPos.y += 1.5f;
                    break;
                }
                //laserList.RemoveAt(j);

            } while (line.Substring((line.Length - nLaser))[0] != '0');

            if (spline.GetPointCount() != 0 && spline.GetPointCount() != 1)
            {
                //Instantiate(rightLaserShapeController, laserPos, Quaternion.Euler(45f, 0, 45f));
                GameObject cloneLaser = Instantiate(laser, laserPos, Quaternion.Euler(0, 0, 0));
                //Destroy(cloneLaser, 5.0f);
                //System.Array.Clear(laserList, 0, laserList.Count); //clear array
            }
        }



        /*for (int j = 0; j < laserList.Count; j++)
        {
            spline.InsertPointAt(spline.GetPointCount(), new Vector3(RLPosX, RLPosY, 0));
            spline.SetTangentMode(spline.GetPointCount() - 1, ShapeTangentMode.Continuous);
            spline.SetHeight(spline.GetPointCount() - 1, 1.0f);
            Debug.Log(spline.GetPointCount());
            if (laserList[j] == '3') // Turn right
            {
                RLPosX++;
                RLPosY += 1.5f;
            }
            else if (laserList[j] == '1') // straight ahead
            {
                RLPosY += 1.5f;
            }
            else if (laserList[j] == '2') // Turn left
            {
                RLPosX--;
                RLPosY += 1.5f;
            }
            else if (laserList[j] == '4') // Go to the right end
            {
                // the difference between posX and posY must be 8 so that the laser is at the right end
                RLPosX = -9;
            }
            else if (laserList[j] == '0')
            {
                break;
            }
            //laserList.RemoveAt(j);
        }

        if (spline.GetPointCount() != 0)
        {
            //Instantiate(rightLaserShapeController, laserPos, Quaternion.Euler(45f, 0, 45f));
            GameObject cloneLaser = Instantiate(laser, laserPos, Quaternion.Euler(0, 0, 0));
            Destroy(cloneLaser, 5.0f);
            //System.Array.Clear(laserList, 0, laserList.Count); //clear array
        }*/


    }

    public bool checkIfLaserExist()
    {
        for (int i = 0; i < laserList.Count; i++)
        {
            if (char.IsDigit(laserList[i]))
            {
                //Debug.Log("TAB : " + laserTab[i]);
                return true;
            }
        }
        return false;
    }
}
