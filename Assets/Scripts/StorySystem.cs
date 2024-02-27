using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    // Represents a node in a story
    public class StoryNode
    {
        public string _text;
        public List<StoryOption> _options;
    }

    // Represents a story option
    public class StoryOption
    {
        public string _optionText;
        public StoryNode _nextNode;
    }

    public Text _storyText;
    public Button[] _optionButtons;
    public GameObject _dialogueUI;
    public Collider _triggerZone;

    private StoryNode _currentNode;
    public StoryNode _initialNode;

    // Initializes the dialogue UI by setting it to inactive
    public void Start()
    {
        _dialogueUI.SetActive(false);
    }

    /*  This method is triggered when a collider enters the trigger zone
        It checks if the collider belongs to the player and activates the dialogue UI   
        It then loads the initial story node    */
    private void OnTriggerEnter(Collider p_other)
    {
        if(p_other.CompareTag("Player"))
        {
            _dialogueUI.SetActive(true);
            LoadStoryNode(_initialNode);
        }
    }

    // Loads a story node into the StorySystem
    public void LoadStoryNode(StoryNode p_node)
    {
        _currentNode = p_node;
        _storyText.text = p_node._text;

        for (int i = 0; i < p_node._options.Count; i++) 
        {
            _optionButtons[i].gameObject.SetActive(true);
            _optionButtons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
        }

        for (int i = p_node._options.Count; i < _optionButtons.Length; i++) 
        {
            _optionButtons[i].gameObject.SetActive(false);
        }
    }

    /*  This method is called when an options is chosen in the story system
        It takes the index of the chosen option and loads the next story node based on that option  */
    public void ChooseOption(int p_optionIndex)
    {
        StoryNode nextNode = _currentNode._options[p_optionIndex]._nextNode;
        LoadStoryNode(nextNode);
    }
}
