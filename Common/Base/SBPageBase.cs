// ***********************************************************************
// Author           : AMERICAS\Puneet_Pattar
// Created          : 3/15/2017 1:00:09 PM
//
// Last Modified By : AMERICAS\Puneet_Pattar
// Last Modified On : 3/15/2017 1:00:09 PM
// ***********************************************************************
// <copyright file="DellWebUIPage1.cs" company="Dell">
//     Copyright (c) Dell 2017. All rights reserved.
// </copyright>
// <summary>Provide a summary of the page class here.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Dell.Adept.Core;
using Dell.Adept.UI.Web.Pages;
using Dell.Adept.UI.Web.Support.Extensions.WebDriver;
using Dell.Adept.UI.Web.Support.Extensions.WebElement;


namespace Common.Base
{
    /// <summary>
    /// This base class is the where all specific page classes will be derived.
    /// </summary>
    public class SBPageBase : PageBase

    {
        IWebDriver webDriver;

        /// <summary>
        /// Constructor to hand off webDriver
        /// </summary>
        /// <param name="webDriver"></param>
        public SBPageBase(IWebDriver webDriver) : base(ref webDriver)
        {
            this.webDriver = webDriver;
            //populate the following variables with the appropriate value
            //Name = "";
            //Url = "";
            //ProductUnit = "";

        }

        /// <summary>
        /// Treat this like a BVT of the page. If Validate does not pass, throw exception and console.writeline a return message into Test Class
        /// </summary>
        /// <returns>validated</returns>
        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// determines whether or not the driver is active on this page. Must be overriden with each subclass.
        /// </summary>
        /// <returns>active</returns>
        public override bool IsActive()
        {
            throw new NotImplementedException();
        }


    }
}
