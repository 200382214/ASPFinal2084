using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using F2018Pranks.Controllers;
using F2018Pranks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace F2018Pranks.Tests.Controllers
{
    [TestClass]
    public class PranksControllerTest
    {
        PranksController controller;
        Mock<IMockPrank> mock;
        List<Prank> pranks;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockPrank>();

            pranks = new List<Prank>
            {
                new Prank {
                    PrankId = 24,
                    Name = "Tape on the Receiver",
                    Description = "Hilarious",
                    Photo = "tape.png"
                },
                new Prank {
                    PrankId = 49,
                    Name = "Disconnect the Monitor",
                    Description = "Infuriating",
                    Photo = "disconnect.png"
                },
                new Prank {
                    PrankId = 72,
                    Name = "Gift Wrap the Desk",
                    Description = "Jim would be so proud",
                    Photo = "wrap.png"
                }
            };

            mock.Setup(m => m.Pranks).Returns(pranks.AsQueryable());
            controller = new PranksController(mock.Object);
        }
    }
}
