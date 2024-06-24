using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpPlayer : MonoBehaviour
{
    private EnemyHealth enemyHealth; 
    public Slider expSlider; // Thanh UI slide exp
    public TextMeshPro expText; // UI textmeshPro exp
    public float expRequired = 100; // Exp cần thiết để lên cấp
    [SerializeField] private int expCurrent = 1;

    const string EXP_SLIDER_TEXT = "Exp Slider";

    private void Awake()
    {
        enemyHealth= GetComponent<EnemyHealth>();
    }
    // kiểm tra nêu như va chạm với thằng có enemyhealth và có gọi tới hamg dead thì mới gọi mấy hàm ở dưới 

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<EnemyHealth>() != null)
        {
        


          
        }    

    }
    private void checkDeadEnemy()
    {
       
    }
    public void GainExp()
    {
        expCurrent += enemyHealth.expEnemy ;
        expSlider.value = expCurrent / expRequired;
        if (expCurrent >= expRequired)
        { 
            LevelUp();
        }

        expText.text = "Level: " + (expCurrent / expRequired);
    }
    private void LevelUp()
    {
     
        expCurrent = 0;
        expRequired *= 1.2f;
        expSlider.value = 0;

        expText.text = "Level: " + (expCurrent / expRequired);
    }
}
