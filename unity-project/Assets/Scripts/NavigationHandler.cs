using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NavigationHandler : MonoBehaviour
{
    
    
    public enum Direction
    {
        North,
        South,
        East,
        West,
        None
    }

    // The array of the grid
    // Up is NORTH, left is WEST etc.
    private string[,,] grid = new string[,,]
    {
        {
            { "Jacqueline has died", "E" },
            { "Jacqueline has measles", "WSE" },
            { "Bad water", "WSE" },
            { "Chimney Rock", "WSE" },
            { "Hijo has died", "W" }
        },
        {
            { "The Dalles", "SE" },
            { "The Ox Skull", "NWS" },
            { "Independence", "SNE" },
            { "The Broken Wheel", "NSEW" },
            { "Inadequate grass", "WS" }
        },
        {
            { "The Arrow", "NS" },
            { "Severe blizzard", "NS" },
            { "The party", "N" },
            { "Hail storm", "NES" },
            { "The river", "NWS" }
        },
        {
            { "The Raft", "NS" },
            { "The Rifle", "NE" },
            { "Blue Mountains", "WSE" },
            { "The Snake", "NSEW" },
            { "Jane has dysentery", "NWS" }
        },
        {
            { "The Tombstone", "N" },
            { "Lose trail", "E" },
            { "Rough trail", "WN" },
            { "Shelley died", "N" },
            { "Jane died", "N" }
        }
    };



    public ContemplationHandler contemplationHandler;
    public Camera cam;
    public GameObject camPivot;
    public AudioSource navWind;
    public float rotationSpeed = 25f;
    public float moveSpeed = 10f;
    public float navigationFadeTime = 2.0f;
    public float directionThreshold = 0.995f;

    public GameObject currentLocation;
    public GameObject currentArtifact;
    public GameObject currentConstellation;

    private Direction facing = Direction.None;
    private GameObject facingObject;
    private GameObject currentNavObject = null;
    private GameObject lastNavObject = null;
    public bool inputEnabled = true;
    private Vector2 currentIndex = new Vector2(0, 1);

    private float MAX_IDLE_TIME = 60 * 5;
    private float idleTime = 0;

    void Start()
    {
        idleTime = 0;

        Input.ResetInputAxes();

        contemplationHandler.ChangedLocation(currentLocation);
//        Debug.Log(currentLocation.name);
        SetCurrentIndex(currentLocation.name);
//        currentArtifact = currentLocation.transform.FindChild("Artifact").gameObject;
//        currentConstellation = GameObject.Find(currentLocation.name + " Constellation");

//        Debug.Log(currentIndex);

//        Debug.Log("0,1 in the grid is " + grid [0, 1] + ", 1,0 in the grid is " + grid [1, 0]);
    }

    void Update()
    {
        idleTime += Time.deltaTime;
        if (idleTime >= MAX_IDLE_TIME)
        {
            SceneManager.LoadScene("Title");
        }

        HandleNavigationDirection();
        HandleCameraRotation();
        HandleNavigationInput();
    }

    void HandleNavigationDirection()
    {
        var camForward = cam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        facing = Direction.None;

        if (camForward.z > directionThreshold)
            facing = Direction.North;
        else if (camForward.z < -directionThreshold)
            facing = Direction.South;
        else if (camForward.x > directionThreshold)
            facing = Direction.East;
        else if (camForward.x < -directionThreshold)
            facing = Direction.West;
        else
            facing = Direction.None;

//        Debug.Log(facing);

        facingObject = GetObjectByDirection(facing);

//        Debug.Log(facingObject);
//        Debug.Log("Facing: " + facing + ", Object: " + (facingObject ? facingObject.name : "Nothing") + ", Current: " + currentLocation.name + ", Current Index: " + currentIndex);


        if (facingObject)
        {
            if (facingObject.GetComponent<NavigationFader>().fadeState == "out")
            {
                contemplationHandler.ShowContemplationLight(facingObject, true);

//                Debug.Log("Facing " + facing + ". Fading in navLine and " + facingObject.name);

                currentNavObject = facingObject;

                GameObject navLine = GameObject.Find("Navigation Line");
                Vector3 facingObjectPos = facingObject.transform.position;
                Vector3 navPos = navLine.transform.position;
                Vector3 currentPos = currentLocation.transform.position;

                if (facing == Direction.West || facing == Direction.East)
                {
                    navLine.transform.rotation = Quaternion.Euler(0, 90, 0);
                    navLine.transform.position = new Vector3(currentPos.x + (facingObjectPos.x - currentPos.x) / 2, navPos.y, currentPos.z);
                }
                else
                {
                    navLine.transform.rotation = Quaternion.Euler(0, 0, 0);
                    navLine.transform.position = new Vector3(currentPos.x, navPos.y, currentPos.z + (facingObjectPos.z - currentPos.z) / 2);
                }

                facingObject.GetComponent<NavigationFader>().FadeIn(navigationFadeTime);
                navLine.GetComponent<NavigationFader>().FadeIn(navigationFadeTime);
            }
        }
        else if (currentNavObject)
        {
            if (currentNavObject.GetComponent<NavigationFader>().fadeState == "in")
            {
//                Debug.Log("Facing " + facing + ". Fading out navLine and " + currentNavObject.name);

                currentNavObject.GetComponent<NavigationFader>().FadeOut(navigationFadeTime);
                GameObject navLine = GameObject.Find("Navigation Line");
                navLine.GetComponent<NavigationFader>().FadeOut(navigationFadeTime);

                currentNavObject = null;
            }
        }
        if (lastNavObject)
        {
            if (lastNavObject.GetComponent<NavigationFader>().fadeState == "in")
            {
//                Debug.Log("Facing " + facing + ". Fading out " + lastNavObject.name);

                lastNavObject.GetComponent<NavigationFader>().FadeOut(navigationFadeTime);
                GameObject navLine = GameObject.Find("Navigation Line");
                if (!currentNavObject)
                    navLine.GetComponent<NavigationFader>().FadeOut(navigationFadeTime);

                lastNavObject = null;
            }
        }
    }

    void HandleNavigationInput()
    {
        if (!inputEnabled)
            return;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Jump"))
//        if (Input.GetKeyDown(KeyCode.W))
        {
            idleTime = 0;

            if (facingObject)
            {
                StartCoroutine("MoveCamPivotTo", facingObject);
            }
        }
    }

    IEnumerator MoveCamPivotTo(GameObject dest)
    {
//        Debug.Log("MoveCamPivotTo(" + dest.name + ")");
        Vector3 target = dest.transform.position;

        inputEnabled = false;

        navWind.volume = 0f;
        navWind.Play();

        while (camPivot.transform.position.x != target.x || camPivot.transform.position.z != target.z)
        {
            if (navWind.volume < 0.4f)
                navWind.volume += 0.05f;
            float step = moveSpeed * Time.deltaTime;
            camPivot.transform.position = Vector3.MoveTowards(camPivot.transform.position, target, step);
            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine("FadeOutNavWind");

        currentNavObject = null;
        lastNavObject = currentLocation;
        currentLocation = dest;
        currentIndex = GetIndexByObject(currentLocation);
        inputEnabled = true;
        contemplationHandler.ChangedLocation(currentLocation);

        Transform t = currentLocation.transform.FindChild("Artifact");
        currentArtifact = t ? t.gameObject : null;
        currentConstellation = GameObject.Find(currentLocation.name + " Constellation");

//        Debug.Log("Moved pivot to " + currentLocation.name + ", with lastNavObject of " + lastNavObject.name);
    }

    IEnumerator FadeOutNavWind()
    {
        while (navWind.volume > 0)
        {
            navWind.volume -= 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
        navWind.Stop();
    }

    void HandleCameraRotation()
    {
        if (!inputEnabled)
            return;


        Debug.Log(Input.GetAxis("Horizontal"));
        Debug.Log(Input.GetAxisRaw("Horizontal"));

//        if (Input.GetKey(KeyCode.LeftArrow))
        if (Input.GetAxis("Horizontal") < -0.5f || Input.GetKey(KeyCode.LeftArrow))
//        if (Input.GetAxis("Joy1X") < 0)
        {
            idleTime = 0;
            camPivot.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
//        else if (Input.GetKey(KeyCode.RightArrow))
        else if (Input.GetAxis("Horizontal") > 0.5f || Input.GetKey(KeyCode.RightArrow))
        {
            idleTime = 0;
            camPivot.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

//        if (Input.GetKey(KeyCode.UpArrow))
        if (Input.GetAxis("Vertical") < -0.5f)// || Input.GetKey(KeyCode.UpArrow))
        {
            idleTime = 0;
            cam.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
//            camPivot.transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
        }
//        else if (Input.GetKey(KeyCode.DownArrow))
        else if (Input.GetAxis("Vertical") > 0.5f)// || Input.GetKey(KeyCode.DownArrow))
        {
            idleTime = 0;
            cam.transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
//            camPivot.transform.Rotate(0,0,-rotationSpeed * Time.deltaTime, 0,);
        }
    }

    bool SetCurrentIndex(string location)
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                if (grid [y, x, 0] == location)
                {
                    currentIndex.x = x;
                    currentIndex.y = y;
                    return true;
                }
            }
        }
        return false;
    }

    Vector2 GetIndexByObject(GameObject o)
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                if (grid [y, x, 0] == o.name)
                {
                    return new Vector2(x, y);
                }
            }
        }

        return new Vector2(-1, -1);
    }

    Direction GetOppositeDirection(Direction dir)
    {
        if (dir == Direction.North)
            return Direction.South;
        if (dir == Direction.South)
            return Direction.North;
        if (dir == Direction.West)
            return Direction.East;
        if (dir == Direction.East)
            return Direction.West;

        return Direction.None;
    }

    GameObject GetObjectByDirection(Direction dir)
    {

        Vector2 index = new Vector2(-1, -1);

        switch (dir)
        {
            case Direction.North:

                if (grid [(int)currentIndex.y, (int)currentIndex.x, 1].IndexOf("N") == -1)
                    break;

                index.y = currentIndex.y - 1;
                index.x = currentIndex.x;

                break;

            case Direction.South:

                if (grid [(int)currentIndex.y, (int)currentIndex.x, 1].IndexOf("S") == -1)
                    break;

                index.y = currentIndex.y + 1;
                index.x = currentIndex.x;

                break;


            case Direction.East:
                if (grid [(int)currentIndex.y, (int)currentIndex.x, 1].IndexOf("E") == -1)
                    break;

                index.x = currentIndex.x + 1;
                index.y = currentIndex.y;

                break;


            case Direction.West:
                if (grid [(int)currentIndex.y, (int)currentIndex.x, 1].IndexOf("W") == -1)
                    break;

                index.x = currentIndex.x - 1;
                index.y = currentIndex.y;

                break;


            case Direction.None:
                
                break;
        }

        if (index.x == -1 || index.y == -1)
            return null;

        GameObject returnValue = GameObject.Find(grid [(int)index.y, (int)index.x, 0]);
        return returnValue;
    }
}
