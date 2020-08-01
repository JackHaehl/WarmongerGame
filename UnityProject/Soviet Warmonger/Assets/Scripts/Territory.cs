using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Territory
{
    public string name;
    public float socialP;
    public float socialC;
    public float militaryP;
    public float militaryC;
    public float health = 1;
    public Team activeTeam;


    public void evaluateControl()
    {
        if (health < 1 && health > 0)
        {
            health += 0.05f;
        }
        if (activeTeam.name == "The Pacific Rebellion")
        {
            if (socialC > 1.2f * socialP)
            {
                switchControl();
            }
            else if (militaryC > 1.2f * militaryP)
            {
                switchControl();
            }
            else
            {
                GameBehaviour.warTide++;
            }
        }
        else
        {
            if (socialP > 1.2f * socialC)
            {
                switchControl();
            }
            else if (militaryP > 1.2f * militaryC)
            {
                switchControl();
            }
            else
            {
                GameBehaviour.warTide++;
            }
        }

        if (health <= 0)
        {
            makeNeutral();
        }
    }
    public void makeNeutral()
    {
        socialP = 0;
        socialC = 0;
        militaryC = 0;
        militaryP = 0;
        activeTeam = null;
    }

    public void switchControl()
    {

        GameBehaviour.warTide = 0;
       if(activeTeam.name == "The Pacific Rebellion")
        {
            activeTeam = GameBehaviour.team[1];
            Debug.Log("Control of " + name + " has switched from The Pacific Rebellion to The Neo Confederacy");
        }
        else
        {
            activeTeam = GameBehaviour.team[0];
            Debug.Log("Control of " + name + " has switched from The Neo Confederacy to The Pacific Rebellion");
        }
    }

    public string displayText()
    {
        return (name + " controlled by " + activeTeam.name + " with a health of " + health + "\n");
    }

}
