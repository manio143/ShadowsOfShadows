﻿using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public abstract class Openable : Thing, IInteractable
    {
        public int LockDificulty { get; set; }

        public Openable() : base()
        {

        }

        public Openable(IRenderable rendarable, int lockDificulty) : base(rendarable)
        {
            LockDificulty = lockDificulty;
        }

        public bool TryToUnlock()
        {
            // maybe here should be some randomization
            if (Screen.MainConsole.Player.UnlockingSkillLevel >= LockDificulty)
            {
                LockDificulty = 0;
                Screen.MessageConsole.PrintMessage("Lockpicking succeeded");
                return true;
            }
            else
            {
                Screen.MessageConsole.PrintMessage("Lockpicking failed");
                return false;
            }
        }

        public abstract void Interact();

        protected bool CheckOpened()
        {
            if (LockDificulty == 0)
                return true;
            else
            {
                Screen.MessageConsole.PrintMessage("Target is locked");
                return false;
            }
        }
    }
}