// ***********************************************************************
// Author           : AMERICAS\Puneet_Pattar
// Created          : 3/15/2017 7:51:51 PM
//
// Last Modified By : AMERICAS\Puneet_Pattar
// Last Modified On : 3/15/2017 7:51:51 PM
// ***********************************************************************
// <copyright file="SBTestBase.cs" company="Dell">
//     Copyright (c) Dell 2017. All rights reserved.
// </copyright>
// <summary>Describe what is being tested in this test class here.</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;
using Dell.Adept.UI.Web.Testing.Framework;
using Dell.Adept.UI.Web.Testing.Framework.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Base
{

    [TestClass]
    [SingleWebDriver(false)]
    public class ServiceTestBase
    {

        [TestInitialize]
        public void SBServiceTestBaseBaseInitialize()
        {
            // base.BaseTestInitialize();
        }
    }
}
