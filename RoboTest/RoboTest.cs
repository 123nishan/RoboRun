using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RoboRun;
namespace RoboRun
{
    [TestClass]
    public class RobotTests
    {

        [TestMethod]
        public void isTheLocationEmpty_empty_returnsEmpty()
        {
            Item[,] boardArr = new Item[5, 5];
            RoboRun.Tools tools = new RoboRun.Tools();
            var isTheLocationEmptyResult = tools.isTheLocationEmpty(boardArr, 1, 1);
            Assert.AreEqual(isTheLocationEmptyResult, "empty");

        }
        [TestMethod]
        public void isTheLocationEmpty_robot_returnsRobot()
        {
            Item[,] boardArr = new Item[5, 5];
            RoboRun.Tools tools = new RoboRun.Tools();
            RoboRun.Item item = new RoboRun.Item(1, 1, "ROBOT", "EAST");
            boardArr[1, 1] = item;

            var isTheLocationEmptyResult = tools.isTheLocationEmpty(boardArr, 1, 1);
            Assert.AreEqual(isTheLocationEmptyResult, "ROBOT");

        }
        [TestMethod]
        public void isTheLocationEmpty_wall_returnsWall()
        {
            Item[,] boardArr = new Item[5, 5];
            RoboRun.Tools tools = new RoboRun.Tools();
            RoboRun.Item item = new RoboRun.Item(1, 1, "WALL", "");
            boardArr[1, 1] = item;

            var isTheLocationEmptyResult = tools.isTheLocationEmpty(boardArr, 1, 1);
            Assert.AreEqual(isTheLocationEmptyResult, "WALL");

        }

        [TestMethod]
        public void rotate_direction_returnsRotatedDirection()
        {

            Tools tools = new Tools();
            var rotateValueLeft = tools.rotate("NORTH", "LEFT");
            var rotateValueRight = tools.rotate("NORTH", "RIGHT");
            Assert.AreEqual(rotateValueLeft, "WEST");
            Assert.AreEqual(rotateValueRight, "EAST");

        }


        [TestMethod]
        public void senseWall_coodinates_returnsTrueFalse()
        {
            Item[,] boardArr = new Item[5, 5];
            Tools tools = new Tools();
            Item item = new Item(1, 1, "WALL", "");
            boardArr[1, 1] = item;


            var expectedFalse = tools.wallAhead(boardArr, 1, 2);
            var expectedTrue = tools.wallAhead(boardArr, 1, 1);
            Assert.IsTrue(expectedTrue);
            Assert.IsFalse(expectedFalse);

        }


        [TestMethod]
        public void clearElements()
        {
            Item[,] boardArr = new Item[5, 5];
            Tools tools = new Tools();
            Item item = new Item(1, 1, "WALL", "");
            boardArr[1, 1] = item;


            tools.clearElement(boardArr, 1, 1);
            var emptyDirection = boardArr[1, 1].direction;
            var emptyName = boardArr[1, 1].name;

            Assert.AreEqual(emptyDirection, "empty");
            Assert.AreEqual(emptyName, "empty");

        }


    }
}
