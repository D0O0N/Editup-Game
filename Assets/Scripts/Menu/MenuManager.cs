using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /*VARIABLES UI*/
    public Button btnDamier;
    public Button btnBrick;
    public Button btnVN;
    public Button btnSoncas;
    public Button btnRDamier;
    public Button btnRBrick;
    public GameObject zoneDesc;
    public Image imgPreview;
    public Sprite damier;
    public Sprite brickBreaker;
    public Sprite soncas;
    public Button btnStart;
    public Text txtComp;
    [SerializeField] Object sceneDamier;
    [SerializeField] Object sceneBrick;
    [SerializeField] Object sceneVS;
    [SerializeField] Object sceneSoncas;
    [SerializeField] Object sceneRDamier;
    [SerializeField] Object sceneRBrick;

    /*VARIABLES INTERNE*/
    private int indJeu = 0;

    // Start is called before the first frame update
    void Start()
    {
        btnDamier.onClick.AddListener(delegate{changeJeu(0);});
        btnBrick.onClick.AddListener(delegate{changeJeu(1);});
        btnVN.onClick.AddListener(delegate{changeJeu(2);});
        btnSoncas.onClick.AddListener(delegate{changeJeu(3);});
        btnRDamier.onClick.AddListener(delegate{changeJeu(4);});
        btnRBrick.onClick.AddListener(delegate{changeJeu(5);});
        btnStart.onClick.AddListener(startJeu);
    }

    void changeJeu(int i) {
        zoneDesc.SetActive(true);
        btnStart.gameObject.SetActive(true);
        indJeu = i;
        switch (i)
        {
            case 0:
                imgPreview.sprite = damier;
                txtComp.text = "La compétence A à acquérir sera un compétence très importante à acquérir";
                break;
            case 1:
                imgPreview.sprite = brickBreaker;
                txtComp.text = "La compétence B à acquérir sera un compétence très importante à acquérir";
                break;
            case 2:
                txtComp.text = "La compétence C à acquérir sera un compétence très importante à acquérir";
                break;
            case 3:
                txtComp.text = "La compétence D à acquérir sera un compétence très importante à acquérir";
                imgPreview.sprite = soncas;
                break;
            case 4:
                txtComp.text = "La compétence E à acquérir sera un compétence très importante à acquérir";
                break;
            case 5:
                txtComp.text = "La compétence F à acquérir sera un compétence très importante à acquérir";
                break;
            default:
                break;
        }
    }

    void startJeu() {
        //POUR CHAQUE SCENE NE PAS OUBLIER DE LA RAJOUTER DANS BUILD SETTINGS (DANS LE MENU DEROULANT FILE)

        switch (indJeu)
        {
            case 0:
                SceneManager.LoadScene(sceneDamier.name);
                break;
            case 1:
                SceneManager.LoadScene(sceneBrick.name);
                break;
            case 2:
                SceneManager.LoadScene(sceneVS.name);
                break;
            case 3:
                SceneManager.LoadScene(sceneSoncas.name);
                break;
            case 4:
                SceneManager.LoadScene(sceneRDamier.name);
                break;
            case 5:
                SceneManager.LoadScene(sceneRBrick.name);
                break;
            default:
                break;
        }
    }
}
