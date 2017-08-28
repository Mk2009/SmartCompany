using System;

namespace SmartCompany.Admin.Shared.Code
{
    public class SharedValues
    {
        /// <summary>
        /// Set the active field value if it's true or false what you'r going to show
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string ShowActiveValue(string field)
        {
            string value = null;
            if (bool.Parse(field) == true)
                value = String.Format("<p class='active'>{0}</p>", Properties.Resources.ActiveTrue);
            else
                value = String.Format("<p class='noactive'>{0}</p>", Properties.Resources.ActiveFalse);

            return value;
        }

        /// <summary>
        /// Set the field value if it's true or false and the result should be yes or no 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string ShowYesNoValue(string field)
        {
            string value = null;
            if (bool.Parse(field))
                value = String.Format("<p class='active'>{0}</p>", Properties.Resources.Yes);
            else
                value = String.Format("<p class='noactive'>{0}</p>", Properties.Resources.No);

            return value;
        }



    }// end class
}// end NS