using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameLogic : MonoBehaviour
{
    /** 
        Die Beispiel Matrix unten hilt dem Programm sich zu orientieren, damit ObjectGruppen (Ketten) nicht mit dem Spielfeldrand kollidieren
        [1][ ]
        [ ][ ]
    **/
    public GameObject mainHitObject;
    public GameObject hitObject2;
    public GameObject hitObject3;
    public GameObject hitObject4;
    public GameObject hitObject5;

    public GameObject hitObject82;
    public GameObject hitObject83;
    public GameObject hitObject84;
    public GameObject hitObject85;
    public GameObject hitObject86;
    public GameObject hitObject87;
    public GameObject hitObject88;
    public GameObject hitObject89;

    public GameObject fireball0;
    public GameObject fireball1;
    public GameObject fireball2;
    public GameObject fireball3;
    public GameObject fireball4;
    public GameObject fireball5;

    public GameObject trap1;
    public GameObject trap2;
    public GameObject trap3;
    public GameObject trap4;
    public GameObject trap5;
    public GameObject trap6;
    public GameObject trap7;
    public GameObject trap8;
    public GameObject trap81;
    public GameObject trap82;

    public TextMeshProUGUI hitScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI loopText;

    // Levelzeit
    private float startTime = 0;

    // Zähler für Gruppen
    private int hitCounter = 0;

    // Zähler für Hits
    private int hitScore = 0;

    // Zähler für Highscore
    private int highScore = 0;

    // Aktuelles Level
    private int currentLevel = 1;

    // Inkrementiert den Wert um 1 nachdem ein Gruppenobject getroffen wurde
    private int hitFlag = 0;
    private int hitFlag8 = 0;

    // Koordinaten
    private int x = 0;
    private int y = 0;

    // Random Auswahl für Gruppenerstellung
    private float selectRandomGroup;

    // Loop Paramerter
    public float end;
    public float start;
    public float result;
    public int gameOverFlag = 1;

    // Prüft ob ein GameObject Kollidiert ist
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //loopGo();
        end = Time.time;
        result = end - start;
        start = end;

        if (result > 2 && gameOverFlag == 0)
        {
            Debug.Log("GameOver");
            gameOver();
        } else
        {
            //Debug.Log("Gute Runde!");
            gameOverFlag = 0;
        }

        // Generiert Zufallskoordinaten x y
        setRandomKoordinates();

        // Prüft ob ein Obstacle Object gertoffen wurde
        if (collisionInfo.collider.tag == "Obstacle")
        {
            safeScore();
            gameOver();
        }

        // Prüft ob das HitObject2 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "h2")
        {
            hitObject2.SetActive(false);
            refreshLineAndCircle();
        }

        // Prüft ob das HitObject3 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "h3")
        {
            hitObject3.SetActive(false);
            refreshLineAndCircle();
        }

        // Prüft ob das HitObject4 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "h4")
        {
            hitObject4.SetActive(false);
            refreshLineAndCircle();
        }

        // Prüft ob das HitObject5 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "h5")
        {
            hitObject5.SetActive(false);
            refreshLineAndCircle();
        }

        // Prüft ob das HitObject6 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "82")
        {
            hitObject82.SetActive(false);
            refreshGroup8();
        }

        // Prüft ob das HitObject6 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "83")
        {
            hitObject83.SetActive(false);
            refreshGroup8();
        }

        // Prüft ob das HitObject6 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "84")
        {
            hitObject84.SetActive(false);
            refreshGroup8();
        }

        // Prüft ob das HitObject6 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "85")
        {
            hitObject85.SetActive(false);
            refreshGroup8();
        }

        // Prüft ob das HitObject6 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "86")
        {
            hitObject86.SetActive(false);
            refreshGroup8();
        }

        // Prüft ob das HitObject7 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "87")
        {
            hitObject87.SetActive(false);
            refreshGroup8();
        }

        // Prüft ob das HitObject8 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "88")
        {
            hitObject88.SetActive(false);
            refreshGroup8();
        }

        // Prüft ob das HitObject9 der Gruppe getroffen wurde und inkrementiert das hitFlag
        if (collisionInfo.collider.tag == "89")
        {
            hitObject89.SetActive(false);
            refreshGroup8();
        }

        // Prüft ob alle Gruppen Hit Objecte getroffen wurden und setzt Flag wieder auf 0
        if (hitFlag == 4)
        {
            resetHitFlags();
            deactivateTrap1();
        }

        // Prüft ob alle Gruppen aus create8 getroffen wurde
        if (hitFlag8 == 8)
        {
            resetHitFlags();
            deactivateTraps8();
        }


        if (collisionInfo.collider.tag == "HitObjectBallon")
        {
            // Wenn hitCounter auf x ist, dann wird eine Gruppe von HitObjecten generiert
            if (hitCounter > 10)
            {
                // Deaktiviere alle Fallen
                deactivateTrap1();
                deactivateTraps8();
                deactivateTrap2And3();
                deactivateTrap4To8();

                // Initialisiere Parameter für aktuelle Runde
                setRandomKoordinates();
                setRandomGroup();

                // Haupt HitObject wird deaktiviert
                mainHitObject.SetActive(false);

                // Aktueller Bereich im Koordinatensystem
                // [1][ ]
                // [ ][ ]

                if (CheckCoordinatepace(x, y) == 1)
                {

                    if (selectRandomGroup == 1)
                    {
                        // Circle
                        setGroupActive();
                        createCircleUpLeft();
                        activateTrap1();
                    }
                    else if (selectRandomGroup == 2)
                    {
                        // Line
                        setGroupActive();
                        createLineGroupUpLeft();
                    } 
                    else
                    {
                        // 8er Gruppe
                        group8Go();
                    }
                }

                // Aktueller Bereich im Koordinatensystem
                // [ ][ ]
                // [2][ ]
                else if (CheckCoordinatepace(x, y) == 2)
                {
                    if (selectRandomGroup == 1)
                    {
                        // Circle
                        setGroupActive();
                        createCircleDownLeft();
                        activateTrap1();
                    }
                    else if(selectRandomGroup == 2)
                    {
                        // Line
                        setGroupActive();
                        createLineGroupDownLeft();
                    }
                    else
                    {
                        // 8er Gruppe
                        group8Go();
                    }
                }

                // Aktueller Bereich im Koordinatensystem
                // [ ][3]
                // [ ][ ]
                else if (CheckCoordinatepace(x, y) == 3)
                {
                    if (selectRandomGroup == 1)
                    {
                        // Circle
                        setGroupActive();
                        createCircleUpRight();
                        activateTrap1();
                    }
                    else if (selectRandomGroup == 2)
                    {
                        // Line
                        setGroupActive();
                        createLineGroupUpRight();
                    }
                    else
                    {
                        // 8er Gruppe
                        group8Go();
                    }
                }

                // Aktueller Bereich im Koordinatensystem
                // [ ][ ]
                // [ ][4]
                else if (CheckCoordinatepace(x, y) == 4)
                {
                    if (selectRandomGroup == 1)
                    {
                        // Circle
                        setGroupActive();
                        createCircleDownRight();
                        activateTrap1();
                    }
                    else if (selectRandomGroup == 2)
                    {
                        // Line
                        setGroupActive();
                        createLineGroupDownRight();
                    }
                    else
                    {
                        // 8er Gruppe
                        group8Go();
                    }
                }
                resetHitcounter();
            }
            else
            {
                // Einzelballon Szene wird hier erstellt
                createOneHitObjectRound();
            }
        }
    }



    // Prüft aktuelle Random x,y Koordinaten und teilt Koordinatenraum in 4 Bereiche
    // Gibt Koordinatenraum Position als int Wert wie folgt zurück
    // [1][3]
    // [2][4]
    int CheckCoordinatepace(int x, int y)
    {
        if (x < 0 && y > 0) // Oben links
        {
            return 1;

        }
        else if (x < 0 && y < 0) // Unten links
        {
            return 2;

        }
        else if (x > 0 && y > 0) // Oben rechts
        {
            return 3;
        }
        else //Unten rechts und falls x = 0 und y = 0
        {
            return 4;
        }
    }



    /// <Funktionen>
    /// Ab hier Modularisierte Funktionen
    /// <Funktionen>



    // Aktualisiert Line und Kreis Objecte
    public void refreshLineAndCircle()
    {
        hitFlag++;
        hitScore++;
        highScore += 10; 
        Debug.Log("Hitscore inkrementiert " + hitScore);
        hitScoreText.text = "" + hitScore;
        highScoreText.text = "" + highScore;
    }

    // Aktualisiert Group8 Objecte
    public void refreshGroup8()
    {
        hitFlag8++;
        hitScore++;
        highScore += 10;
        Debug.Log("Hitscore inkrementiert " + hitScore);
        hitScoreText.text = "" + hitScore;
        highScoreText.text = "" + highScore;
    }

    // Setzt HitFlags auf 0 und aktiviert MainObject
    public void resetHitFlags()
    {
        mainHitObject.SetActive(true);
        hitFlag = 0;
        hitFlag8 = 0;
    }

    // Aktiviert Fallen aus Gruppe 8
    public void activateTraps8()
    {
        trap81.SetActive(true);
        trap82.SetActive(true);
    }

    // Deaktiviert Fallen aus Gruppe 8
    public void deactivateTraps8()
    {
        trap81.SetActive(false);
        trap82.SetActive(false);
    }

    // Deaktiviert Fallen 2 und 3
    public void deactivateTrap2And3()
    {
        trap2.SetActive(false);
        trap3.SetActive(false);
    }
    // Aktiviert Fallen 2 und 3
    public void activateTrap2And3()
    {
        trap2.SetActive(true);
        trap3.SetActive(true);
    }

    // Deaktiviert Fallen 4 bis 8
    public void deactivateTrap4To8()
    {
        trap4.SetActive(false);
        trap5.SetActive(false);
        trap6.SetActive(false);
        trap7.SetActive(false);
        trap8.SetActive(false);
    }
    // Aktiviert Fallen 4 bis 8
    public void activateTrap4To8()
    {
        trap4.SetActive(true);
        trap5.SetActive(true);
        trap6.SetActive(true);
        trap7.SetActive(true);
        trap8.SetActive(true);
    }

    // Aktiviert Falle 1
    public void activateTrap1()
    {
        trap1.SetActive(true);
    }

    // Deaktiviert Falle 1
    public void deactivateTrap1()
    {
        trap1.SetActive(false);
    }
    // Setzt HitCounter auf 0
    public void resetHitcounter()
    {
        hitCounter = 0;
    }

    // Generiert Gruppe 8
    public void group8Go()
    {
        activateGroup8();
        activateTraps8();
        createGroup8();
    }

    // Safe the hitScore
    public void safeScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    // Berechnet die daure eines Loops falls result > 2 = Game Over else Spiel geht weiter
    public void loopGo()
    { 
        end = Time.time;
        result = end - start;
        start = end;
    }

    // Generiert Zufallskoordinaten x y
    void setRandomKoordinates()
    {
        x = Random.Range(-6, 6);
        y = Random.Range(-3, 3);
    }

    // Random Parameter zwischen 1 und exkl 4 für auswahl der Gruppe
    void setRandomGroup()
    {
        selectRandomGroup = Random.Range(1, 4);
    }

    // Prüft ob HitObject auf Obstical spawnt wenn ja dann verschiebt Ballon um 1
    // Ab hitscore > 10 && < 20 wird y Achse geprüft
    // ab hitscore < 10 wird nur x Achse geprüft
    // Ab hitscore > 20 wird y und x Achse geprüft
    void spawnCollisionsControll()
    {
        if (hitScore < 10)
        {
            if (x == 0)
            {
                x = -1;
            }
        }
        else if (hitScore >= 12 && hitScore < 22)
        {
            if (y == 0)
            {
                y = -1;
            }
        }
        else if (hitScore >= 22 && hitScore < 40)
        {
            if (y == -3 || y == 3)
            {
                y = -1;
            }

        } 
        else
        {
        if (x == -2 || x == 2)
            {
                x += 1;
            }
        }
    }

    // Einzelballon Szene wird hier erstellt
    void createOneHitObjectRound()
    {
        // Einzelballon Szene wird hier erstellt
        // Prüft ob HitObject auf Obstical spawnt
        spawnCollisionsControll();

        // HitObject und Obsticals werden erzeugt
        mainHitObject.transform.position = new Vector2(x, y);
        createObsticalLine();
        activateTrap1();
        activateTraps8();
        activateTrap2And3();
        activateTrap4To8();

        // Parameter werden aktualisiert
        hitCounter++;
        hitScore++;
        highScore += 10;
        hitScoreText.text = "" + hitScore;
        highScoreText.text = "" + highScore;
    }

    // Führt GameOver aus und setzt gameOverFlag auf 1 damit erste Runde frei ist
    void gameOver()
    {
        gameOverFlag = 1;
        SceneManager.LoadScene("ResultsMenu");
    }

    // Aktiviert alle Gruppe8 Objecte
    void activateGroup8()
    {
        hitObject82.SetActive(true);
        hitObject83.SetActive(true);
        hitObject84.SetActive(true);
        hitObject85.SetActive(true);
        hitObject86.SetActive(true);
        hitObject87.SetActive(true);
        hitObject88.SetActive(true);
        hitObject89.SetActive(true);
    }

    // Aktiviert alle Line und Circle Group Objecte
    void setGroupActive()
    {
        hitObject2.SetActive(true);
        hitObject3.SetActive(true);
        hitObject4.SetActive(true);
        hitObject5.SetActive(true);
    }


    /// </Funktionen>
    /// Ende Modularisierte Funktionen


    void Awake()
    {

    }

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;
        string seconds = (t % 60).ToString("f1");
        timerText.text = "" + seconds;

        if (hitScore > 22.0F)
        {
            fireball0.transform.Translate(Vector3.right * Time.deltaTime * 4, Camera.main.transform);
        }

        if (hitScore > 40.0F)
        {
            fireball1.transform.Translate(Vector3.right * Time.deltaTime * 4, Camera.main.transform);
            fireball2.transform.Translate(Vector3.right * Time.deltaTime * 4, Camera.main.transform);
        }
        if (hitScore > 55.0F)
        {
            fireball3.transform.Translate(Vector3.right * Time.deltaTime * 4, Camera.main.transform);
            fireball4.transform.Translate(Vector3.right * Time.deltaTime * 4, Camera.main.transform);
            fireball5.transform.Translate(Vector3.right * Time.deltaTime * 4, Camera.main.transform);
        }

        levelText.text = currentLevel.ToString();
        //loopText.text = result.ToString();
    }



    // Erstellt Line aus 4 HitObjecten für den Bereich
    // [x][ ]
    // [ ][ ]
    void createLineGroupUpLeft()
    {
        hitObject2.transform.position = new Vector2(x + 1, y - 1);
        hitObject3.transform.position = new Vector2(x + 2, y - 2);
        hitObject4.transform.position = new Vector2(x + 3, y - 3);
        hitObject5.transform.position = new Vector2(x, y);
        Debug.Log("Line");
    }

    // Erstellt Line aus 4 HitObjecten für den Bereich
    // [ ][ ]
    // [x][ ]
    void createLineGroupDownLeft()
    {
        hitObject2.transform.position = new Vector2(x + 1, y + 1);
        hitObject3.transform.position = new Vector2(x + 2, y + 2);
        hitObject4.transform.position = new Vector2(x + 3, y + 3);
        hitObject5.transform.position = new Vector2(x, y);
        Debug.Log("Line");
    }

    // Erstellt Line aus 4 HitObjecten für den Bereich
    // [ ][x]
    // [ ][ ]
    void createLineGroupUpRight()
    {
        hitObject2.transform.position = new Vector2(x - 1, y - 1);
        hitObject3.transform.position = new Vector2(x - 2, y - 2);
        hitObject4.transform.position = new Vector2(x - 3, y - 3);
        hitObject5.transform.position = new Vector2(x, y);
        Debug.Log("Line");
    }

    // Erstellt Line aus 4 HitObjecten für den Bereich
    // [ ][ ]
    // [ ][x]
    void createLineGroupDownRight()
    {
        hitObject2.transform.position = new Vector2(x - 1, y + 1);
        hitObject3.transform.position = new Vector2(x - 2, y + 2);
        hitObject4.transform.position = new Vector2(x - 3, y + 3);
        hitObject5.transform.position = new Vector2(x, y);
        Debug.Log("Line");
    }

    // Erstellt die 8
    void createGroup8()
    {
        int xx = Random.Range(-6, -1); 
        int yy = Random.Range(3, -3); ;
        hitObject82.transform.position = new Vector2(xx + 2, yy);
        hitObject83.transform.position = new Vector2(xx + 2, yy - 2);
        hitObject84.transform.position = new Vector2(xx, yy - 2);
        hitObject85.transform.position = new Vector2(xx, yy);
        trap81.transform.position = new Vector2(xx + 1, yy - 1);

        hitObject86.transform.position = new Vector2(xx + 6, yy);
        hitObject87.transform.position = new Vector2(xx + 6, yy - 2);
        hitObject88.transform.position = new Vector2(xx + 4, yy);
        hitObject89.transform.position = new Vector2(xx + 4, yy - 2);
        trap82.transform.position = new Vector2(xx + 5, yy - 1);
        Debug.Log("Group 8");
    }

    // Erstellt Circle
    void createCircleUpLeft()
    {
        hitObject2.transform.position = new Vector2(x + 2, y);
        hitObject3.transform.position = new Vector2(x + 2, y - 2);
        hitObject4.transform.position = new Vector2(x, y - 2);
        hitObject5.transform.position = new Vector2(x, y);
        trap1.transform.position = new Vector2(x + 1, y - 1);
        Debug.Log("Circle");

    }

    void createCircleDownLeft()
    {
        hitObject2.transform.position = new Vector2(x, y + 2);
        hitObject3.transform.position = new Vector2(x + 2, y + 2);
        hitObject4.transform.position = new Vector2(x + 2, y);
        hitObject5.transform.position = new Vector2(x, y);
        trap1.transform.position = new Vector2(x + 1, y + 1);
        Debug.Log("Circle");

    }

    void createCircleUpRight()
    {
        hitObject2.transform.position = new Vector2(x, y - 2);
        hitObject3.transform.position = new Vector2(x - 2, y - 2);
        hitObject4.transform.position = new Vector2(x - 2, y);
        hitObject5.transform.position = new Vector2(x, y);
        trap1.transform.position = new Vector2(x - 1, y - 1);
        Debug.Log("Circle");

    }

    void createCircleDownRight()
    {
        hitObject2.transform.position = new Vector2(x - 2, y);
        hitObject3.transform.position = new Vector2(x - 2, y + 2);
        hitObject4.transform.position = new Vector2(x, y + 2);
        hitObject5.transform.position = new Vector2(x, y);
        trap1.transform.position = new Vector2(x - 1, y + 1);
        Debug.Log("Circle");

    }

    void createObsticalLine()
    {
        if(hitScore > 5 && hitScore < 10)
        {
            trap1.transform.position = new Vector2(0, 3);
            trap81.transform.position = new Vector2(0, 0);
            trap82.transform.position = new Vector2(0, -3);
        } 
        else if(hitScore >= 12 && hitScore < 22)
        {
            trap1.transform.position = new Vector2(6, 0);
            trap2.transform.position = new Vector2(3, 0);
            trap3.transform.position = new Vector2(0, 0);
            trap81.transform.position = new Vector2(-3, 0);
            trap82.transform.position = new Vector2(-6, 0);
            currentLevel = 2;
        }
        else if(hitScore >= 22 && hitScore < 40)
        {
            trap1.transform.position = new Vector2(6, 3);
            trap2.transform.position = new Vector2(3, 3);
            trap3.transform.position = new Vector2(0, 3);
            trap81.transform.position = new Vector2(-3, 3);
            trap82.transform.position = new Vector2(-6, 3);

            trap4.transform.position = new Vector2(6, -3);
            trap5.transform.position = new Vector2(3, -3);
            trap6.transform.position = new Vector2(0, -3);
            trap7.transform.position = new Vector2(-6, -3);
            trap8.transform.position = new Vector2(-3, -3);
            currentLevel = 3;
        }
        else if(hitScore >= 40)
        {
            trap1.transform.position = new Vector2(-2, 4);
            trap2.transform.position = new Vector2(-2, 3);
            trap3.transform.position = new Vector2(-2, 2);
            trap81.transform.position = new Vector2(-2, 1);
            trap82.transform.position = new Vector2(-2, 0);

            trap4.transform.position = new Vector2(2, -4);
            trap5.transform.position = new Vector2(2, -2);
            trap6.transform.position = new Vector2(2, -1);
            trap7.transform.position = new Vector2(2, -0);
            trap8.transform.position = new Vector2(2, -3);
            currentLevel = 4;
        }
    }

}




