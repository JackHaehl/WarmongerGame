using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public List<Scenario> scenarios;
    public static List<Team> team;
    public List<Team> teams;
    public List<Territory> territories;
    private Scenario currentScenario;
    public static float wealth = 2000;
    int newScenario;
    int newTeam;
    public static int warTide = 0;
    public GameObject territoriesText;
    public GameObject scenarioText;
    public GameObject choiceText1;
    public GameObject choiceText2;
    public GameObject stats;
    string territoryString;
    int months = 0;
    bool loss = false;

    // Start is called before the first frame update
    void Awake()
    {
        team = teams;
        for (int i = 0; i < territories.Count; i++)
        {
            territories[i].activeTeam = teams[0];
            territories[i].evaluateControl();
        }

        NewScenario();

    }

    // Update is called once per frame
    void Update()
    {
       // NewScenario();
    }

    void NewScenario()
    {
        checkLoss();
        months++;
        newScenario = Random.Range(0, scenarios.Count);
        currentScenario = scenarios[newScenario];
        newTeam = Random.Range(0, team.Count);
        currentScenario.setupScenario(team[newTeam],team[Mathf.Abs(newTeam-1)],territories[Random.Range(0,territories.Count)]);
        Debug.Log(currentScenario.displayText());

        for(int i = 0; i < currentScenario.choices.Count; i++)
        {
            Debug.Log(currentScenario.choices[i].displayText());
        }
        Debug.Log("----------------------------------------------------");

        territoriesText.GetComponent<TextMeshProUGUI>().text = "";
        scenarioText.GetComponent<TextMeshProUGUI>().text = currentScenario.displayText();
        choiceText1.GetComponent<TextMeshProUGUI>().text = currentScenario.choices[0].displayText();
        choiceText2.GetComponent<TextMeshProUGUI>().text = currentScenario.choices[1].displayText();
        territoryString = "";
        for(int i = 0; i < territories.Count; i++)
        {
           // territories[i].evaluateControl();
            territoryString += territories[i].displayText();
        }
        territoriesText.GetComponent<TextMeshProUGUI>().text = territoryString;
        if (!loss)
        {
            stats.GetComponent<TextMeshProUGUI>().text = (
    "The stalemate timer is " + warTide + " of 5 \n" +
    "Your Wealth: " + wealth + "\n" +
    "Current Month: " + months + "\n"

            );
        }
        else
        {
            stats.GetComponent<TextMeshProUGUI>().text += "YOU HAVE LOST, RIP";
        }
    }

    private void checkLoss()
    {
        if(wealth < 0)
        {
            loss = true;
        }
        if(warTide >= 5)
        {
            loss = true;
        }


        int pacific = 0;
        int confederate = 0;
        for (int i = 0; i < territories.Count; i++)
        {
            if (territories[i].activeTeam.name == "The Pacific Rebellion")
            {
                pacific++;
            }
            else
            {
                confederate++;
            }
        }
        if (confederate == 8)
        {
            loss = true;
        }
        if(pacific == 8)
        {
            loss = true;
        }

    }

    public void press1()
    {
        if (currentScenario.choices[0] != null && currentScenario.choices[0].choose())
        {
            Debug.Log("Go fer it!!!!!!!11");
            NewScenario();
        }
        else
        {
            Debug.Log("YOU AVEN'T GOT ET???????????");
        }

    }

    public void press2()
    {
        if (currentScenario.choices[1] != null && currentScenario.choices[1].choose())
        {
            Debug.Log("Go fer it!!!!!!!11");
            NewScenario();
        }
        else
        {
            Debug.Log("YOU AVEN'T GOT ET???????????");
        }
    }

    public void press3()
    {
        if (currentScenario.choices[2] != null && currentScenario.choices[2].choose())
        {
            Debug.Log("Go fer it!!!!!!!11");
            NewScenario();
        }
        else
        {
            Debug.Log("YOU AVEN'T GOT ET???????????");
        }
    }

    public void press4()
    {
        if (currentScenario.choices[3] != null && currentScenario.choices[3].choose())
        {
            Debug.Log("Go fer it!!!!!!!11");
            NewScenario();
        }
        else
        {
            Debug.Log("YOU AVEN'T GOT ET???????????");
        }
    }
}
