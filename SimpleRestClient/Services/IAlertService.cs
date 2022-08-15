using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestClient.Services
{
    public interface IAlertService
    {
        /// <summary>
        /// Shows an alert
        /// </summary>
        /// <param name="title">The title of your alert</param>
        /// <param name="message">The message</param>
        /// <param name="cancel">The confirmbutton</param>
        Task ShowAlertAsync(string title, string message, string cancel = "OK");

        /// <summary>
        /// Shows an alert
        /// </summary>
        /// <param name="title">The title of your alert</param>
        /// <param name="message">The message</param>
        /// <param name="cancel">The confirmbutton</param>
        void ShowAlert(string title, string message, string cancel = "OK");

        
    }
}
