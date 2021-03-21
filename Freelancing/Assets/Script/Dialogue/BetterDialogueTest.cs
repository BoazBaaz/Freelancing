using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetterDialogueTest : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlight;

    [SerializeField] TextMeshProUGUI dialogText;

    [SerializeField] GameObject dragon;
    [SerializeField] GameObject shadow;

    public void Start()
    {
        StartCoroutine(RealDialogue());
    }


    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        yield return new WaitForSeconds(1f);
    }


    public IEnumerator RealDialogue()
    {
        yield return TypeDialog("Jij: Hey? Waar is iedereen?");
        yield return TypeDialog("Jij:... hmm wat is dit? Is.. is dat een portaal? Dat kan toch niet?");
        shadow.SetActive(true);
        yield return TypeDialog("Onbekend: kom.. hom hier...");
        yield return TypeDialog("Jij: hallo? Is daar iemand?");
        yield return TypeDialog("Onbekend: help.. mij..");
        yield return TypeDialog("Jij: Ik kom eraan! Houd vol!!");
        yield return TypeDialog("Je gaat door de portaal en komt uit in een engere versie van de school waar je net was");
        yield return TypeDialog("JIJ: What the...? Lance? Rene? Wat doen jullie hier?");
        yield return TypeDialog("........................");
        yield return TypeDialog("JIJ: Hallo??? Wat is er met jullie aan de hand?");
        yield return TypeDialog("........................");
        yield return TypeDialog("JIJ: Laat maar!! Ik ben weg hier!!");
        shadow.SetActive(false);
        yield return TypeDialog("Je probeerd hier weg te komen, maar voordat je bij het portaal komt, word je hard tegen de muur geslagen");
        yield return TypeDialog("JIJ: Oefff!");
        yield return TypeDialog("JIJ: Wat was dat?");
        yield return TypeDialog("Je kijkt op en ziet een grote draak voor je staan");
        dragon.SetActive(true);
        yield return TypeDialog("JIJ: ... wow...dat is niet mogelijk...");
        yield return TypeDialog("Draak: Breng hem naar de cel!");
        yield return TypeDialog("Je word door de docenten de kerker door gesleurd.");
        yield return TypeDialog("Toen je aankwam in de cel, zie je dat de zelfde docenten die je net meegetrokken hebben, vastgebonden zitten aan de muur.");
        yield return TypeDialog("JIJ: Huh? Maar dat kan niet?! Er kunnen geen twee van jullie zijn!");
        yield return TypeDialog("Draak: Idioot!! Heb je nogsteeds niet door dat het clones zijn?");
        yield return TypeDialog("Draak: Ik dacht dat jij 1 van de slimme was, deze losers schreeuwen al de hele tijd dat jij ze wel kwam redden");
        yield return TypeDialog("JIJ: zo goed ben ik ook niet... ");
        yield return TypeDialog("JIJ: Hey!!! Ik ga je wel verslaan! Al is het alleen maar zodat ik hier uit kom!");
        yield return TypeDialog("Draak: Dan zal je eerst mijn clonen moeten verslaan is een spel die ik zelf bedacht heb! Muahahahahahaha");
        yield return TypeDialog("Draak: Je kan ze niet verslaan! Ze zijn onverslaanbaar!!");
        yield return TypeDialog("JIJ: Niemand is overslaanbaar!! Kom maar op!!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
