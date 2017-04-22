using System;

using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.Entities
{
    public abstract class  Openable : Thing, IInteractable
    {
        public int LockDificulty { get; set; }

        public Openable(IRenderable rendarable, int lockDificulty) : base(rendarable)
        {
            LockDificulty = lockDificulty;
        }

        public bool TryToUnlock(/*Character character*/)
        {
            // maybe here should be some randomization
            if(/*character.UnlockingSkills >= LockDificulty*/ true)
            {
                LockDificulty = 0;
                // TODO: msg console print successfuly opened
                return true;
            }
            else
            {
                // TODO: msg console print opening failed
                return false;
            }
        }

        public abstract void Interact();
    }
}
