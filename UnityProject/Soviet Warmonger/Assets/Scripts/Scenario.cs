using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Scenario
{
    //Inside of the text, put [TEAM] for team and [TERRITORY] for territory name.
    [SerializeField]
    public string text;
    public string visibleText;
    public string team;
    public int territory;
    private Team currentTeam;
    private Team inactiveTeam;
    public Territory currentTerritory;
    //public Territory territory;
    public List<Option> choices;

    public void setupScenario(Team team,Team inactiveTeam, Territory territory)
    {
        currentTeam = team;
        currentTerritory = territory;
        this.inactiveTeam = inactiveTeam;
        for(int i = 0; i < choices.Count; i++)
        {
            choices[i].setupOption(team, inactiveTeam, territory);
        }
    }

    public string displayText()
    {
        visibleText = text;
        visibleText = visibleText.Replace("[TEAM]", currentTeam.name);
        visibleText = visibleText.Replace("[TERRITORY]", currentTerritory.name);
        visibleText = visibleText.Replace("[INACTIVETEAM]", inactiveTeam.name);

        return visibleText;
    }


}
