using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Territory
{

    public GameObject image;
    public GameObject center;
    public string name;
    public float socialP;
    public float socialC;
    public float militaryP;
    public float militaryC;
    public float health = 1;
    public Team activeTeam;
    public GameObject iconHappy;
    public GameObject iconSad;
    public GameObject iconGun;
    public GameObject iconRipGun;
    public GameObject iconBiohazard;
    private float variationIcon = 1.2f;
    Color oldColor;
    Color newColor;
    private float t;
    float duration = 1; // This will be your time in seconds.


    public void Awake()
    {

    }
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
        changeColor();
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

    public void changeColor()
    {
        oldColor = image.GetComponent<Image>().color;
        if (health <= 0)
        {
            image.GetComponent<Image>().color = new Color32(40, 223, 40, 255);
        }
        else
        {
            if(activeTeam == null)
            {
                newColor = new Color32(150, 150, 150, 255);
            }else if(activeTeam.name == "The Pacific Rebellion")
            {
                newColor = new Color32(0, 0, (byte)(255 * health), 255);
            }
            else
            {
                newColor = new Color32((byte)(255 * health), 0, 0, 255);
            }
        }
        t = 0;
    }

    public void lerpColor(float delta)
    {
        if(t <= duration)
        {
            image.GetComponent<Image>().color = Color.Lerp(oldColor, newColor, t/duration);
            t += delta;
        }
    }

    public void renderEffects(float social, float miliary, float health)
    {
        if (social > 0)
        {
            for (int i = 0; i < Mathf.Abs((int)(social / 100)); i++)
            {
                GameObject.Instantiate(iconHappy, new Vector3(center.transform.position.x + Random.Range(-variationIcon, variationIcon), center.transform.position.y + Random.Range(0, variationIcon)), Quaternion.identity,GameObject.FindGameObjectWithTag("Respawn").transform);
            }
        }else if(social < 0)
        {
            for (int i = 0; i < Mathf.Abs((int)(social / 100)); i++)
            {
                GameObject.Instantiate(iconSad, new Vector3(center.transform.position.x + Random.Range(-variationIcon, variationIcon), center.transform.position.y + Random.Range(0, variationIcon)), Quaternion.identity, GameObject.FindGameObjectWithTag("Respawn").transform);
            }
        }

        if(miliary > 0)
        {
            for (int i = 0; i < Mathf.Abs((int)(miliary / 100)); i++)
            {
                GameObject.Instantiate(iconGun, new Vector3(center.transform.position.x + Random.Range(-variationIcon, variationIcon), center.transform.position.y + Random.Range(0, variationIcon)), Quaternion.identity, GameObject.FindGameObjectWithTag("Respawn").transform);
            }
        }else if(miliary < 0)
        {
            for (int i = 0; i < Mathf.Abs((int)(miliary / 100)); i++)
            {
                GameObject.Instantiate(iconRipGun, new Vector3(center.transform.position.x + Random.Range(-variationIcon, variationIcon), center.transform.position.y + Random.Range(0, variationIcon)), Quaternion.identity, GameObject.FindGameObjectWithTag("Respawn").transform);
            }
        }
        if(health < 0)
        {
            for (int i = 0; i < Mathf.Abs((int)(health / 0.05f)); i++)
            {
                GameObject.Instantiate(iconBiohazard, new Vector3(center.transform.position.x + Random.Range(-variationIcon, variationIcon), center.transform.position.y + Random.Range(0, variationIcon)), Quaternion.identity, GameObject.FindGameObjectWithTag("Respawn").transform);
            }
        }
        
    }

}
