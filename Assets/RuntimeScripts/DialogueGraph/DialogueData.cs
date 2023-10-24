using DialogueTree;
using System;
using System.Collections.Generic;

public class DialogueData
{
    public Dictionary<Guid, DialogueRuntimeNode> graph { get; private set; }
    public Guid headNode { get; private set; }

    public DialogueData()
    {
        var charMorse = "Morse";
        var charMaria = "Maria";

        // Instantiate a Dictionary for testing purposes.
        var npc_c = new NPCNode(Guid.NewGuid(), Guid.Empty, "NPC", "npc_c", charMaria);
        var npc_b = new NPCNode(Guid.NewGuid(), npc_c.Guid, "OtherNPC", "npc_b", charMorse);
        var npc_a = new NPCNode(Guid.NewGuid(), npc_b.Guid, "NPC", "npc_a", charMaria);
        var choice_a = new DialogueChoices(npc_a.Guid, "choice_a");
        var choice_c = new DialogueChoices(npc_c.Guid, "choice_c");
        DialogueChoices[] choices = { choice_a, choice_c };
        var player_z = new PlayerNode(Guid.NewGuid(), "Player", choices);
        headNode = npc_a.Guid;

        graph = new Dictionary<Guid, DialogueRuntimeNode>
        {
            { npc_c.Guid, npc_c },
            { npc_b.Guid, npc_b },
            { npc_a.Guid, npc_a },
            { player_z.Guid, player_z }
        };
    }

    /// <summary>
    /// Create a DialogueData file in project directory.
    /// </summary>
    void InstanciateFile()
    { }
}