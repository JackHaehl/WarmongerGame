using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Option
{
    public string text;
    public float socialActive;
    public float socialOther;
    public bool controlChange;
    public bool neutrality;
    public float militaryActive;
    public float militaryOther;
    public float money;
    public float healthChange;
    public string visibleText;
    private Team currentTeam;
    private Team inactiveTeam;
    private Territory currentTerritory;

    public void setupOption(Team team,Team inactiveTeam, Territory territory)
    {
        currentTeam = team;
        currentTerritory = territory;
        this.inactiveTeam = inactiveTeam;
    }

    public string displayText()
    {
        visibleText = text;
        visibleText = visibleText.Replace("[TEAM]", currentTeam.name);
        visibleText = visibleText.Replace("[TERRITORY]", currentTerritory.name);
        visibleText = visibleText.Replace("[INACTIVETEAM]", inactiveTeam.name);
        return visibleText;
    }

    public bool choose()
    {
        if (currentTerritory.health <= 0)
        {
            return true;
        }
        else
        {
            if (currentTeam.name == "The Pacific Rebellion")
            {

                currentTerritory.socialP += socialActive;
                currentTerritory.socialC += socialOther;
                currentTerritory.militaryP += militaryActive;
                currentTerritory.militaryC += militaryOther;
            }
            else
            {
                currentTerritory.socialC += socialActive;
                currentTerritory.socialP += socialOther;
                currentTerritory.militaryC += militaryActive;
                currentTerritory.militaryP += militaryOther;
            }

            currentTerritory.health += healthChange;

            GameBehaviour.wealth += money;

            if (neutrality)
            {
                currentTerritory.makeNeutral();
            }
            else
            {
                currentTerritory.evaluateControl();
            }
            currentTerritory.renderEffects(socialActive, militaryActive, healthChange);
            currentTerritory.renderEffects(socialOther, militaryOther, 0);
            return true;
        }
    }

   
}
