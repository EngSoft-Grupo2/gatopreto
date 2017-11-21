using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
    public class Attribute : MonoBehaviour
    {
        //Controll variables - Use this to change some properties of the attribute
        private float fastBlink = 0.1f, slowBlink = 0.5f; //Relted to the blink animation time
        private int impactThreshold = 20; //Related to the impact threshold. Wich number defines a big impact?
        private int initialQuantityValue = 50; //Related to the initial value of the attribute
        private float animationWaitTime = 0.01f; //Related to the update animation speed (to make it faster, decrease this value)

        //Class private variables
        private int quantity;
        private Image myImage;
        private Coroutine updatingValueCoroutine;
        private Coroutine showingImpactCoroutine;

        //Animation Controll variables - just some flags
        private bool animating, showingImpact;

        //Class public variables - to be set outside the code
        public PlayerAttribute attributeType = PlayerAttribute.NONE;
        public Sprite normal, negative, positive;

        //When the attribute is created in the scene...
        void Awake()
        {
            animating = false;
            showingImpact = false;
            myImage = GetComponent<Image>();

        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            myImage.fillAmount = (float) (GameManager.instance.player[attributeType] * 100f / Player.maxAttributeValue) / 100.0f;

            GameManager.instance.player[attributeType] = 0;
            //Erase this part for the actual game
            StartCoroutine(Test());
        }

        //Erase this method for the actual game
        private IEnumerator Test()
        {
            while (true)
            {
                yield return new WaitUntil(() => animating == false);
                yield return new WaitForSecondsRealtime(2.0f);
                int update = Random.Range(-5, 5);
                update *= 10;
                ShowImpact(update);
                yield return new WaitForSecondsRealtime(5.0f);
                UpdateValue(update);
            }
        }

        //This method is responsible for updating the attribute quantity and call the animation
        //Returns true if the value was updated and false if the attribute was already updating when called
        public bool UpdateValue(int impact)
        {
            if (animating)
                return false;
            //If the impact animation is being performed, call the stop method
            if (showingImpact)
                StopShowingImpact();
            //This coroutine is saved for safety, but it should never be stoped without completing itself
            updatingValueCoroutine = StartCoroutine(PerformAnimation(impact));
            return true;
        }

        //This method is responsible for showing the impact in the attribute with a blinking animation
        //Returns true if the method could start correctly and false if the attribute was updating when called
        public bool ShowImpact(int impact)
        {
            if (animating)
                return false;
            //If the impact animation is being performed, call the stop method
            if (showingImpact)
                StopShowingImpact();
            //This verifies if the impact is high or low and call the coroutine with the correct blink time
            if (Mathf.Abs(impact) > impactThreshold)
                showingImpactCoroutine = StartCoroutine(PerformImpactAnimation(fastBlink));
            else
                showingImpactCoroutine = StartCoroutine(PerformImpactAnimation(slowBlink));
            return true;
        }

        //This method stops the impact animation
        public void StopShowingImpact()
        {
            if (showingImpact)
            {
                //Cancel the coroutine
                StopCoroutine(showingImpactCoroutine);
                //Assures that the image is visible
                myImage.enabled = true;
                //Sets the control variable
                showingImpact = false;
            }
        }

        //This method performs the updating anmation
        private IEnumerator PerformAnimation(int impact)
        {
            //Controll
            animating = true;
            //This verifies if the impact is positive or negative and choose the correct sprite
            if (impact > 0)
            {
                myImage.sprite = positive;
            }
            else
            {
                myImage.sprite = negative;
            }

            //This calculates the target quantity and corrects if it's under 0 or over 100
            int targetQuantity = quantity + impact;
            if (targetQuantity < 0)
                targetQuantity = 0;
            if (targetQuantity > 100)
                targetQuantity = 100;

            //Step by step, the quantity is increased or decreased towards the target
            //The fill amount is refreshed and a time is waited until the next step
            while (quantity != targetQuantity)
            {
                if (targetQuantity > quantity)
                    quantity++;
                else
                    quantity--;
                myImage.fillAmount = (float) quantity / 100.0f;
                yield return new WaitForSeconds(animationWaitTime);
            }

            //Sets the controll variable and the sprite back to normal
            myImage.sprite = normal;
            animating = false;
        }

        //This method performs the blinking animation given a blink time
        private IEnumerator PerformImpactAnimation(float blinkTime)
        {
            //If the animation has started, this variable is set to true
            showingImpact = true;

            //It never ends by itself
            while (true)
            {
                //Swap the visibility and wait some time
                myImage.enabled = !myImage.enabled;
                yield return new WaitForSeconds(blinkTime);
            }
        }
    }
}