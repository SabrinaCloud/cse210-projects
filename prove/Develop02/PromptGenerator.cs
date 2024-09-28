using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "If I had one thing I could do over today, what would it be?",
        "What was the best part of my day?",
        "Who was the most interesting person I interacted with today?",
        "How do I see the hand of the Load in my life today?",
        "What is the strongest emotion I feel today?"
    };
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}