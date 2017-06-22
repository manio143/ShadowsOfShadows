using ShadowsOfShadows.Consoles;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public abstract class Openable : Thing, IInteractable
    {
        public int LockDificulty { get; set; }

        public Openable() : base() { }

        public Openable(char c) : base(c) { }

        public Openable(IRenderable rendarable, int lockDificulty) : base(rendarable)
        {
            LockDificulty = lockDificulty;
        }

        public bool TryToUnlock()
        {
            if (LockDificulty == 0)
                return true;
            // maybe here should be some randomization
            if (Screen.MainConsole.Player.UnlockingSkillLevel >= LockDificulty)
            {
                LockDificulty = 0;
                Screen.MessageConsole.PrintMessageWithTimeout("Lockpicking succeeded", TimeoutMessage.GENERAL_TIMEOUT);
                return true;
            }
            else
            {
                Screen.MessageConsole.PrintMessageWithTimeout("Lockpicking failed", TimeoutMessage.GENERAL_TIMEOUT);
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
                Screen.MessageConsole.PrintMessageWithTimeout("Target is locked", TimeoutMessage.GENERAL_TIMEOUT);
                return false;
            }
        }
    }
}