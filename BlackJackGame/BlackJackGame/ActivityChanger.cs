using System.Collections.Generic;

namespace BlackJackGame
{
    public class ActivityChanger
    {
        public void SetNextActive(List<Button> bList)
        {
            for (int i = 0; i < bList.Count; i++)
            {
                if (bList[i].GetIsActive())
                {
                    bList[i].SetNotActive();
                    bList[i + 1].SetActive();
                    return;
                }
            }
        }

        public void SetPreviousActive(List<Button> bList)
        {
            for (int i = 0; i < bList.Count; i++)
            {
                if (bList[i].GetIsActive())
                {
                    bList[i].SetNotActive();
                    bList[i - 1].SetActive();
                    return;
                }
            }
        }
    }
}