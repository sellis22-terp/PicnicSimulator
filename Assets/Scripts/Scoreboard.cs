using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    private int count = 0;
    private TextMeshProUGUI scoreText;
    [SerializeField] int maxCount;
    [SerializeField] GameObject sceneChanger;
    [SerializeField] Vector3[] spawnPositions;

    void Start()
    {   
        scoreText = GetComponent<TextMeshProUGUI>();
        ChangeText();
    }
    
    public void incrementCount()
    {
        count += 1;
        ChangeText();
    }
    public void ChangeText()
    {   
        scoreText.text = count + "/" + maxCount + " collected";
        
        if (count == maxCount)
        {
            int random = Random.Range(0, 2);

            if (random == 0)
            {
                scoreText.text = "Head to the <color=red>red</color> flowers!";
            }
            else
            {
                scoreText.text = "Head to the <color=blue>blue</color> flowers!";
            }
            GameObject temp = Instantiate(sceneChanger);
            sceneChanger.GetComponent<SceneChange>().SetScene("scene1");
            temp.transform.position = spawnPositions[random];
            
        }
    }
}
