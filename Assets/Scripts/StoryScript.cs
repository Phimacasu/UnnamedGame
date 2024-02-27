using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StorySystem;

/* --- TEMPLATE FOR OUR STORY ---
 * - Can still make some changes, just the bare bones of the story system
 * - Change the placeholder texts and create/assign new functions to the nextNode
 */

public class StoryScript : MonoBehaviour
{
    public StoryNode _initialNode;

    /*  This code snippet is a method named Start() within the StoryScript class
        It is called when the script starts running 
        The method initializes the _initialNode variable of type StoryNode with a new instance of StoryNode */
    void Start()
    {
        _initialNode = new StoryNode
        {
            _text = "Lorem ipsum dolor sit amet.",
            _options = new List<StoryOption>
            {
                new StoryOption { _optionText = "Lorem ipsum dolor sit amet.", _nextNode = null},
                new StoryOption { _optionText = "Lorem ipsum dolor sit amet.", _nextNode = null}
            }
        };
    }

    // Creates a path A in the story
    private StoryNode CreatePathA()
    {
        return new StoryNode
        {
            _text = "Lorem ipsum dolor sit amet.",
            _options = new List<StoryOption>
            {
                new StoryOption { _optionText = "Lorem ipsum dolor sit amet.", _nextNode = null },
                new StoryOption { _optionText = "Lorem ipsum dolor sit amet.", _nextNode = null }
            }
        };
    }

    // Creates a path B in the story
    private StoryNode CreatePathB()
    {
        return new StoryNode
        {
            _text = "Lorem ipsum dolor sit amet.",
            _options = new List<StoryOption>
            {
                new StoryOption { _optionText = "Lorem ipsum dolor sit amet.", _nextNode = null },
                new StoryOption { _optionText = "Lorem ipsum dolor sit amet.", _nextNode = null }
            }
        };
    }

    // Creates a path end in the story
    private StoryNode CreatePathEnd()
    {
        return new StoryNode
        {
            _text = "Lorem ipsum dolor sit amet.",
            _options = new List<StoryOption>()
        };
    }
}
