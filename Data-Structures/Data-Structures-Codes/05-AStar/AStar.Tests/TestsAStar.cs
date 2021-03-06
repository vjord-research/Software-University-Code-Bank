using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class AStarSearchTests
{
    [TestMethod]
    public void GetHCost_Straight_Horizontal()
    {
        // Arrange
        var current = new Node(0, 0);
        var goal = new Node(0, 5);

        // Act
        var h = AStar.GetH(current, goal);

        // Assert
        Assert.AreEqual(5, h, "Wrong H cost");
    }

    [TestMethod]
    public void GetHCost_Straight_Vertical()
    {
        // Arrange
        var current = new Node(0, 0);
        var goal = new Node(5, 0);

        // Act
        var h = AStar.GetH(current, goal);

        // Assert
        Assert.AreEqual(5, h, "Wrong H cost");
    }

    [TestMethod]
    public void GetHCost_Diagonal()
    {
        // Arrange
        var current = new Node(0, 0);
        var goal = new Node(5, 5);

        var h = AStar.GetH(current, goal);

        Assert.AreEqual(10, h, "Wrong H cost");
    }

    [TestMethod]
    public void AStarSearch_StraightHorizontal()
    {
        // Arrange
        char[,] map =
        {
                    { 'P', '-', '-', '*' },
                    { '-', '-', '-', '-' },
                    { '-', '-', '-', '-' },
                    { '-', '-', '-', '-' },
            };

        // Act
        var aStar = new AStar(map);
        var path = aStar.GetPath(new Node(0, 0), new Node(0, 3));

        // Assert
        var expected = new List<Node>()
        {
            new Node(0, 0),
            new Node(0, 1),
            new Node(0, 2),
            new Node(0, 3),
        };

        CollectionAssert.AreEqual(expected, new List<Node>(path), "Wrong path");
    }

    [TestMethod]
    public void AStarSearch_StraightVertical()
    {
        // Arrange
        char[,] map =
        {
                    { 'P', '-', '-', '-' },
                    { '-', '-', '-', '-' },
                    { '-', '-', '-', '-' },
                    { '*', '-', '-', '-' },
            };

        // Act
        var aStar = new AStar(map);
        var path = aStar.GetPath(new Node(0, 0), new Node(3, 0));

        // Assert
        var expected = new List<Node>()
        {
            new Node(0, 0),
            new Node(1, 0),
            new Node(2, 0),
            new Node(3, 0),
        };

        CollectionAssert.AreEqual(expected, new List<Node>(path), "Wrong path");
    }

    [TestMethod]
    public void AStarSearch_TestFirstMap()
    {
        // Arrange
        char[,] map =
        {
                    { '-', '-', '-', '-', '-' },
                    { '-', '-', '*', '-', '-' },
                    { '-', 'W', 'W', 'W', '-' },
                    { '-', '-', '-', '-', '-' },
                    { '-', '-', '-', 'P', '-' },
                    { '-', '-', '-', '-', '-' }
            };

        // Act
        var aStar = new AStar(map);
        var path = aStar.GetPath(new Node(4, 3), new Node(1, 2));

        // Assert
        var expected = new List<Node>()
        {
            new Node(4, 3),
            new Node(3, 3),
            new Node(3, 4),
            new Node(2, 4),
            new Node(1, 4),
            new Node(1, 3),
            new Node(1, 2),
        };

        CollectionAssert.AreEqual(expected, new List<Node>(path), "Wrong path");
    }

    [TestMethod]
    public void AStarSearch_TestSecondMap()
    {
        // Arrange
        char[,] map =
        {
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', 'W', '*', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', 'W', 'W', 'W', 'W', 'W', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', 'P', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' }
            };

        var aStar = new AStar(map);

        var path = aStar.GetPath(new Node(4, 7), new Node(1, 4));

        var expected = new List<Node>()
        {
            new Node(4, 7),
            new Node(3, 7),
            new Node(3, 8),
            new Node(2, 8),
            new Node(1, 8),
            new Node(1, 7),
            new Node(1, 6),
            new Node(1, 5),
            new Node(1, 4),
        };

        CollectionAssert.AreEqual(expected, new List<Node>(path), "Wrong path");
    }


    [TestMethod]
    public void AStarSearch_TestThirdMap()
    {
        // Arrange
        char[,] map =
        {
                { 'W', 'W', 'W', 'W', 'W', 'W' },
                { '-', '-', '-', '-', '-', '-' },
                { 'P', 'W', 'W', 'W', 'W', '-' },
                { '-', '-', 'W', 'W', 'W', '*' },
                { '-', '-', 'W', 'W', 'W', '-' },
                { '-', '-', '-', '-', '-', '-' }
            };

        // Act
        var aStar = new AStar(map);
        var path = aStar.GetPath(new Node(2, 0), new Node(3, 5));

        // Assert
        var expected = new List<Node>()
        {
            new Node(2, 0),
            new Node(1, 0),
            new Node(1, 1),
            new Node(1, 2),
            new Node(1, 3),
            new Node(1, 4),
            new Node(1, 5),
            new Node(2, 5),
            new Node(3, 5),
        };

        CollectionAssert.AreEqual(expected, new List<Node>(path), "Wrong path");
    }

    [TestMethod]
    public void AStarSearch_TestFourthMap()
    {
        // Arrange
        char[,] map =
        {
                { 'P', '-', '-', 'W', '-' },
                { '-', 'W', '-', 'W', '-' },
                { '-', '-', 'W', 'W', '-' },
                { '-', 'W', '-', 'W', '*' },
                { '-', '-', '-', '-', '-' }

            };

        // Act
        var aStar = new AStar(map);
        var path = aStar.GetPath(new Node(0, 0), new Node(3, 4));

        // Assert
        var expected = new List<Node>()
        {
            new Node(0, 0),
            new Node(1, 0),
            new Node(2, 0),
            new Node(3, 0),
            new Node(4, 0),
            new Node(4, 1),
            new Node(4, 2),
            new Node(4, 3),
            new Node(4, 4),
            new Node(3, 4),
        };

        CollectionAssert.AreEqual(expected, new List<Node>(path), "Wrong path");
    }

    [TestMethod]
    public void AStarSearch_TestFifthMap()
    {
        // Arrange
        char[,] map =
        {
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', 'P', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '*' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
            };

        // Act
        var aStar = new AStar(map);
        var path = aStar.GetPath(new Node(15, 2), new Node(15, 6));

        // Assert
        Assert.AreEqual(21, new List<Node>(path).Count, "Wrong path length");
    }

    [TestMethod]
    public void AStarSearch_TestNoPath()
    {
        // Arrange
        char[,] map =
        {
                { 'P', 'W', '-' },
                { 'W', 'W', '-' },
                { '-', '-', 'W' },
                { '-', 'W', '-' },
                { '-', '-', '*' }

            };

        // Act
        var aStar = new AStar(map);
        var path = aStar.GetPath(new Node(0, 0), new Node(3, 4));

        // Assert
        var expected = new List<Node>() { new Node(0, 0) };
        CollectionAssert.AreEqual(expected, new List<Node>(path), "Wrong path");
    }

    [TestMethod]
    public void AStarSearch_TestPerformance()
    {
        // Arrange
        char[,] map =
        {
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', 'P', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '*' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', 'W', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
            };

        // Act
        var aStar = new AStar(map);

        // Assert
        for (int i = 0; i < 100000; i++)
        {
            var path = aStar.GetPath(new Node(15, 2), new Node(15, 6));
            Assert.AreEqual(21, new List<Node>(path).Count, "Wrong path length");
        }
    }
}
