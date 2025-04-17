using UnityEngine;

public class SwitchesAllCorrect : MonoBehaviour
{
    public FlipSwitch[] switches;  // Array of switches to check
    public bool switchesCorrect = false;  // Boolean to track if all switches are correct

    public ButtonChangeColors ButtonChangeColors;  //References button script
    public ButtonVR buttonVR;

    private void Update()
    {
        CheckSwitches();
    }

    private void CheckSwitches()
    {
        switchesCorrect = true;  // Assume all are correct until proven otherwise

        foreach (FlipSwitch switchObj in switches)
        {
            SwitchLight switchLight = switchObj.GetComponent<SwitchLight>();
            if (switchLight != null && switchObj.switchPosition != switchLight.correctPosition)
            {
                switchesCorrect = false;  // If any switch is incorrect, set to false
                break;  // No need to check further
            }
        }

        if (switchesCorrect)
        {
            foreach (FlipSwitch switchObj in switches)
            {
                switchObj.flippable = false;  // Disable flipping
            }
            if (ButtonChangeColors != null)
            {
                ButtonChangeColors.SetToGreen();  // Change color
            }
            if(buttonVR != null){
                buttonVR.SetUnlocked(true);
            }
        }
    }
}

