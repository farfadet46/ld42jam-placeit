using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class PickUpObject : MonoBehaviour
{
    
    int score;
    GameObject VisedObject;

    [Header("--- Physique ---")]
    public float distance = 2.5f;

    [Header("--- delayer ---")]
    public TMP_Text TextFIN;
    public float delayerBeforeExit = 60f;
    
    bool decompte = false;
    float timerr;


    [Header("--- Chronometre ---")]
    //timing
    public TMP_Text TimerText;
    [Tooltip("En secondes")]
    public float DureeJeu = 100;
    public bool ChronoActive = false;
    float EnCours;

    private void Start()
    {
        ChronoActive = true;
        EnCours = DureeJeu;
        TextFIN.text = "";

        score = PlayerPrefs.GetInt("score");
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward, Color.red); //rayon de debug par rapport a la cam.
        RaycastHit hit;

        // Chronometre du jeu
        if (ChronoActive)
        {
            if (EnCours > 1)
            {
                EnCours -= Time.deltaTime;
                TimerText.text = Mathf.Round(EnCours).ToString();

                // Selection du siege
                if (Physics.Raycast(transform.position, (forward), out hit))
                {
                    if (hit.distance <= distance)
                    {
                        if (hit.collider.GetComponent<Outline_delayer>()) //s'il dispose du script outline ;
                        {
                            hit.collider.GetComponent<Outline_delayer>().Activate(); //on l'active
                        }
                        if (Input.GetButtonUp("Fire1"))//si on clique
                        {
                            this.GetComponent<FirstPersonController>().enabled = false; //empecher le joueur de bouger (et d'aller cliquer sur un autre) ;)
                            ChronoActive = false; //desactive le chrono

                            timerr = delayerBeforeExit; //determinier la durée d'attente
                            decompte = true; //activer le décompte avant de quitter

                            if (hit.collider.gameObject.tag == "SiegeVide") //si ce collider a un tag siege vide
                            {
                                // Debug.Log("GAGNE !");
                                TextFIN.text = "OK, next !";
                                ScoreIng(1);
                                new WaitForSeconds(3);
                                SceneManager.LoadScene(1);
                            }
                            else
                            {
                                // Debug.Log("PERDU !");
                                TextFIN.text = "Seriously ?";
                                ScoreIng(0);
                            }
                        }
                    }
                }
            }
            else //fin du temps imparti
            {

                this.GetComponent<FirstPersonController>().enabled = false;
                ChronoActive = false;

                TextFIN.text = "Seriously ? no time left ?";
                ScoreIng(0);
                timerr = delayerBeforeExit;
                decompte = true; //pour attendre la map "menu"
            }
        }

        //décompte avant de changer de scene :
        if (decompte)
        {
            if (timerr > 0)
            {
                timerr--;
            }
            else
            { 
                SceneManager.LoadScene("menu");
            }
        }
    }

    void ScoreIng(int valeur)
    {
        PlayerPrefs.SetInt("score", score + valeur);
        //Debug.Log( PlayerPrefs.GetInt("score") );
    }

}